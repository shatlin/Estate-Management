using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
    [Authorize(Policy = MMPolicies.AllowUserAccess)]
    public class EventCostModel : PageModel
    {
        private readonly ClientDbContext _context;
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<EventCostModel> _logger;
        private IActivity _activity;
        private string EntityName = "Event Cost";

        public EventCostModel(ClientDbContext context, IAuthorizationService authorizationService, ILogger<EventCostModel> logger,
            UserManager<ApplicationUser> userManager, IActivity activity)
        {
            _context = context;
            _authorizationService = authorizationService;
            _userManager = userManager;
            _logger = logger;
            _activity = activity;
        }



        [BindProperty]
        public EventCost EventCost { get; set; }

        [ViewData]
        public SelectList Events { get; set; }

        [ViewData]
        public SelectList EventCostItems { get; set; }

        [BindProperty]
        public List<Event> EventList { get; set; }

        [BindProperty]
        public List<EventCostItem> EventCostItemList { get; set; }

        private string errorMessage;

        // called first time the page is loaded.
        public async Task<IActionResult> OnGetAsync()
        {
            EventList = _context.Event.ToList();
            Events = new SelectList(EventList, nameof(Event.Id), nameof(Event.EventUniqueName));

            EventCostItemList = _context.EventCostItem.ToList();
            Events = new SelectList(EventCostItemList, nameof(EventCostItem.Id), nameof(EventCostItem.Name));

            await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Accessed + EntityName, UserTypeValues.Staff);
            return Page();
        }

        // called to load and refresh grid
        public IActionResult OnGetList()
        {
            var eclist = _context.EventCost.Include(x => x.Event).Include(x => x.EventCostItem).ToList();
            List <EventCostVM> EventCostVMList = new List<EventCostVM>();
           
            try
            {
                foreach (var eventCost in eclist)
                {
                    EventCostVM ecVM = new EventCostVM
                    {
                        Id = eventCost.Id,
                        EventCostItemId = eventCost.EventCostItem.Id,
                        EventCostItemName = eventCost.EventCostItem.Name,
                        EventId = eventCost.Event.Id,
                        EventName = eventCost.Event.EventUniqueName,
                        IsActive = eventCost.IsActive,
                        Amount = eventCost.Amount
                    };
                    EventCostVMList.Add(ecVM);
                }
                return new JsonResult(EventCostVMList);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            return new JsonResult(new { success = false, message = "Error. Please check values entered "+ errorMessage });
        }

        public async Task<IActionResult>  OnGetSelectedRecordAsync(int id)
        {
            return new JsonResult(await _context.EventCost.Where(x=>x.Id==id).FirstOrDefaultAsync());
        }
    
        public async Task<IActionResult> OnPostSaveAsync(EventCost EventCost)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new { success = false, message = "Error. Please check values entered" });
            }
            if (EventCost.Id > 0)
            {
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Updated + EntityName + " Name: " + EventCost.EventId, UserTypeValues.Staff);
                _context.Attach(EventCost).State = EntityState.Modified;
            }
            else
            {
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Added + EntityName + " Name: " + EventCost.EventId, UserTypeValues.Staff);
                _context.EventCost.Add(EventCost);
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

            EventCost = await _context.EventCost.FindAsync(id);

            if (EventCost != null)
            {
                _context.EventCost.Remove(EventCost);
                await _context.SaveChangesAsync();
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Deleted + EntityName + " Name: " + EventCost.EventId, UserTypeValues.Staff);
                return new JsonResult(new { success = true, message = "Deleted successfully" });
            }
            return new JsonResult(new { success = false, message = "No such record found to delete" });

        }
    }
}
