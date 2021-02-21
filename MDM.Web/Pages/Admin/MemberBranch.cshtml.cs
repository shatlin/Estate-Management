using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Policy = MMPolicies.AllowSetUp)]
    public class MemberBranchModel : PageModel
    {
        private readonly ClientDbContext _context;
        private readonly ILogger<MemberBranchModel> _logger;
        private IActivity _activity;
        private string EntityName = "Member Branch";

        public MemberBranchModel(ClientDbContext context, ILogger<MemberBranchModel> logger, IActivity activity)
        {
            _context = context;
            _activity = activity;
            _logger = logger;
        }



        [BindProperty]
        public MemberBranch MemberBranch { get; set; }

        [ViewData]
        public SelectList Organizations { get; set; }

        [BindProperty]
        public List<Organization> OrganizationList { get; set; }
        
        private string errorMessage;

        // called first time the page is loaded.
        public IActionResult OnGet()
        {
            OrganizationList = _context.Organization.ToList();
            Organizations = new SelectList(OrganizationList, nameof(Organization.Id), nameof(Organization.Name));
            return Page();
        }

        // called to load and refresh grid
        public async Task<IActionResult> OnGetListAsync()
        {
            var mblist = _context.MemberBranch.ToList();
            List <MemberBranchVM> MemberBranchVMList = new List<MemberBranchVM>();

            try
            {
                foreach (var memberBranch in mblist)
                {
                    MemberBranchVM mbVM = new MemberBranchVM
                    {
                        Id = memberBranch.Id,
                        Name = memberBranch.Name,
                        Description = memberBranch.Description,
                        
                        
                    };
                    MemberBranchVMList.Add(mbVM);
                }
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Accessed + EntityName, UserTypeValues.Staff);
                return new JsonResult(MemberBranchVMList);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            return new JsonResult(new { success = false, message = "Error. Please check values entered "+ errorMessage });
        }

        public async Task<IActionResult>  OnGetSelectedRecordAsync(int id)
        {
            return new JsonResult(await _context.MemberBranch.Where(x=>x.Id==id).FirstOrDefaultAsync());
        }
    
        public async Task<IActionResult> OnPostSaveAsync(MemberBranch MemberBranch)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new { success = false, message = "Error. Please check values entered" });
            }
            if (MemberBranch.Id > 0)
            {
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Updated + EntityName + " Name: " + MemberBranch.Name, UserTypeValues.Staff);
                _context.Attach(MemberBranch).State = EntityState.Modified;
            }
            else
            {
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Added + EntityName + " Name: " + MemberBranch.Name, UserTypeValues.Staff);
                _context.MemberBranch.Add(MemberBranch);
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

            MemberBranch = await _context.MemberBranch.FindAsync(id);

            if (MemberBranch != null)
            {
                _context.MemberBranch.Remove(MemberBranch);
                await _context.SaveChangesAsync();
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Deleted + EntityName + " Name: " + MemberBranch.Name, UserTypeValues.Staff);
                return new JsonResult(new { success = true, message = "Deleted successfully" });
            }
            return new JsonResult(new { success = false, message = "No such record found to delete" });

        }
    }
}
