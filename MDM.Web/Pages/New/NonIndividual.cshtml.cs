using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MM.ClientModels;
using MM.Helper;
using WISA.Services;

namespace WISA.Pages.New
{
    [AllowAnonymous]
    public class NonIndividualModel : PageModel
    {

        public class MemberVM
        {
            public int MemberId { get; set; }
            public string FullName { get; set; }
            public string MembershipStatus { get; set; }
            public int? MembershipGradeId { get; set; }
            public string MembershipGrade { get; set; }
            public string Email { get; set; }
        }

        private readonly ClientDbContext _context;
        private readonly ILogger<NonIndividualModel> _logger;
        private IActivity _activity;
        private string EntityName = "Add Non Individual";
        private readonly IEmailCreator _emailCreator;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public NonIndividualModel(ClientDbContext context, ILogger<NonIndividualModel> logger, IActivity activity, IEmailCreator emailCreator,IConfiguration configuration, IWebHostEnvironment env)
        {
            _context = context;
            _logger = logger;
            _activity = activity;
            _emailCreator = emailCreator;
            _configuration = configuration;
            _env = env;
        }


        [BindProperty]
        public Organization Organization { get; set; }

        [BindProperty]
        public Address PhysicalAddress { get; set; }

        [BindProperty]
        [Required]
        public Address PostalAddress { get; set; }

        [BindProperty]
        public List<MemberVM> membervmlist { get; set; }

        [BindProperty]
        public List<OrganizationBusinessXref> OrganizationBusinessList { get; set; }

        [BindProperty]
        public List<IFormFile> Documents { get; set; }

        [ViewData]
        public int? PrimaryContactId { get; set; }

        [ViewData]
        public string PrimaryContactName { get; set; }

        [ViewData]
        public int? ContactPersonId { get; set; }

        [ViewData]
        public string ContactPersonName { get; set; }

        public async Task GetBusinessesAsync()
        {
            List<Business> businessList = await _context.Business.ToListAsync();
            OrganizationBusinessList = new List<OrganizationBusinessXref>();

            foreach (var business in businessList)
            {
                OrganizationBusinessList.Add(new OrganizationBusinessXref { IsSelected = false, Business = business, BusinessId = business.Id, OrganizationId = null });
            }
            OrganizationBusinessList = OrganizationBusinessList.OrderBy(x => x.BusinessId).ToList();
        }


        public async Task<IActionResult> SetViewData()
        {
            //PhysicalAddress = _context.Address.Where(x => x.RelatedEntityId == id && x.RelatedToId == (int)RelatedToEnum.Organization && x.AddressTypeId == 2).FirstOrDefault();
            //PostalAddress = _context.Address.Where(x => x.RelatedEntityId == id && x.RelatedToId == (int)RelatedToEnum.Organization && x.AddressTypeId == 1).FirstOrDefault();

            //Organization = await _context.Organization
            //.Include(m => m.MemberStatus)
            //.Include(m => m.OrganizationGrade)
            //.Include(m => m.MemberShipType)
            //.Include(m => m.TransactionCurrency)
            //.Include(m => m.ClientBranch).FirstOrDefaultAsync(m => m.Id == id);

            //if (Organization == null)
            //{
            //    return NotFound();
            //}

            //     membervmlist = _context.MemberUser.Include(x => x.ApplicationUser).Include(x => x.MembershipType).Include(x => x.MemberStatus)
            //.Where(x => x.OrganizationId == Organization.Id)
            //        .Select(x => new MemberVM
            //        {
            //            MemberId = x.Id,
            //            FullName = x.ApplicationUser.FullName,
            //            MembershipStatus = x.MemberStatus.Name,
            //            MembershipGradeId = x.MembershipTypeId,
            //            MembershipGrade = x.MembershipType.Name,
            //            Email = x.ApplicationUser.Email,
            //        }).ToList();


            //MemberVM primaryContact = membervmlist.Where(x => x.MembershipGradeId == (int)MembershipTypeEnum.PrimaryContact).FirstOrDefault();

            //if (primaryContact != null) { PrimaryContactId = primaryContact.MemberId; PrimaryContactName = primaryContact.FullName; }
            //MemberVM ContactPerson = membervmlist.Where(x => x.MembershipGradeId == (int)MembershipTypeEnum.ContactPerson).FirstOrDefault();
            //if (ContactPerson != null) { ContactPersonId = ContactPerson.MemberId; ContactPersonName = ContactPerson.FullName; }

            await GetBusinessesAsync();

            ViewData["MemberStatusId"] = new SelectList(_context.MemberStatus, "Id", "Name");
            ViewData["OrganizationGradeId"] = new SelectList(_context.OrganizationGrade, "Id", "Name");
            ViewData["MemberShipTypeId"] = new SelectList(_context.MembershipGrade, "Id", "Name");
            ViewData["TransactionCurrencyId"] = new SelectList(_context.Currency, "Id", "Name");
            ViewData["ClientBranchId"] = new SelectList(_context.ClientBranch, "Id", "Name");
            ViewData["YesNoList"] = new SelectList(new YesNoLookup().YesNoList(), nameof(YesNoLookup.Id), nameof(YesNoLookup.Name));
            ViewData["ProvinceId"] = new SelectList(_context.State.ToList(), nameof(State.Id), nameof(State.Name));
            ViewData["CountryId"] = new SelectList(_context.Country.ToList(), nameof(Country.Id), nameof(Country.Name));
            return null;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            await SetViewData();
            await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Accessed + EntityName, UserTypeValues.Staff);
            return Page();
        }


        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                int OrgMemberCode = 1;

                var lastMember = _context.Organization.OrderByDescending(x => x.Id).FirstOrDefault();
                if (lastMember != null)
                {
                    OrgMemberCode = Convert.ToInt32(_context.Organization.OrderByDescending(x => x.Id).FirstOrDefault().OrgMemberCode) + 1;
                    var org = _context.Organization.Where(x => x.OrgMemberCode == OrgMemberCode.ToString()).FirstOrDefault();
                    while (org != null)
                    {
                        OrgMemberCode += 1;
                        org = _context.Organization.Where(x => x.OrgMemberCode == OrgMemberCode.ToString()).FirstOrDefault();
                    }
                }
                Organization.OrgMemberCode = OrgMemberCode.ToString();
                _context.Organization.Add(Organization);
                await _context.SaveChangesAsync();


                PhysicalAddress.AddressTypeId = (int)AddressTypeEnum.Physical;
                PhysicalAddress.RelatedToId = (int)RelatedToEnum.Organization;
                PhysicalAddress.RelatedEntityId = Organization.Id;
                _context.Address.Add(PhysicalAddress);


                PostalAddress.AddressTypeId = (int)AddressTypeEnum.Postal;
                PostalAddress.RelatedToId = (int)RelatedToEnum.Organization;
                PostalAddress.RelatedEntityId = Organization.Id;
                _context.Address.Add(PostalAddress);

                foreach (var orgbusiness in OrganizationBusinessList)
                {
                    if (orgbusiness.IsSelected == true)
                    {
                        orgbusiness.OrganizationId = Organization.Id;
                        await _context.OrganizationBusinessXref.AddAsync(orgbusiness);
                    }
                }

                await UploadFiles(Documents, Organization.OrgMemberCode, Organization.Name, Organization.Id);

                await _context.SaveChangesAsync();


                string emailaddresses = EmailRecipients.GetEmailSenderList("NewNonIndividual", "NonIndividual", null, (int)RelatedToEnum.Organization, Organization.Id);

                await _emailCreator.SendEmailAsync("NewNonIndividual", emailaddresses, "Evelyn", "WISA: New Non Individual Joined", "New Non Individual",
                    Url.Page("/Manage/NonIndividual", pageHandler: null, values: new { id = Organization.Id }, protocol: Request.Scheme));

                return LocalRedirect("/new/EditNonIndividual?id=" + Organization.Id);

            }
            else
            {
                _logger.LogInformation(string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)));
                await SetViewData();
                return Page();

            }

        }


        public async Task UploadFiles(List<IFormFile> files, string memberUserCode,string OrganizationName, int memberUserId)
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
                    parentfolder = Convert.ToInt32(memberUserCode) / 1000 ;

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
