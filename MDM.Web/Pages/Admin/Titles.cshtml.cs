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
    public class TitleModel : PageModel
    {
        private DB _context;
        private readonly ILogger<TitleModel> _logger;
        private IActivity _activity;
        private string EntityName = "Title";
        private readonly IAuthorizationService _authorizationService;

        public TitleModel(DB context, IAuthorizationService authorizationService, ILogger<TitleModel> logger, IActivity activity)
        {
            _context = context;
            _authorizationService = authorizationService;
            _activity = activity;
            _logger = logger;
        }

        [BindProperty]
        public IList<Title> TitleList { get; set; }

        [BindProperty]
        public Title Title { get; set; }

        public async Task<IActionResult> OnGetListAsync()
        {
            await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Accessed + EntityName, UserTypeValues.Staff);
            return new JsonResult(await _context.Title.ToListAsync());
        }

        public async Task<IActionResult> OnGetSelectedRecordAsync(int id)
        {
            return new JsonResult(await _context.Title.Where(x => x.Id == id).FirstOrDefaultAsync());
        }

        public async Task<IActionResult> OnPostSaveAsync(Title title)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new { success = false, message = MMMessages.Error_Please_check_values_entered });
            }
            var isAuthorized = await _authorizationService.AuthorizeAsync(User, MDMPolicies.AllowSetupUpdate);

            if (!isAuthorized.Succeeded)
            {
                return new JsonResult(new { success = false, message = MMMessages.Authorization_failed });
            }

            if (title.Id > 0)
            {
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Updated + EntityName + " Name: " + Title.Name, UserTypeValues.Staff);
                _context.Attach(title).State = EntityState.Modified;
            }
            else
            {
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Added + EntityName + " Name: " + Title.Name, UserTypeValues.Staff);
                _context.Title.Add(title);
            }
            await _context.SaveChangesAsync();
            return new JsonResult(new { success = true, message = MMMessages.SavedSuccessfully });
        }

        public async Task<IActionResult> OnGetDeleteAsync(int? id)
        {
            var isAuthorized = await _authorizationService.AuthorizeAsync(User, MDMPolicies.AllowSetupDelete);

            if (!isAuthorized.Succeeded)
            {
                return new JsonResult(new { success = false, MMMessages.Authorization_failed });
            }
            if (id == null)
            {
                return new JsonResult(new { success = false, MMMessages.NoRecordToDelete });
            }
            Title = await _context.Title.FindAsync(id);

            if (Title != null)
            {
                _context.Title.Remove(Title);
                await _context.SaveChangesAsync();
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Deleted + EntityName + " Name: " + Title.Name, UserTypeValues.Staff);
                return new JsonResult(new { success = true, message = MMMessages.DeletedSuccessfully });
            }
            return new JsonResult(new { success = false, message = MMMessages.NoRecordToDelete });
        }
    }
}
