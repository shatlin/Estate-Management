using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MM.ClientModels;
using MM.Helper;
using WISA.Services;

namespace MM.Pages.Client
{
    [Authorize(Policy = MMPolicies.AllowSetUp)]
    public class MemberLevelModel : PageModel
    {
        private readonly ClientDbContext _context;
        private readonly ILogger<MemberLevelModel> _logger;
        private IActivity _activity;
        private string EntityName = "Member Level";

        public MemberLevelModel(ClientDbContext context, ILogger<MemberLevelModel> logger, IActivity activity)
        {
            _context = context;
            _activity = activity;
            _logger = logger;
        }

        [BindProperty]
        public IList<MemberLevel> MemberLevelList { get;set; }

        [BindProperty]
        public MemberLevel MemberLevel { get; set; }

        public async Task<IActionResult> OnGetListAsync()
        {
            await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Accessed + EntityName, UserTypeValues.Staff);
            return new JsonResult(await _context.MemberLevel.ToListAsync());
        }

        public async Task<IActionResult>  OnGetSelectedRecordAsync(int id)
        {
            return new JsonResult(await _context.MemberLevel.Where(x=>x.Id==id).FirstOrDefaultAsync());
        }
    
 
        public async Task<IActionResult> OnPostSaveAsync(MemberLevel MemberLevel)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new { success = false, message = "Error. Please check values entered" });
            }

            if (MemberLevel.Id > 0)
            {
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Updated + EntityName + " Name: " + MemberLevel.Name, UserTypeValues.Staff);
                _context.Attach(MemberLevel).State = EntityState.Modified;
            }
            else
            {
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Added + EntityName + " Name: " + MemberLevel.Name, UserTypeValues.Staff);
                _context.MemberLevel.Add(MemberLevel);
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

            MemberLevel = await _context.MemberLevel.FindAsync(id);

            if (MemberLevel != null)
            {
                _context.MemberLevel.Remove(MemberLevel);
                await _context.SaveChangesAsync();
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Deleted + EntityName + " Name: " + MemberLevel.Name, UserTypeValues.Staff);
                return new JsonResult(new { success = true, message = "Deleted successfully" });
            }
            return new JsonResult(new { success = false, message = "No such record found to delete" });

        }
    }
}
