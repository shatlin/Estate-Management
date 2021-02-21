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
using MDM.Models;
using MDM.Helper;
using MDM.Services;

namespace MDM.Pages.Client
{
    [Authorize(Policy = MDMPolicies.AllowSetUp)]
    public class RelatedToModel : PageModel
    {
        private readonly DB _context;
        private readonly ILogger<RelatedToModel> _logger;
        private IActivity _activity;
        private string EntityName = "Affliation";

        public RelatedToModel(DB context, ILogger<RelatedToModel> logger, IActivity activity)
        {
            _context = context;
            _activity = activity;
            _logger = logger;
        }

        [BindProperty]
        public IList<RelatedTo> RelatedToList { get;set; }

        [BindProperty]
        public RelatedTo RelatedTo { get; set; }

        public async Task<IActionResult> OnGetListAsync()
        {
            await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Accessed + EntityName, UserTypeValues.Staff);
            return new JsonResult(await _context.RelatedTo.ToListAsync());
        }

        public async Task<IActionResult>  OnGetSelectedRecordAsync(int id)
        {
            return new JsonResult(await _context.RelatedTo.Where(x=>x.Id==id).FirstOrDefaultAsync());
        }
    
 
        public async Task<IActionResult> OnPostSaveAsync(RelatedTo RelatedTo)
        {

            if (!ModelState.IsValid)
            {
                return new JsonResult(new { success = false, message = "Error. Please check values entered" });
            }

            if (RelatedTo.Id > 0)
            {
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Updated + EntityName + " Name: " + RelatedTo.Name, UserTypeValues.Staff);
                _context.Attach(RelatedTo).State = EntityState.Modified;
            }
            else
            {
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Added + EntityName + " Name: " + RelatedTo.Name, UserTypeValues.Staff);
                _context.RelatedTo.Add(RelatedTo);
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

            RelatedTo = await _context.RelatedTo.FindAsync(id);

            if (RelatedTo != null)
            {
                _context.RelatedTo.Remove(RelatedTo);
                await _context.SaveChangesAsync();
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Deleted + EntityName + " Name: " + RelatedTo.Name, UserTypeValues.Staff);
                return new JsonResult(new { success = true, message = "Deleted successfully" });
            }
            return new JsonResult(new { success = false, message = "No such record found to delete" });

        }
    }
}
