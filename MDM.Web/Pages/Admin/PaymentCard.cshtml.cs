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
    public class PaymentCardModel : PageModel
    {
        private readonly ClientDbContext _context;
        private readonly ILogger<PaymentCardModel> _logger;
        private IActivity _activity;
        private string EntityName = "PaymentCard";

        public PaymentCardModel(ClientDbContext context, ILogger<PaymentCardModel> logger, IActivity activity)
        {
            _context = context;
            _activity = activity;
            _logger = logger;
        }

        [BindProperty]
        public IList<PaymentCard> PaymentCardList { get;set; }

        [BindProperty]
        public PaymentCard PaymentCard { get; set; }

        public async Task<IActionResult> OnGetListAsync()
        {
            await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Accessed + EntityName, UserTypeValues.Staff);
            return new JsonResult(await _context.PaymentCard.ToListAsync());
        }

        public async Task<IActionResult>  OnGetSelectedRecordAsync(int id)
        {
            return new JsonResult(await _context.PaymentCard.Where(x=>x.Id==id).FirstOrDefaultAsync());
        }
    
 
        public async Task<IActionResult> OnPostSaveAsync(PaymentCard PaymentCard)
        {

            if (!ModelState.IsValid)
            {
                return new JsonResult(new { success = false, message = "Error. Please check values entered" });
            }

            if (PaymentCard.Id > 0)
            {
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Updated + EntityName + " Name: " + PaymentCard.Name, UserTypeValues.Staff);
                _context.Attach(PaymentCard).State = EntityState.Modified;
            }
            else
            {
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Added + EntityName + " Name: " + PaymentCard.Name, UserTypeValues.Staff);
                _context.PaymentCard.Add(PaymentCard);
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

            PaymentCard = await _context.PaymentCard.FindAsync(id);

            if (PaymentCard != null)
            {
                _context.PaymentCard.Remove(PaymentCard);
                await _context.SaveChangesAsync();
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Deleted + EntityName + " Name: " + PaymentCard.Name, UserTypeValues.Staff);
                return new JsonResult(new { success = true, message = "Deleted successfully" });
            }
            return new JsonResult(new { success = false, message = "No such record found to delete" });

        }
    }
}
