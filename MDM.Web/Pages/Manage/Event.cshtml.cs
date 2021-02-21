using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.OracleClient;
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
    public class EventModel : PageModel
    {
        private readonly ClientDbContext _context;
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<EventModel> _logger;
        private IActivity _activity;
        private string EntityName = "Event";


        public EventModel(ClientDbContext context, IAuthorizationService authorizationService, ILogger<EventModel> logger,
            UserManager<ApplicationUser> userManager, IActivity activity)
        {
            _context = context;
            _authorizationService = authorizationService;
            _userManager = userManager;
            _logger = logger;
            _activity = activity;

        }



        [BindProperty]
        public Event Event { get; set; }

        [ViewData]
        public SelectList Addresses { get; set; }

        [ViewData]
        public SelectList Titles { get; set; }

        [ViewData]
        public SelectList TimeZones { get; set; }

        [ViewData]
        public List<SelectListItem> Organizers { get; set; }


        [BindProperty]
        public List<Address> AddressList { get; set; }

        [BindProperty]
        public List<Title> TitleList { get; set; }

        [BindProperty]
        public List<ClientTimeZone> TimeZoneList { get; set; }

        [BindProperty]
        public List<ClientUser> OrganizerList { get; set; }

        private string errorMessage;

        // called first time the page is loaded.
        public async Task<IActionResult> OnGetAsync()
        {
            AddressList = _context.Address.ToList();
            Addresses = new SelectList(AddressList, nameof(Address.Id), nameof(Address.AddressLine1));

            TitleList = _context.Title.ToList();
            Titles = new SelectList(TitleList, nameof(Title.Id), nameof(Title.Name));

            TimeZoneList = _context.ClientTimeZone.ToList();
            TimeZones = new SelectList(TimeZoneList, nameof(ClientTimeZone.Id), nameof(ClientTimeZone.Description));

            OrganizerList = _context.ClientUser.Include(x=>x.ApplicationUser).ToList();

            Organizers = new List<SelectListItem>();
            foreach (var clientUser in OrganizerList)
            {
                Organizers.Add(new SelectListItem
                {
                    Value = clientUser.Id.ToString(),
                    Text = clientUser.ApplicationUser.FirstName
                });
            }
            await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Accessed + EntityName, UserTypeValues.Staff);
            return Page();
        }

   


        // called to load and refresh grid
        public IActionResult OnGetList()
        {

            var elist = _context.Event.Include(x => x.Address).Include(x => x.TimeZone).Include(x => x.Organizer).Include(x => x.Organizer.ApplicationUser).ToList();
            List<EventVM> EventVMList = new List<EventVM>();

            try
            {
                foreach (var events in elist)
                {
                    EventVM eVM = new EventVM
                    {
                        Id = events.Id,
                        EventUniqueName = events.EventUniqueName,
                        isInternal = events.InternalOrExternal,
                        AddressId = events.Address.Id,
                        OrganizerId = events.Organizer.Id,
                        OrganizerName = events.Organizer.ApplicationUser.FirstName,
                        Title = events.Title,
                        TimeZoneId = events.TimeZone.Id,
                        TimeZoneName = events.TimeZone.Name,
                        StartDate = events.StartDate,
                        EndDate = events.EndDate,
                        StartTime = events.StartTime,
                        EndTime = events.EndTime,
                        RegStartDate = events.RegStartDate,
                        RegEndDate = events.RegEndDate,
                        RegStartTime = events.RegStartTime,
                        RegEndTime = events.RegEndTime,
                        MaxRegistrationsAllowed = events.MaxRegistrationsAllowed,
                        IsCpdevent = events.IsCpdevent,
                        IsChargableEvent = events.IsChargableEvent,
                        ShowMaxRegistrationsAllowed = events.ShowMaxRegistrationsAllowed,
                        AllowGuestRegistrations = events.AllowGuestRegistrations,
                        GuestLimitPerRegistrant = events.GuestLimitPerRegistrant,
                        AllowCancellations = events.AllowCancellations,
                        CancellationbeforeDays = events.CancellationbeforeDays,
                        Description = events.Description,
                        AllowRegistration = events.AllowRegistration
                    };
                    EventVMList.Add(eVM);
                }
                return new JsonResult(EventVMList);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            return new JsonResult(new { success = false, message = "Error. Please check values entered " + errorMessage });
        }

        public async Task<IActionResult> OnGetSelectedRecordAsync(int id)
        {
            return new JsonResult(await _context.Event.Where(x => x.Id == id).FirstOrDefaultAsync());
        }

        public async Task<IActionResult> OnPostSaveAsync(Event Event)
        {

            IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);

            if (!ModelState.IsValid)
            {
                return new JsonResult(new { success = false, message = "Error. Please check values entered" });
            }
            if (Event.Id > 0)
            {
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Updated + EntityName + " Name: " + Event.Title, UserTypeValues.Staff);
                _context.Attach(Event).State = EntityState.Modified;
            }
            else
            {
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Added + EntityName + " Name: " + Event.Title, UserTypeValues.Staff);
                _context.Event.Add(Event);
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

            Event = await _context.Event.FindAsync(id);

            if (Event != null)
            {
                _context.Event.Remove(Event);
                await _context.SaveChangesAsync();
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Deleted + EntityName + " Name: " + Event.Title, UserTypeValues.Staff);
                return new JsonResult(new { success = true, message = "Deleted successfully" });
            }
            return new JsonResult(new { success = false, message = "No such record found to delete" });

        }
    }
}
