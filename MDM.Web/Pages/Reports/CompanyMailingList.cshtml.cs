using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MM.ClientModels;
using MM.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WISA.Services;

namespace MM.Pages.Report
{
    [Authorize(Policy = MMPolicies.AllowUserAccess)]
    public class CompanyMailingListModel : PageModel
    {
        #region Constructor

        private readonly ClientDbContext _clientDbContext;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<CompanyMailingListModel> _logger;
        private readonly IEmailCreator _emailCreator;
        private readonly IConfiguration _configuration;
        private IActivity _activity;
        private string EntityName = "Resigned Members";

        public CompanyMailingListModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            ILogger<CompanyMailingListModel> logger, IEmailCreator emailCreator, ClientDbContext clientDbContext, IConfiguration configuration, IActivity activity)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailCreator = emailCreator;
            _clientDbContext = clientDbContext;
            _configuration = configuration;
            _activity = activity;

        }
        #endregion

            #region Bindings

        [BindProperty]
        public IList<NonIndividualVM> NonIndividualVMList { get; set; }


        #endregion

     public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnGetListAsync()
        {
            NonIndividualVMList = new List<NonIndividualVM>();

            await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Accessed + EntityName, UserTypeValues.Staff);


            var nonindividuals = await _clientDbContext.Organization
                .Include(x => x.MemberStatus)
                .ToListAsync();

            var members = await _clientDbContext.MemberUser
                
                .Include(x => x.ApplicationUser)
                .Where(x => x.MembershipTypeId >= 5)
                .ToListAsync();

            int i = 0;
            int d = 0;
            foreach (var nonindividual in nonindividuals)
            {
                if (nonindividual.MemberStatus != null && nonindividual.MemberStatus.Name.ToUpper() == "ACTIVE")
                {
                    try
                    {

                        i++;
                        d = nonindividual.Id;
                        NonIndividualVM nvm = new NonIndividualVM();


                        nvm.OrgMemberCode = nonindividual.OrgMemberCode;
                        nvm.Name = nonindividual.Name;


                        MemberUser PrimaryContact = members.FirstOrDefault(x => x.ParentMemberid == nonindividual.Id && x.MembershipTypeId == 5);

                        if (PrimaryContact != null)
                        {
                            ApplicationUser applicationUser = await _userManager.FindByEmailAsync(PrimaryContact.Email);
                            if (applicationUser != null)
                            {
                                nvm.PrimaryContact = applicationUser.FullName;
                                 nvm.PrimaryContactEmail = applicationUser.Email;
                            }
                        }
                        else
                        {

                        MemberUser ContactPerson = members.FirstOrDefault(x => x.ParentMemberid == nonindividual.Id && x.MembershipTypeId == 7);

                        if (ContactPerson != null)
                        {
                            ApplicationUser applicationUser = await _userManager.FindByEmailAsync(ContactPerson.Email);
                            if (applicationUser != null)
                            {
                                nvm.PrimaryContact = applicationUser.FullName;
                                    nvm.PrimaryContactEmail = applicationUser.Email;
                                }
                            
                        }
                        
                        }
                        NonIndividualVMList.Add(nvm);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError("Exception at row" + i + " Organization Id " + d);
                    }
                }
            }



            return new JsonResult(NonIndividualVMList);
        }




    }
}