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
using Microsoft.AspNetCore.Http;
using System.IO;

namespace MDM.Pages
{
    
    public class NewTicketModel :  PageBase
    {

        public NewTicketModel(SignInManager<ApplicationUser> signInManager,
           ILogger<PageBase> logger,
           UserManager<ApplicationUser> userManager, DB db, IMemoryCache cache, IWebHostEnvironment env, IEmailCreator emailCreator, IConfiguration configuration, IActivity activity,IEmailRecipients emailRecipients) : base(signInManager,
            logger,userManager,db, cache,env,emailCreator,configuration,activity, emailRecipients)
        {
            PageName= PageNames.HomePage;
        }

        [BindProperty]
        public TaskItem taskItem { get; set; }

        [BindProperty]
        public List<IFormFile> TicketFiles { get; set; }

        public void GetLookups()
        {
             ViewData[Lookups.priorities] = _cache.GetOrCreate(
             Lookups.priorities, c => { return new SelectList(_db.Priority.ToList(), nameof(Priority.Id), nameof(Priority.Name)); });

            ViewData[Lookups.categories] = _cache.GetOrCreate(
            Lookups.categories, c => { return new SelectList(_db.Category.ToList(), nameof(Category.Id), nameof(Category.Name)); });

            ViewData[Lookups.taskitemtypes] = _cache.GetOrCreate(
            Lookups.taskitemtypes, c => { return new SelectList(_db.TaskItemType.ToList(), nameof(TaskItemType.Id), nameof(TaskItemType.Name)); });
        }
        public async Task<IActionResult> OnGetAsync()
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
            taskItem.GroupId = GroupValues.Maintenance;
            taskItem.UnitId= _db.SystemUser.FirstOrDefault(x => x.ApplicationUserId == taskItem.UserId).UnitId;
           _db.Add(taskItem);
           _db.SaveChanges();
            GetLookups();
           
            var emailaddresses = _emailRecipients.GetEmailSenderList("NewTicket", "Tenant", User.GetEmail());

            await _emailCreator.SendEmailAsync("NewTicket", emailaddresses, "Trustees",  taskItem.Name, "View Ticket",
                 Url.Page("/Manage/Tasks", pageHandler: null, values: new { id = taskItem.Id }, protocol: Request.Scheme));

            notification = new Notification { message = "Ticket Raised Successfully. Ticket No " + taskItem.Id, notificationtype = NotificationTypeValues.success };
            await UploadFiles(TicketFiles, FileTypevalues.Ticket, taskItem);
            return Page();
        }

        public async Task UploadFiles(List<IFormFile> files, int? filetype, TaskItem taskItem)
        {
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    string file = string.Empty;
                    if (formFile.FileName.Length > 150)
                    {
                        file = formFile.FileName.Substring(formFile.FileName.Length - (formFile.FileName.Length - 150));
                    }
                    else
                    {
                        file = formFile.FileName;
                    }

                    var filePath = Path.Combine(_env.ContentRootPath + _configuration["StoredFilesPath"], "Tickets", "Unit "+taskItem.UnitId.ToString(), taskItem.Id.ToString());
                    if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);
                    filePath = Path.Combine(filePath, file);

                    if (System.IO.File.Exists(filePath)) System.IO.File.Delete(filePath);
                    var filepathToStore = Path.Combine("Tickets", "Unit " + taskItem.UnitId.ToString(), taskItem.Id.ToString(), file);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                        TaskItemFile taskItemFile = new TaskItemFile();
                        taskItemFile.TaskItemId = taskItem.Id;
                        taskItemFile.FilePath = filepathToStore;
                        taskItemFile.FileName = file;
                        taskItemFile.FileTypeId = filetype;
                        await _db.TaskItemFile.AddAsync(taskItemFile);
                    }
                }
            }


            await _db.SaveChangesAsync();
        }


    }
}
