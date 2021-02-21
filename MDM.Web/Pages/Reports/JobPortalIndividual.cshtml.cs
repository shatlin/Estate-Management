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
    public class JobPortalIndividualModel : PageModel
    {
        #region Constructor

        private readonly ClientDbContext _clientDbContext;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<JobPortalIndividualModel> _logger;
        private readonly IEmailCreator _emailCreator;
        private readonly IConfiguration _configuration;
        private IActivity _activity;
        private string EntityName = "Job Portal Individual";

        public JobPortalIndividualModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            ILogger<JobPortalIndividualModel> logger, IEmailCreator emailCreator, ClientDbContext clientDbContext, IConfiguration configuration, IActivity activity)
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
        public IList<ApplicationIndividualVM> ApplicationIndividualVMList { get; set; }



        #endregion

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnGetListAsync()
        {
            ApplicationIndividualVMList = new List<ApplicationIndividualVM>();

            await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Accessed + EntityName, UserTypeValues.Staff);

            var members = await _clientDbContext.MemberUser
                .Include(x => x.MembershipGrade)
                .Include(x => x.MemberStatus)
                .Include(x => x.MembershipType)
                .Include(x => x.MemberAddress)
                .Include(x => x.ApplicationUser)
                .Include(x => x.ApplicationUser.Gender)
                .Include(x => x.Ethnicity)
                .Include(x => x.Occupation)
                .Include(x => x.ClientBranch).OrderBy(x=>x.MembershipType.Name).Where(x=>x.MemberStatus.Name.ToUpper()=="ACTIVE" 
                )
                .ToListAsync();
            int i = 0;
            int d = 0;

            foreach (var member in members)
            {
                try
                {
                    i++;
                   
                    d = member.Id;
                    ApplicationIndividualVM avm = new ApplicationIndividualVM();
                    avm.MembershipGradeName = member.MembershipGrade == null ? null : member.MembershipGrade.Name;
                    avm.MemberStatusName = member.MemberStatus == null ? null : member.MemberStatus.Name;
                    avm.MemberCode = member.MemberCode;
                    avm.MembershipTypeName = member.MembershipType == null ? null : member.MembershipType.Name;
                    avm.FullName = member.ApplicationUser.FullName;
                    avm.FirstName = member.ApplicationUser.FirstName;
                    avm.LastName = member.ApplicationUser.LastName;
                    avm.IDNumber = member.IDNumber;
                    avm.BirthDay = member.ApplicationUser.BirthDay;
                    avm.Email = member.Email;
                    avm.HomePhoneNumber = member.HomePhoneNumber;
                    avm.BusinessPhoneNumber = member.BusinessPhoneNumber;
                    avm.MobilePhone = member.MobilePhone;
                    avm.AccountBalance = member.AccountBalanceOftheCompany;
                    avm.ClientBranchName = member.ClientBranch == null ? null : member.ClientBranch.Name;
                    avm.StartDate = member.StartDate;
                    avm.EndDate = member.EndDate;
                    avm.CreatedOn = member.CreatedOn;
                    avm.ModifiedOn = member.ModifiedOn;
                    avm.CompanyName = member.CompanyName;
                    avm.OccupationName = member.Occupation == null ? null : member.Occupation.Name;
                    avm.EthnicityName = member.Ethnicity == null ? null : member.Ethnicity.Name;
                    avm.GenderName = member.ApplicationUser.Gender == null ? null : member.ApplicationUser.Gender.Name;
                    avm.InterestedInVolunteerWork = member.InterestedInVolunteerWork;
                    avm.PublishCompanyInAnnualMemberDirectory = member.PublishCompanyInAnnualMemberDirectory;
                    avm.ApplicationCancelledMemberfeeNotpaidDate = member.ApplicationCancelledMemberfeeNotpaidDate;
                    ApplicationIndividualVMList.Add(avm);
                }
                catch (Exception ex)
                {
                    _logger.LogError("Exception at row" + i + " Member Id " + d);
                }
            }
       
           

            return new JsonResult(ApplicationIndividualVMList);
    }



}
}