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
    public class CPDMembershipGradeSetUpModel : PageModel
    {
        private readonly ClientDbContext _context;
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<CPDMembershipGradeSetUpModel> _logger;
        private IActivity _activity;
        private string EntityName = "CPD Membership Type SetUp";

        public CPDMembershipGradeSetUpModel(ClientDbContext context, IAuthorizationService authorizationService, ILogger<CPDMembershipGradeSetUpModel> logger,
            UserManager<ApplicationUser> userManager, IActivity activity)
        {
            _context = context;
            _authorizationService = authorizationService;
            _userManager = userManager;
            _logger = logger;
            _activity = activity;
        }

        [BindProperty]
        public CpdMemberShipGradeSetUp CPDMembershipGradeSetUp { get; set; }

        [ViewData]
        public SelectList MembershipTypes { get; set; }

        [ViewData]
        public SelectList RelatedTos { get; set; }

        [BindProperty]
        public List<MemberShipGrade> MembershipTypeList { get; set; }

        [BindProperty]
        public List<RelatedTo> RelatedToList { get; set; }

        private string errorMessage;

        // called first time the page is loaded.
        public async Task<IActionResult> OnGetAsync()
        {
            MembershipTypeList = _context.MembershipGrade.ToList();
            MembershipTypes = new SelectList(MembershipTypeList, nameof(MemberShipGrade.Id), nameof(MemberShipGrade.Name));

            RelatedToList = _context.RelatedTo.ToList();
            RelatedTos = new SelectList(RelatedToList, nameof(RelatedTo.Id), nameof(RelatedTo.Name));

            await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Accessed + EntityName, UserTypeValues.Staff);
            return Page();
        }

        // called to load and refresh grid
        public IActionResult OnGetList()
        {
            var mtlist = _context.CPDMembershipGradeSetUp.Include(x => x.MembershipGrade).Include(x => x.RelatedTo).ToList();
            List <CPDMembershipGradeSetUpVM> CPDMembershipGradeSetUpVMList = new List<CPDMembershipGradeSetUpVM>();
           
            try
            {
                foreach (var CPDMembershipGradeSetUp in mtlist)
                {
                    CPDMembershipGradeSetUpVM mtVM = new CPDMembershipGradeSetUpVM
                    {
                        Id = CPDMembershipGradeSetUp.Id,
                        MembershipTypelId = CPDMembershipGradeSetUp.MembershipGrade.Id,
                        MembershipTypeName = CPDMembershipGradeSetUp.MembershipGrade.Name,
                        RelatedToId = CPDMembershipGradeSetUp.RelatedTo.Id,
                        RelatedToName = CPDMembershipGradeSetUp.RelatedTo.Name,
                        RelatedRecordId = CPDMembershipGradeSetUp.RelatedRecordId,
                        Cpdcount = CPDMembershipGradeSetUp.Cpdcount,
                    };
                    CPDMembershipGradeSetUpVMList.Add(mtVM);
                }
                return new JsonResult(CPDMembershipGradeSetUpVMList);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            return new JsonResult(new { success = false, message = "Error. Please check values entered "+ errorMessage });
        }

        public async Task<IActionResult>  OnGetSelectedRecordAsync(int id)
        {
            return new JsonResult(await _context.CPDMembershipGradeSetUp.Where(x=>x.Id==id).FirstOrDefaultAsync());
        }
    
        public async Task<IActionResult> OnPostSaveAsync(CpdMemberShipGradeSetUp CPDMembershipGradeSetUp)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new { success = false, message = "Error. Please check values entered" });
            }
            if (CPDMembershipGradeSetUp.Id > 0)
            {

                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Updated + EntityName + " Name: " + CPDMembershipGradeSetUp.Id, UserTypeValues.Staff);
                _context.Attach(CPDMembershipGradeSetUp).State = EntityState.Modified;
            }
            else
            {
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Added + EntityName + " Name: " + CPDMembershipGradeSetUp.Id, UserTypeValues.Staff);
                _context.CPDMembershipGradeSetUp.Add(CPDMembershipGradeSetUp);
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

            CPDMembershipGradeSetUp = await _context.CPDMembershipGradeSetUp.FindAsync(id);

            if (CPDMembershipGradeSetUp != null)
            {
                _context.CPDMembershipGradeSetUp.Remove(CPDMembershipGradeSetUp);
                await _context.SaveChangesAsync();
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Deleted + EntityName + " Name: " + CPDMembershipGradeSetUp.Id, UserTypeValues.Staff);
                return new JsonResult(new { success = true, message = "Deleted successfully" });
            }
            return new JsonResult(new { success = false, message = "No such record found to delete" });

        }
    }
}
