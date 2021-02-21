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
    public class EmailTemplateContentModel : PageModel
    {
        private readonly ClientDbContext _context;
        private readonly ILogger<EmailTemplateContentModel> _logger;
        private IActivity _activity;
        private string EntityName = "Email Template Content";

        public EmailTemplateContentModel(ClientDbContext context, ILogger<EmailTemplateContentModel> logger, IActivity activity)
        {
            _context = context;
            _activity = activity;
            _logger = logger;
        }



        [BindProperty]
        public EmailTemplateContent EmailTemplateContent { get; set; }

        [ViewData]
        public SelectList EmailTemplates { get; set; }

        [BindProperty]
        public List<EmailTemplateName> EmailTemplateList { get; set; }
        
        private string errorMessage;

        // called first time the page is loaded.
        public IActionResult OnGet()
        {
            EmailTemplateList = _context.EmailTemplateName.ToList();
            EmailTemplates = new SelectList(EmailTemplateList, nameof(EmailTemplateName.Id), nameof(EmailTemplateName.Name));
            return Page();
        }

        // called to load and refresh grid
        public async Task<IActionResult> OnGetListAsync()
        {
            var etlist = _context.EmailTemplateContent.Include(x=>x.EmailTemplateName).ToList();
            List <EmailTemplateContentVM> EmailTemplateContentVMList = new List<EmailTemplateContentVM>();
           
            try
            {
                foreach (var emailTemplateContent in etlist)
                {
                    EmailTemplateContentVM tcVM = new EmailTemplateContentVM
                    {
                        Id = emailTemplateContent.Id,
                        TemplateName = emailTemplateContent.EmailTemplateName.Name,
                        TemplateId = emailTemplateContent.EmailTemplateName.Id,
                        EmailContent = emailTemplateContent.EmailContent,
                        
                    };
                    EmailTemplateContentVMList.Add(tcVM);
                }
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Accessed + EntityName, UserTypeValues.Staff);
                return new JsonResult(EmailTemplateContentVMList);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            return new JsonResult(new { success = false, message = "Error. Please check values entered "+ errorMessage });
        }

        public async Task<IActionResult>  OnGetSelectedRecordAsync(int id)
        {
            return new JsonResult(await _context.EmailTemplateContent.Where(x=>x.Id==id).FirstOrDefaultAsync());
        }
    
        public async Task<IActionResult> OnPostSaveAsync(EmailTemplateContent EmailTemplateContent)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new { success = false, message = "Error. Please check values entered" });
            }
            if (EmailTemplateContent.Id > 0)
            {
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Updated + EntityName + " Name: " + EmailTemplateContent.EmailTemplateName.Name, UserTypeValues.Staff);
                _context.Attach(EmailTemplateContent).State = EntityState.Modified;
            }
            else
            {
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Added + EntityName + " Name: " + EmailTemplateContent.EmailTemplateName.Name, UserTypeValues.Staff);
                _context.EmailTemplateContent.Add(EmailTemplateContent);
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

            EmailTemplateContent = await _context.EmailTemplateContent.FindAsync(id);

            if (EmailTemplateContent != null)
            {
                _context.EmailTemplateContent.Remove(EmailTemplateContent);
                await _context.SaveChangesAsync();
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Deleted + EntityName + " Name: " + EmailTemplateContent.EmailTemplateName.Name, UserTypeValues.Staff);
                return new JsonResult(new { success = true, message = "Deleted successfully" });
            }
            return new JsonResult(new { success = false, message = "No such record found to delete" });

        }
    }
}
