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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using WISA.Services;

namespace MM.Pages.Member
{
    [Authorize(Policy = MMPolicies.AllowMemberAccess)]
    public class ProfileModel : PageModel
    {
        #region Constructor

        private readonly ClientDbContext _clientDbContext;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<ProfileModel> _logger;
        private readonly IEmailCreator _emailCreator;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public ProfileModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            ILogger<ProfileModel> logger, IEmailCreator emailCreator, ClientDbContext clientDbContext, IConfiguration configuration, IWebHostEnvironment env)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailCreator = emailCreator;
            _clientDbContext = clientDbContext;
            _configuration = configuration;
            _env = env;
        }
        #endregion

        #region Bindings

        [BindProperty]
        public ApplicationIndividualVM ApplicationIndividualVM { get; set; }

        [BindProperty]
        public List<qualificationvm> qvmlist { get; set; }

  

        [BindProperty]
        public List<employmentvm> empvmlist { get; set; }


        [BindProperty]
        public Notification notification { get; set; }

        [BindProperty]
        public List<refereevm> refvmlist { get; set; }

        [BindProperty]
        public List<MemberRefereeXref> MemberRefereeList { get; set; }

        [BindProperty]
        public List<IFormFile> IDDocuments { get; set; }

        [BindProperty]
        public List<IFormFile> Certificates { get; set; }

    

        [BindProperty]
        public List<IFormFile> ProofOfReg { get; set; }

        [BindProperty]
        public List<IFormFile> ProofOfPayment { get; set; }

        [BindProperty]
        public List<IFormFile> ProofOfStudentLetter { get; set; }

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

        public async Task GetAllDivisionsAsync(int? memberid)
        {
            var selectedMemberDivisionList = await _clientDbContext.DivisionMemberXref.Where(x => x.MemberId == memberid).ToListAsync();

            MemberDivisionList = new List<MemberDivision>();
            var allDivisions = _clientDbContext.Division.ToList();
            foreach (var Division in allDivisions)
            {
                var found = false;
                foreach (var selectedDivision in selectedMemberDivisionList)
                {
                    if (Division.Id == selectedDivision.DivisonId)
                    {
                        MemberDivisionList.Add(new MemberDivision { IsSelected = true, Id = Division.Id, Name = Division.Name });
                        found = true;
                    }
                }
                if (found == false)
                {
                    MemberDivisionList.Add(new MemberDivision { IsSelected = false, Id = Division.Id, Name = Division.Name });
                }

            }

        }

        #endregion

        #region Member Affliation List


        public class MemberAffliation
        {
            public bool IsSelected { get; set; }
            public int? Id { get; set; }
            public string Name { get; set; }
            public string MemberSpecificAffliationName { get; set; }
            public string MemberNumber { get; set; }
        }

        [BindProperty]
        public List<MemberAffliation> MemberAffliationList { get; set; }

        public async Task GetAllAffliationsAsync(int? memberid)
        {
            var selectedMemberAffliationList = await _clientDbContext.MemberAffliationXref.Where(x => x.MemberId == memberid).ToListAsync();
            MemberAffliationList = new List<MemberAffliation>();
            var allAffliations = _clientDbContext.Affliation.ToList();
            foreach (var Affliation in allAffliations)

            {
                var found = false;
                foreach (var selectedAffliation in selectedMemberAffliationList)
                {
                    if (Affliation.Id == selectedAffliation.AffliationId)
                    {
                        MemberAffliationList.Add(new MemberAffliation { IsSelected = true, Id = Affliation.Id, Name = Affliation.Name, MemberSpecificAffliationName = selectedAffliation.MemberSpecificAffliationName, MemberNumber = selectedAffliation.MemberNumber });
                        found = true;
                    }
                }
                if (found == false)
                {
                    MemberAffliationList.Add(new MemberAffliation { IsSelected = false, Id = Affliation.Id, Name = Affliation.Name, MemberSpecificAffliationName = string.Empty, MemberNumber = string.Empty });
                }

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


        public async Task GetAllDisabilitiesAsync(int? memberid)
        {
            var selectedMemberDisabilityList = await _clientDbContext.DisabilityMemberXref.Where(x => x.MemberId == memberid).ToListAsync();
            MemberDisabilityList = new List<MemberDisability>();
            var allDisabilities = _clientDbContext.Disability.ToList();
            foreach (var Disability in allDisabilities)

            {
                var found = false;
                foreach (var selectedDisability in selectedMemberDisabilityList)
                {
                    if (Disability.Id == selectedDisability.DisabilityId)
                    {
                        MemberDisabilityList.Add(new MemberDisability { IsSelected = true, Id = Disability.Id, Name = Disability.Name, DisabilityLevelId = selectedDisability.DisabilityLevelId });
                        found = true;
                    }
                }
                if (found == false)
                {
                    MemberDisabilityList.Add(new MemberDisability { IsSelected = false, Id = Disability.Id, Name = Disability.Name, DisabilityLevelId = 0 });
                }

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

        public async Task GetAllInvolvementsAsync(int? memberid)
        {
            var selectedMemberInvolvementList = await _clientDbContext.InvolvementMemberXref.Where(x => x.MemberId == memberid).ToListAsync();
            MemberInvolvementList = new List<MemberInvolvement>();
            var allInvolvements = _clientDbContext.Involvement.ToList();
            foreach (var Involvement in allInvolvements)
            {
                var found = false;
                foreach (var selectedInvolvement in selectedMemberInvolvementList)
                {
                    if (Involvement.Id == selectedInvolvement.InvolvementId)
                    {
                        MemberInvolvementList.Add(new MemberInvolvement { IsSelected = true, Id = Involvement.Id, Name = Involvement.Name });
                        found = true;
                    }
                }
                if (found == false)
                {
                    MemberInvolvementList.Add(new MemberInvolvement { IsSelected = false, Id = Involvement.Id, Name = Involvement.Name });
                }
            }

        }

        #endregion

        [BindProperty]
        public List<MemberQualificationXref> MemberQualificationList { get; set; }

        [BindProperty]
        public List<EmploymentMemberXref> MemberEmploymentList { get; set; }

  


        [BindProperty]
        public List<MemberFileXref> MemberFileList { get; set; }

        [BindProperty]
        public Address PhysicalAddress { get; set; }

        [BindProperty]
        public Address PostalAddress { get; set; }

        public void SetApplicationIndividual(MemberUser memberUser)
        {
            ApplicationIndividualVM = new ApplicationIndividualVM();
            ApplicationIndividualVM.Id = memberUser.Id;
            ApplicationIndividualVM.ApplicationUserId = memberUser.ApplicaitonUserId;
            ApplicationIndividualVM.TitleId = memberUser.ApplicationUser.TitleId;
            ApplicationIndividualVM.Initials = memberUser.Initials;
            ApplicationIndividualVM.FirstName = memberUser.ApplicationUser.FirstName;
            ApplicationIndividualVM.LastName = memberUser.ApplicationUser.LastName;
            ApplicationIndividualVM.BirthDay = memberUser.ApplicationUser.BirthDay;
            ApplicationIndividualVM.IDNumber = memberUser.IDNumber;
            ApplicationIndividualVM.CountryId = memberUser.CountryId;
            ApplicationIndividualVM.HomeLanguageId = memberUser.HomeLanguageId;
            ApplicationIndividualVM.GenderId = memberUser.ApplicationUser.GenderId;
            ApplicationIndividualVM.EthnicityId = memberUser.EthnicityId;
            ApplicationIndividualVM.OccupationId = memberUser.OccupationId;
            ApplicationIndividualVM.HighestQualificationId = memberUser.HighestQualitificationId;
            ApplicationIndividualVM.CompanyName = memberUser.CompanyName;
            ApplicationIndividualVM.JobTitle = memberUser.JobTitle;
            ApplicationIndividualVM.HomePhoneNumber = memberUser.HomePhoneNumber;
            ApplicationIndividualVM.BusinessPhoneNumber = memberUser.BusinessPhoneNumber;
            ApplicationIndividualVM.FAXNumber = memberUser.FAXNumber;
            ApplicationIndividualVM.FaxToEmail = memberUser.FaxToEmail;
            ApplicationIndividualVM.MobilePhone = memberUser.MobilePhone;
            ApplicationIndividualVM.Email = memberUser.Email;
            ApplicationIndividualVM.SecondaryEmail = memberUser.SecondaryEmail;

            ApplicationIndividualVM.PublishCompanyInAnnualMemberDirectory = memberUser.PublishCompanyInAnnualMemberDirectory;
            ApplicationIndividualVM.InterestedInVolunteerWork = memberUser.InterestedInVolunteerWork;
            ApplicationIndividualVM.VolunteerWorkHoursId = memberUser.VolunteerWorkHoursId;
            ApplicationIndividualVM.ReferralTypeId = memberUser.ReferralTypeId;
            ApplicationIndividualVM.ReferralOther = memberUser.ReferralOther;
            ApplicationIndividualVM.TermAccepted = (bool)memberUser.TermAccepted;
            ApplicationIndividualVM.DoNotSMS = memberUser.DoNotSMS;
            ApplicationIndividualVM.DoNotEmail = memberUser.DoNotEmail;
            ApplicationIndividualVM.DonotFax = memberUser.DonotFax;
            ApplicationIndividualVM.DonotBulkPostalMail = memberUser.DonotBulkPostalMail;
            ApplicationIndividualVM.DonotpostalMail = memberUser.DonotpostalMail;
            ApplicationIndividualVM.DonotBulkEmail = memberUser.DonotBulkEmail;
            ApplicationIndividualVM.DonotSendMassMarketing = memberUser.DonotSendMassMarketing;
            ApplicationIndividualVM.DonotPhone = memberUser.DonotPhone;
            ApplicationIndividualVM.MemberCode = memberUser.MemberCode;
            ApplicationIndividualVM.MembershipTypeId = memberUser.MembershipGradeId;
            ApplicationIndividualVM.MembershipTypeName = memberUser.MembershipGrade == null ? null : memberUser.MembershipGrade.Name;
            ApplicationIndividualVM.MembershipGradeId = memberUser.MembershipTypeId;
            ApplicationIndividualVM.MembershipGradeName = memberUser.MembershipType == null ? null : memberUser.MembershipType.Name;
            ApplicationIndividualVM.ClientBranchId = memberUser.MemberBranchId;
            ApplicationIndividualVM.Notes = memberUser.Notes;



            if (PhysicalAddress != null)
            {
                ApplicationIndividualVM.PhysicalAddressLine1 = PhysicalAddress.AddressLine1;
                ApplicationIndividualVM.PhysicalAddressLine2 = PhysicalAddress.AddressLine2;
                ApplicationIndividualVM.PhysicalSuburb = PhysicalAddress.Suburb;
                ApplicationIndividualVM.PhysicalCity = PhysicalAddress.CityName;
                ApplicationIndividualVM.PhysicalProvince = PhysicalAddress.Province;
                ApplicationIndividualVM.PhysicalStateId = PhysicalAddress.StateId;
                ApplicationIndividualVM.PhysicalCountryId = PhysicalAddress.CountryId;
                ApplicationIndividualVM.PhysicalPostalCode = PhysicalAddress.PostalCode;
            }
            if (PostalAddress != null)
            {
                ApplicationIndividualVM.PostalAddressLine1 = PostalAddress.AddressLine1;
                ApplicationIndividualVM.PostalAddressLine2 = PostalAddress.AddressLine2;
                ApplicationIndividualVM.PostalSuburb = PostalAddress.Suburb;
                ApplicationIndividualVM.PostalCity = PostalAddress.CityName;
                ApplicationIndividualVM.PostalProvince = PostalAddress.Province;
                ApplicationIndividualVM.PostalStateId = PostalAddress.StateId;
                ApplicationIndividualVM.PostalCountryId = PostalAddress.CountryId;
                ApplicationIndividualVM.PostalPostalCode = PostalAddress.PostalCode;
            }

        }

        public async Task<IActionResult> OnGetAsync()
        {

            await SetViewData();
            return Page();
        }

        //public async Task UploadFilesOld(List<IFormFile> files, int? filetype, string folder, int memberUserId, string MemberCode,string membername)
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


        //            int parentfolder = 0;
        //            parentfolder = Convert.ToInt32(MemberCode) / 1000;

        //            string subfolder = MemberCode + "_" + Regex.Replace(membername, "[^A-Za-z0-9]", "");
        //            if (subfolder.Length > 15)
        //            {
        //                subfolder = subfolder.Substring(0, 15);
        //            }
        //            var filePath = Path.Combine(_env.ContentRootPath + _configuration["StoredFilesPath"], "Ind", parentfolder.ToString(), subfolder, folder);
        //            if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);
        //            filePath = Path.Combine(filePath, file);
        //            if (System.IO.File.Exists(filePath)) System.IO.File.Delete(filePath);
        //            var filepathToStore = Path.Combine("Ind", parentfolder.ToString(), subfolder, folder, file);


        //            using (var stream = new FileStream(filePath, FileMode.Create))
        //            {
        //                await formFile.CopyToAsync(stream);
        //                MemberFileXref filexref = new MemberFileXref();
        //                filexref.RelatedEntityId = memberUserId;
        //                filexref.RelatedToId = (int)RelatedToEnum.Member;
        //                filexref.FileName = file;
        //                filexref.FilePath = filePath;
        //                filexref.CreatedOn = DateTime.Now;
        //                filexref.ModifiedOn = DateTime.Now;
        //                filexref.FileTypeId = filetype;
        //                await _clientDbContext.MemberFileXref.AddAsync(filexref);
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

        public async Task SetViewData()
        {
            MemberUser memberUser = new MemberUser();
            var user = await _userManager.GetUserAsync(User);

            if (user != null)
            {
                memberUser = await _clientDbContext.MemberUser.Where(m => m.ApplicaitonUserId == user.Id)
                    .Include(m => m.ApplicationUser)
                    .Include(m => m.ApplicationUser.Gender)
                    .Include(m => m.ApplicationUser.Title)
                    .Include(m => m.ClientBranch)
                    .Include(m => m.Ethnicity)
                    .Include(m => m.HighestQualitification)
                    .Include(m => m.HomeLanguage)
                    .Include(m => m.MemberBranch)
                    .Include(m => m.MembershipType)
                    .Include(m => m.MemberLevel)
                    .Include(m => m.MemberStatus)
                    .Include(m => m.MemberTeam)
                    .Include(m => m.MembershipGrade)
                    .Include(m => m.Country)
                    .Include(m => m.Occupation)
                    .Include(m => m.Organization)
                    .Include(m => m.OrganizationStructure)
                    .Include(m => m.OwnerClientUser)
                    .Include(m => m.PreferredAppointmentTime)
                    .Include(m => m.ReferralType)
                    .Include(m => m.TransactionCurrency)
                    .Include(m => m.VolunteerWorkHours).FirstOrDefaultAsync();
                    

                if (memberUser == null)
                {
                   
                }
                MemberRefereeList = await _clientDbContext.MemberRefereeXref.Where(x => x.RelatedEntityId == memberUser.Id).ToListAsync();
                MemberQualificationList = await _clientDbContext.MemberQualificationXref.Include(m => m.QualificationType).Where(x => x.MemberId == memberUser.Id).ToListAsync();
                MemberEmploymentList = await _clientDbContext.EmploymentMemberXref.Include(m => m.EmploymentCategory).Where(x => x.MemberUserId == memberUser.Id).ToListAsync();
                MemberFileList = await _clientDbContext.MemberFileXref.Include(m => m.FileType).Where(x => x.RelatedEntityId == memberUser.Id && x.RelatedToId == (int)RelatedToEnum.Member).ToListAsync();
                PhysicalAddress = _clientDbContext.Address.Where(x => x.RelatedEntityId == memberUser.Id && x.RelatedToId == (int)RelatedToEnum.Member && x.AddressTypeId == 2).FirstOrDefault();
                PostalAddress = _clientDbContext.Address.Where(x => x.RelatedEntityId == memberUser.Id && x.RelatedToId == (int)RelatedToEnum.Member && x.AddressTypeId == 1).FirstOrDefault();

                SetApplicationIndividual(memberUser);
                await GetAllDivisionsAsync(memberUser.Id);
                await GetAllAffliationsAsync(memberUser.Id);
                await GetAllDisabilitiesAsync(memberUser.Id);
                await GetAllInvolvementsAsync(memberUser.Id);
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
            ViewData["Provinces"] = new SelectList(_clientDbContext.State.ToList(), nameof(State.Id), nameof(State.Name));
            ViewData["Countries"] = new SelectList(_clientDbContext.Country.ToList(), nameof(Country.Id), nameof(Country.Description));
            ViewData["DisabilityLevels"] = new SelectList(_clientDbContext.DisabilityLevel.ToList(), nameof(DisabilityLevel.Id), nameof(DisabilityLevel.Name));
            ViewData["MemberBranchId"] = new SelectList(_clientDbContext.MemberBranch.ToList(), nameof(MemberBranch.Id), nameof(MemberBranch.Name));
            ViewData["VolunteerWorkHrs"] = new SelectList(_clientDbContext.VolunteerHours.ToList(), nameof(VolunteerHours.Id), nameof(VolunteerHours.Name));
            ViewData["Referrals"] = new SelectList(_clientDbContext.ReferralType.ToList(), nameof(ReferralType.Id), nameof(ReferralType.Name));
            ViewData["FileTypes"] = new SelectList(_clientDbContext.FileType.ToList(), nameof(FileType.Id), nameof(FileType.Name));
            ViewData["MembershipTypeId"] = new SelectList(_clientDbContext.MembershipType.Where(x => x.Id >= 5).ToList(), nameof(MembershipType.Id), nameof(MembershipType.Name));
            ViewData["YesNoList"] = new SelectList(new YesNoLookup().YesNoList(), nameof(YesNoLookup.Id), nameof(YesNoLookup.Name));
        }

        public async Task<MemberUser> UpdateMemberUser(string appUserId)
        {
            MemberUser MemberUser = await _clientDbContext.MemberUser.FirstOrDefaultAsync(m => m.ApplicaitonUserId == appUserId);

            MemberUser.Initials = ApplicationIndividualVM.Initials;
            MemberUser.IDNumber = ApplicationIndividualVM.IDNumber;
            MemberUser.HomeLanguageId = ApplicationIndividualVM.HomeLanguageId;
            MemberUser.EthnicityId = ApplicationIndividualVM.EthnicityId;
            MemberUser.OccupationId = ApplicationIndividualVM.OccupationId;
            MemberUser.HighestQualitificationId = ApplicationIndividualVM.HighestQualificationId;
            MemberUser.CompanyName = ApplicationIndividualVM.CompanyName;
            MemberUser.JobTitle = ApplicationIndividualVM.JobTitle;
            MemberUser.CountryId = ApplicationIndividualVM.CountryId;
            MemberUser.HomePhoneNumber = ApplicationIndividualVM.HomePhoneNumber;
            MemberUser.BusinessPhoneNumber = ApplicationIndividualVM.BusinessPhoneNumber;
            MemberUser.FAXNumber = ApplicationIndividualVM.FAXNumber;
            MemberUser.FaxToEmail = ApplicationIndividualVM.FaxToEmail;
            MemberUser.MobilePhone = ApplicationIndividualVM.MobilePhone;
            MemberUser.SecondaryEmail = ApplicationIndividualVM.SecondaryEmail;
            MemberUser.ReferralTypeId = ApplicationIndividualVM.ReferralTypeId;
            MemberUser.ReferralOther = ApplicationIndividualVM.ReferralOther;
            MemberUser.MemberBranchId = ApplicationIndividualVM.ClientBranchId;
            MemberUser.InterestedInVolunteerWork = ApplicationIndividualVM.InterestedInVolunteerWork;
            MemberUser.PublishCompanyInAnnualMemberDirectory = ApplicationIndividualVM.PublishCompanyInAnnualMemberDirectory;
            MemberUser.DonotFax = ApplicationIndividualVM.DonotFax;
            MemberUser.DoNotSMS = ApplicationIndividualVM.DoNotSMS;
            MemberUser.DoNotEmail = ApplicationIndividualVM.DoNotEmail;
            MemberUser.DonotBulkPostalMail = ApplicationIndividualVM.DonotBulkPostalMail;
            MemberUser.DonotBulkEmail = ApplicationIndividualVM.DonotBulkEmail;
            MemberUser.DonotSendMassMarketing = ApplicationIndividualVM.DonotSendMassMarketing;
            MemberUser.DonotpostalMail = ApplicationIndividualVM.DonotpostalMail;
            MemberUser.DonotPhone = ApplicationIndividualVM.DonotPhone;
            MemberUser.ModifiedOn = DateTime.Now;
            MemberUser.VolunteerWorkHoursId = ApplicationIndividualVM.VolunteerWorkHoursId;
            MemberUser.TermAccepted = ApplicationIndividualVM.TermAccepted;

            _clientDbContext.MemberUser.Update(MemberUser);
            await _clientDbContext.SaveChangesAsync();


            PhysicalAddress = _clientDbContext.Address.Where(x => x.RelatedEntityId == MemberUser.Id && x.RelatedToId == (int)RelatedToEnum.Member && x.AddressTypeId == 2).FirstOrDefault();
            PostalAddress = _clientDbContext.Address.Where(x => x.RelatedEntityId == MemberUser.Id && x.RelatedToId == (int)RelatedToEnum.Member && x.AddressTypeId == 1).FirstOrDefault();


            if (PhysicalAddress == null)
            {
                PhysicalAddress = new Address();
                PhysicalAddress.RelatedEntityId = MemberUser.Id;
                PhysicalAddress.RelatedToId = (int)RelatedToEnum.Member;
                PhysicalAddress.AddressTypeId = (int)AddressTypeEnum.Physical;
                PhysicalAddress.AddressLine1 = ApplicationIndividualVM.PhysicalAddressLine1;
                PhysicalAddress.AddressLine2 = ApplicationIndividualVM.PhysicalAddressLine2;
                PhysicalAddress.Suburb = ApplicationIndividualVM.PhysicalSuburb;
                PhysicalAddress.Province = ApplicationIndividualVM.PhysicalProvince;
                PhysicalAddress.PostalCode = ApplicationIndividualVM.PhysicalPostalCode;
                PhysicalAddress.StateId = ApplicationIndividualVM.PhysicalStateId;
                PhysicalAddress.CountryId = ApplicationIndividualVM.PhysicalCountryId;
                await _clientDbContext.Address.AddAsync(PhysicalAddress);
            }
            else
            {
                PhysicalAddress.RelatedEntityId = MemberUser.Id;
                PhysicalAddress.RelatedToId = (int)RelatedToEnum.Member;
                PhysicalAddress.AddressTypeId = (int)AddressTypeEnum.Physical;
                PhysicalAddress.AddressLine1 = ApplicationIndividualVM.PhysicalAddressLine1;
                PhysicalAddress.AddressLine2 = ApplicationIndividualVM.PhysicalAddressLine2;
                PhysicalAddress.Suburb = ApplicationIndividualVM.PhysicalSuburb;
                PhysicalAddress.Province = ApplicationIndividualVM.PhysicalProvince;
                PhysicalAddress.PostalCode = ApplicationIndividualVM.PhysicalPostalCode;
                PhysicalAddress.CityName = ApplicationIndividualVM.PhysicalCity;
                PhysicalAddress.StateId = ApplicationIndividualVM.PhysicalStateId;
                PhysicalAddress.CountryId = ApplicationIndividualVM.PhysicalCountryId;
                _clientDbContext.Address.Update(PhysicalAddress);
            }

            if (PostalAddress == null)
            {
                PostalAddress = new Address();
                PostalAddress.RelatedEntityId = MemberUser.Id;
                PostalAddress.RelatedToId = (int)RelatedToEnum.Member;
                PostalAddress.AddressTypeId = (int)AddressTypeEnum.Postal;
                PostalAddress.AddressLine1 = ApplicationIndividualVM.PostalAddressLine1;
                PostalAddress.AddressLine2 = ApplicationIndividualVM.PostalAddressLine2;
                PostalAddress.Suburb = ApplicationIndividualVM.PostalSuburb;
                PostalAddress.Province = ApplicationIndividualVM.PostalProvince;
                PostalAddress.StateId = ApplicationIndividualVM.PostalStateId;
                PostalAddress.PostalCode = ApplicationIndividualVM.PostalPostalCode;
                PostalAddress.CityName = ApplicationIndividualVM.PostalCity;
                PostalAddress.CountryId = ApplicationIndividualVM.PostalCountryId;
                await _clientDbContext.Address.AddAsync(PostalAddress);
            }
            else
            {
                PostalAddress.RelatedEntityId = MemberUser.Id;
                PostalAddress.RelatedToId = (int)RelatedToEnum.Member;
                PostalAddress.AddressTypeId = (int)AddressTypeEnum.Postal;
                PostalAddress.AddressLine1 = ApplicationIndividualVM.PostalAddressLine1;
                PostalAddress.AddressLine2 = ApplicationIndividualVM.PostalAddressLine2;
                PostalAddress.Suburb = ApplicationIndividualVM.PostalSuburb;
                PostalAddress.Province = ApplicationIndividualVM.PostalProvince;
                PostalAddress.PostalCode = ApplicationIndividualVM.PostalPostalCode;
                PostalAddress.StateId = ApplicationIndividualVM.PostalStateId;
                PostalAddress.CityName = ApplicationIndividualVM.PostalCity;
                PostalAddress.CountryId = ApplicationIndividualVM.PostalCountryId;
                _clientDbContext.Address.Update(PostalAddress);
            }

            await _clientDbContext.SaveChangesAsync();

       
       

            foreach (var qualification in qvmlist)
            {
                if (string.IsNullOrEmpty(qualification.isdeleted) && qualification.id == null)
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



            foreach (var employment in empvmlist)
            {
                if (string.IsNullOrEmpty(employment.isdeleted) && employment.id == null)
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


            foreach (var referee in refvmlist)
            {
                if (string.IsNullOrEmpty(referee.isdeleted) && referee.id == null)
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
                    await _clientDbContext.MemberRefereeXref.AddAsync(refer);
                }
            }



            var selectedMemberDisabilityList = _clientDbContext.DisabilityMemberXref.Where(x => x.MemberId == MemberUser.Id);
            foreach (var a in selectedMemberDisabilityList)
            {
                _clientDbContext.DisabilityMemberXref.Remove(a);
            }
            await _clientDbContext.SaveChangesAsync();


            foreach (var disabilty in MemberDisabilityList)
            {
                DisabilityMemberXref disabxref = new DisabilityMemberXref();
                if (disabilty.IsSelected)
                {
                    disabxref.MemberId = MemberUser.Id;
                    disabxref.DisabilityId = disabilty.Id;
                    disabxref.DisabilityLevelId = disabilty.DisabilityLevelId;

                    await _clientDbContext.DisabilityMemberXref.AddAsync(disabxref);
                    await _clientDbContext.SaveChangesAsync();
                }
            }



            var selectedMemberAffliationList = _clientDbContext.MemberAffliationXref.Where(x => x.MemberId == MemberUser.Id);
            foreach (var a in selectedMemberAffliationList)
            {
                _clientDbContext.MemberAffliationXref.Remove(a);
            }
            await _clientDbContext.SaveChangesAsync();

            foreach (var affliation in MemberAffliationList)
            {
                MemberAffliationXref affXref = new MemberAffliationXref();
                if (affliation.IsSelected)
                {
                    affXref.MemberId = MemberUser.Id;
                    affXref.AffliationId = affliation.Id;
                    affXref.MemberNumber = affliation.MemberNumber;
                    if (affXref.AffliationId == 6)
                    {
                        affXref.MemberSpecificAffliationName = affliation.MemberSpecificAffliationName;
                    }
                    await _clientDbContext.MemberAffliationXref.AddAsync(affXref);
                    await _clientDbContext.SaveChangesAsync();
                }
            }



            var selectedMemberInvolvementList = _clientDbContext.InvolvementMemberXref.Where(x => x.MemberId == MemberUser.Id);

            foreach (var a in selectedMemberInvolvementList)
            {
                _clientDbContext.InvolvementMemberXref.Remove(a);
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
                    await _clientDbContext.SaveChangesAsync();
                }
            }



            var selectedMemberDivisionList = _clientDbContext.DivisionMemberXref.Where(x => x.MemberId == MemberUser.Id);

            foreach (var a in selectedMemberDivisionList)
            {
                _clientDbContext.DivisionMemberXref.Remove(a);
            }

            await _clientDbContext.SaveChangesAsync();

            foreach (var division in MemberDivisionList)
            {
                DivisionMemberXref divisionXref = new DivisionMemberXref();
                if (division.IsSelected)
                {
                    divisionXref.MemberId = MemberUser.Id;
                    divisionXref.DivisonId = division.Id;
                    await _clientDbContext.DivisionMemberXref.AddAsync(divisionXref);
                    await _clientDbContext.SaveChangesAsync();
                }
            }


         //   public async Task UploadFiles(List<IFormFile> files, int? filetype, string folder, string memberUserCode, string MemberName, int memberUserId)

            await UploadFiles(IDDocuments, (int?)FileTypesEnum.IDDocs, "IDDocs",MemberUser.MemberCode,MemberUser.ApplicationUser.FullName, MemberUser.Id);
            await UploadFiles(Certificates, (int?)FileTypesEnum.Certificates, "Certificates",  MemberUser.MemberCode,MemberUser.ApplicationUser.FullName,MemberUser.Id);
            await UploadFiles(ProofOfReg, (int?)FileTypesEnum.StudentReg, "StudentRegistration", MemberUser.MemberCode, MemberUser.ApplicationUser.FullName, MemberUser.Id);
            await UploadFiles(ProofOfPayment, (int?)FileTypesEnum.Payment, "ProofOfPay",  MemberUser.MemberCode,MemberUser.ApplicationUser.FullName, MemberUser.Id);
            await UploadFiles(ProofOfStudentLetter, (int?)FileTypesEnum.StudentLetter, "StudentLetter", MemberUser.MemberCode, MemberUser.ApplicationUser.FullName, MemberUser.Id);

            return MemberUser;
        }

        public async Task<ApplicationUser> UpdateApplicationUser()
        {

            ApplicationUser AppUser = await _userManager.GetUserAsync(User);


            try
            {
                AppUser.FirstName = ApplicationIndividualVM.FirstName;
                AppUser.LastName = ApplicationIndividualVM.LastName;
                AppUser.BirthDay = ApplicationIndividualVM.BirthDay;
                AppUser.PhoneNumber = ApplicationIndividualVM.MobilePhone;
                AppUser.TitleId = Convert.ToInt32(ApplicationIndividualVM.TitleId);
                AppUser.GenderId = Convert.ToInt32(ApplicationIndividualVM.GenderId);
                var result = await _userManager.UpdateAsync(AppUser);

                var test = result.Errors;
                if (result.Succeeded)
                {

                }
                return AppUser;
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception Occured while Updating Application User |" + ex.Message);
            }
            return null;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {

            notification = null;

            qvmlist.RemoveAll(x => x.isdeleted == "true");
            empvmlist.RemoveAll(x => x.isdeleted == "true");
            refvmlist.RemoveAll(x => x.isdeleted == "true");

            returnUrl = returnUrl ?? Url.Content("~/");
            ApplicationUser AppUser = new ApplicationUser();
            MemberUser MemberUser = new MemberUser();

            if (ModelState.ContainsKey("ApplicationIndividualVM.Password"))
                ModelState["ApplicationIndividualVM.Password"].Errors.Clear();

            AppUser = await UpdateApplicationUser();

            MemberUser = await UpdateMemberUser(AppUser.Id);

            await SetViewData();
            return Page();

        }



    }
}