using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MM.ClientModels;
using MM.Helper;
using Newtonsoft.Json;
using WISA.Services;

namespace MM.Pages.Client
{
    [Authorize(Policy = MMPolicies.AllowUserAccess)]
    public class CpdmemberLevelSetUpModel : PageModel
    {
        private readonly ClientDbContext _context;
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<CpdmemberLevelSetUpModel> _logger;
        private IActivity _activity;
        private string EntityName = "CPD Member Level SetUp";

        public CpdmemberLevelSetUpModel(ClientDbContext context, IAuthorizationService authorizationService, ILogger<CpdmemberLevelSetUpModel> logger,
            UserManager<ApplicationUser> userManager, IActivity activity)
        {
            _context = context;
            _authorizationService = authorizationService;
            _userManager = userManager;
            _logger = logger;
            _activity = activity;
        }



        [BindProperty]
        public CpdmemberLevelSetUp CpdmemberLevelSetUp { get; set; }

        [ViewData]
        public SelectList MemberLevels { get; set; }

        [ViewData]
        public SelectList RelatedTos { get; set; }

        [BindProperty]
        public List<MemberLevel> MemberLevelList { get; set; }

        [BindProperty]
        public List<RelatedTo> RelatedToList { get; set; }

        private string errorMessage;

        // called first time the page is loaded.
        public async Task<IActionResult> OnGetAsync()
        {
            MemberLevelList = _context.MemberLevel.ToList();
            MemberLevels = new SelectList(MemberLevelList, nameof(MemberLevel.Id), nameof(MemberLevel.Name));

            RelatedToList = _context.RelatedTo.ToList();
            RelatedTos = new SelectList(RelatedToList, nameof(RelatedTo.Id), nameof(RelatedTo.Name));

            await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Accessed + EntityName, UserTypeValues.Staff);
            return Page();
        }

        // called to load and refresh grid
        public IActionResult OnGetList()
        {
            var mllist = _context.CpdmemberLevelSetUp.Include(x => x.MemberLevel).Include(x => x.RelatedTo).ToList();
            List <CpdmemberLevelSetUpVM> CpdmemberLevelSetUpVMList = new List<CpdmemberLevelSetUpVM>();
           
            try
            {
                foreach (var cpdmemberLevelSetUp in mllist)
                {
                    CpdmemberLevelSetUpVM mlVM = new CpdmemberLevelSetUpVM
                    {
                        Id = CpdmemberLevelSetUp.Id,
                        MemberLevelId = cpdmemberLevelSetUp.MemberLevel.Id,
                        MemberLevelName = cpdmemberLevelSetUp.MemberLevel.Name,
                        RelatedToId = cpdmemberLevelSetUp.RelatedTo.Id,
                        RelatedToName = cpdmemberLevelSetUp.RelatedTo.Name,
                        RelatedRecordId = cpdmemberLevelSetUp.RelatedRecordId,
                        Cpdcount = cpdmemberLevelSetUp.Cpdcount,
                    };
                    CpdmemberLevelSetUpVMList.Add(mlVM);
                }
                return new JsonResult(CpdmemberLevelSetUpVMList);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            return new JsonResult(new { success = false, message = "Error. Please check values entered "+ errorMessage });
        }

        public async Task<IActionResult>  OnGetSelectedRecordAsync(int id)
        {
            return new JsonResult(await _context.CpdmemberLevelSetUp.Where(x=>x.Id==id).FirstOrDefaultAsync());
        }
    
        public async Task<IActionResult> OnPostSaveAsync(CpdmemberLevelSetUp CpdmemberLevelSetUp)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new { success = false, message = "Error. Please check values entered" });
            }
            if (CpdmemberLevelSetUp.Id > 0)
            {
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Updated + EntityName + " Name: " + CpdmemberLevelSetUp.Id, UserTypeValues.Staff);
                _context.Attach(CpdmemberLevelSetUp).State = EntityState.Modified;
            }
            else
            {
                
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Added + EntityName + " Name: " + CpdmemberLevelSetUp.Id, UserTypeValues.Staff);
                _context.CpdmemberLevelSetUp.Add(CpdmemberLevelSetUp);
            }
             await _context.SaveChangesAsync();
            return new JsonResult( new { success = true, message = "Saved successfully" });
        }

         public async Task<IActionResult> OnGetDeleteAsync(int? id)
        {

            if (id == null)
            {
                return new JsonResult(new { success = false, message = "No such record found to delete" });
            }

            CpdmemberLevelSetUp = await _context.CpdmemberLevelSetUp.FindAsync(id);

            if (CpdmemberLevelSetUp != null)
            {
                _context.CpdmemberLevelSetUp.Remove(CpdmemberLevelSetUp);
                await _context.SaveChangesAsync();
                return new JsonResult(new { success = true, message = "Deleted successfully" });
            }
            await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Deleted + EntityName + " Name: " + CpdmemberLevelSetUp.Id, UserTypeValues.Staff);
            return new JsonResult(new { success = false, message = "No such record found to delete" });

        }
    }
}
