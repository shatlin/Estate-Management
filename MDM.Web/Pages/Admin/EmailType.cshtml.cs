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
    public class EmailTypeModel : PageModel
    {
        private readonly ClientDbContext _context;
        private readonly ILogger<EmailTypeModel> _logger;
        private IActivity _activity;
        private string EntityName = "Email Type";

        public EmailTypeModel(ClientDbContext context, ILogger<EmailTypeModel> logger, IActivity activity)
        {
            _context = context;
            _activity = activity;
            _logger = logger;
        }

        [BindProperty]
        public IList<EmailType> EmailTypeList { get;set; }

        [BindProperty]
        public EmailType EmailType { get; set; }

        public async Task<IActionResult> OnGetListAsync()
        {
            await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Accessed + EntityName, UserTypeValues.Staff);
            return new JsonResult(await _context.EmailType.ToListAsync());
        }

        public async Task<IActionResult>  OnGetSelectedRecordAsync(int id)
        {
            return new JsonResult(await _context.EmailType.Where(x=>x.Id==id).FirstOrDefaultAsync());
        }
    
 
        public async Task<IActionResult> OnPostSaveAsync(EmailType EmailType)
        {

            if (!ModelState.IsValid)
            {
                return new JsonResult(new { success = false, message = "Error. Please check values entered" });
            }

            if (EmailType.Id > 0)
            {
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Updated + EntityName + " Name: " + EmailType.Name, UserTypeValues.Staff);
                _context.Attach(EmailType).State = EntityState.Modified;
            }
            else
            {
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Added + EntityName + " Name: " + EmailType.Name, UserTypeValues.Staff);
                _context.EmailType.Add(EmailType);
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

            EmailType = await _context.EmailType.FindAsync(id);

            if (EmailType != null)
            {
                _context.EmailType.Remove(EmailType);
                await _context.SaveChangesAsync();
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Deleted + EntityName + " Name: " + EmailType.Name, UserTypeValues.Staff);
                return new JsonResult(new { success = true, message = "Deleted successfully" });
            }
            return new JsonResult(new { success = false, message = "No such record found to delete" });

        }
    }
}
