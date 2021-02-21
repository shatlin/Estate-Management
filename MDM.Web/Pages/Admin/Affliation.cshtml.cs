using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
    public class AffliationModel : PageModel
    {
        private readonly ClientDbContext _context;
        private readonly ILogger<AffliationModel> _logger;
        private IActivity _activity;
        private string EntityName = "Affliation";

        public AffliationModel(ClientDbContext context, ILogger<AffliationModel> logger, IActivity activity)
        {
            _context = context;
            _activity = activity;
            _logger = logger;
        }

        [BindProperty]
        public IList<Affliation> AffliationList { get; set; }

        [BindProperty]
        public Affliation Affliation { get; set; }

        public async Task<IActionResult> OnGetListAsync()
        {
            await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Accessed + EntityName, UserTypeValues.Staff);
            return new JsonResult(await _context.Affliation.ToListAsync());
        }

        public async Task<IActionResult> OnGetSelectedRecordAsync(int id)
        {
            return new JsonResult(await _context.Affliation.Where(x => x.Id == id).FirstOrDefaultAsync());
        }


        public async Task<IActionResult> OnPostSaveAsync(Affliation Affliation)
        {
            
            if (!ModelState.IsValid)
            {
                return new JsonResult(new { success = false, message = "Error. Please check values entered" });
            }


            if (Affliation.Id > 0)
            {
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Updated + EntityName + " Name: " + Affliation.Name, UserTypeValues.Staff);
                _context.Attach(Affliation).State = EntityState.Modified;
            }
            else
            {
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Added + EntityName  + " Name: " + Affliation.Name, UserTypeValues.Staff);
                _context.Affliation.Add(Affliation);
            }
            await _context.SaveChangesAsync();
            
            return new JsonResult(new { success = true, message = "Saved successfully" });


        }

        public async Task<IActionResult> OnGetDeleteAsync(int? id)
        {

            if (id == null)
            {
                return new JsonResult(new { success = false, message = "No such record found to delete" });
            }

            Affliation = await _context.Affliation.FindAsync(id);

            if (Affliation != null)
            {
                _context.Affliation.Remove(Affliation);
                await _context.SaveChangesAsync();
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Deleted + EntityName + " Name: " + Affliation.Name, UserTypeValues.Staff);
                return new JsonResult(new { success = true, message = "Deleted successfully" });
            }
            return new JsonResult(new { success = false, message = "No such record found to delete" });

        }
    }
}
