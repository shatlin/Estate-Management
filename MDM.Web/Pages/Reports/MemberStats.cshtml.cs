using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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

namespace MM.Pages.Reports
{
    [Authorize(Policy = MMPolicies.AllowSetUp)]
    public class MemberStatsModel : PageModel
    {
        #region Constructor

        private readonly ClientDbContext _clientDbContext;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<MemberStatsModel> _logger;
        private readonly IEmailCreator _emailCreator;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        private IActivity _activity;
        private string EntityName = "Member Stats";
        public MemberStatsModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            ILogger<MemberStatsModel> logger, IEmailCreator emailCreator, ClientDbContext clientDbContext, IConfiguration configuration, IWebHostEnvironment env, IActivity activity)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailCreator = emailCreator;
            _clientDbContext = clientDbContext;
            _configuration = configuration;
            _env = env;
            _activity = activity;
        }
        #endregion

        #region Bindings

        [BindProperty]
        public ApplicationIndividualVM ApplicationIndividualVM { get; set; }

        [BindProperty]
        public List<qualificationvm> qvmlist { get; set; }

        [BindProperty]
        public List<dwsclassvm> classlist { get; set; }

        #endregion

        #region Member Division
        public class MemberDivision
        {
            public bool IsSelected { get; set; }
            public int Id { get; set; }
            public string Name { get; set; }
        }
        [BindProperty]
        public List<MemberDivision> MemberDivisionList { get; set; }

        public void GetAllDivisions()
        {
            MemberDivisionList = new List<MemberDivision>();
            var allDivisions = _clientDbContext.Division.ToList();
            foreach (var division in allDivisions)
            {
                MemberDivisionList.Add(new MemberDivision { IsSelected = false, Id = division.Id, Name = division.Name });
            }
        }

        #endregion

        #region Member Affliation List
        public class MemberAffiliation
        {
            public bool IsSelected { get; set; }
            public int? Id { get; set; }
            public string Name { get; set; }
            public string MemberSpecificAffliationName { get; set; }
            public string MemberNumber { get; set; }
        }

        [BindProperty]
        public List<MemberAffiliation> MemberAffiliationList { get; set; }

        public void GetAllAffiliations()
        {

            MemberAffiliationList = new List<MemberAffiliation>();
            var allAffiliations = _clientDbContext.Affliation.ToList();
            foreach (var Affiliation in allAffiliations)
            {
                MemberAffiliationList.Add(new MemberAffiliation { IsSelected = false, Id = Affiliation.Id, Name = Affiliation.Name, MemberSpecificAffliationName = string.Empty, MemberNumber = string.Empty });
            }
        }
        #endregion

        #region Member Disability List
        public class MemberDisability
        {
            public bool IsSelected { get; set; }
            public int? Id { get; set; }
            public string Name { get; set; }
            public int? DisabilityLevelId { get; set; }
        }

        [BindProperty]
        public List<MemberDisability> MemberDisabilityList { get; set; }

        public void GetAllDisabilities()
        {

            MemberDisabilityList = new List<MemberDisability>();
            var allDisabilities = _clientDbContext.Disability.ToList();
            foreach (var Disability in allDisabilities)
            {
                MemberDisabilityList.Add(new MemberDisability { IsSelected = false, Id = Disability.Id, Name = Disability.Name, DisabilityLevelId = 0 });
            }
        }

        #endregion

        #region Member Involvement
        public class MemberInvolvement
        {
            public bool IsSelected { get; set; }
            public int Id { get; set; }
            public string Name { get; set; }
        }

        [BindProperty]
        public List<MemberInvolvement> MemberInvolvementList { get; set; }

        public void GetAllInvolvements()
        {

            MemberInvolvementList = new List<MemberInvolvement>();
            var allInvolvements = _clientDbContext.Involvement.ToList();
            foreach (var Involvement in allInvolvements)
            {
                MemberInvolvementList.Add(new MemberInvolvement { IsSelected = false, Id = Involvement.Id, Name = Involvement.Name });
            }
        }
        #endregion

        public async Task<IActionResult> OnGetAsync()
        {
            SetViewData();
            await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Accessed + EntityName, UserTypeValues.Staff);
            return Page();
        }

        public void SetViewData()
        {
            GetAllDivisions();
            GetAllAffiliations();
            GetAllDisabilities();
            GetAllInvolvements();
            ViewData["Titles"] = new SelectList(_clientDbContext.Title.ToList(), nameof(Title.Id), nameof(Title.Name));
            ViewData["Genders"] = new SelectList(_clientDbContext.Gender.ToList(), nameof(Gender.Id), nameof(Gender.Name));
            ViewData["Qualifications"] = new SelectList(_clientDbContext.Qualification.ToList(), nameof(Qualification.Id), nameof(Qualification.Name));
            ViewData["QualificationCategories"] = new SelectList(_clientDbContext.QualificationCategory.ToList(), nameof(QualificationCategory.Id), nameof(QualificationCategory.Name));
            ViewData["QualificationTypes"] = new SelectList(_clientDbContext.QualificationType.ToList(), nameof(QualificationType.Id), nameof(QualificationType.Name));
            ViewData["EnrolmentCategories"] = new SelectList(_clientDbContext.QualificationEnrolmentCategory.ToList(), nameof(QualificationEnrolmentCategory.Id), nameof(QualificationEnrolmentCategory.Name));
            ViewData["HomeLanguages"] = new SelectList(_clientDbContext.Language.ToList(), nameof(Language.Id), nameof(Language.Name));
            ViewData["Ethnicities"] = new SelectList(_clientDbContext.Ethnicity.ToList(), nameof(Ethnicity.Id), nameof(Ethnicity.Name));
            ViewData["Occupations"] = new SelectList(_clientDbContext.Occupation.ToList(), nameof(Occupation.Id), nameof(Occupation.Name));
            ViewData["EmploymentCategories"] = new SelectList(_clientDbContext.EmploymentCategory.ToList(), nameof(EmploymentCategory.Id), nameof(EmploymentCategory.Name));
            ViewData["Provinces"] = new SelectList(_clientDbContext.State.ToList(), nameof(State.Id), nameof(State.Name));
            ViewData["Countries"] = new SelectList(_clientDbContext.Country.ToList(), nameof(Country.Id), nameof(Country.Name));
            ViewData["DisabilityLevels"] = new SelectList(_clientDbContext.DisabilityLevel.ToList(), nameof(DisabilityLevel.Id), nameof(DisabilityLevel.Name));
            ViewData["ClientBranchId"] = new SelectList(_clientDbContext.ClientBranch.ToList(), nameof(ClientBranch.Id), nameof(ClientBranch.Name));
            ViewData["VolunteerWorkHrs"] = new SelectList(_clientDbContext.VolunteerHours.ToList(), nameof(VolunteerHours.Id), nameof(VolunteerHours.Name));
            ViewData["Referrals"] = new SelectList(_clientDbContext.ReferralType.ToList(), nameof(ReferralType.Id), nameof(ReferralType.Name));
            ViewData["FileTypes"] = new SelectList(_clientDbContext.FileType.ToList(), nameof(FileType.Id), nameof(FileType.Name));
            ViewData["MembershipTypeId"] = new SelectList(_clientDbContext.MembershipType.Where(x => x.Id >= 5).ToList(), nameof(MembershipType.Id), nameof(MembershipType.Name));
            ViewData["YesNoList"] = new SelectList(new YesNoLookup().YesNoList(), nameof(YesNoLookup.Id), nameof(YesNoLookup.Name));
        }

        public IActionResult OnPost(int? OrgId, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                SetViewData();
                return Page();
            }

            else
            {
                _logger.LogInformation(string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)));
                SetViewData();
                return Page();
            }
        }
    }
}