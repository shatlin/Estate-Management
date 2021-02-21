using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MM.ClientModels;
using MM.Helper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WISA.Pages.Member
{
    public class ProfileModel : PageModel
    {

        private readonly ClientDbContext _clientDbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<ProfileModel> _logger;
        

        public ProfileModel(ILogger<ProfileModel> logger, UserManager<ApplicationUser> userManager, ClientDbContext context)
        {
            _userManager = userManager;
            _logger = logger;
            _clientDbContext = context;
        }


        [BindProperty]
        public MemberUser MemberUser { get; set; }

        [BindProperty]
        public ApplicationUser ApplicationUser { get; set; }

        //New Classes

        public class MemberDivision
        {
            public bool IsSelected { get; set; }
            public int Id { get; set; }
            public string Name { get; set; }
        }

        [BindProperty]
        public List<MemberDivision> MemberDivisionList { get; set; }

        [BindProperty]
        public ApplicationIndividualVM ApplicationIndividualVM { get; set; }


        public void GetAllDivisions()
        {

            MemberDivisionList = new List<MemberDivision>();
            var allDivisions = _clientDbContext.Division.ToList();
            foreach (var division in allDivisions)
            {
                MemberDivisionList.Add(new MemberDivision { IsSelected = false, Id = division.Id, Name = division.Name });
            }
        }

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


        public class MemberDisability
        {
            public bool IsSelected { get; set; }
            public int? Id { get; set; }
            public string Name { get; set; }
            public int? DisabilityLevelId { get; set; }
        }

        [BindProperty]
        public List<MemberDisability> MemberDisabilityList { get; set; }

        [BindProperty]
        public List<IFormFile> IDDocuments { get; set; }

        [BindProperty]
        public List<IFormFile> Certificates { get; set; }

        [BindProperty]
        public List<IFormFile> ProofofDWS { get; set; }

        [BindProperty]
        public List<IFormFile> ProofOfReg { get; set; }

        [BindProperty]
        public List<IFormFile> ProofOfPayment { get; set; }


        public void GetAllDisabilities()
        {

            MemberDisabilityList = new List<MemberDisability>();
            var allDisabilities = _clientDbContext.Disability.ToList();
            foreach (var Disability in allDisabilities)
            {
                MemberDisabilityList.Add(new MemberDisability { IsSelected = false, Id = Disability.Id, Name = Disability.Name, DisabilityLevelId = 0 });
            }
        }

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


        public async Task<IActionResult> OnGetAsync()
        {
            GetAllDivisions();
            GetAllAffiliations();
            GetAllDisabilities();
            GetAllInvolvements();

            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {

                MemberUser = await _clientDbContext.MemberUser
                    .Include(m => m.ApplicationUser)
                     .Include(m => m.ApplicationUser.Gender)
                      .Include(m => m.ApplicationUser.Title)
                    .Include(m => m.ClientBranch)
                    .Include(m => m.Ethnicity)
                    .Include(m => m.HighestQualitification)
                    .Include(m => m.HomeLanguage)
                    .Include(m => m.MemberBranch)
                    .Include(m => m.MemberCategory)
                    .Include(m => m.MemberLevel)
                    .Include(m => m.MemberStatus)
                    .Include(m => m.MemberTeam)
                    .Include(m => m.MembershipType)
                    .Include(m => m.Country)
                    .Include(m => m.Occupation)
                    .Include(m => m.Organization)
                    .Include(m => m.OrganizationStructure)
                    .Include(m => m.OwnerClientUser)
                    .Include(m => m.PreferredAppointmentTime)
                    .Include(m => m.ReferralType)
                    .Include(m => m.TransactionCurrency)
                    .Include(m => m.VolunteerWorkHours).FirstOrDefaultAsync(m => m.ApplicaitonUserId == user.Id);
            }
            if (MemberUser == null)
            {
                return NotFound();
            }
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

          //  ViewData["Nationalities"] = new SelectList(_clientDbContext.Nationality.ToList(), nameof(Nationality.Id), nameof(Nationality.Name));

            ViewData["Provinces"] = new SelectList(_clientDbContext.State.ToList(), nameof(State.Id), nameof(State.Name));

            ViewData["Countries"] = new SelectList(_clientDbContext.Country.ToList(), nameof(Country.Id), nameof(Country.Name));

            //   ViewData["Disabilities"] = new SelectList(_clientDbContext.Disability.ToList(), nameof(Disability.Id), nameof(Disability.Name));

            ViewData["DisabilityLevels"] = new SelectList(_clientDbContext.DisabilityLevel.ToList(), nameof(DisabilityLevel.Id), nameof(DisabilityLevel.Name));

            ViewData["ClientBranchId"] = new SelectList(_clientDbContext.ClientBranch.ToList(), nameof(ClientBranch.Id), nameof(ClientBranch.Name));

            ViewData["VolunteerWorkHrs"] = new SelectList(_clientDbContext.VolunteerHours.ToList(), nameof(VolunteerHours.Id), nameof(VolunteerHours.Name));

            ViewData["Referrals"] = new SelectList(_clientDbContext.ReferralType.ToList(), nameof(ReferralType.Id), nameof(ReferralType.Name));

            ViewData["FileTypes"] = new SelectList(_clientDbContext.FileType.ToList(), nameof(FileType.Id), nameof(FileType.Name));

            ViewData["YesNoList"] = new SelectList(new YesNoLookup().YesNoList(), nameof(YesNoLookup.Id), nameof(YesNoLookup.Name));
            return Page();
        }
    }
}