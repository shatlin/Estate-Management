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
    public class EventCostItemModel : PageModel
    {
        private readonly ClientDbContext _context;
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<EventCostItemModel> _logger;
        private IActivity _activity;
        private string EntityName = "EventCost Item";

        public EventCostItemModel(ClientDbContext context, IAuthorizationService authorizationService, ILogger<EventCostItemModel> logger,
            UserManager<ApplicationUser> userManager, IActivity activity)
        {
            _context = context;
            _authorizationService = authorizationService;
            _userManager = userManager;
            _logger = logger;
            _activity = activity;
        }



        [BindProperty]
        public EventCostItem EventCostItem { get; set; }

        [ViewData]
        public SelectList Events { get; set; }

        [BindProperty]
        public List<Event> EventList { get; set; }
        
        private string errorMessage;

        // called first time the page is loaded.
        public async Task<IActionResult> OnGetAsync()
        {
            EventList = _context.Event.ToList();
            Events = new SelectList(EventList, nameof(Event.Id), nameof(Event.EventUniqueName));

            await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Accessed + EntityName, UserTypeValues.Staff);
            return Page();
        }

        // called to load and refresh grid
        public IActionResult OnGetList()
        {
            var eclist = _context.EventCostItem.Include(x=>x.Event).ToList();
            List <EventCostItemVM> EventCostItemVMList = new List<EventCostItemVM>();
           
            try
            {
                foreach (var EventCostItem in eclist)
                {
                    EventCostItemVM ecVM = new EventCostItemVM
                    {
                        Id = EventCostItem.Id,
                        Name = EventCostItem.Name,
                        Description = EventCostItem.Description,
                        EventId = EventCostItem.Event.Id,
                        EventName = EventCostItem.Event.EventUniqueName,
                        IsActive = EventCostItem.IsActive   
                    };
                    EventCostItemVMList.Add(ecVM);
                }
                return new JsonResult(EventCostItemVMList);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            return new JsonResult(new { success = false, message = "Error. Please check values entered "+ errorMessage });
        }

        public async Task<IActionResult>  OnGetSelectedRecordAsync(int id)
        {
            return new JsonResult(await _context.EventCostItem.Where(x=>x.Id==id).FirstOrDefaultAsync());
        }
    
        public async Task<IActionResult> OnPostSaveAsync(EventCostItem EventCostItem)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new { success = false, message = "Error. Please check values entered" });
            }
            if (EventCostItem.Id > 0)
            {
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Updated + EntityName + " Name: " + EventCostItem.Name, UserTypeValues.Staff);
                _context.Attach(EventCostItem).State = EntityState.Modified;
            }
            else
            {
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Added + EntityName + " Name: " + EventCostItem.Name, UserTypeValues.Staff);
                _context.EventCostItem.Add(EventCostItem);
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

            EventCostItem = await _context.EventCostItem.FindAsync(id);

            if (EventCostItem != null)
            {
                _context.EventCostItem.Remove(EventCostItem);
                await _context.SaveChangesAsync();
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Deleted + EntityName + " Name: " + EventCostItem.Name, UserTypeValues.Staff);
                return new JsonResult(new { success = true, message = "Deleted successfully" });
            }
            return new JsonResult(new { success = false, message = "No such record found to delete" });

        }
    }
}
