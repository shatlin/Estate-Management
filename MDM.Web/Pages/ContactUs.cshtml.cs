using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MDM.Models;


namespace MDM.Pages
{
    public class ContactUsModel : PageModel
    {
        private readonly DB _db;
        
        private readonly IEmailSender _emailSender;

        public ContactUsModel( IEmailSender emailSender, DB db)
        {
            _emailSender = emailSender;
            _db = db;
        }

        [BindProperty]
        public SelectList ContactUsRelatedItems { get; set; }

        [BindProperty]
        public ContactUs ContactUs { get; set; }

        public IActionResult OnGet()
        {
            ContactUsRelatedItems =
          new SelectList(_db.ContactUsRelatedTo, nameof(ContactUsRelatedTo.Id), nameof(ContactUsRelatedTo.Name));
            return Page();
        }

            public async Task<IActionResult> OnGetListAsync()
        {
          

            return new JsonResult(await _db.ContactUs.ToListAsync());
        }

        public async Task<IActionResult> OnGetSelectedRecordAsync(int id)
        {
            return new JsonResult(await _db.ContactUs.Where(x => x.Id == id).FirstOrDefaultAsync());
        }

        public async Task<IActionResult> OnPostSaveAsync()
        {

            if (!ModelState.IsValid)
            {
                return new JsonResult(new { success = false, message = "Error. Please check values entered" });
            }

            if (ContactUs.Id > 0)
            {
                _db.Attach(ContactUs).State = EntityState.Modified;
            }
            else
            {
                _db.ContactUs.Add(ContactUs);
            }
            await _db.SaveChangesAsync();
            return new JsonResult(new { success = true, message = "Saved successfully" });
        }

        public async Task<IActionResult> OnGetDeleteAsync(int? id)
        {

            if (id == null)
            {
                return new JsonResult(new { success = false, message = "No such record found to delete" });
            }

            ContactUs = await _db.ContactUs.FindAsync(id);

            if (ContactUs != null)
            {
                _db.ContactUs.Remove(ContactUs);
                await _db.SaveChangesAsync();
                return new JsonResult(new { success = true, message = "Deleted successfully" });
            }
            return new JsonResult(new { success = false, message = "No such record found to delete" });
        }
    }
}
