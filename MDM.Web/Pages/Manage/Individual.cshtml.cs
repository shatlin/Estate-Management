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
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using WISA.Services;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace MM.Pages.Manage
{
    [Authorize(Policy = MMPolicies.AllowUserAccess)]
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class IndividualModel : PageModel
    {
        #region Constructor

        private readonly ClientDbContext _clientDbContext;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<IndividualModel> _logger;
        private readonly IEmailCreator _emailCreator;
        private readonly IConfiguration _configuration;
        private IActivity _activity;
        private string EntityName = " Manage Individual ";
        private readonly IWebHostEnvironment _env;

        public IndividualModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            ILogger<IndividualModel> logger, IWebHostEnvironment env, IEmailCreator emailCreator, ClientDbContext clientDbContext, IConfiguration configuration, IActivity activity)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailCreator = emailCreator;
            _clientDbContext = clientDbContext;
            _configuration = configuration;
            _activity = activity;
            _env = env;

        }
        #endregion

        #region Bindings

        [BindProperty]
        public Notification notification { get; set; }


        [BindProperty]
        public List<qualificationvm> qvmlist { get; set; }

        [BindProperty]
        public List<dwsclassvm> classlist { get; set; }

        [BindProperty]
        public List<employmentvm> empvmlist { get; set; }

        [BindProperty]
        public List<refereevm> refvmlist { get; set; }


        [BindProperty]
        public List<IFormFile> NotesFiles { get; set; }

        [BindProperty]
        public List<IFormFile> IDDocuments { get; set; }

        [BindProperty]
        public List<IFormFile> Certificates { get; set; }

        [BindProperty]
        public List<IFormFile> ProofofDWS { get; set; }

        [BindProperty]
        public List<IFormFile> ProofOfReg { get; set; }

        [BindProperty]
        public List<IFormFile> ProofOfStudentLetter { get; set; }

        [BindProperty]
        public List<IFormFile> ProofOfPayment { get; set; }

        [BindProperty]
        public int RequestType { get; set; }

        [BindProperty]
        public int? OrganizationId { get; set; }


        [BindProperty]
        public string OrganizationName { get; set; }

        [BindProperty]
        public MemberUser MemberUser { get; set; }

        [BindProperty]
        public Address PhysicalAddress { get; set; }

        [BindProperty]
        public Address PostalAddress { get; set; }


        [BindProperty]
        public string MembershipChangeReasonNotes { get; set; }

        [BindProperty]
        public int? MemberShipChangeReasonId { get; set; }
        
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

        public async Task GetAllHistoryAsync(int? memberid)
        {
            var selectedMemberHistory = await _clientDbContext.IndividualMemberShipHistory
                .Include(x => x.MemberShipChangeReason)
                   .Include(x => x.MemberShipGrade)
                      .Include(x => x.MembershipType)
                .Where(x => x.MemberId == memberid).ToListAsync();

            IndividualMemberShipHistoryVMList = new List<MemberShipHistoryVM>();
            MemberShipHistoryVM IndividualMemberShipHistoryVM = null;
            foreach (var History in selectedMemberHistory)
            {
                IndividualMemberShipHistoryVM = new MemberShipHistoryVM();

                IndividualMemberShipHistoryVM.MemberId = History.MemberId;
                IndividualMemberShipHistoryVM.StartDate = History.StartDate;
                IndividualMemberShipHistoryVM.EndDate = History.EndDate;
                IndividualMemberShipHistoryVM.MemberShipChangeReasonName = History.MemberShipChangeReason == null ? null : History.MemberShipChangeReason.Name;
                IndividualMemberShipHistoryVM.MemberShipGradeName = History.MemberShipGrade == null ? null : History.MemberShipGrade.Name;
                IndividualMemberShipHistoryVM.MembershipTypeName = History.MembershipType == null ? null : History.MembershipType.Name;
                IndividualMemberShipHistoryVM.Notes = History.Notes;
                IndividualMemberShipHistoryVMList.Add(IndividualMemberShipHistoryVM);
            }

            IndividualMemberShipHistoryVM = new MemberShipHistoryVM();

            IndividualMemberShipHistoryVM.MemberId = MemberUser.Id;
            IndividualMemberShipHistoryVM.StartDate = MemberUser.StartDate;
            IndividualMemberShipHistoryVM.EndDate = null;
            IndividualMemberShipHistoryVM.MemberShipGradeName = MemberUser.MembershipGrade == null ? null : MemberUser.MembershipGrade.Name;
            IndividualMemberShipHistoryVM.MembershipTypeName = MemberUser.MembershipType == null ? null : MemberUser.MembershipType.Name;
            IndividualMemberShipHistoryVMList.Add(IndividualMemberShipHistoryVM);

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
        public List<MemberRefereeXref> MemberRefereeList { get; set; }

        [BindProperty]
        public List<DWSClassMemberXref> MemberDWSClassList { get; set; }

        [BindProperty]
        public List<MemberFileXref> MemberFileList { get; set; }

        [BindProperty]
        public List<MemberNotesXref> MemberNoteList { get; set; }

        [BindProperty]
        public List<MemberEmailXref> MemberEmailList { get; set; }

        [BindProperty]
        public List<MemberShipHistoryVM> IndividualMemberShipHistoryVMList { get; set; }

        [BindProperty]
        public List<Activity> ActivityList { get; set; }

        public class Activity
        {
            public string ActivityType { get; set; }
            public string Content { get; set; }
            public int EmailId { get; set; }
            public string From { get; set; }
            public string To { get; set; }
            public string Subject { get; set; }
            public List<string> Files { get; set; }
            public DateTime? CreatedOn { get; set; }
            public string CreatedBy { get; set; }
        }


        public async Task<IActionResult> OnGetAsync(int? id)
        {

            await SetViewData(id);
            await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Accessed + EntityName + "  Email : " + MemberUser.Email, UserTypeValues.Staff);
            return Page();
        }

        public async Task UploadFiles(List<IFormFile> files, int? filetype, string folder)
        {
            var loggedinUserApplicationId = User.GetUserId();
            var loggedinUserId = _clientDbContext.ClientUser.First(x => x.ApplicaitonUserId == loggedinUserApplicationId).Id;
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
                    parentfolder = Convert.ToInt32(MemberUser.MemberCode) / 1000;

                    string subfolder = MemberUser.MemberCode + "_" + Regex.Replace(MemberUser.ApplicationUser.FullName, "[^A-Za-z0-9]", "");
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
                        filexref.RelatedEntityId = MemberUser.Id;
                        filexref.RelatedToId = (int)RelatedToEnum.Member;
                        filexref.FilePath = filepathToStore;
                        filexref.FileName = file;
                        filexref.CreatedOn = DateTime.Now;
                        filexref.ModifiedOn = DateTime.Now;
                        filexref.CreatedBy = loggedinUserId;
                        filexref.FileTypeId = filetype;
                        await _clientDbContext.MemberFileXref.AddAsync(filexref);
                    }
                }
            }

            await _clientDbContext.SaveChangesAsync();
        }

        public async Task SetViewData(int? id)
        {

            _logger.LogInformation("Accessing Member User Started.Id is :"+id);
            int newId = Convert.ToInt32(id);
            MemberUser = await _clientDbContext.MemberUser
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
               .Include(m => m.VolunteerWorkHours).FirstOrDefaultAsync(b => b.Id == newId);

            MemberDWSClassList = await _clientDbContext.DWSClassMemberXref.Include(m => m.DWSClass).Where(x => x.MemberId == MemberUser.Id).ToListAsync();
            MemberQualificationList = await _clientDbContext.MemberQualificationXref.Include(m => m.QualificationType).Where(x => x.MemberId == MemberUser.Id).ToListAsync();
            MemberEmploymentList = await _clientDbContext.EmploymentMemberXref.Include(m => m.EmploymentCategory).Where(x => x.MemberUserId == MemberUser.Id).ToListAsync();
            MemberRefereeList = await _clientDbContext.MemberRefereeXref.Where(x => x.RelatedEntityId == MemberUser.Id).ToListAsync();
            MemberFileList = await _clientDbContext.MemberFileXref.Include(m => m.FileType).Where(x => x.RelatedEntityId == MemberUser.Id && x.RelatedToId == 1).ToListAsync();
            MemberNoteList = await _clientDbContext.MemberNotesXref.Where(x => x.RelatedEntityId == MemberUser.Id && x.RelatedToId == 1).ToListAsync();
            MemberEmailList = await _clientDbContext.MemberEmailXref.Where(x => x.RelatedEntityId == MemberUser.Id && x.RelatedToId == 1).ToListAsync();

            ActivityList = new List<Activity>();

            var StaffList = await _clientDbContext.ClientUser.ToListAsync();
            var StaffApplciationUserList = await _userManager.Users.Where(x => x.UserTypeId == 1).ToListAsync();

            string createby = string.Empty;

            foreach (var email in MemberEmailList)
            {
                if (email.CreatedBy != null)
                {
                    var staffAppId = StaffList.Where(x => x.Id == email.CreatedBy).First().ApplicaitonUserId;
                    createby = StaffApplciationUserList.Where(x => x.Id == staffAppId).First().FullName;
                }

                //string html = email.Body;

                //HtmlDocument doc = new HtmlDocument();
                //doc.LoadHtml(html);

                //if (doc.ParseErrors.Count() > 0)
                //{
                //    email.Body = "Error.Email not in displayable format.";
                //}

                ActivityList.Add(new Activity
                {
                    EmailId=email.Id,
                    ActivityType = "Email",
                    Content = email.Body,
                    From = email.From,
                    To = email.To,
                    Subject = email.Subject,
                    CreatedOn = email.CreatedOn,
                    CreatedBy = createby
                });
            }

            foreach (var note in MemberNoteList)
            {
                if (note.CreatedBy != null)
                {
                    var staffAppId = StaffList.Where(x => x.Id == note.CreatedBy).First().ApplicaitonUserId;
                    createby = StaffApplciationUserList.Where(x => x.Id == staffAppId).First().FullName;
                }
                var notefiles = _clientDbContext.MemberFileXref.Where(x => x.RelatedEntityId == note.Id && x.RelatedToId == (int)RelatedToEnum.Note);

                Activity activity = new Activity();

                activity.ActivityType = "Note";
                activity.Content = note.Notes;
                activity.Subject = note.Subject;
                activity.CreatedOn = note.CreatedOn;
                activity.CreatedBy = createby;
                if (notefiles != null)
                {
                    activity.Files = new List<string>();
                    foreach (var notefile in notefiles)
                    {
                        activity.Files.Add(notefile.FilePath);
                    }
                }
                ActivityList.Add(activity);
            }

            PhysicalAddress = _clientDbContext.Address.Where(x => x.RelatedEntityId == MemberUser.Id && x.RelatedToId == (int)RelatedToEnum.Member && x.AddressTypeId == 2).FirstOrDefault();
            PostalAddress = _clientDbContext.Address.Where(x => x.RelatedEntityId == MemberUser.Id && x.RelatedToId == (int)RelatedToEnum.Member && x.AddressTypeId == 1).FirstOrDefault();

            await GetAllDivisionsAsync(MemberUser.Id);
            await GetAllHistoryAsync(MemberUser.Id);
            await GetAllAffliationsAsync(MemberUser.Id);
            await GetAllDisabilitiesAsync(MemberUser.Id);
            await GetAllInvolvementsAsync(MemberUser.Id);

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
            ViewData["MembershipTypeId"] = new SelectList(_clientDbContext.MembershipType.ToList(), nameof(MembershipType.Id), nameof(MembershipType.Name));
            ViewData["MembershipGradeId"] = new SelectList(_clientDbContext.MembershipGrade.ToList(), nameof(MemberShipGrade.Id), nameof(MemberShipGrade.Name));
            ViewData["MemberStatusId"] = new SelectList(_clientDbContext.MemberStatus.ToList(), nameof(MemberStatus.Id), nameof(MemberStatus.Name));
            ViewData["MemberShipChangeReasons"] = new SelectList(_clientDbContext.MemberShipChangeReason.ToList(), nameof(MemberShipChangeReason.Id), nameof(MemberShipChangeReason.Name));
            //ViewData["MemberEmails"] = new SelectList(_clientDbContext.MemberEmailXref.ToList(), nameof(MemberEmailXref.Subject), nameof(MemberEmailXref.Body));
            ViewData["YesNoList"] = new SelectList(new YesNoLookup().YesNoList(), nameof(YesNoLookup.Id), nameof(YesNoLookup.Name));

            _logger.LogInformation("Accessing Member User Completed.Id is :" + id);
        }

        


  

        public async Task<MemberUser> UpdateMemberUser(int? id)
        {

            try
            {
                MemberUser muser = MemberUser;
                muser.ModifiedOn = DateTime.Now;

                //test the following
                var organzationId=MemberUser.OrganizationId;
                if(organzationId!=null && muser.ParentMemberid==null)
                {
                    muser.ParentMemberid=organzationId;
                }

                _clientDbContext.Entry(muser).State = EntityState.Modified;
                //test the above

                var currentGradeId = _clientDbContext.MemberUser.AsNoTracking().Where(x => x.Id == id).FirstOrDefault().MembershipGradeId;
                var currentTypeId = _clientDbContext.MemberUser.AsNoTracking().Where(x => x.Id == id).FirstOrDefault().MembershipTypeId;

                if (currentGradeId != MemberUser.MembershipGradeId || currentTypeId != MemberUser.MembershipTypeId)
                {
                    IndividualMemberShipHistory history = new IndividualMemberShipHistory();

                    var lasthistory = _clientDbContext.IndividualMemberShipHistory.Where(x => x.MemberId == MemberUser.Id).OrderByDescending(x => x.Id).FirstOrDefault();
                    if (lasthistory != null)
                    {
                        history.StartDate = lasthistory.EndDate;
                    }
                    else
                    {
                        history.StartDate = MemberUser.StartDate;
                    }

                    history.MemberId = MemberUser.Id;
                    history.MemberShipGradeId = currentGradeId;
                    history.MembershipTypeId = currentTypeId;
                    history.EndDate = DateTime.Now;
                    history.MemberShipChangeReasonId = MemberShipChangeReasonId;
                    history.Notes = MembershipChangeReasonNotes;
                   await _clientDbContext.IndividualMemberShipHistory.AddAsync(history);
                }




                var physicalAddresstemp = _clientDbContext.Address.Where(x => x.RelatedEntityId == MemberUser.Id && x.RelatedToId == (int)RelatedToEnum.Member && x.AddressTypeId == 2).FirstOrDefault();
                var postalAddresstemp = _clientDbContext.Address.Where(x => x.RelatedEntityId == MemberUser.Id && x.RelatedToId == (int)RelatedToEnum.Member && x.AddressTypeId == 1).FirstOrDefault();


                if (physicalAddresstemp == null)
                {
                    PhysicalAddress.RelatedEntityId = MemberUser.Id;
                    PhysicalAddress.RelatedToId = (int)RelatedToEnum.Member;
                    PhysicalAddress.AddressTypeId = (int)AddressTypeEnum.Physical;
                    await _clientDbContext.Address.AddAsync(PhysicalAddress);
                }
                else
                {

                    physicalAddresstemp.AddressTypeId = (int)AddressTypeEnum.Physical;
                    physicalAddresstemp.AddressLine1 = PhysicalAddress.AddressLine1;
                    physicalAddresstemp.AddressLine2 = PhysicalAddress.AddressLine2;
                    physicalAddresstemp.Suburb = PhysicalAddress.Suburb;
                    physicalAddresstemp.Province = PhysicalAddress.Province;
                    physicalAddresstemp.PostalCode = PhysicalAddress.PostalCode;
                    physicalAddresstemp.CityName = PhysicalAddress.CityName;
                    physicalAddresstemp.CountryId = PhysicalAddress.CountryId;
                    physicalAddresstemp.StateId = PhysicalAddress.StateId;
                    _clientDbContext.Address.Update(physicalAddresstemp);
                }


                if (postalAddresstemp == null)
                {
                    PostalAddress.RelatedEntityId = MemberUser.Id;
                    PostalAddress.RelatedToId = (int)RelatedToEnum.Member;
                    PostalAddress.AddressTypeId = (int)AddressTypeEnum.Postal;
                    await _clientDbContext.Address.AddAsync(PostalAddress);
                }
                else
                {

                    postalAddresstemp.AddressTypeId = (int)AddressTypeEnum.Postal;
                    postalAddresstemp.AddressLine1 = PostalAddress.AddressLine1;
                    postalAddresstemp.AddressLine2 = PostalAddress.AddressLine2;
                    postalAddresstemp.Suburb = PostalAddress.Suburb;
                    postalAddresstemp.Province = PostalAddress.Province;
                    postalAddresstemp.PostalCode = PostalAddress.PostalCode;
                    postalAddresstemp.CityName = PostalAddress.CityName;
                    postalAddresstemp.CountryId = PostalAddress.CountryId;
                    postalAddresstemp.StateId = PostalAddress.StateId;
                    _clientDbContext.Address.Update(postalAddresstemp);
                }




                if (MemberUser.MembershipTypeId == (int)MembershipTypeEnum.ProfessionalProcessController)
                {
                    foreach (var dwsclass in classlist)
                    {
                        if (string.IsNullOrEmpty(dwsclass.isdeleted) && dwsclass.id == null)
                        {
                            DWSClassMemberXref dWSClassMemberXref = new DWSClassMemberXref();
                            dWSClassMemberXref.MemberId = MemberUser.Id;
                            dWSClassMemberXref.DWSClassId = dwsclass.waterclass;
                            dWSClassMemberXref.ClassDate = dwsclass.waterdate;
                            await _clientDbContext.DWSClassMemberXref.AddAsync(dWSClassMemberXref);
                        }
                    }

                }

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







                var selectedMemberDisabilityList = _clientDbContext.DisabilityMemberXref.Where(x => x.MemberId == MemberUser.Id);
                foreach (var a in selectedMemberDisabilityList)
                {
                    _clientDbContext.DisabilityMemberXref.Remove(a);
                }



                foreach (var disabilty in MemberDisabilityList)
                {
                    DisabilityMemberXref disabxref = new DisabilityMemberXref();
                    if (disabilty.IsSelected)
                    {
                        disabxref.MemberId = MemberUser.Id;
                        disabxref.DisabilityId = disabilty.Id;
                        disabxref.DisabilityLevelId = disabilty.DisabilityLevelId;

                        await _clientDbContext.DisabilityMemberXref.AddAsync(disabxref);

                    }
                }



                var selectedMemberAffliationList = _clientDbContext.MemberAffliationXref.Where(x => x.MemberId == MemberUser.Id);
                foreach (var a in selectedMemberAffliationList)
                {
                    _clientDbContext.MemberAffliationXref.Remove(a);
                }


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

                    }
                }



                var selectedMemberInvolvementList = _clientDbContext.InvolvementMemberXref.Where(x => x.MemberId == MemberUser.Id);

                foreach (var a in selectedMemberInvolvementList)
                {
                    _clientDbContext.InvolvementMemberXref.Remove(a);
                }



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

                var selectedMemberDivisionList = _clientDbContext.DivisionMemberXref.Where(x => x.MemberId == MemberUser.Id);

                foreach (var a in selectedMemberDivisionList)
                {
                    _clientDbContext.DivisionMemberXref.Remove(a);
                }



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

                await UploadFiles(IDDocuments, (int?)FileTypesEnum.IDDocs, "IDDocs");
                await UploadFiles(Certificates, (int?)FileTypesEnum.Certificates, "Certificates");
                await UploadFiles(ProofofDWS, (int?)FileTypesEnum.DWSReg, "ProofOfDWS");
                await UploadFiles(ProofOfReg, (int?)FileTypesEnum.StudentReg, "StudentRegistration");
                await UploadFiles(ProofOfPayment, (int?)FileTypesEnum.Payment, "ProofOfPay");
                await UploadFiles(ProofOfStudentLetter, (int?)FileTypesEnum.StudentLetter, "StudentLetter");
            }
            catch (Exception ex)
            {
                Rollback();
                _logger.LogInformation("Exception while saving member. No changes are saved " + MemberUser.MemberCode);
                notification = new Notification { message = "Exception while saving member. No changes are saved ", notificationtype = "danger" };
            }
            await _clientDbContext.SaveChangesAsync();
            return MemberUser;
        }

        public async Task<ApplicationUser> UpdateApplicationUser()
        {

            try
            {
                //if (string.IsNullOrEmpty(MemberUser.Email)||MemberUser.Email=="null")
                //{
                //    return MemberUser.ApplicationUser;
                //}


                ApplicationUser AppUser = await _userManager.FindByIdAsync(MemberUser.ApplicaitonUserId);
                AppUser.Email = MemberUser.Email;
                AppUser.UserName = MemberUser.Email;
                AppUser.NormalizedEmail= MemberUser.Email.ToUpper();
                AppUser.NormalizedUserName = MemberUser.Email.ToUpper();
                AppUser.EmailConfirmed=true;
                AppUser.TitleId = MemberUser.ApplicationUser.TitleId;
                AppUser.GenderId = MemberUser.ApplicationUser.GenderId;
                AppUser.BirthDay = MemberUser.ApplicationUser.BirthDay;
                AppUser.FirstName = MemberUser.ApplicationUser.FirstName;
                AppUser.LastName = MemberUser.ApplicationUser.LastName;
                var result = await _userManager.UpdateAsync(AppUser);
                var test = result.Errors;

                if (result.Errors.Count() > 0)
                {
                    string errors = string.Empty;
                    foreach (var error in result.Errors)
                    {
                        errors += error.Description + ",";
                    }
                    _logger.LogError("Exception Occured while Updating Application User |" + errors);
                    Rollback();
                    _logger.LogInformation("Exception while saving member. No changes are saved " + MemberUser.MemberCode + " Exception " + errors);
                    notification = new Notification { message = "Exception while saving member. No changes are saved ", notificationtype = "danger" };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception Occured while Updating Application User |" + ex.Message);
                Rollback();
                _logger.LogInformation("Exception while saving member. No changes are saved " + MemberUser.MemberCode + " Exception " + ex.Message);
                notification = new Notification { message = "Exception while saving member. No changes are saved ", notificationtype = "danger" };
            }
            return MemberUser.ApplicationUser;
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            notification = null;

            //if (ModelState.IsValid)
            {
                qvmlist.RemoveAll(x => x.isdeleted == "true");
                empvmlist.RemoveAll(x => x.isdeleted == "true");
                refvmlist.RemoveAll(x => x.isdeleted == "true");

                await UpdateApplicationUser();

                if (notification == null)
                {
                    await UpdateMemberUser(id);
                }
                await SetViewData(id);

                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Updated + EntityName + "  Email: " + MemberUser.Email, UserTypeValues.Staff);

                if (notification == null)
                {
                    notification = new Notification { message = "Member Details updated Successfully", notificationtype = "success" };
                }
                else
                {
                    notification = new Notification { message = "Please fill all mandatory fields. Kindly go through each tab and check errors.", notificationtype = NotificationTypeValues.danger };
                }
            }
            //else
            //{
            //    notification = new Notification { message = "Please fill all mandatory fields. Kindly go through each tab and check errors.", notificationtype = NotificationTypeValues.danger };

            //    foreach (var modelStateKey in ViewData.ModelState.Keys)
            //    {
            //        var value = ViewData.ModelState[modelStateKey];

            //        foreach (var error in value.Errors)
            //        {
            //            _logger.LogInformation("Key=" + modelStateKey + ", Error= " + error.ErrorMessage);
            //        }
            //    }
            //}

         

            return Page();
        }

        private void Rollback()
        {
            foreach (var entry in _clientDbContext.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified; //Revert changes made to deleted entity.
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                }
            }
        }

        public async Task<IActionResult> OnPostUpload()

        {
            string id = string.Empty;
            string note = string.Empty;
            string subject = string.Empty;
            string result = string.Empty;
            try
            {

                var files = Request.Form.Files;

                foreach (var key in Request.Form.Keys)
                {
                    if (key.Contains("id"))
                    {
                        id = Request.Form["id"].ToString();
                    }
                    if (key.Contains("note"))
                    {
                        note = Request.Form["note"].ToString();
                    }
                    if (key.Contains("subject"))
                    {
                        subject = Request.Form["subject"].ToString();
                    }
                }


                if (string.IsNullOrEmpty(note))
                {
                    return new JsonResult(new { success = false, message = MMMessages.Error_Subject_note_Missing });
                }

                var loggedinUserApplicationId = User.GetUserId();
                var loggedinUserId = _clientDbContext.ClientUser.First(x => x.ApplicaitonUserId == loggedinUserApplicationId).Id;

                var membernote = new MemberNotesXref
                {
                 
                    RelatedEntityId = Convert.ToInt32(id),
                    Subject = subject,
                    Notes = note,
                    RelatedToId = (int)RelatedToEnum.Member,
                    CreatedBy = loggedinUserId,
                    CreatedOn = DateTime.Now
                };
                await _clientDbContext.MemberNotesXref.AddAsync(membernote);
                await _clientDbContext.SaveChangesAsync();

                MemberUser = _clientDbContext.MemberUser.Where(x => x.Id == Convert.ToInt32(id)).Include(x => x.ApplicationUser).FirstOrDefault();
                string filepaths = string.Empty;
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
                        parentfolder = Convert.ToInt32(MemberUser.MemberCode) / 1000;

                        string subfolder = MemberUser.MemberCode + "_" + Regex.Replace(MemberUser.ApplicationUser.FullName, "[^A-Za-z0-9]", "");
                        if (subfolder.Length > 15)
                        {
                            subfolder = subfolder.Substring(0, 15);
                        }


                        var filePath = Path.Combine(_env.ContentRootPath + _configuration["StoredFilesPath"], "Ind", parentfolder.ToString(), subfolder, "Notes");
                        if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);
                        filePath = Path.Combine(filePath, file);
                        if (System.IO.File.Exists(filePath)) System.IO.File.Delete(filePath);
                        var filepathToStore = Path.Combine("Ind", parentfolder.ToString(), subfolder, "Notes", file);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await formFile.CopyToAsync(stream);
                            MemberFileXref filexref = new MemberFileXref();
                            filexref.RelatedEntityId = membernote.Id;
                            filexref.RelatedToId = (int)RelatedToEnum.Note;
                            filexref.FilePath = filepathToStore;
                            filexref.FileName = file;
                            filexref.CreatedOn = DateTime.Now;
                            filexref.ModifiedOn = DateTime.Now;
                            filexref.CreatedBy = loggedinUserId;
                            filexref.FileTypeId = (int)FileTypesEnum.Note;
                            filepaths += filexref.FilePath;
                            await _clientDbContext.MemberFileXref.AddAsync(filexref);
                        }
                    }


                }
                await _clientDbContext.SaveChangesAsync();
                return new JsonResult(new { success = true, message = MMMessages.SavedSuccessfully, files = filepaths });

            }

            catch (Exception ex)

            {

                result = ex.Message;

            }

            return new JsonResult(new { success = true, message = MMMessages.SavedSuccessfully });

        }

    }
}