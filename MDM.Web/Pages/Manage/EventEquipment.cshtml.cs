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
    public class EventEquipmentModel : PageModel
    {
        private readonly ClientDbContext _context;
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<EventEquipmentModel> _logger;
        private IActivity _activity;
        private string EntityName = "Event Equipment";

        public EventEquipmentModel(ClientDbContext context, IAuthorizationService authorizationService, ILogger<EventEquipmentModel> logger,
            UserManager<ApplicationUser> userManager, IActivity activity)
        {
            _context = context;
            _authorizationService = authorizationService;
            _userManager = userManager;
            _logger = logger;
            _activity = activity;
        }



        [BindProperty]
        public EventEquipment EventEquipment { get; set; }

        [ViewData]
        public SelectList Events { get; set; }

        [ViewData]
        public SelectList Equipments { get; set; }

        [BindProperty]
        public List<Event> EventList { get; set; }

        [BindProperty]
        public List<Equipment> EquipmentList { get; set; }

        private string errorMessage;

        // called first time the page is loaded.
        public async Task<IActionResult> OnGetAsync()
        {
            EventList = _context.Event.ToList();
            Events = new SelectList(EventList, nameof(Event.Id), nameof(Event.EventUniqueName));

            EquipmentList = _context.Equipment.ToList();
            Equipments = new SelectList(EquipmentList, nameof(Equipment.Id), nameof(Equipment.Name));

            await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Accessed + EntityName, UserTypeValues.Staff);
            return Page();
        }

        // called to load and refresh grid
        public IActionResult OnGetList()
        {
            var eelist = _context.EventEquipment.Include(x => x.Event).Include(x => x.Equipment).ToList();
            List <EventEquipmentVM> EventEquipmentVMList = new List<EventEquipmentVM>();
           
            try
            {
                foreach (var eventEquipment in eelist)
                {
                    EventEquipmentVM eeVM = new EventEquipmentVM
                    {
                        Id = EventEquipment.Id,
                        EventId = EventEquipment.Event.Id,
                        EventName = EventEquipment.Event.EventUniqueName,
                        EquipmentId = EventEquipment.Equipment.Id,
                        EquipmentName = EventEquipment.Equipment.Name,
                        RequiredCount = EventEquipment.RequiredCount
                    };
                    EventEquipmentVMList.Add(eeVM);
                }
                return new JsonResult(EventEquipmentVMList);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            return new JsonResult(new { success = false, message = "Error. Please check values entered "+ errorMessage });
        }

        public async Task<IActionResult>  OnGetSelectedRecordAsync(int id)
        {
            return new JsonResult(await _context.EventEquipment.Where(x=>x.Id==id).FirstOrDefaultAsync());
        }
    
        public async Task<IActionResult> OnPostSaveAsync(EventEquipment EventEquipment)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new { success = false, message = "Error. Please check values entered" });
            }
            if (EventEquipment.Id > 0)
            {
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Updated + EntityName + " Name: " + EventEquipment.Equipment.Name, UserTypeValues.Staff);
                _context.Attach(EventEquipment).State = EntityState.Modified;
            }
            else
            {
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Added + EntityName + " Name: " + EventEquipment.Equipment.Name, UserTypeValues.Staff);
                _context.EventEquipment.Add(EventEquipment);
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

            EventEquipment = await _context.EventEquipment.FindAsync(id);

            if (EventEquipment != null)
            {
                _context.EventEquipment.Remove(EventEquipment);
                await _context.SaveChangesAsync();
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Deleted + EntityName + " Name: " + EventEquipment.Equipment.Name, UserTypeValues.Staff);
                return new JsonResult(new { success = true, message = "Deleted successfully" });
            }
            return new JsonResult(new { success = false, message = "No such record found to delete" });

        }
    }
}
