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
using MM.ClientModels;


namespace MM.Pages.Client
{
    public class ContactUsModel : PageModel
    {
        private readonly ClientDbContext _context;
        
        private readonly IEmailSender _emailSender;

        public ContactUsModel( IEmailSender emailSender, ClientDbContext clientDbContext)
        {
            _emailSender = emailSender;
            _context = clientDbContext;
        }

        [BindProperty]
        public SelectList ContactUsRelatedItems { get; set; }

        [BindProperty]
        public ContactUs ContactUs { get; set; }

        public IActionResult OnGet()
        {
            ContactUsRelatedItems =
          new SelectList(_context.ContactUsRelatedTo, nameof(ContactUsRelatedTo.Id), nameof(ContactUsRelatedTo.Name));
            return Page();
        }

            public async Task<IActionResult> OnGetListAsync()
        {
          

            return new JsonResult(await _context.ContactUs.ToListAsync());
        }

        public async Task<IActionResult> OnGetSelectedRecordAsync(int id)
        {
            return new JsonResult(await _context.ContactUs.Where(x => x.Id == id).FirstOrDefaultAsync());
        }

        public async Task<IActionResult> OnPostSaveAsync()
        {

            if (!ModelState.IsValid)
            {
                return new JsonResult(new { success = false, message = "Error. Please check values entered" });
            }

            if (ContactUs.Id > 0)
            {
                _context.Attach(ContactUs).State = EntityState.Modified;
            }
            else
            {
                _context.ContactUs.Add(ContactUs);
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

            ContactUs = await _context.ContactUs.FindAsync(id);

            if (ContactUs != null)
            {
                _context.ContactUs.Remove(ContactUs);
                await _context.SaveChangesAsync();
                return new JsonResult(new { success = true, message = "Deleted successfully" });
            }
            return new JsonResult(new { success = false, message = "No such record found to delete" });
        }
    }
}
