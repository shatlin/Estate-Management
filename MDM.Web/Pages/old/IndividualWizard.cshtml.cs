﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MM.ClientModels;
using MM.Helper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MM.Pages.Apply
{
    public class IndividualWizardModel : PageModel
    {

        private readonly ClientDbContext _clientDbContext;

        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<IndividualWizardModel> _logger;
        private readonly IEmailSender _emailSender;

        public IndividualWizardModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<IndividualWizardModel> logger, RoleManager<ApplicationRole> roleManager,
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

            ApplicationIndividualVM=new ApplicationIndividualVM();
            ApplicationIndividualVM.CanWeSendCommunication=true;
             ApplicationIndividualVM.PublishCompanyInAnnualMemberDirectory=true;
            ApplicationIndividualVM.InterestedInVolunteerWork=false;

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

            //ViewData["Nationalities"] = new SelectList(_clientDbContext.Nationality.ToList(), nameof(Nationality.Id), nameof(Nationality.Name));

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


        //public async Task<IActionResult> OnPostAsync()
        //{
        //    try { _logger.LogInformation("Id|" + ApplicationIndividualVM.Id.ToString()); } catch { _logger.LogInformation("Id|" + "null"); }
        //    try { _logger.LogInformation("TitleId|" + ApplicationIndividualVM.TitleId.ToString()); } catch { _logger.LogInformation("TitleId|" + "null"); }
        //    try { _logger.LogInformation("Initials|" + ApplicationIndividualVM.Initials.ToString()); } catch { _logger.LogInformation("Initials|" + "null"); }
        //    try { _logger.LogInformation("FirstName|" + ApplicationIndividualVM.FirstName.ToString()); } catch { _logger.LogInformation("FirstName|" + "null"); }
        //    try { _logger.LogInformation("LastName|" + ApplicationIndividualVM.LastName.ToString()); } catch { _logger.LogInformation("LastName|" + "null"); }
        //    try { _logger.LogInformation("BirthDay|" + ApplicationIndividualVM.BirthDay.ToString()); } catch { _logger.LogInformation("BirthDay|" + "null"); }
        //    try { _logger.LogInformation("IDNumber|" + ApplicationIndividualVM.IDNumber.ToString()); } catch { _logger.LogInformation("IDNumber|" + "null"); }
        //    try { _logger.LogInformation("NationalityId|" + ApplicationIndividualVM.NationalityId.ToString()); } catch { _logger.LogInformation("NationalityId|" + "null"); }
        //    try { _logger.LogInformation("HomeLanguageId|" + ApplicationIndividualVM.HomeLanguageId.ToString()); } catch { _logger.LogInformation("HomeLanguageId|" + "null"); }
        //    try { _logger.LogInformation("GenderId|" + ApplicationIndividualVM.GenderId.ToString()); } catch { _logger.LogInformation("GenderId|" + "null"); }
        //    try { _logger.LogInformation("EthnicityId|" + ApplicationIndividualVM.EthnicityId.ToString()); } catch { _logger.LogInformation("EthnicityId|" + "null"); }
        //    try { _logger.LogInformation("OccupationId|" + ApplicationIndividualVM.OccupationId.ToString()); } catch { _logger.LogInformation("OccupationId|" + "null"); }
        //    try { _logger.LogInformation("HighestQualificationId|" + ApplicationIndividualVM.HighestQualificationId.ToString()); } catch { _logger.LogInformation("HighestQualificationId|" + "null"); }
        //    try { _logger.LogInformation("CompanyName|" + ApplicationIndividualVM.CompanyName.ToString()); } catch { _logger.LogInformation("CompanyName|" + "null"); }
        //    try { _logger.LogInformation("JobTitle|" + ApplicationIndividualVM.JobTitle.ToString()); } catch { _logger.LogInformation("JobTitle|" + "null"); }
        //    try { _logger.LogInformation("CountryId|" + ApplicationIndividualVM.CountryId.ToString()); } catch { _logger.LogInformation("CountryId|" + "null"); }

        //    try { _logger.LogInformation("HomePhoneNumber|" + ApplicationIndividualVM.HomePhoneNumber.ToString()); } catch { _logger.LogInformation("HomePhoneNumber|" + "null"); }
        //    try { _logger.LogInformation("BusinessPhoneNumber|" + ApplicationIndividualVM.BusinessPhoneNumber.ToString()); } catch { _logger.LogInformation("BusinessPhoneNumber|" + "null"); }
        //    try { _logger.LogInformation("FAXNumber|" + ApplicationIndividualVM.FAXNumber.ToString()); } catch { _logger.LogInformation("FAXNumber|" + "null"); }
        //    try { _logger.LogInformation("FaxToEmail|" + ApplicationIndividualVM.FaxToEmail.ToString()); } catch { _logger.LogInformation("FaxToEmail|" + "null"); }
        //    try { _logger.LogInformation("MobilePhone|" + ApplicationIndividualVM.MobilePhone.ToString()); } catch { _logger.LogInformation("MobilePhone|" + "null"); }
        //    try { _logger.LogInformation("Email|" + ApplicationIndividualVM.Email.ToString()); } catch { _logger.LogInformation("Email|" + "null"); }
        //    try { _logger.LogInformation("SecondaryEmail|" + ApplicationIndividualVM.SecondaryEmail.ToString()); } catch { _logger.LogInformation("SecondaryEmail|" + "null"); }


        //    try { _logger.LogInformation("physicalAddressLine1|" + ApplicationIndividualVM.PhysicalAddressLine1.ToString()); } catch { _logger.LogInformation("physicaladress.AddressLine1|" + "null"); }
        //    try { _logger.LogInformation("physicalAddressLine2|" + ApplicationIndividualVM.PhysicalAddressLine2.ToString()); } catch { _logger.LogInformation("physicaladress.AddressLine2|" + "null"); }
        //    try { _logger.LogInformation("physicalSuburb|" + ApplicationIndividualVM.PhysicalSuburb.ToString()); } catch { _logger.LogInformation("physicaladress.Suburb|" + "null"); }
        //    try { _logger.LogInformation("physicalCity|" + ApplicationIndividualVM.PhysicalCity.ToString()); } catch { _logger.LogInformation("physicaladress.City|" + "null"); }
        //    try { _logger.LogInformation("physicalProvince|" + ApplicationIndividualVM.PhysicalProvince.ToString()); } catch { _logger.LogInformation("physicaladress.Province|" + "null"); }
        //    try { _logger.LogInformation("physicalCountryId|" +ApplicationIndividualVM.PhysicalCountryId.ToString()); } catch { _logger.LogInformation("physicaladress.CountryId|" + "null"); }
        //    try { _logger.LogInformation("physicalPostalCode|" + ApplicationIndividualVM.PhysicalPostalCode.ToString()); } catch { _logger.LogInformation("physicaladress.PostalCode|" + "null"); }


        //    try { _logger.LogInformation("postalAddressLine1|" +  ApplicationIndividualVM.PostalAddressLine1.ToString()); } catch { _logger.LogInformation(" ApplicationIndividualVM.PostalAddressLine1|" + "null"); }
        //    try { _logger.LogInformation("postalAddressLine2|" +  ApplicationIndividualVM.PostalAddressLine2.ToString()); } catch { _logger.LogInformation(" ApplicationIndividualVM.PostalAddressLine2|" + "null"); }
        //    try { _logger.LogInformation("postalSuburb|" +  ApplicationIndividualVM.PostalSuburb.ToString()); } catch { _logger.LogInformation(" ApplicationIndividualVM.PostalSuburb|" + "null"); }
        //    try { _logger.LogInformation("postalCity|" +  ApplicationIndividualVM.PostalCity.ToString()); } catch { _logger.LogInformation(" ApplicationIndividualVM.PostalCity|" + "null"); }
        //    try { _logger.LogInformation("postalProvince|" +  ApplicationIndividualVM.PostalProvince.ToString()); } catch { _logger.LogInformation(" ApplicationIndividualVM.PostalProvince|" + "null"); }
        //    try { _logger.LogInformation("postalCountryId|" +  ApplicationIndividualVM.PostalCountryId.ToString()); } catch { _logger.LogInformation(" ApplicationIndividualVM.PostalCountryId|" + "null"); }
        //    try { _logger.LogInformation("postalPostalCode|" +  ApplicationIndividualVM.PostalPostalCode.ToString()); } catch { _logger.LogInformation(" ApplicationIndividualVM.PostalPostalCode|" + "null"); }

        //    int i = 0;

        //    foreach (var qualification in qvmlist)
        //    {
        //        try { _logger.LogInformation("qvmlist[" + i + "].categoryid|" + qualification.categoryid.ToString()); } catch { _logger.LogInformation("qvmlist[" + i + "].categoryid|" + "null"); }
        //        try { _logger.LogInformation("qvmlist[" + i + "].institute|" + qualification.institute.ToString()); } catch { _logger.LogInformation("qvmlist[" + i + "].institute|" + "null"); }
        //        try { _logger.LogInformation("qvmlist[" + i + "].qualificationname|" + qualification.qualificationname.ToString()); } catch { _logger.LogInformation("qvmlist[" + i + "].qualificationname|" + "null"); }
        //        try { _logger.LogInformation("qvmlist[" + i + "].studentnumber|" + qualification.studentnumber.ToString()); } catch { _logger.LogInformation("qvmlist[" + i + "].studentnumber|" + "null"); }
        //        try { _logger.LogInformation("qvmlist[" + i + "].startdate|" + qualification.startdate.ToString()); } catch { _logger.LogInformation("qvmlist[" + i + "].startdate|" + "null"); }
        //        try { _logger.LogInformation("qvmlist[" + i + "].enddate|" + qualification.enddate.ToString()); } catch { _logger.LogInformation("qvmlist[" + i + "].enddate|" + "null"); }
        //        try { _logger.LogInformation("qvmlist[" + i + "].qualificationtype|" + qualification.qualificationtype.ToString()); } catch { _logger.LogInformation("qvmlist[" + i + "].qualificationtype|" + "null"); }
        //        try { _logger.LogInformation("qvmlist[" + i + "].enrolmentcategoryid|" + qualification.enrolmentcategoryid.ToString()); } catch { _logger.LogInformation("qvmlist[" + i + "].enrolmentcategoryid|" + "null"); }
        //        i++;
        //    }

        //    i = 0;

        //    foreach (var employment in empvmlist)
        //    {
        //        try { _logger.LogInformation("empvmlist[" + i + "].empcategoryid|" + employment.empcategoryid.ToString()); } catch { _logger.LogInformation("empvmlist[" + i + "].empcategoryid|" + "null"); }
        //        try { _logger.LogInformation("empvmlist[" + i + "].empcompanyemail|" + employment.empcompanyemail.ToString()); } catch { _logger.LogInformation("empvmlist[" + i + "].empcompanyemail|" + "null"); }
        //        try { _logger.LogInformation("empvmlist[" + i + "].empdesignation|" + employment.empdesignation.ToString()); } catch { _logger.LogInformation("empvmlist[" + i + "].empdesignation|" + "null"); }
        //        try { _logger.LogInformation("empvmlist[" + i + "].empduties|" + employment.empduties.ToString()); } catch { _logger.LogInformation("empvmlist[" + i + "].empduties|" + "null"); }
        //        try { _logger.LogInformation("empvmlist[" + i + "].empstartdate|" + employment.empstartdate.ToString()); } catch { _logger.LogInformation("empvmlist[" + i + "].empstartdate|" + "null"); }
        //        try { _logger.LogInformation("empvmlist[" + i + "].empenddate|" + employment.empenddate.ToString()); } catch { _logger.LogInformation("empvmlist[" + i + "].empenddate|" + "null"); }
        //        try { _logger.LogInformation("empvmlist[" + i + "].employer|" + employment.employer.ToString()); } catch { _logger.LogInformation("empvmlist[" + i + "].employer|" + "null"); }
        //        try { _logger.LogInformation("empvmlist[" + i + "].emptelnumber|" + employment.emptelnumber.ToString()); } catch { _logger.LogInformation("empvmlist[" + i + "].emptelnumber|" + "null"); }
        //        i++;
        //    }


        //    i = 0;
        //    foreach (var disabilty in MemberDisabilityList)
        //    {
        //        try { _logger.LogInformation("MemberDisabilityList[" + i + "].Id|" + disabilty.Id.ToString()); } catch { _logger.LogInformation("MemberDisabilityList[" + i + "].Id|" + "null"); }
        //        try { _logger.LogInformation("MemberDisabilityList[" + i + "].IsSelected|" + disabilty.IsSelected.ToString()); } catch { _logger.LogInformation("MemberDisabilityList[" + i + "].IsSelected|" + "null"); }
        //        try { _logger.LogInformation("MemberDisabilityList[" + i + "].DisabilityLevelId|" + disabilty.DisabilityLevelId.ToString()); } catch { _logger.LogInformation("MemberDisabilityList[" + i + "].DisabilityLevelId|" + "null"); }
        //        try { _logger.LogInformation("MemberDisabilityList[" + i + "].Name|" + disabilty.Name.ToString()); } catch { _logger.LogInformation("MemberDisabilityList[" + i + "].Name|" + "null"); }
        //        i++;
        //    }

        //    try { _logger.LogInformation("ClientBranchId|" + ApplicationIndividualVM.ClientBranchId.ToString()); } catch { _logger.LogInformation("ClientBranchId|" + "null"); }


        //    i = 0;
        //    foreach (var divisionlist in MemberDivisionList)
        //    {
        //        try { _logger.LogInformation("MemberDivisionList[" + i + "].Id|" + divisionlist.Id.ToString()); } catch { _logger.LogInformation("MemberDivisionList[" + i + "].Id|" + "null"); }
        //        try { _logger.LogInformation("MemberDivisionList[" + i + "].IsSelected|" + divisionlist.IsSelected.ToString()); } catch { _logger.LogInformation("MemberDivisionList[" + i + "].IsSelected|" + "null"); }
        //        try { _logger.LogInformation("MemberDivisionList[" + i + "].Name|" + divisionlist.Name.ToString()); } catch { _logger.LogInformation("MemberDivisionList[" + i + "].Name|" + "null"); }
        //        i++;
        //    }

        //    i = 0;
        //    foreach (var affliationlist in MemberAffiliationList)
        //    {
        //        try { _logger.LogInformation("affliationlist[" + i + "].Id|" + affliationlist.Id.ToString()); } catch { _logger.LogInformation("affliationlist[" + i + "].Id|" + "null"); }
        //        try { _logger.LogInformation("affliationlist[" + i + "].IsSelected|" + affliationlist.IsSelected.ToString()); } catch { _logger.LogInformation("affliationlist[" + i + "].IsSelected|" + "null"); }
        //        try { _logger.LogInformation("affliationlist[" + i + "].MemberNumber|" + affliationlist.MemberNumber.ToString()); } catch { _logger.LogInformation("affliationlist[" + i + "].MemberNumber|" + "null"); }
        //        try { _logger.LogInformation("affliationlist[" + i + "].MemberSpecificAffliationName|" + affliationlist.MemberSpecificAffliationName.ToString()); } catch { _logger.LogInformation("affliationlist[" + i + "].MemberSpecificAffliationName|" + "null"); }
        //        i++;
        //    }

        //     i = 0;
        //    foreach (var involvementlist in MemberInvolvementList)
        //    {
        //        try { _logger.LogInformation("involvementlist[" + i + "].Id|" + involvementlist.Id.ToString()); } catch { _logger.LogInformation("involvementlist[" + i + "].Id|" + "null"); }
        //        try { _logger.LogInformation("involvementlist[" + i + "].IsSelected|" + involvementlist.IsSelected.ToString()); } catch { _logger.LogInformation("involvementlist[" + i + "].IsSelected|" + "null"); }
        //        try { _logger.LogInformation("involvementlist[" + i + "].Name|" + involvementlist.Name.ToString()); } catch { _logger.LogInformation("involvementlist[" + i + "].Name|" + "null"); }
        //        i++;
        //    }


        //    //if (!ModelState.IsValid)
        //    //{
        //    //}
        //    //else
        //    //{
        //    //    ApplicationUser AppUser = new ApplicationUser();

        //    //    //AppUser.UserTypeId = 2;
        //    //    AppUser.TitleId = (int)ApplicationIndividualVM.TitleId;
        //    //    AppUser.FirstName = ApplicationIndividualVM.FirstName;
        //    //    AppUser.LastName = ApplicationIndividualVM.LastName;
        //    //    AppUser.Email = ApplicationIndividualVM.Email;
        //    //    AppUser.GenderId = (int)ApplicationIndividualVM.GenderId;
        //    //    AppUser.BirthDay = ApplicationIndividualVM.BirthDay;
        //    //    AppUser.PhoneNumber = ApplicationIndividualVM.MobilePhone;

        //    //    var result = await _userManager.CreateAsync(AppUser, AppUser.Pwd);
        //    //    MemberUser memUser = new MemberUser();
        //    //    if (result.Succeeded)
        //    //    {

        //    //        memUser.ApplicaitonUserId = AppUser.Id;
        //    //        memUser.Initials = ApplicationIndividualVM.Initials;
        //    //        memUser.IDNumber = ApplicationIndividualVM.IDNumber;
        //    //        memUser.NationalityId = ApplicationIndividualVM.NationalityId;
        //    //        memUser.HomeLanguageId = ApplicationIndividualVM.HomeLanguageId;
        //    //        memUser.EthnicityId = ApplicationIndividualVM.EthnicityId;
        //    //        memUser.OccupationId = ApplicationIndividualVM.OccupationId;
        //    //        memUser.HighestQualitificationId = ApplicationIndividualVM.HighestQualificationId;
        //    //        memUser.HomePhoneNumber = ApplicationIndividualVM.HomePhoneNumber;
        //    //        memUser.BusinessPhoneNumber = ApplicationIndividualVM.BusinessPhoneNumber;
        //    //        memUser.FAXNumber = ApplicationIndividualVM.FAXNumber;
        //    //        memUser.FaxToEmail = ApplicationIndividualVM.FaxToEmail;
        //    //        memUser.SecondaryEmail = ApplicationIndividualVM.SecondaryEmail;

        //    //        //memUser.MemberAddress = ApplicationIndividualVM.AddressLine1;
        //    //        //memUser.Suburb = ApplicationIndividualVM.Suburb;
        //    //        //memUser.TownCity = ApplicationIndividualVM.TownCity;
        //    //        //memUser.ProvinceId = ApplicationIndividualVM.ProvinceId;
        //    //        //memUser.CountryId = ApplicationIndividualVM.CountryId;
        //    //        //memUser.PostalCode = ApplicationIndividualVM.PostalCode;
        //    //        //memUser.DisabilityId = ApplicationIndividualVM.DisabilityId;
        //    //        //memUser.DisabilityLevelId = ApplicationIndividualVM.DisabilityLevelId;
        //    //        //memUser.StudentNumber = ApplicationIndividualVM.StudentNumber;
        //    //        //memUser.QualificationName = ApplicationIndividualVM.QualificationName;
        //    //        //memUser.JobDuties = ApplicationIndividualVM.JobDuties;

        //    //        memUser.VolunteerWorkHoursId = ApplicationIndividualVM.VolunteerWorkHoursId;

        //    //        memUser.TermAccepted = ApplicationIndividualVM.TermAccepted;
        //    //        memUser.ReferralTypeId = ApplicationIndividualVM.ReferralTypeId;
        //    //        memUser.ReferralOther = ApplicationIndividualVM.ReferralOther;
        //    //        memUser.MemberCode = ApplicationIndividualVM.MemberCode;

        //    //        _clientDbContext.MemberUser.Add(memUser);
        //    //    }
        //    //}
        //    //await _clientDbContext.SaveChangesAsync();
        //    return new JsonResult(new { success = true, message = "Saved successfully" });
        //}


    }
}