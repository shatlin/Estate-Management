using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MDM.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Mvc.Rendering;
using MDM.Helper;
using Microsoft.AspNetCore.Hosting;
using MDM.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace MDM.Pages.Manage
{
    
    public class TasksTryModel :  PageBase
    {

        public TasksTryModel(SignInManager<ApplicationUser> signInManager,
         ILogger<PageBase> logger,
         UserManager<ApplicationUser> userManager, DB db, IMemoryCache cache, IWebHostEnvironment env, IEmailCreator emailCreator, IConfiguration configuration, IActivity activity, IEmailRecipients emailRecipients) : base(signInManager,
          logger, userManager, db, cache, env, emailCreator, configuration, activity, emailRecipients)
        {
            PageName = PageNames.HomePage;
        }

        [BindProperty]
        public List<TaskItem> taskItems { get; set; }

        [BindProperty]
        public List<Group> groups { get; set; }

        public void GetLookups()
        {
            ViewData[Lookups.priorities] = _cache.GetOrCreate(
         Lookups.priorities, c => { return new SelectList(_db.Priority.ToList(), nameof(Priority.Id), nameof(Priority.Name)); });

            ViewData[Lookups.categories] = _cache.GetOrCreate(
            Lookups.categories, c => { return new SelectList(_db.Category.ToList(), nameof(Category.Id), nameof(Category.Name)); });

            ViewData[Lookups.taskitemtypes] = _cache.GetOrCreate(
            Lookups.taskitemtypes, c => { return new SelectList(_db.TaskItemType.ToList(), nameof(TaskItemType.Id), nameof(TaskItemType.Name)); });
            groups= _cache.GetOrCreate(Lookups.groups, c => { return _db.Group.ToList(); });
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
      
            taskItems=_db.TaskItem.Include(x => x.Group).Include(x=>x.Status).Where(x=>x.Status.Name=="Open").ToList();

            GetLookups();
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                return Page();
            }
                return LocalRedirect("/Account/Login");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            GetLookups();
            notification = new Notification { message = " Message ", notificationtype = NotificationTypeValues.success };
            return Page();
        }
    }
}
