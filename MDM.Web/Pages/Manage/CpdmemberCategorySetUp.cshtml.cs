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
    public class CPDMembershipTypeSetUpModel : PageModel
    {
        private readonly ClientDbContext _context;
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<CPDMembershipTypeSetUpModel> _logger;
        private IActivity _activity;
        private string EntityName = "CPD Membership Type SetUp";

        public CPDMembershipTypeSetUpModel(ClientDbContext context, IAuthorizationService authorizationService, ILogger<CPDMembershipTypeSetUpModel> logger,
            UserManager<ApplicationUser> userManager, IActivity activity)
        {
            _context = context;
            _authorizationService = authorizationService;
            _userManager = userManager;
            _logger = logger;
            _activity = activity;
        }



        [BindProperty]
        public CpdmembershipTypeSetUp CPDMembershipTypeSetUp { get; set; }

        [ViewData]
        public SelectList MemberCategories { get; set; }

        [ViewData]
        public SelectList RelatedTos { get; set; }

        [BindProperty]
        public List<MembershipType> MembershipTypeList { get; set; }

        [BindProperty]
        public List<RelatedTo> RelatedToList { get; set; }

        private string errorMessage;

        // called first time the page is loaded.
        public async Task<IActionResult> OnGetAsync()
        {
            MembershipTypeList = _context.MembershipType.ToList();
            MemberCategories = new SelectList(MembershipTypeList, nameof(MembershipType.Id), nameof(MembershipType.Name));

            RelatedToList = _context.RelatedTo.ToList();
            RelatedTos = new SelectList(RelatedToList, nameof(RelatedTo.Id), nameof(RelatedTo.Name));

            await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Accessed + EntityName, UserTypeValues.Staff);
            return Page();
        }

        // called to load and refresh grid
        public IActionResult OnGetList()
        {
            var mclist = _context.CPDMembershipTypeSetUp.Include(x => x.MembershipType).Include(x => x.RelatedTo).ToList();
            List <CPDMembershipTypeSetUpVM> CPDMembershipTypeSetUpVMList = new List<CPDMembershipTypeSetUpVM>();
           
            try
            {
                foreach (var CPDMembershipTypeSetUp in mclist)
                {
                    CPDMembershipTypeSetUpVM eeVM = new CPDMembershipTypeSetUpVM
                    {
                        Id = CPDMembershipTypeSetUp.Id,
                        MembershipTypeId = CPDMembershipTypeSetUp.MembershipType.Id,
                        MembershipTypeName = CPDMembershipTypeSetUp.MembershipType.Name,
                        RelatedToId = CPDMembershipTypeSetUp.RelatedTo.Id,
                        RelatedToName = CPDMembershipTypeSetUp.RelatedTo.Name,
                        RelatedRecordId = CPDMembershipTypeSetUp.RelatedRecordId,
                        Cpdcount = CPDMembershipTypeSetUp.Cpdcount,
                    };
                    CPDMembershipTypeSetUpVMList.Add(eeVM);
                }
                return new JsonResult(CPDMembershipTypeSetUpVMList);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            return new JsonResult(new { success = false, message = "Error. Please check values entered "+ errorMessage });
        }

        public async Task<IActionResult>  OnGetSelectedRecordAsync(int id)
        {
            return new JsonResult(await _context.CPDMembershipTypeSetUp.Where(x=>x.Id==id).FirstOrDefaultAsync());
        }
    
        public async Task<IActionResult> OnPostSaveAsync(CpdmembershipTypeSetUp CPDMembershipTypeSetUp)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new { success = false, message = "Error. Please check values entered" });
            }
            if (CPDMembershipTypeSetUp.Id > 0)
            {
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Updated + EntityName + " Name: " + CPDMembershipTypeSetUp.Id, UserTypeValues.Staff);
                _context.Attach(CPDMembershipTypeSetUp).State = EntityState.Modified;
            }
            else
            {
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Added + EntityName + " Name: " + CPDMembershipTypeSetUp.Id, UserTypeValues.Staff);
                _context.CPDMembershipTypeSetUp.Add(CPDMembershipTypeSetUp);
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

            CPDMembershipTypeSetUp = await _context.CPDMembershipTypeSetUp.FindAsync(id);

            if (CPDMembershipTypeSetUp != null)
            {
                _context.CPDMembershipTypeSetUp.Remove(CPDMembershipTypeSetUp);
                await _context.SaveChangesAsync();
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Deleted + EntityName + " Name: " + CPDMembershipTypeSetUp.Id, UserTypeValues.Staff);
                return new JsonResult(new { success = true, message = "Deleted successfully" });
            }
            return new JsonResult(new { success = false, message = "No such record found to delete" });

        }
    }
}
