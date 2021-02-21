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
using MM.Web.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using WISA.Services;

namespace MM.Pages.Apply
{
    [AllowAnonymous]

    public class IndividualModel : PageModel
    {
        #region Constructor

        private readonly ClientDbContext _clientDbContext;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<IndividualModel> _logger;
        private readonly IEmailCreator _emailCreator;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        private readonly IAuthorizationService _authorizationService;
        private IActivity _activity;
        private string EntityName = "Add Individual";

        public IndividualModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            ILogger<IndividualModel> logger, IEmailCreator emailCreator,
            ClientDbContext clientDbContext, IConfiguration configuration, IWebHostEnvironment env, IActivity activity, IAuthorizationService authorizationService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailCreator = emailCreator;
            _clientDbContext = clientDbContext;
            _configuration = configuration;
            _env = env;
            _activity = activity;
            _authorizationService = authorizationService;
        }
        #endregion

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{

        //    if (qvmlist != null && qvmlist.Count == 0)
        //        yield return new ValidationResult("Atlease one Qualification is Required");

        //    if (AppIndVM.HaveEmploymentHistory==true && (qvmlist == null || qvmlist.Count == 0) )
        //    {
        //        yield return new ValidationResult("Atleast one Employment History is required");
        //    }
        //}

        #region Bindings

        [BindProperty]
        public ApplicationIndividualVM AppIndVM { get; set; }

        [BindProperty]
        public List<employmentvm> empvmlist { get; set; }

        [BindProperty]
        public List<qualificationvm> qvmlist { get; set; }

        [BindProperty]
        public List<refereevm> refvmlist { get; set; }

        [BindProperty]
        public List<dwsclassvm> classlist { get; set; }

        [BindProperty]
        public List<IFormFile> IDDocuments { get; set; }

        [BindProperty]
        public List<IFormFile> ProofOfStudentLetter { get; set; }


        [BindProperty]
        public List<IFormFile> Certificates { get; set; }

        [BindProperty]
        public List<IFormFile> ProofofDWS { get; set; }

        [BindProperty]
        public List<IFormFile> ProofOfReg { get; set; }

        [BindProperty]
        public List<IFormFile> ProofOfPayment { get; set; }

        [BindProperty]
        public int RequestType { get; set; }

        [BindProperty]
        public int? OrganizationId { get; set; }


        [BindProperty]
        public string OrganizationName { get; set; }
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

        [BindProperty]
        public Notification notification { get; set; }

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
            ViewData["nationalities"] = new SelectList(_clientDbContext.Country.ToList(), nameof(Country.Id), nameof(Country.Description));
            ViewData["Countries"] = new SelectList(_clientDbContext.Country.ToList(), nameof(Country.Id), nameof(Country.Name));
            ViewData["DisabilityLevels"] = new SelectList(_clientDbContext.DisabilityLevel.ToList(), nameof(DisabilityLevel.Id), nameof(DisabilityLevel.Name));
            ViewData["MemberBranchId"] = new SelectList(_clientDbContext.MemberBranch.ToList(), nameof(MemberBranch.Id), nameof(MemberBranch.Name));
            ViewData["VolunteerWorkHrs"] = new SelectList(_clientDbContext.VolunteerHours.ToList(), nameof(VolunteerHours.Id), nameof(VolunteerHours.Name));
            ViewData["Referrals"] = new SelectList(_clientDbContext.ReferralType.ToList(), nameof(ReferralType.Id), nameof(ReferralType.Name));
            ViewData["FileTypes"] = new SelectList(_clientDbContext.FileType.ToList(), nameof(FileType.Id), nameof(FileType.Name));
            ViewData["MembershipTypeId"] = new SelectList(_clientDbContext.MembershipType.Where(x => x.Id >= 5).ToList(), nameof(MembershipType.Id), nameof(MembershipType.Name));
            ViewData["YesNoList"] = new SelectList(new YesNoLookup().YesNoList(), nameof(YesNoLookup.Id), nameof(YesNoLookup.Name));
        }

        public async Task<MemberUser> CreateMemberUser(string appUserId)
        {
            MemberUser MemberUser = new MemberUser();
            MemberUser.ApplicaitonUserId = appUserId;
            MemberUser.Initials = AppIndVM.Initials;
            MemberUser.IDNumber = AppIndVM.IDNumber;
            MemberUser.HomeLanguageId = AppIndVM.HomeLanguageId;
            MemberUser.EthnicityId = AppIndVM.EthnicityId;
            MemberUser.OccupationId = AppIndVM.OccupationId;
            MemberUser.HighestQualitificationId = AppIndVM.HighestQualificationId;
            MemberUser.CompanyName = AppIndVM.CompanyName;
            MemberUser.JobTitle = AppIndVM.JobTitle;
            MemberUser.CountryId = AppIndVM.CountryId;
            MemberUser.HomePhoneNumber = AppIndVM.HomePhoneNumber;
            MemberUser.BusinessPhoneNumber = AppIndVM.BusinessPhoneNumber;
            MemberUser.FAXNumber = AppIndVM.FAXNumber;
            MemberUser.FaxToEmail = AppIndVM.FaxToEmail;
            MemberUser.MobilePhone = AppIndVM.MobilePhone;
            MemberUser.Email = AppIndVM.Email;
            MemberUser.SecondaryEmail = AppIndVM.SecondaryEmail;
            MemberUser.ReferralTypeId = AppIndVM.ReferralTypeId;
            MemberUser.ReferralOther = AppIndVM.ReferralOther;
            MemberUser.MemberBranchId = AppIndVM.ClientBranchId;
            MemberUser.InterestedInVolunteerWork = AppIndVM.InterestedInVolunteerWork;
            MemberUser.PublishCompanyInAnnualMemberDirectory = AppIndVM.PublishCompanyInAnnualMemberDirectory;
            MemberUser.DonotFax = AppIndVM.DonotFax;
            MemberUser.DoNotSMS = AppIndVM.DoNotSMS;
            MemberUser.DoNotEmail = AppIndVM.DoNotEmail;
            MemberUser.DonotBulkPostalMail = AppIndVM.DonotBulkPostalMail;
            MemberUser.DonotBulkEmail = AppIndVM.DonotBulkEmail;
            MemberUser.DonotSendMassMarketing = AppIndVM.DonotSendMassMarketing;
            MemberUser.DonotpostalMail = AppIndVM.DonotpostalMail;
            MemberUser.DonotPhone = AppIndVM.DonotPhone;
            MemberUser.CreatedOn = DateTime.Now;
            MemberUser.ModifiedOn = DateTime.Now;
            MemberUser.VolunteerWorkHoursId = AppIndVM.VolunteerWorkHoursId;
            MemberUser.TermAccepted = AppIndVM.TermAccepted;
            MemberUser.ApplicationreceivedDate = DateTime.Now;
            MemberUser.IsActive = true;
            if (RequestType == 2)
            {
                MemberUser.MembershipTypeId = (int?)MembershipTypeEnum.ProfessionalProcessController;
            }
            else
            {
                MemberUser.MembershipTypeId = (int?)MembershipTypeEnum.IndividualMember;
            }
            if (RequestType == 3)
            {
                MemberUser.ParentMemberid = OrganizationId;
                MemberUser.OrganizationId = OrganizationId;
                MemberUser.MembershipGradeId = AppIndVM.MembershipGradeId;
            }

            MemberUser.MemberStatusId = 2;
            int MemberCode = 1;

            var lastMember = _clientDbContext.MemberUser.OrderByDescending(x => x.Id).FirstOrDefault();
            if (lastMember != null)
            {
                MemberCode = Convert.ToInt32(_clientDbContext.MemberUser.OrderByDescending(x => x.Id).FirstOrDefault().MemberCode) + 1;
                var member = _clientDbContext.MemberUser.Where(x => x.MemberCode == MemberCode.ToString()).FirstOrDefault();
                while (member != null)
                {
                    MemberCode += 1;
                    member = _clientDbContext.MemberUser.Where(x => x.MemberCode == MemberCode.ToString()).FirstOrDefault();
                }
            }
            MemberUser.MemberCode = MemberCode.ToString();

            _clientDbContext.MemberUser.Add(MemberUser);
            await _clientDbContext.SaveChangesAsync();

            Address physicalAddress = new Address();
            physicalAddress.RelatedEntityId = MemberUser.Id;
            physicalAddress.RelatedToId = (int)RelatedToEnum.Member;
            physicalAddress.AddressTypeId = (int)AddressTypeEnum.Physical;
            physicalAddress.AddressLine1 = AppIndVM.PhysicalAddressLine1;
            physicalAddress.AddressLine2 = AppIndVM.PhysicalAddressLine2;
            physicalAddress.Suburb = AppIndVM.PhysicalSuburb;
            physicalAddress.CityName = AppIndVM.PhysicalCity;
            physicalAddress.Province = AppIndVM.PhysicalProvince;
            physicalAddress.PostalCode = AppIndVM.PhysicalPostalCode;
            physicalAddress.CountryId = AppIndVM.PhysicalCountryId;
            physicalAddress.StateId = AppIndVM.PhysicalStateId;
            await _clientDbContext.Address.AddAsync(physicalAddress);
            await _clientDbContext.SaveChangesAsync();

            Address PostalAddress = new Address();
            PostalAddress.RelatedEntityId = MemberUser.Id;
            PostalAddress.RelatedToId = (int)RelatedToEnum.Member;
            PostalAddress.AddressTypeId = (int)AddressTypeEnum.Postal;
            PostalAddress.AddressLine1 = AppIndVM.PostalAddressLine1;
            PostalAddress.AddressLine2 = AppIndVM.PostalAddressLine2;
            PostalAddress.Suburb = AppIndVM.PostalSuburb;
            PostalAddress.CityName = AppIndVM.PostalCity;
            PostalAddress.Province = AppIndVM.PostalProvince;
            PostalAddress.PostalCode = AppIndVM.PostalPostalCode;
            PostalAddress.CountryId = AppIndVM.PostalCountryId;
            PostalAddress.StateId = AppIndVM.PostalStateId;

            await _clientDbContext.Address.AddAsync(PostalAddress);
            await _clientDbContext.SaveChangesAsync();

            if (RequestType == 2)
            {
                foreach (var dwsclass in classlist)
                {
                    if (string.IsNullOrEmpty(dwsclass.isdeleted))
                    {
                        DWSClassMemberXref dWSClassMemberXref = new DWSClassMemberXref();
                        dWSClassMemberXref.MemberId = MemberUser.Id;
                        dWSClassMemberXref.DWSClassId = dwsclass.waterclass;
                        dWSClassMemberXref.ClassDate = dwsclass.waterdate;
                        await _clientDbContext.DWSClassMemberXref.AddAsync(dWSClassMemberXref);
                    }
                }
                await _clientDbContext.SaveChangesAsync();
            }
            foreach (var qualification in qvmlist)
            {
                if (string.IsNullOrEmpty(qualification.isdeleted))
                {
                    MemberQualificationXref qual = new MemberQualificationXref();
                    qual.MemberId = MemberUser.Id;
                    qual.QualificationCategoryId = qualification.categoryid;
                    qual.MemberSpecificQualificationName = qualification.qualificationname;
                    qual.InstituteName = qualification.institute;
                    qual.StudentNumber = qualification.studentnumber;
                    qual.QualificationFrom = qualification.startdate;
                    qual.QualificationTill = qualification.enddate;
                    qual.QualificationTypeId = qualification.qualificationtype;
                    qual.QualificationEnrolmentCategoryId = qualification.enrolmentcategoryid;
                    await _clientDbContext.MemberQualificationXref.AddAsync(qual);
                }
            }
            await _clientDbContext.SaveChangesAsync();

            foreach (var referee in refvmlist)
            {
                if (string.IsNullOrEmpty(referee.isdeleted))
                {
                    MemberRefereeXref refer = new MemberRefereeXref();
                    refer.RelatedToId = (int)RelatedToEnum.Member;
                    refer.RelatedEntityId = MemberUser.Id;
                    refer.Title = referee.title;
                    refer.Initials = referee.initial;
                    refer.FirstName = referee.firstname;
                    refer.LastName = referee.lastname;
                    refer.Email = referee.email;
                    refer.CellPhone = referee.mobilenumber;
                    refer.TelephoneNumber = referee.phonenumber;
                    refer.NameOfEmployer = referee.employername;
                    refer.PositionOfReferree = referee.positionofreferee;
                    refer.ProfessionalRegistrationNumber = referee.professionalregnoofreferee;
                    refer.CreatedOn = DateTime.Now;
                    refer.ModifiedOn = DateTime.Now;
                    await _clientDbContext.MemberRefereeXref.AddAsync(refer);
                    await _clientDbContext.SaveChangesAsync();
                }
            }
            

            foreach (var employment in empvmlist)
            {
                if (string.IsNullOrEmpty(employment.isdeleted))
                {
                    EmploymentMemberXref empl = new EmploymentMemberXref();
                    empl.MemberUserId = MemberUser.Id;
                    empl.EmploymentCategoryId = employment.empcategoryid;
                    empl.CompanyEmail = employment.empcompanyemail;
                    empl.Designation = employment.empdesignation;
                    empl.YourDuties = employment.empduties;
                    empl.StartDate = employment.empstartdate;
                    empl.EndDate = employment.empenddate;
                    empl.EmployerName = employment.employer;
                    empl.CompanyTelephoneNumber = employment.emptelnumber;
                    await _clientDbContext.EmploymentMemberXref.AddAsync(empl);
                }
            }

            await _clientDbContext.SaveChangesAsync();

            foreach (var disabilty in MemberDisabilityList)
            {
                DisabilityMemberXref disab = new DisabilityMemberXref();
                if (disabilty.IsSelected)
                {
                    disab.MemberId = MemberUser.Id;
                    disab.DisabilityId = disabilty.Id;
                    disab.DisabilityLevelId = disabilty.DisabilityLevelId;
                    await _clientDbContext.DisabilityMemberXref.AddAsync(disab);
                }
            }

            await _clientDbContext.SaveChangesAsync();

            foreach (var affliation in MemberAffiliationList)
            {
                MemberAffliationXref affXref = new MemberAffliationXref();
                if (affliation.IsSelected)
                {
                    affXref.MemberId = MemberUser.Id;
                    affXref.AffliationId = affliation.Id;
                    affXref.MemberNumber = affliation.MemberNumber;
                    affXref.MemberSpecificAffliationName = affliation.MemberSpecificAffliationName;
                    await _clientDbContext.MemberAffliationXref.AddAsync(affXref);
                }
            }
            await _clientDbContext.SaveChangesAsync();
            foreach (var involvement in MemberInvolvementList)
            {
                InvolvementMemberXref invXref = new InvolvementMemberXref();
                if (involvement.IsSelected)
                {
                    invXref.MemberId = MemberUser.Id;
                    invXref.InvolvementId = involvement.Id;
                    await _clientDbContext.InvolvementMemberXref.AddAsync(invXref);
                }
            }
            await _clientDbContext.SaveChangesAsync();


            await UploadFiles(IDDocuments, (int?)FileTypesEnum.IDDocs, "IDDocs", MemberUser.MemberCode, MemberUser.ApplicationUser.FullName, MemberUser.Id);
            await UploadFiles(Certificates, (int?)FileTypesEnum.Certificates, "Certificates", MemberUser.MemberCode, MemberUser.ApplicationUser.FullName, MemberUser.Id);
            await UploadFiles(ProofOfReg, (int?)FileTypesEnum.StudentReg, "StudentRegistration", MemberUser.MemberCode, MemberUser.ApplicationUser.FullName, MemberUser.Id);
            await UploadFiles(ProofOfPayment, (int?)FileTypesEnum.Payment, "ProofOfPay", MemberUser.MemberCode, MemberUser.ApplicationUser.FullName, MemberUser.Id);
            await UploadFiles(ProofOfStudentLetter, (int?)FileTypesEnum.StudentLetter, "StudentConfirmation", MemberUser.MemberCode, MemberUser.ApplicationUser.FullName, MemberUser.Id);

            //var tempFolder = Path.Combine(_env.ContentRootPath + _configuration["StoredFilesPath"], "tmp", MemberUser.ApplicationUser.FullName);
            //await UploadFilesNew(tempFolder + "\\IDDocs", (int?)FileTypesEnum.IDDocs, "IDDocs", MemberUser.MemberCode, MemberUser.ApplicationUser.FullName, MemberUser.Id);
            //await UploadFilesNew(tempFolder + "\\Certificates", (int?)FileTypesEnum.IDDocs, "Certificates", MemberUser.MemberCode, MemberUser.ApplicationUser.FullName, MemberUser.Id);
            //await UploadFilesNew(tempFolder + "\\StudentRegistration", (int?)FileTypesEnum.IDDocs, "StudentRegistration", MemberUser.MemberCode, MemberUser.ApplicationUser.FullName, MemberUser.Id);
            //await UploadFilesNew(tempFolder + "\\ProofOfPay", (int?)FileTypesEnum.IDDocs, "ProofOfPay", MemberUser.MemberCode, MemberUser.ApplicationUser.FullName, MemberUser.Id);
            //await UploadFilesNew(tempFolder + "\\StudentConfirmation", (int?)FileTypesEnum.IDDocs, "StudentConfirmation", MemberUser.MemberCode, MemberUser.ApplicationUser.FullName, MemberUser.Id);


            foreach (var division in MemberDivisionList)
            {
                DivisionMemberXref divisionXref = new DivisionMemberXref();
                if (division.IsSelected)
                {
                    divisionXref.MemberId = MemberUser.Id;
                    divisionXref.DivisonId = division.Id;
                    await _clientDbContext.DivisionMemberXref.AddAsync(divisionXref);
                }
            }
            await _clientDbContext.SaveChangesAsync();

            return MemberUser;
        }

        public async Task<ApplicationUser> CreateApplicationUser()
        {
            ApplicationUser AppUser = new ApplicationUser();
            try
            {
                var isStaff = await _authorizationService.AuthorizeAsync(User, MMPolicies.AllowUserAccess);
                if (isStaff.Succeeded)
                {
                    AppUser.IsAdminCreated = true;
                }
                AppUser.Email = AppIndVM.Email;
                AppUser.UserName = AppIndVM.Email;
                AppUser.FirstName = AppIndVM.FirstName;
                AppUser.LastName = AppIndVM.LastName;
                AppUser.BirthDay = AppIndVM.BirthDay;
                AppUser.TitleId = Convert.ToInt32(AppIndVM.TitleId);
                AppUser.GenderId = Convert.ToInt32(AppIndVM.GenderId);
                AppUser.UserTypeId = (int)UserTypeValues.Member;
                return AppUser;
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception Occured while Creating Application User |" + ex.Message);
            }
            return null;
        }

        public async Task<IActionResult> OnGetAsync(int? ReqId = 1, int? OrgId = 0)
        {

            AppIndVM = new ApplicationIndividualVM();
            AppIndVM.CanWeSendCommunication = true;
            AppIndVM.PublishCompanyInAnnualMemberDirectory = true;
            AppIndVM.InterestedInVolunteerWork = false;

            var isStaff = await _authorizationService.AuthorizeAsync(User, MMPolicies.AllowUserAccess);
            if (isStaff.Succeeded)
            {
                AppIndVM.Password = HelperMethods.GeneratePassword(8);
                AppIndVM.ConfirmPassword = AppIndVM.Password;
            }
            if (ReqId == 1)
            {
                RequestType = 1;//Individual
            }
            else if (ReqId == 2)//Professional
            {
                RequestType = 2;
            }
            else if (ReqId == 3)
            {
                RequestType = 3;

                if (OrgId != null)
                {
                    Organization org = _clientDbContext.Organization.Where(x => x.Id == OrgId).FirstOrDefault();
                    OrganizationId = OrgId;
                    OrganizationName = org.Name;
                }
            }

            SetViewData();
            await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Accessed + EntityName, UserTypeValues.Staff);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? OrgId, string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ApplicationUser AppUser = new ApplicationUser();
            MemberUser MemberUser = new MemberUser();

            qvmlist.RemoveAll(x => x.isdeleted == "true");
            empvmlist.RemoveAll(x => x.isdeleted == "true");
            refvmlist.RemoveAll(x => x.isdeleted == "true");


            if (qvmlist == null || qvmlist.Count == 0)
            {
                ModelState.AddModelError("qvmlist", " * Atleast one Qualification is required");
            }

            if (AppIndVM.HaveEmploymentHistory == true)
            {
                if (empvmlist == null)
                {
                    ModelState.AddModelError("empvmlist", " * Atleast one Employment history is required");
                }
                else if (empvmlist.Count == 0)
                {
                    ModelState.AddModelError("empvmlist", " * Atleast one Employment history is required");
                }
            }

            var idDocsPath = Path.Combine(_env.ContentRootPath + _configuration["StoredFilesPath"], "tmp", AppIndVM.FirstName + " " + AppIndVM.LastName, "IDDocs");

            if (Directory.Exists(idDocsPath) && Directory.GetFiles(idDocsPath).Count() > 0)
            {
            }
            else if (IDDocuments == null || IDDocuments.Count == 0)
            {
                ModelState.AddModelError("IDDocuments", " * Please upload ID documents");
            }

            var proofofPayPath = Path.Combine(_env.ContentRootPath + _configuration["StoredFilesPath"], "tmp", AppIndVM.FirstName + " " + AppIndVM.LastName, "ProofOfPay");

            if (Directory.Exists(proofofPayPath) && Directory.GetFiles(proofofPayPath).Count() > 0)
            {
            }
            else if (AppIndVM.OccupationId != null && AppIndVM.OccupationId != 3 && ProofOfPayment == null || ProofOfPayment.Count == 0)
            {
                ModelState.AddModelError("ProofOfPayment", " * Proof of Payment is Required");
            }

            if (qvmlist != null & qvmlist.Count > 0)
            {
                for (int j = 0; j < qvmlist.Count; j++)
                {
                    if (ModelState.ContainsKey("qvmlist[" + j + "].categoryid"))
                    {
                        ModelState["qvmlist[" + j + "].categoryid"].Errors.Clear();
                        ModelState["qvmlist[" + j + "].categoryid"].ValidationState = ModelValidationState.Valid;
                    }
                    if (ModelState.ContainsKey("qvmlist[" + j + "].qualificationtype"))
                    {
                        ModelState["qvmlist[" + j + "].qualificationtype"].Errors.Clear();
                        ModelState["qvmlist[" + j + "].qualificationtype"].ValidationState = ModelValidationState.Valid;
                    }
                    if (ModelState.ContainsKey("qvmlist[" + j + "].enrolmentcategoryid"))
                    {
                        ModelState["qvmlist[" + j + "].enrolmentcategoryid"].Errors.Clear();
                        ModelState["qvmlist[" + j + "].enrolmentcategoryid"].ValidationState = ModelValidationState.Valid;
                    }
                }
            }

            if (RequestType == 3)
            {

                ModelState.Clear();

                if (string.IsNullOrEmpty(AppIndVM.Email))
                {
                   
                        ModelState.AddModelError("AppIndVM.Email", "Email is required");
                }
                if (AppIndVM.GenderId==null)
                {

                    ModelState.AddModelError("AppIndVM.GenderId", "Gender is required");
                }

                if (AppIndVM.TitleId == null)
                {

                    ModelState.AddModelError("AppIndVM.TitleId", "Title is required");
                }

                if (string.IsNullOrEmpty(AppIndVM.FirstName))
                {

                    ModelState.AddModelError("AppIndVM.FirstName", "First Name is required");
                }

                if (string.IsNullOrEmpty(AppIndVM.LastName))
                {

                    ModelState.AddModelError("AppIndVM.LastName", "Last Name is required");
                }

                if (string.IsNullOrEmpty(AppIndVM.BusinessPhoneNumber))
                {

                    ModelState.AddModelError("AppIndVM.BusinessPhoneNumber", "Business Phone Number is required");
                }

                if (string.IsNullOrEmpty(AppIndVM.MobilePhone))
                {

                    ModelState.AddModelError("AppIndVM.MobilePhone", "Mobile Phone Numeber is required");

                }
                if (string.IsNullOrEmpty(AppIndVM.IDNumber))
                {

                    ModelState.AddModelError("AppIndVM.IDNumber", "ID / Passport Number is required");
                }

                if (string.IsNullOrEmpty(AppIndVM.JobTitle))
                {

                    ModelState.AddModelError("AppIndVM.JobTitle", "Job Title is required");
                }


                if (string.IsNullOrEmpty(AppIndVM.Password))
                {
                    ModelState.AddModelError("AppIndVM.Password", "Password must be minimum 8 characters");
                }
             
            }

            if (!string.IsNullOrEmpty(AppIndVM.Email))
            {
                AppUser = _userManager.FindByEmailAsync(AppIndVM.Email).Result;

                if (AppUser != null)
                {
                    ModelState.AddModelError("AppIndVM.Email", "User with this email already exists. Please use another email");
                }
            }


            if (AppIndVM.Email != AppIndVM.ConfirmEmail)
            {
                ModelState.AddModelError("AppIndVM.ConfirmEmail", "Email and Confirm Email do not match");
            }

            if (AppIndVM.Password != null && AppIndVM.Password.Length < 8)
            {
                ModelState.AddModelError("AppIndVM.Password", "Password must be minimum 8 characters");
            }

            if (AppIndVM.Password != AppIndVM.ConfirmPassword)
            {
                ModelState.AddModelError("AppIndVM.ConfirmPassword", "Password and Confirm Password do not match");

            }

            if (ModelState.IsValid)
            {
                AppUser = await CreateApplicationUser();

                if (AppUser == null)
                {
                    SetViewData();
                    return Page();
                }

                var result = await _userManager.CreateAsync(AppUser, AppIndVM.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("Application User Created");
                    await _userManager.AddToRoleAsync(AppUser, MMRoles.ContactRole);
                    await _userManager.AddToRoleAsync(AppUser, MMRoles.MemberRole);
                    _logger.LogInformation("Roles Added");
                }

                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                        _logger.LogInformation(error.Description);
                        notification = new Notification { message = "Error while creating User.Please fix and retry. Please remember to re-upload files", notificationtype = NotificationTypeValues.danger };
                    }
                    SetViewData();
                    return Page();
                }

                MemberUser = await CreateMemberUser(AppUser.Id);

                _logger.LogInformation("MemberUser Created");

                if (MemberUser == null)
                {
                    SetViewData();
                    return Page();
                }


                var code = await _userManager.GenerateEmailConfirmationTokenAsync(AppUser);
                code = HttpUtility.UrlEncode(code);

                string callbackUrl = Url.Page("/Account/ConfirmEmail", pageHandler: null, values: new { userId = AppUser.Id, code = code, returnUrl = returnUrl }, protocol: Request.Scheme);

                _logger.LogInformation("callbackUrl Created");
                string emailaddresses = EmailRecipients.GetEmailSenderList("ConfirmEmail", null, MemberUser.Email, (int)RelatedToEnum.Member, MemberUser.Id);
                await _emailCreator.SendEmailAsync("ConfirmEmail", emailaddresses, AppUser.FullName, "WISA: Confirm your email", "Confirm Email", callbackUrl);


                _logger.LogInformation("Email confirmation mail sent");

                if (MemberUser.MembershipTypeId == (int?)MembershipTypeEnum.ProfessionalProcessController)
                {
                    emailaddresses = EmailRecipients.GetEmailSenderList("NewMember", "pro", MemberUser.Email, (int)RelatedToEnum.Member, MemberUser.Id);
                    await _emailCreator.SendEmailAsync("NewMember", emailaddresses, "Talent", "WISA: New Member Joined", "New Member",
                    Url.Page("/Manage/Individual", pageHandler: null, values: new { id = MemberUser.Id }, protocol: Request.Scheme));
                }
                else if (MemberUser.MembershipTypeId == (int?)MembershipTypeEnum.IndividualMember)
                {
                    if(MemberUser.OccupationId!=null && MemberUser.OccupationId==3) //FULL IME STUDENT
                    {
                        emailaddresses = EmailRecipients.GetEmailSenderList("NewMember", "student", MemberUser.Email, (int)RelatedToEnum.Member, MemberUser.Id);
                        await _emailCreator.SendEmailAsync("NewMember", emailaddresses, "Talent", "WISA: New Member Joined", "New Member",
                             Url.Page("/Manage/Individual", pageHandler: null, values: new { id = MemberUser.Id }, protocol: Request.Scheme));
                    }
                    else
                    { 
                    emailaddresses = EmailRecipients.GetEmailSenderList("NewMember", "ind", MemberUser.Email, (int)RelatedToEnum.Member, MemberUser.Id);
                    await _emailCreator.SendEmailAsync("NewMember", emailaddresses, "Evelyn", "WISA: New Member Joined", "New Member",
                    Url.Page("/Manage/Individual", pageHandler: null, values: new { id = MemberUser.Id }, protocol: Request.Scheme));
                    }
                }

                    

                _logger.LogInformation("New Member Email sent");

                var user = await _userManager.GetUserAsync(User);

                if (user != null)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    if (roles.Contains(MMRoles.SuperUserRole) || roles.Contains(MMRoles.AdminFullAccessRole) || roles.Contains(MMRoles.ClientUserRole))
                    {
                        return LocalRedirect("/Manage/Individual?Id=" + MemberUser.Id.ToString());
                    }
                }

                _logger.LogInformation("New Member Email sent");

                if (_userManager.Options.SignIn.RequireConfirmedAccount)
                {
                    _logger.LogInformation("Trying to redirect to /Account/RegisterConfirmation");
                    return RedirectToPage("/Account/RegisterConfirmation", new { email = AppUser.Email, returnUrl = returnUrl });
                }
                else
                {
                    if (RequestType != 3)
                    {
                        await _signInManager.SignInAsync(AppUser, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                    SetViewData();

                    _logger.LogInformation(" redirecting to /Manage/NonIndividualMember");
                    return LocalRedirect("/Manage/NonIndividualMember?Id=" + OrgId);
                }
            }
            else
            {

                notification = new Notification { message = "Please fill all mandatory fields. Kindly go through each tab and check errors.Please remember to re-upload files", notificationtype = NotificationTypeValues.danger };

                foreach (var modelStateKey in ViewData.ModelState.Keys)
                {
                    var value = ViewData.ModelState[modelStateKey];

                    foreach (var error in value.Errors)
                    {
                        _logger.LogInformation("Key=" + modelStateKey + ", Error= " + error.ErrorMessage);
                    }
                }

                SetViewData();
              
            }
            return Page();
        }

        //public async Task UploadFilesTemploarily(List<IFormFile> files, int? filetype, string folder, string MemberName)
        //{
        //    foreach (var formFile in files)
        //    {

        //        if (formFile.Length > 0)
        //        {
        //            string file = string.Empty;
        //            if (formFile.FileName.Length > 150)
        //            {
        //                file = formFile.FileName.Substring(formFile.FileName.Length - (formFile.FileName.Length - 150));
        //            }
        //            else
        //            {
        //                file = formFile.FileName;
        //            }

        //            var filePath = Path.Combine(_env.ContentRootPath + _configuration["StoredFilesPath"], "tmp", MemberName, folder);
        //            if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);
        //            filePath = Path.Combine(filePath, file);
        //            if (System.IO.File.Exists(filePath)) System.IO.File.Delete(filePath);

        //            using (var stream = new FileStream(filePath, FileMode.Create))
        //            {
        //                await formFile.CopyToAsync(stream);
        //            }
        //        }
        //    }
        //    await _clientDbContext.SaveChangesAsync();
        //}

        public async Task UploadFiles(List<IFormFile> files, int? filetype, string folder, string memberUserCode, string MemberName, int memberUserId)
        {
            foreach (var formFile in files)
            {

                if (formFile.Length > 0)
                {
                    string file = string.Empty;
                    if (formFile.FileName.Length > 150)
                    {
                        file = formFile.FileName.Substring(formFile.FileName.Length - (formFile.FileName.Length - 150));
                    }
                    else
                    {
                        file = formFile.FileName;
                    }

                    int parentfolder = 0;
                    parentfolder = Convert.ToInt32(memberUserCode) / 1000;

                    string subfolder = memberUserCode + "_" + Regex.Replace(MemberName, "[^A-Za-z0-9]", "");
                    if (subfolder.Length > 15)
                    {
                        subfolder = subfolder.Substring(0, 15);
                    }

                    var filePath = Path.Combine(_env.ContentRootPath + _configuration["StoredFilesPath"], "Ind", parentfolder.ToString(), subfolder, folder);
                    if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);
                    filePath = Path.Combine(filePath, file);
                    if (System.IO.File.Exists(filePath)) System.IO.File.Delete(filePath);
                    var filepathToStore = Path.Combine("Ind", parentfolder.ToString(), subfolder, folder, file);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                        MemberFileXref filexref = new MemberFileXref();
                        filexref.RelatedEntityId = memberUserId;
                        filexref.RelatedToId = (int)RelatedToEnum.Member;
                        filexref.FilePath = filepathToStore;
                        filexref.FileName = file;
                        filexref.CreatedOn = DateTime.Now;
                        filexref.ModifiedOn = DateTime.Now;
                        filexref.FileTypeId = filetype;
                        await _clientDbContext.MemberFileXref.AddAsync(filexref);
                    }
                }
            }

            await _clientDbContext.SaveChangesAsync();
        }


        //public async Task UploadFilesNew(string SourceFolder, int? filetype, string folder, string memberUserCode, string MemberName, int memberUserId)
        //{
        //    int parentfolder = 0;
        //    parentfolder = Convert.ToInt32(memberUserCode) / 1000;
        //    string subfolder = memberUserCode + "_" + Regex.Replace(MemberName, "[^A-Za-z0-9]", "");
        //    if (subfolder.Length > 15)
        //    {
        //        subfolder = subfolder.Substring(0, 15);
        //    }
        //    var filePath = Path.Combine(_env.ContentRootPath + _configuration["StoredFilesPath"], "Ind", parentfolder.ToString(), subfolder, folder);
        //    var foldertocreate = Path.Combine(_env.ContentRootPath + _configuration["StoredFilesPath"], "Ind", parentfolder.ToString(), subfolder);
        //    if (!Directory.Exists(foldertocreate)) Directory.CreateDirectory(foldertocreate);

        //    Directory.Move(SourceFolder, filePath);

        //    var files = Directory.GetFiles(filePath);

        //    foreach (string file in files)
        //    {
        //        var filename = file.Substring(file.LastIndexOf("\\"));
        //        var filepathToStore = Path.Combine("Ind", parentfolder.ToString(), subfolder, folder, filename);
        //        MemberFileXref filexref = new MemberFileXref();
        //        filexref.RelatedEntityId = memberUserId;
        //        filexref.RelatedToId = (int)RelatedToEnum.Member;
        //        filexref.FilePath = filepathToStore;
        //        filexref.FileName = filename;
        //        filexref.CreatedOn = DateTime.Now;
        //        filexref.ModifiedOn = DateTime.Now;
        //        filexref.FileTypeId = filetype;
        //        await _clientDbContext.MemberFileXref.AddAsync(filexref);

        //    }

        //    await _clientDbContext.SaveChangesAsync();
        //}
    }
}
