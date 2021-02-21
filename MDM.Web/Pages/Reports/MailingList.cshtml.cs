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
    public class MailingListModel : PageModel
    {
        #region Constructor

        private readonly ClientDbContext _clientDbContext;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<MailingListModel> _logger;
        private readonly IEmailCreator _emailCreator;
        private readonly IConfiguration _configuration;
        private IActivity _activity;
        private string EntityName = "Mailing List";

        public MailingListModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            ILogger<MailingListModel> logger, IEmailCreator emailCreator, ClientDbContext clientDbContext, IConfiguration configuration, IActivity activity)
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
        public IList<MailingListVM> MailingList { get; set; }

        #endregion

        public async Task<IActionResult> OnGetAsync()
        {

            MailingList = new List<MailingListVM>();

            await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Accessed + EntityName, UserTypeValues.Staff);

            var members = await _clientDbContext.MemberUser
                .Include(x => x.MemberStatus).Where(

                x => x.MemberStatus.Name == "Active" || 
                x.MemberStatus.Name == "Suspended" || 
                x.MemberStatus.Name==null||
                x.MemberStatus.Name==string.Empty

                )
                .Include(x => x.MembershipGrade)
                 .Include(x => x.MembershipType)
                 .Include(x => x.MemberBranch)
                  .Include(x => x.Organization)
                .Include(x => x.ApplicationUser)
                 .Include(x => x.ApplicationUser.Title)
                .ToListAsync();


            var organizations = await _clientDbContext.Organization
            .Include(x => x.MemberStatus).Where(

                x => x.MemberStatus.Name == "Active" ||
                x.MemberStatus.Name == "Suspended" ||
                x.MemberStatus.Name == null ||
                x.MemberStatus.Name == string.Empty

                )
                .Include(x => x.OrganizationGrade)
                 .Include(x => x.OrganizationType)
                 .Include(x => x.ClientBranch)
                .ToListAsync();


            foreach (var member in members)
            {

                MailingListVM mailingListVM = new MailingListVM();
                mailingListVM.Id = member.Id;
                mailingListVM.MemberGrade = member.MembershipGrade == null ? "" : member.MembershipGrade.Name;
                mailingListVM.MemberType = member.MembershipType == null ? "" : member.MembershipType.Name;
                mailingListVM.MemberStatus = member.MemberStatus == null ? "" : member.MemberStatus.Name;
                mailingListVM.MemberNumber = member.MemberCode;
                mailingListVM.Title = member.ApplicationUser.Title == null ? "" : member.ApplicationUser.Title.Name;
                mailingListVM.FullName = member.ApplicationUser == null ? "" : member.ApplicationUser.FullName;
                mailingListVM.Email = member.ApplicationUser == null ? "" : member.ApplicationUser.Email;
                mailingListVM.ContactNumber = member.MobilePhone;
                mailingListVM.CompanyName = member.Organization != null ? member.Organization.Name : member.CompanyName;
                mailingListVM.Branch = member.MemberBranch == null ? "" : member.MemberBranch.Name;
                MailingList.Add(mailingListVM);


            }

            foreach (var organization in organizations)
            {

                MailingListVM mailingListVM = new MailingListVM();
                mailingListVM.Id = organization.Id;
                mailingListVM.MemberGrade = organization.OrganizationGrade == null ? "" : organization.OrganizationGrade.Name;
                mailingListVM.MemberType = organization.OrganizationType == null ? "" : organization.OrganizationType.Name;
                mailingListVM.MemberStatus = organization.MemberStatus == null ? "" : organization.MemberStatus.Name;
                mailingListVM.MemberNumber = organization.OrgMemberCode;
                mailingListVM.Title = "";
                mailingListVM.FullName = organization.Name;
                mailingListVM.Email = "";
                mailingListVM.ContactNumber = organization.PhoneNumber;
                mailingListVM.CompanyName = organization.Name;
                mailingListVM.Branch = organization.ClientBranch == null ? "" : organization.ClientBranch.Name;


                MemberUser PrimaryContact = members.FirstOrDefault(x => x.ParentMemberid == organization.Id && x.MembershipTypeId == 5);

                if (PrimaryContact != null)
                {
                    ApplicationUser applicationUser = await _userManager.FindByEmailAsync(PrimaryContact.Email);
                    if (applicationUser != null)
                    {
                       
                        mailingListVM.Email = applicationUser.Email;
                    }
                }
                else
                {

                    MemberUser ContactPerson = members.FirstOrDefault(x => x.ParentMemberid == organization.Id && x.MembershipTypeId == 7);

                    if (ContactPerson != null)
                    {
                        ApplicationUser applicationUser = await _userManager.FindByEmailAsync(ContactPerson.Email);
                        if (applicationUser != null)
                        {
                            mailingListVM.Email = applicationUser.Email;
                        }

                    }

                }

                MailingList.Add(mailingListVM);
            }
      

          

            return Page();
    }




}
}