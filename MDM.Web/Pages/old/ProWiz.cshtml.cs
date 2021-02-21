using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Web;
using DocumentFormat.OpenXml.ExtendedProperties;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MM.ClientModels;

namespace MM.Pages.Apply
{
    public class ProWizModel : PageModel
    {

        private readonly ClientDbContext _clientDbContext;

        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<ProWizModel> _logger;
        private readonly IEmailSender _emailSender;

        public ProWizModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<ProWizModel> logger, RoleManager<ApplicationRole> roleManager,
            IEmailSender emailSender, ClientDbContext clientDbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _clientDbContext = clientDbContext;
            _roleManager = roleManager;
        }

        [BindProperty]
        public List<qualificationvm> qvmlist { get; set; }

        [BindProperty]
        public List<employmentvm> empvmlist { get; set; }

        [BindProperty]
        public addressvm postaladress { get; set; }
        [BindProperty]
        public addressvm physicaladress { get; set; }

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


        // called first time the page is loaded.
        public IActionResult OnGet()
        {
            //AppUsersList = _clientDbContext.ApplicationUser.ToList();
            //AppUsers = new SelectList(AppUsersList, nameof(ApplicationUser.Id), nameof(ApplicationUser.FirstName));

            //List<MemberBranch> MemBranchesList = ;

            //ApplicationIndividualVM = new ApplicationIndividualVM();
            //ApplicationIndividualVM.QualificationVMList.Add(new QualificationVM { QualificationName="MCOM", EnrolmentCategoryId=1, Institute="MSUNIV"});
            //ApplicationIndividualVM.QualificationVMList.Add(new QualificationVM { QualificationName = "MBA", EnrolmentCategoryId = 2, Institute = "MKUNIV" });
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

            ViewData["Nationalities"] = new SelectList(_clientDbContext.Nationality.ToList(), nameof(Nationality.Id), nameof(Nationality.Name));

            ViewData["Provinces"] = new SelectList(_clientDbContext.State.ToList(), nameof(State.Id), nameof(State.Name));

            ViewData["Countries"] = new SelectList(_clientDbContext.Country.ToList(), nameof(Country.Id), nameof(Country.Name));

            //   ViewData["Disabilities"] = new SelectList(_clientDbContext.Disability.ToList(), nameof(Disability.Id), nameof(Disability.Name));

            ViewData["DisabilityLevels"] = new SelectList(_clientDbContext.DisabilityLevel.ToList(), nameof(DisabilityLevel.Id), nameof(DisabilityLevel.Name));

            ViewData["ClientBranchId"] = new SelectList(_clientDbContext.ClientBranch.ToList(), nameof(ClientBranch.Id), nameof(ClientBranch.Name));

            ViewData["VolunteerWorkHrs"] = new SelectList(_clientDbContext.VolunteerHours.ToList(), nameof(VolunteerHours.Id), nameof(VolunteerHours.Name));

            ViewData["Referrals"] = new SelectList(_clientDbContext.ReferralType.ToList(), nameof(ReferralType.Id), nameof(ReferralType.Name));

            ViewData["FileTypes"] = new SelectList(_clientDbContext.FileType.ToList(), nameof(FileType.Id), nameof(FileType.Name));


            return Page();
        }


        public async Task<IActionResult> OnPostAsync()

        {
            if (!ModelState.IsValid)
            {
            }
            else
            {
                ApplicationUser AppUser = new ApplicationUser();

                //AppUser.UserTypeId = 2;
                AppUser.TitleId = (int)ApplicationIndividualVM.TitleId;
                AppUser.FirstName = ApplicationIndividualVM.FirstName;
                AppUser.LastName = ApplicationIndividualVM.LastName;
                AppUser.Email = ApplicationIndividualVM.Email;
                AppUser.GenderId = (int)ApplicationIndividualVM.GenderId;
                AppUser.BirthDay = ApplicationIndividualVM.BirthDay;
                AppUser.PhoneNumber = ApplicationIndividualVM.MobilePhone;


                var result = await _userManager.CreateAsync(AppUser, AppUser.Pwd);
                MemberUser memUser = new MemberUser();
                if (result.Succeeded)
                {

                    memUser.ApplicaitonUserId = AppUser.Id;
                    memUser.Initials = ApplicationIndividualVM.Initials;
                    memUser.IDNumber = ApplicationIndividualVM.IDNumber;
                    memUser.NationalityId = ApplicationIndividualVM.NationalityId;
                    memUser.HomeLanguageId = ApplicationIndividualVM.HomeLanguageId;
                    memUser.EthnicityId = ApplicationIndividualVM.EthnicityId;
                    memUser.OccupationId = ApplicationIndividualVM.OccupationId;
                    memUser.HighestQualitificationId = ApplicationIndividualVM.HighestQualificationId;
                    memUser.CompanyName = ApplicationIndividualVM.CompanyName;
                    memUser.JobTitle = ApplicationIndividualVM.JobTitle;
                    memUser.HomePhoneNumber = ApplicationIndividualVM.HomePhoneNumber;
                    memUser.BusinessPhoneNumber = ApplicationIndividualVM.BusinessPhoneNumber;
                    memUser.FAXNumber = ApplicationIndividualVM.FAXNumber;
                    memUser.FaxToEmail = ApplicationIndividualVM.FaxToEmail;
                    memUser.SecondaryEmail = ApplicationIndividualVM.SecondaryEmail;

                    //memUser.MemberAddress = ApplicationIndividualVM.AddressLine1;
                    //memUser.Suburb = ApplicationIndividualVM.Suburb;
                    //memUser.TownCity = ApplicationIndividualVM.TownCity;
                    //memUser.ProvinceId = ApplicationIndividualVM.ProvinceId;
                    //memUser.CountryId = ApplicationIndividualVM.CountryId;
                    //memUser.PostalCode = ApplicationIndividualVM.PostalCode;
                    //memUser.DisabilityId = ApplicationIndividualVM.DisabilityId;
                    //memUser.DisabilityLevelId = ApplicationIndividualVM.DisabilityLevelId;
                    //memUser.StudentNumber = ApplicationIndividualVM.StudentNumber;
                    //memUser.QualificationName = ApplicationIndividualVM.QualificationName;
                    //memUser.JobDuties = ApplicationIndividualVM.JobDuties;
                    //memUser.MemberBranch = ApplicationIndividualVM.MemberBranch;
                    memUser.VolunteerWorkHoursId = ApplicationIndividualVM.VolunteerWorkHoursId;

                    memUser.TermAccepted = ApplicationIndividualVM.TermAccepted;
                    memUser.ReferralTypeId = ApplicationIndividualVM.ReferralTypeId;
                    memUser.ReferralOther = ApplicationIndividualVM.ReferralOther;
                    memUser.MemberCode = ApplicationIndividualVM.MemberCode;

                    _clientDbContext.MemberUser.Add(memUser);
                }
            }
            await _clientDbContext.SaveChangesAsync();
            return new JsonResult(new { success = true, message = "Saved successfully" });
        }


    }
}