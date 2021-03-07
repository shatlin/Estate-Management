using MDM.Helper;
using MDM.Models;
using MDM.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MDM.Pages.Admin
{
    public class TitleModel : PageBase
    {

        private readonly IAuthorizationService _authorizationService;

        public TitleModel(SignInManager<ApplicationUser> signInManager, ILogger<PageBase> logger, UserManager<ApplicationUser> userManager, DB db, IMemoryCache cache, IWebHostEnvironment env, IEmailCreator emailCreator, IConfiguration configuration, IActivity activity, IEmailRecipients emailRecipients, IAuthorizationService authorizationService) : base(signInManager, logger, userManager, db, cache, env, emailCreator, configuration, activity, emailRecipients)
        {
            _authorizationService = authorizationService;
            PageName = PageNames.titlesPage;
        }

        [BindProperty]
        public IList<Title> TitleList { get; set; }

        [BindProperty]
        public Title Title { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            TitleList = await _db.Title.ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnGetListAsync()
        {
           
            return new JsonResult(await _db.Title.ToListAsync());
        }

        public async Task<IActionResult> OnGetSelectedRecordAsync(int id)
        {
            return new JsonResult(await _db.Title.Where(x => x.Id == id).FirstOrDefaultAsync());
        }

        public async Task<IActionResult> OnPostSaveAsync(Title title)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new { success = false, message = MMMessages.Error_Please_check_values_entered });
            }
            var isAuthorized = await _authorizationService.AuthorizeAsync(User, MDMPolicies.AllowAdmin);

            if (!isAuthorized.Succeeded)
            {
                return new JsonResult(new { success = false, message = MMMessages.Authorization_failed });
            }

            if (title.Id > 0)
            {
              
                _db.Attach(title).State = EntityState.Modified;
            }
            else
            {
               
                _db.Title.Add(title);
            }
            await _db.SaveChangesAsync();
            return new JsonResult(new { success = true, message = MMMessages.SavedSuccessfully });
        }

        public async Task<IActionResult> OnGetDeleteAsync(int? id)
        {
            var isAuthorized = await _authorizationService.AuthorizeAsync(User, MDMPolicies.AllowAdmin);

            if (!isAuthorized.Succeeded)
            {
                return new JsonResult(new { success = false, MMMessages.Authorization_failed });
            }
            if (id == null)
            {
                return new JsonResult(new { success = false, MMMessages.NoRecordToDelete });
            }
            Title = await _db.Title.FindAsync(id);

            if (Title != null)
            {
                _db.Title.Remove(Title);
                await _db.SaveChangesAsync();
          
                return new JsonResult(new { success = true, message = MMMessages.DeletedSuccessfully });
            }
            return new JsonResult(new { success = false, message = MMMessages.NoRecordToDelete });
        }
    }
}
