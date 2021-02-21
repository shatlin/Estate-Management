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
    public class MembershipGradeModel : PageModel
    {
        private readonly ClientDbContext _context;
        private readonly ILogger<MembershipGradeModel> _logger;
        private IActivity _activity;
        private string EntityName = "Membership Grade";

        public MembershipGradeModel(ClientDbContext context, ILogger<MembershipGradeModel> logger, IActivity activity)
        {
            _context = context;
            _activity = activity;
            _logger = logger;
        }



        [BindProperty]
        public MemberShipGrade MembershipGrade { get; set; }

        
      //  private string errorMessage;

        // called first time the page is loaded.
        public IActionResult OnGet()
        {
       
            return Page();
        }

        // called to load and refresh grid
        public async Task<IActionResult> OnGetListAsync()
        {
            var mclist = _context.MembershipGrade.ToList();
            await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Accessed + EntityName, UserTypeValues.Staff);
            return new JsonResult(_context.MembershipGrade.ToList());
        }

        public async Task<IActionResult>  OnGetSelectedRecordAsync(int id)
        {
            return new JsonResult(await _context.MembershipGrade.Where(x=>x.Id==id).FirstOrDefaultAsync());
        }
    
        public async Task<IActionResult> OnPostSaveAsync(MemberShipGrade MembershipGrade)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new { success = false, message = "Error. Please check values entered" });
            }
            if (MembershipGrade.Id > 0)
            {
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Updated + EntityName + " Name: " + MembershipGrade.Name, UserTypeValues.Staff);
                _context.Attach(MembershipGrade).State = EntityState.Modified;
            }
            else
            {
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Added + EntityName + " Name: " + MembershipGrade.Name, UserTypeValues.Staff);
                _context.MembershipGrade.Add(MembershipGrade);
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

            MembershipGrade = await _context.MembershipGrade.FindAsync(id);

            if (MembershipGrade != null)
            {
                _context.MembershipGrade.Remove(MembershipGrade);
                await _context.SaveChangesAsync();
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Deleted + EntityName + " Name: " + MembershipGrade.Name, UserTypeValues.Staff);
                return new JsonResult(new { success = true, message = "Deleted successfully" });
            }
            return new JsonResult(new { success = false, message = "No such record found to delete" });

        }
    }
}
