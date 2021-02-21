using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MM.ClientModels;
using MM.Helper;
using WISA.Services;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace WISA.Pages.Manage
{
    [Authorize(Policy = MMPolicies.AllowUserAccess)]
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class NonIndividualModel : PageModel
    {

        public class MemberVM
        {
            public int MemberId { get; set; }

            [Display(Name = "Full Name")]
            //[Required(ErrorMessage = "Full Name is required")]
            public string FullName { get; set; }
           
            public int? MembershipStatusId { get; set; }

            [Display(Name = "Membership Status")]
            public string MembershipStatus { get; set; }

            public int? MembershipGradeId { get; set; }

            [Display(Name = "Membership Grade")]
            public string MembershipGrade { get; set; }

         
            public int? MembershipTypeId { get; set; }

            [Display(Name = "Membership Type")]
            public string MembershipType { get; set; }

            public string Email { get; set; }
        }

        private readonly ClientDbContext _context;
        private readonly ILogger<NonIndividualModel> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private IActivity _activity;
        private string EntityName = " Manage Non Individual ";
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public NonIndividualModel(ClientDbContext context, ILogger<NonIndividualModel> logger, UserManager<ApplicationUser> userManager, IActivity activity, IWebHostEnvironment env, IConfiguration configuration)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
            _activity = activity;
            _env = env;
            _configuration = configuration;
        }


        [BindProperty]
        public Organization Organization { get; set; }

        [BindProperty]
        public List<MemberFileXref> MemberFileList { get; set; }

        [BindProperty]
        public Address PhysicalAddress { get; set; }

        [BindProperty]
        public Address PostalAddress { get; set; }

        [BindProperty]
        public List<MemberVM> membervmlist { get; set; }

        [BindProperty]
        public List<IFormFile> Documents { get; set; }


        [BindProperty]
        public List<IFormFile> NotesFiles { get; set; }


        [BindProperty]
        public List<OrganizationBusinessXref> OrganizationBusinessList { get; set; }

        [BindProperty]
        public List<MemberShipHistoryVM> MemberShipHistoryVMList { get; set; }


        public async Task GetAllHistoryAsync(int? orgId)
        {
            MemberShipHistoryVM MemberShipHistoryVM = null;
            var selectedHistory = await _context.OrganizationMemberShipHistory
                .Include(x => x.MemberShipChangeReason)
                   .Include(x => x.OrganizationGrade)
                      .Include(x => x.OrganizationType)
                .Where(x => x.OrganizationId == orgId).ToListAsync();

            MemberShipHistoryVMList = new List<MemberShipHistoryVM>();

            foreach (var History in selectedHistory)
            {
                MemberShipHistoryVM = new MemberShipHistoryVM();
                MemberShipHistoryVM.MemberId = History.OrganizationId;
                MemberShipHistoryVM.StartDate = History.StartDate;
                MemberShipHistoryVM.EndDate = History.EndDate;
                MemberShipHistoryVM.MemberShipChangeReasonName = History.MemberShipChangeReason == null ? null : History.MemberShipChangeReason.Name;
                MemberShipHistoryVM.MemberShipGradeName = History.OrganizationGrade == null ? null : History.OrganizationGrade.Name;
                MemberShipHistoryVM.MembershipTypeName = History.OrganizationType == null ? null : History.OrganizationType.Name;
                MemberShipHistoryVM.Notes = History.Notes;
                MemberShipHistoryVMList.Add(MemberShipHistoryVM);
            }

            MemberShipHistoryVM = new MemberShipHistoryVM();
            MemberShipHistoryVM.MemberId = Organization.Id;
            MemberShipHistoryVM.StartDate = Organization.StartDate;
            MemberShipHistoryVM.EndDate = null;
            MemberShipHistoryVM.MemberShipGradeName = Organization.OrganizationGrade == null ? null : Organization.OrganizationGrade.Name;
            MemberShipHistoryVM.MembershipTypeName = Organization.OrganizationType == null ? null : Organization.OrganizationType.Name;
            MemberShipHistoryVMList.Add(MemberShipHistoryVM);
        }

        public async Task GetAllMembersofOrganizationAsync(int? orgId)
        {
            var Members = await _context.MemberUser
                .Include(x => x.ApplicationUser)
                .Include(x => x.MemberStatus)
                .Include(x => x.MembershipType)
                 .Include(x => x.MembershipGrade)
                .Where(x => x.ParentMemberid == orgId).ToListAsync();

       
            membervmlist = new List<MemberVM>();

            foreach (var member in Members)
            {
                MemberVM memberVM = new MemberVM();
                memberVM.MemberId = member.Id;
                memberVM.FullName = member.ApplicationUser==null?"": member.ApplicationUser.FullName;
                memberVM.MembershipGradeId = member.MembershipGradeId;
                memberVM.MembershipTypeId = member.MembershipTypeId;
                memberVM.MembershipStatusId = member.MemberStatusId;
                memberVM.MembershipStatus = member.MemberStatus == null ? null : member.MemberStatus.Name;
                memberVM.MembershipGrade = member.MembershipGrade == null ? null : member.MembershipGrade.Name;
                memberVM.MembershipType = member.MembershipType == null ? null : member.MembershipType.Name;
                membervmlist.Add(memberVM);
            }
        }


        [BindProperty]
        public List<MemberNotesXref> MemberNoteList { get; set; }

        [BindProperty]
        public List<MemberEmailXref> MemberEmailList { get; set; }

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
            public DateTime? CreatedOn { get; set; }
            public List<string> Files { get; set; }
            public string CreatedBy { get; set; }
        }

        [ViewData]
        public int? PrimaryContactId { get; set; }

        [ViewData]
        public string PrimaryContactName { get; set; }

        [ViewData]
        public int? ContactPersonId { get; set; }

        [ViewData]
        public string ContactPersonName { get; set; }

        public async Task GetBusinessesAsync(int? OrgId)
        {

            List<Business> businessList = await _context.Business.ToListAsync();
            OrganizationBusinessList = await _context.OrganizationBusinessXref.Include(x => x.Business).Where(x => x.OrganizationId == OrgId).ToListAsync();

            foreach (var business in businessList)
            {
                var found = false;
                foreach (var selectedbusiness in OrganizationBusinessList)
                {
                    if (selectedbusiness.BusinessId == business.Id)
                    {
                        selectedbusiness.IsSelected = true;
                        found = true;
                    }
                }
                if (found == false)
                {
                    OrganizationBusinessList.Add(new OrganizationBusinessXref { IsSelected = false, Business = business, BusinessId = business.Id, OrganizationId = OrgId });
                }
            }
            OrganizationBusinessList = OrganizationBusinessList.OrderBy(x => x.BusinessId).ToList();
        }


        public async Task<IActionResult> SetViewData(int? id)
        {
            PhysicalAddress = _context.Address.Where(x => x.RelatedEntityId == id && x.RelatedToId == (int)RelatedToEnum.Organization && x.AddressTypeId == 2).FirstOrDefault();
            PostalAddress = _context.Address.Where(x => x.RelatedEntityId == id && x.RelatedToId == (int)RelatedToEnum.Organization && x.AddressTypeId == 1).FirstOrDefault();
            MemberNoteList = await _context.MemberNotesXref.Where(x => x.RelatedEntityId == id && x.RelatedToId == (int)RelatedToEnum.Organization).ToListAsync();
            MemberEmailList = await _context.MemberEmailXref.Where(x => x.RelatedEntityId == id && x.RelatedToId == (int)RelatedToEnum.Organization).ToListAsync();
            MemberFileList = await _context.MemberFileXref.Include(m => m.FileType).Where(x => x.RelatedEntityId == id && x.RelatedToId == (int)RelatedToEnum.Organization).ToListAsync();


            Organization = await _context.Organization
            .Include(m => m.MemberStatus)
            .Include(m => m.OrganizationGrade)
            .Include(m => m.OrganizationType)
            .Include(m => m.TransactionCurrency)
            .Include(m => m.ClientBranch).FirstOrDefaultAsync(m => m.Id == id);


            await GetAllHistoryAsync(id);



            ActivityList = new List<Activity>();

            var StaffList = await _context.ClientUser.ToListAsync();
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
                    EmailId = email.Id,
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
                var notefiles = _context.MemberFileXref.Where(x => x.RelatedEntityId == note.Id && x.RelatedToId == (int)RelatedToEnum.Note);

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


            if (Organization == null)
            {
                return NotFound();
            }


            await GetBusinessesAsync(Organization.Id);
            await GetAllMembersofOrganizationAsync(Organization.Id);

            MemberVM primaryContact = membervmlist.Where(x => x.MembershipTypeId == (int)MembershipTypeEnum.PrimaryContact).FirstOrDefault();

            if (primaryContact != null) { PrimaryContactId = primaryContact.MemberId; PrimaryContactName = primaryContact.FullName; }
            MemberVM ContactPerson = membervmlist.Where(x => x.MembershipTypeId == (int)MembershipTypeEnum.ContactPerson).FirstOrDefault();
            if (ContactPerson != null) { ContactPersonId = ContactPerson.MemberId; ContactPersonName = ContactPerson.FullName; }

            ViewData["MemberStatusId"] = new SelectList(_context.MemberStatus, "Id", "Name");
            ViewData["OrganizationGradeId"] = new SelectList(_context.OrganizationGrade, "Id", "Name");
            ViewData["OrganizationTypeId"] = new SelectList(_context.OrganizationType, "Id", "Name");
            ViewData["TransactionCurrencyId"] = new SelectList(_context.Currency, "Id", "Name");
            ViewData["ClientBranchId"] = new SelectList(_context.ClientBranch, "Id", "Name");
            ViewData["YesNoList"] = new SelectList(new YesNoLookup().YesNoList(), nameof(YesNoLookup.Id), nameof(YesNoLookup.Name));
            ViewData["ProvinceId"] = new SelectList(_context.State.ToList(), nameof(State.Id), nameof(State.Name));
            ViewData["CountryId"] = new SelectList(_context.Country.ToList(), nameof(Country.Id), nameof(Country.Name));
            return null;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            await SetViewData(id);
            await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Accessed + EntityName + " Name: " + Organization.Name, UserTypeValues.Staff);
            return Page();
        }

        public async Task<IActionResult> OnGetSaveNotes(int id, string subject, string note)
        {
            if (string.IsNullOrEmpty(note))
            {
                return new JsonResult(new { success = false, message = MMMessages.Error_Please_check_values_entered });
            }
            var loggedinUserApplicationId = User.GetUserId();
            var loggedinUserId = _context.ClientUser.First(x => x.ApplicaitonUserId == loggedinUserApplicationId).Id;
            await _context.MemberNotesXref.AddAsync(new MemberNotesXref
            {
                RelatedEntityId = id,
                Subject = subject,
                Notes = note,
                RelatedToId = (int)RelatedToEnum.Organization,
                CreatedBy = loggedinUserId,
                CreatedOn = DateTime.Now
            });
            await _context.SaveChangesAsync();

            return new JsonResult(new { success = true, message = MMMessages.SavedSuccessfully });
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
                var loggedinUserId = _context.ClientUser.First(x => x.ApplicaitonUserId == loggedinUserApplicationId).Id;

                var membernote = new MemberNotesXref
                {
                    RelatedEntityId = Convert.ToInt32(id),
                    Subject = subject,
                    Notes = note,
                    RelatedToId = (int)RelatedToEnum.Organization,
                    CreatedBy = loggedinUserId,
                    CreatedOn = DateTime.Now
                };
                await _context.MemberNotesXref.AddAsync(membernote);
                await _context.SaveChangesAsync();

                var organinzation = _context.Organization.Where(x => x.Id == Convert.ToInt32(id)).FirstOrDefault();
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
                        parentfolder = Convert.ToInt32(organinzation.OrgMemberCode) / 1000;

                        string subfolder = organinzation.OrgMemberCode + "_" + Regex.Replace(organinzation.Name, "[^A-Za-z0-9]", "");
                        if (subfolder.Length > 15)
                        {
                            subfolder = subfolder.Substring(0, 15);
                        }
                        var filePath = Path.Combine(_env.ContentRootPath + _configuration["StoredFilesPath"], "nonind", parentfolder.ToString(), subfolder,"Notes");
                        if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);
                        filePath = Path.Combine(filePath, file);
                        if (System.IO.File.Exists(filePath)) System.IO.File.Delete(filePath);
                        var filepathToStore = Path.Combine("nonind", parentfolder.ToString(), subfolder, "Notes",file);

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
                            await _context.MemberFileXref.AddAsync(filexref);
                        }
                    }
                }
                await _context.SaveChangesAsync();
                return new JsonResult(new { success = true, message = MMMessages.SavedSuccessfully, files = filepaths });

            }

            catch (Exception ex)

            {

                result = ex.Message;

            }



            return new JsonResult(new { success = true, message = MMMessages.SavedSuccessfully });

        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                _context.Organization.Update(Organization);

                await _context.SaveChangesAsync();

                var physicalAddresstemp = _context.Address.Where(x => x.RelatedEntityId == Organization.Id && x.RelatedToId == (int)RelatedToEnum.Organization && x.AddressTypeId == 2).FirstOrDefault();
                var postalAddresstemp = _context.Address.Where(x => x.RelatedEntityId == Organization.Id && x.RelatedToId == (int)RelatedToEnum.Organization && x.AddressTypeId == 1).FirstOrDefault();


                if (physicalAddresstemp == null)
                {
                    PhysicalAddress.RelatedEntityId = Organization.Id;
                    PhysicalAddress.RelatedToId = (int)RelatedToEnum.Organization;
                    PhysicalAddress.AddressTypeId = (int)AddressTypeEnum.Physical;
                    await _context.Address.AddAsync(PhysicalAddress);
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
                    _context.Address.Update(physicalAddresstemp);
                }


                if (postalAddresstemp == null)
                {
                    PostalAddress.RelatedEntityId = Organization.Id;
                    PostalAddress.RelatedToId = (int)RelatedToEnum.Organization;
                    PostalAddress.AddressTypeId = (int)AddressTypeEnum.Postal;
                    await _context.Address.AddAsync(PostalAddress);
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
                    _context.Address.Update(postalAddresstemp);
                }

                var businesslist = await _context.OrganizationBusinessXref.Where(x => x.OrganizationId == Organization.Id).ToListAsync();
                _context.OrganizationBusinessXref.RemoveRange(businesslist);


                foreach (var orgbusiness in OrganizationBusinessList)
                {
                    if (orgbusiness.IsSelected == true)
                    {
                        await _context.OrganizationBusinessXref.AddAsync(orgbusiness);
                        await _context.SaveChangesAsync();
                    }
                }


                await UploadFiles(Documents, Organization.OrgMemberCode, Organization.Name, Organization.Id);
                await _context.SaveChangesAsync();
            }
            else
            {
                _logger.LogInformation(string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)));

            }
            await SetViewData(Organization.Id);
            await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Updated + EntityName + "  Name: " + Organization.Name, UserTypeValues.Staff);
            return Page();
        }

        public async Task UploadFiles(List<IFormFile> files, string memberUserCode, string OrganizationName, int memberUserId)
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

                    string subfolder = memberUserCode + "_" + Regex.Replace(OrganizationName, "[^A-Za-z0-9]", "");
                    if (subfolder.Length > 15)
                    {
                        subfolder = subfolder.Substring(0, 15);
                    }
                    var filePath = Path.Combine(_env.ContentRootPath + _configuration["StoredFilesPath"], "nonind", parentfolder.ToString(), subfolder);
                    if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);
                    filePath = Path.Combine(filePath, file);
                    if (System.IO.File.Exists(filePath)) System.IO.File.Delete(filePath);
                    var filepathToStore = Path.Combine("nonind", parentfolder.ToString(), subfolder, file);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                        MemberFileXref filexref = new MemberFileXref();
                        filexref.RelatedEntityId = memberUserId;
                        filexref.RelatedToId = (int)RelatedToEnum.Organization;
                        filexref.FilePath = filepathToStore;
                        filexref.FileName = file;
                        filexref.CreatedOn = DateTime.Now;
                        filexref.ModifiedOn = DateTime.Now;
                        filexref.FileTypeId = null;
                        await _context.MemberFileXref.AddAsync(filexref);
                    }
                }
            }

            await _context.SaveChangesAsync();
        }

      
    }
}
