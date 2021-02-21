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
    public class AllNonIndividualInformationModel : PageModel
    {
        #region Constructor

        private readonly ClientDbContext _clientDbContext;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<AllNonIndividualInformationModel> _logger;
        private readonly IEmailCreator _emailCreator;
        private readonly IConfiguration _configuration;
        private IActivity _activity;
        private string EntityName = "Non Individual Member Report";

        public AllNonIndividualInformationModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            ILogger<AllNonIndividualInformationModel> logger, IEmailCreator emailCreator, ClientDbContext clientDbContext, IConfiguration configuration, IActivity activity)
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
                .Include(x => x.OrganizationGrade)
                .Include(x => x.ClientBranch)
                .ToListAsync();

            var members = await _clientDbContext.MemberUser
                .Include(x => x.MembershipGrade)
                .Include(x => x.MemberStatus)
                .Include(x => x.MembershipType)
                .Include(x => x.MemberAddress)
                .Include(x => x.ApplicationUser)
                .Include(x => x.ApplicationUser.Gender)
                .Include(x => x.Ethnicity)
                .Include(x => x.Occupation)
                .Include(x => x.ClientBranch)
                .Where(x => x.MembershipTypeId >= 5)
                .ToListAsync();

            var addresses = await _clientDbContext.Address.Where(x => x.RelatedToId == (int)RelatedToEnum.Organization).ToListAsync();


            int i = 0;
            int d = 0;
            foreach (var nonindividual in nonindividuals)
            {
                try
                {
                    i++;
                    d = nonindividual.Id;
                    NonIndividualVM nvm = new NonIndividualVM();
                    nvm.MemberStatusName = nonindividual.MemberStatus == null ? null :
                    nonindividual.MemberStatus.Name;
                    nvm.OrganizationGrade = nonindividual.OrganizationGrade == null ? null :
                    nonindividual.OrganizationGrade.Name;
                    nvm.OrgMemberCode = nonindividual.OrgMemberCode;
                    nvm.Name = nonindividual.Name;
                    nvm.PhoneNumber = nonindividual.PhoneNumber;
                    nvm.WebSite = nonindividual.WebSite;
                    nvm.RegistrationNumber = nonindividual.RegistrationNumber;
                    nvm.TaxNumber = nonindividual.TaxNumber;

                    nvm.AccountBalance = nonindividual.AccountBalance == null ? null : nonindividual.AccountBalance.ToString();
                    nvm.CreatedOn = nonindividual.CreatedOn;
                    nvm.StartDate = nonindividual.StartDate;
                    nvm.EndDate = nonindividual.EndDate;
                    nvm.BranchMembership = nonindividual.ClientBranch == null ? null : nonindividual.ClientBranch.Name;
                    nvm.CancelapplicationNopayDate = nonindividual.CancelapplicationNopayDate;
                    nvm.ApplicationCancelledMemberfeeNotpaidDate = nonindividual.CancelapplicationNopayDate;


                    Address PhysicalAddress = addresses.FirstOrDefault(x => x.RelatedEntityId == nonindividual.Id && x.AddressTypeId == (int)AddressTypeEnum.Physical);
                    if (PhysicalAddress != null)
                    {
                        nvm.PhysicalAddress = PhysicalAddress.AddressLine1 + "\n" + PhysicalAddress.AddressLine2;
                    }
                    else
                    {
                        nvm.PhysicalAddress = "";
                    }

                    Address PostalAddress = addresses.FirstOrDefault(x => x.RelatedEntityId == nonindividual.Id && x.AddressTypeId == (int)AddressTypeEnum.Postal);
                    if (PostalAddress != null)
                    {
                        nvm.PostalAddress = PostalAddress.AddressLine1 + "\n" + PostalAddress.AddressLine2;
                    }

                    else
                    {
                        nvm.PostalAddress = "";
                    }


                    MemberUser PrimaryContact = members.FirstOrDefault(x => x.ParentMemberid == nonindividual.Id && x.MembershipTypeId == 5);

                    if (PrimaryContact != null)
                    {
                        ApplicationUser applicationUser = await _userManager.FindByEmailAsync(PrimaryContact.Email);
                        if (applicationUser != null)
                        {
                            nvm.PrimaryContact = applicationUser.FullName;
                        }
                        nvm.PrimaryContactFax = PrimaryContact.FAXNumber;
                        nvm.PrimaryContactEmail = PrimaryContact.Email;
                        nvm.PrimaryContactMobile = PrimaryContact.MobilePhone;
                        nvm.PrimaryContactJobTitle = PrimaryContact.JobTitle;
                    }

                    MemberUser ContactPerson = members.FirstOrDefault(x => x.ParentMemberid == nonindividual.Id && x.MembershipTypeId == 7);

                    if (ContactPerson != null)
                    {
                        ApplicationUser applicationUser = await _userManager.FindByEmailAsync(ContactPerson.Email);
                        if (applicationUser != null)
                        {
                            nvm.ContactPerson = applicationUser.FullName;
                        }
                        else
                        {
                            nvm.ContactPerson=nvm.PrimaryContact;
                        }
                    }
                    else
                    {
                        
                            nvm.ContactPerson=nvm.PrimaryContact;
                       
                    }
                    NonIndividualVMList.Add(nvm);
                }
                catch (Exception ex)
                {
                    _logger.LogError("Exception at row" + i + " Organization Id " + d);
                }
            }

           

            return new JsonResult(NonIndividualVMList);
        }



    }
}