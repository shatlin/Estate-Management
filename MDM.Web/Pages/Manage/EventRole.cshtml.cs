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
    public class EventRoleModel : PageModel
    {
        private readonly ClientDbContext _context;
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<EventRoleModel> _logger;
        private IActivity _activity;
        private string EntityName = "Event Role";

        public EventRoleModel(ClientDbContext context, IAuthorizationService authorizationService, ILogger<EventRoleModel> logger,
            UserManager<ApplicationUser> userManager, IActivity activity)
        {
            _context = context;
            _authorizationService = authorizationService;
            _userManager = userManager;
            _logger = logger;
            _activity = activity;
        }



        [BindProperty]
        public EventRole EventRole { get; set; }

        [ViewData]
        public SelectList EventRoles { get; set; }

        [BindProperty]
        public List<Event> EventList { get; set; }
        
        private string errorMessage;

        // called first time the page is loaded.
        public async Task<IActionResult> OnGetAsync()
        {
            EventList = _context.Event.ToList();
            EventRoles = new SelectList(EventList, nameof(Event.Id), nameof(Event.EventUniqueName));

            await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Accessed + EntityName, UserTypeValues.Staff);
            return Page();
        }

        // called to load and refresh grid
        public IActionResult OnGetList()
        {
            var evlist = _context.EventRole.Include(x=>x.Event).ToList();
            List <EventRoleVM> EventRoleVMList = new List<EventRoleVM>();
           
            try
            {
                foreach (var eventRole in evlist)
                {
                    EventRoleVM evVM = new EventRoleVM
                    {
                        Id = EventRole.Id,
                        Name = EventRole.Name,
                        EventId = EventRole.Event.Id,
                        EventName = EventRole.Event.EventUniqueName,
                        Description = EventRole.Description
                        
                    };
                    EventRoleVMList.Add(evVM);
                }
                return new JsonResult(EventRoleVMList);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            return new JsonResult(new { success = false, message = "Error. Please check values entered "+ errorMessage });
        }

        public async Task<IActionResult>  OnGetSelectedRecordAsync(int id)
        {
            return new JsonResult(await _context.EventRole.Where(x=>x.Id==id).FirstOrDefaultAsync());
        }
    
        public async Task<IActionResult> OnPostSaveAsync(EventRole EventRole)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new { success = false, message = "Error. Please check values entered" });
            }
            if (EventRole.Id > 0)
            {
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Updated + EntityName + " Name: " + EventRole.Name, UserTypeValues.Staff);
                _context.Attach(EventRole).State = EntityState.Modified;
            }
            else
            {
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Added + EntityName + " Name: " + EventRole.Name, UserTypeValues.Staff);
                _context.EventRole.Add(EventRole);
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

            EventRole = await _context.EventRole.FindAsync(id);

            if (EventRole != null)
            {
                _context.EventRole.Remove(EventRole);
                await _context.SaveChangesAsync();
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Deleted + EntityName + " Name: " + EventRole.Name, UserTypeValues.Staff);
                return new JsonResult(new { success = true, message = "Deleted successfully" });
            }
            return new JsonResult(new { success = false, message = "No such record found to delete" });

        }
    }
}
