using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MM.ClientModels;


namespace MM.Pages.Client
{
    public class MemberUserModel : PageModel
    {
        private readonly ClientDbContext _clientDbContext;

        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<MemberUserModel> _logger;
        private readonly IEmailSender _emailSender;
       
        public MemberUserModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<MemberUserModel> logger, RoleManager<ApplicationRole> roleManager,
            IEmailSender emailSender,  ClientDbContext clientDbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _clientDbContext = clientDbContext;
            _roleManager = roleManager;
        }

        [BindProperty]
        public MemberUserVM MemberUserVM { get; set; }



        [ViewData]
        public SelectList Titles { get; set; }

        [ViewData]
        public SelectList Genders { get; set; }

        [ViewData]
        public SelectList MemBranches { get; set; }

        [ViewData]
        public SelectList Orgs { get; set; }

        [ViewData]
        public SelectList Referrals { get; set; }

        [ViewData]
        public SelectList OrgStructures { get; set; }

        [ViewData]
        public SelectList MemStatus { get; set; }

        [ViewData]
        public SelectList MemLevels { get; set; }

        [ViewData]
        public SelectList MemTeams { get; set; }

        [ViewData]
        public SelectList MemTypes { get; set; }

          [ViewData]
        public SelectList HighestQualifications { get; set; }

        [BindProperty]
        public List<ApplicationUser> AppUsersList { get; set; }

        //public List<Organization> OrgsList { get; set; }
        //public List<ReferralType> ReferralsList { get; set; }
        //public List<OrganizationStructure> OrgStructuresList { get; set; }
        //public List<MemberStatus> MemStatusList { get; set; }
        //public List<MemberLevel> MemLevelsList { get; set; }
        //public List<MemberTeam> MemTeamsList { get; set; }
        //public List<MembershipType> MemTypesList { get; set; }


        private string errorMessage;

        // called first time the page is loaded.
        public IActionResult OnGet()
        {
            //AppUsersList = _context.ApplicationUser.ToList();
            //AppUsers = new SelectList(AppUsersList, nameof(ApplicationUser.Id), nameof(ApplicationUser.FirstName));

            //List<MemberBranch> MemBranchesList = ;
            //ViewData["ApplicaitonUserId"] = new SelectList(_clientDbContext.Users, "Id", "Id");
            //ViewData["TitleId"] = new SelectList(_clientDbContext.Title, "Id", "Name");
            //ViewData["GenderId"] = new SelectList(_clientDbContext.Gender, "Id", "Name");
            //ViewData["MemberBranchId"] = new SelectList(_clientDbContext.MemberBranch, "Id", "Name");
            //ViewData["Organization"] = new SelectList(_clientDbContext.Organization, "Id", "Name");

            Titles = new SelectList(_clientDbContext.Title.ToList(), nameof(Title.Id), nameof(Title.Name));
            
            Genders = new SelectList(_clientDbContext.Gender.ToList(), nameof(Gender.Id), nameof(Gender.Name));

            MemBranches = new SelectList(_clientDbContext.MemberBranch.ToList(), nameof(MemberBranch.Id), nameof(MemberBranch.Name));

            //OrgsList = ;
            Orgs = new SelectList(_clientDbContext.Organization.ToList(), nameof(Organization.Id), nameof(Organization.Name));

            //ReferralsList = ;
            Referrals = new SelectList(_clientDbContext.ReferralType.ToList(), nameof(ReferralType.Id), nameof(ReferralType.Name));

            //OrgStructuresList = ;
            OrgStructures = new SelectList(_clientDbContext.OrganizationStructure.ToList(), nameof(OrganizationStructure.Id), nameof(OrganizationStructure.Name));

            //MemStatusList = ;
            MemStatus = new SelectList(_clientDbContext.MemberStatus.ToList(), nameof(MemberStatus.Id), nameof(MemberStatus.Name));

            //MemLevelsList = ;
            MemLevels = new SelectList(_clientDbContext.MemberLevel.ToList(), nameof(MemberLevel.Id), nameof(MemberLevel.Name));

            //MemTeamsList = ;
            MemTeams = new SelectList(_clientDbContext.MemberTeam.ToList(), nameof(MemberTeam.Id), nameof(MemberTeam.Name));

            //MemTypesList = ;
            MemTypes = new SelectList(_clientDbContext.MembershipType.ToList(), nameof(MemberShipType.Id), nameof(MemberShipType.Name));

            //MemTypesList = ;
            MemTypes = new SelectList(_clientDbContext.Qualification.ToList(), nameof(Qualification.Id), nameof(Qualification.Name));


            return Page();
        }

        // called to load and refresh grid
        public IActionResult OnGetList()
        {
            var mulist = _clientDbContext.MemberUser.Include(x => x.ApplicationUser).Include(x => x.Organization).Include(x => x.ReferralType).Include
                                                    (x => x.MemberBranch).Include(x => x.OrganizationStructure).Include(x => x.MemberStatus).Include
                                                    (x => x.MemberLevel).Include(x => x.MemberTeam).Include(x => x.MembershipType).ToList();
            List<MemberUserVM> MemberUserVMList = new List<MemberUserVM>();

            try
            {
                foreach (var memberUser in mulist)
                {
                    MemberUserVM muVM = new MemberUserVM
                    {
                        Id = memberUser.Id,
                        ApplicaitonUserId = memberUser.ApplicationUser.Id,
                        Email = memberUser.ApplicationUser.Email,
                        PhoneNumber = memberUser.ApplicationUser.PhoneNumber,
                        FirstName = memberUser.ApplicationUser.FirstName,
                        MiddleName = memberUser.ApplicationUser.MiddleName,
                        LastName = memberUser.ApplicationUser.LastName,
                        OrganizationId = memberUser.Organization.Id,
                        OrganizationName = memberUser.Organization.Name,
                        ReferralTypeId = memberUser.ReferralType.Id,
                        ReferralTypeName = memberUser.ReferralType.Name,
                        OrganizationStructureId = memberUser.OrganizationStructure.Id,
                        OrganizationStructureName = memberUser.OrganizationStructure.Name,
                        MemberBranchId = memberUser.MemberBranch.Id,
                        MemberBranchName = memberUser.MemberBranch.Name,
                        MemberStatusId = memberUser.MemberStatus.Id,
                        MemberStatusName = memberUser.MemberStatus.Name,
                        MemberLevelId = memberUser.MemberLevel.Id,
                        MemberLevelName = memberUser.MemberLevel.Name,
                        MemberTeamId = memberUser.MemberTeam.Id,
                        MemberTeamName = memberUser.MemberTeam.Name,
                        MembershipTypeId = memberUser.MembershipType.Id,
                        MembershipTypeName = memberUser.MembershipType.Name,
                        MemberCode = memberUser.MemberCode,
                        Photo = memberUser.Photo,
                        Notes = memberUser.Notes,
                    };
                    MemberUserVMList.Add(muVM);
                }
                return new JsonResult(MemberUserVMList);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            return new JsonResult(new { success = false, message = "Error. Please check values entered " + errorMessage });
        }

        public async Task<IActionResult> OnGetSelectedRecordAsync(int id)
        {
            return new JsonResult(await _clientDbContext.MemberUser.Where(x => x.Id == id).FirstOrDefaultAsync());
        }

        public async Task<IActionResult> OnPostSaveAsync()
        //public IActionResult OnPostSave()
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new { success = false, message = "Error. Please check values entered" });
            }
            if (MemberUserVM.Id > 0)
            {
                _clientDbContext.Attach(MemberUserVM).State = EntityState.Modified;
            }
            else
            {
                ApplicationUser AppUser = new ApplicationUser();
                AppUser.UserName = MemberUserVM.Email;
                AppUser.UserTypeId = 2;
                AppUser.TitleId = MemberUserVM.TitleId;
                AppUser.FirstName = MemberUserVM.FirstName;
                AppUser.MiddleName = MemberUserVM.MiddleName;
                AppUser.LastName = MemberUserVM.LastName;
                AppUser.Email = MemberUserVM.Email;
                AppUser.Pwd = MemberUserVM.Pwd;
                AppUser.GenderId = MemberUserVM.GenderId;
                AppUser.BirthDay = MemberUserVM.BirthDay;
                AppUser.PhoneNumber = MemberUserVM.PhoneNumber;


                var result = await _userManager.CreateAsync(AppUser, AppUser.Pwd);
                MemberUser memUser = new MemberUser();
                if (result.Succeeded)
                {
                    memUser.ApplicaitonUserId = AppUser.Id;
                    memUser.OrganizationId = MemberUserVM.OrganizationId;
                    memUser.OrganizationStructureId = MemberUserVM.OrganizationStructureId;
                    memUser.MemberBranchId = MemberUserVM.MemberBranchId;
                    memUser.MemberStatusId = MemberUserVM.MemberStatusId;
                    memUser.MemberLevelId = MemberUserVM.MemberLevelId;
                    memUser.MemberTeamId = MemberUserVM.MemberTeamId;
                    memUser.MembershipTypeId = MemberUserVM.MembershipTypeId;
                    memUser.IsBranchContact = MemberUserVM.IsBranchContact;
                    memUser.IsBillingContact = MemberUserVM.IsBillingContact;
                    memUser.TermAccepted = MemberUserVM.TermAccepted;
                    memUser.IsActive = MemberUserVM.IsActive;
                    memUser.ReferralTypeId = MemberUserVM.ReferralTypeId;
                    memUser.MemberCode = MemberUserVM.MemberCode;
                    memUser.Photo = MemberUserVM.Photo;
                    memUser.Notes = MemberUserVM.Notes;
                    _clientDbContext.MemberUser.Add(memUser);
                }
                    
                
            }
            await _clientDbContext.SaveChangesAsync();
            return new JsonResult(new { success = true, message = "Saved successfully" });
        }

        public async Task<IActionResult> OnGetDeleteAsync(int? id)
        {

            if (id == null)
            {
                return new JsonResult(new { success = false, message = "No such record found to delete" });
            }

           // MemberUserVM = await _context.MemberUser.FindAsync(id);

            if (MemberUserVM != null)
            {
              //  _context.MemberUser.Remove(MemberUserVM);
                await _clientDbContext.SaveChangesAsync();
                return new JsonResult(new { success = true, message = "Deleted successfully" });
            }
            return new JsonResult(new { success = false, message = "No such record found to delete" });

        }
    }
}
