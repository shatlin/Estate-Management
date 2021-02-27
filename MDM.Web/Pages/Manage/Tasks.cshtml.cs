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

namespace MDM.Pages.Manage
{
    
    public class TasksModel :  PageBase
    {

        public TasksModel(SignInManager<ApplicationUser> signInManager,
         ILogger<PageBase> logger,
         UserManager<ApplicationUser> userManager, DB db, IMemoryCache cache, IWebHostEnvironment env, IEmailCreator emailCreator, IConfiguration configuration, IActivity activity, EmailRecipients emailRecipients) : base(signInManager,
          logger, userManager, db, cache, env, emailCreator, configuration, activity, emailRecipients)
        {
            PageName = PageNames.HomePage;
        }

        [BindProperty]
        public TaskItem taskItem { get; set; }

      
        public void GetLookups()
        {
            ViewData[Lookups.priorities] = _cache.GetOrCreate(
         Lookups.priorities, c => { return new SelectList(_db.Priority.ToList(), nameof(Priority.Id), nameof(Priority.Name)); });

            ViewData[Lookups.categories] = _cache.GetOrCreate(
            Lookups.categories, c => { return new SelectList(_db.Category.ToList(), nameof(Category.Id), nameof(Category.Name)); });

            ViewData[Lookups.taskitemtypes] = _cache.GetOrCreate(
            Lookups.taskitemtypes, c => { return new SelectList(_db.TaskItemType.ToList(), nameof(TaskItemType.Id), nameof(TaskItemType.Name)); });
        }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
          
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
            taskItem.StatusId=StatusValues.Open;
            taskItem.UserId=User.GetUserId();
            taskItem.UnitId= _db.SystemUser.FirstOrDefault(x => x.ApplicationUserId == taskItem.UserId).UnitId;
           _db.Add(taskItem);
           _db.SaveChanges();
            GetLookups();
            notification = new Notification { message = "Ticket Raised Successfully. Ticket No "+ taskItem.Id, notificationtype = NotificationTypeValues.success };

            var emailaddresses = _emailRecipients.GetEmailSenderList("NewTaskItem", "Tenant", User.GetEmail());

            await _emailCreator.SendEmailAsync("NewTaskItem", emailaddresses, "Trustees",  taskItem.Name, "View Ticket",
                 Url.Page("/Manage/Tasks", pageHandler: null, values: new { id = taskItem.Id }, protocol: Request.Scheme));

            return Page();
        }


    }
}
