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
using WISA.Web.Pages.Manage;

namespace MM.Pages.Client
{
    [Authorize(Policy = MMPolicies.AllowUserAccess)]
    public class EquipmentCountModel : PageModel
    {
        private readonly ClientDbContext _context;
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<EquipmentCountModel> _logger;
        private IActivity _activity;
        private string EntityName = "Equipment Count";

        public EquipmentCountModel(ClientDbContext context, IAuthorizationService authorizationService, ILogger<EquipmentCountModel> logger,
            UserManager<ApplicationUser> userManager, IActivity activity)
        {
            _context = context;
            _authorizationService = authorizationService;
            _userManager = userManager;
            _logger = logger;
            _activity = activity;
        }

        [BindProperty]
        public EquipmentCount EquipmentCount { get; set; }

        [ViewData]
        public SelectList Equipments { get; set; }

        [BindProperty]
        public List<Equipment> EquipmentsList { get; set; }

        private string errorMessage;

        // called first time the page is loaded.
        public async Task<IActionResult> OnGetAsync()
        {
            EquipmentsList = _context.Equipment.ToList();
            Equipments = new SelectList(EquipmentsList, nameof(Equipment.Id), nameof(Equipment.Name));
            await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Accessed + EntityName, UserTypeValues.Staff);
            return Page();
        }

        // called to load and refresh grid
        public IActionResult OnGetList()
        {
            var equiplist = _context.EquipmentCount.Include(x => x.Equipment).ToList();
            List<EquipmentCountVM> equipmentCountVMList = new List<EquipmentCountVM>();

            try
            {
                foreach (var equipmentCount in equiplist)
                {
                    EquipmentCountVM ecVM = new EquipmentCountVM
                    {
                        Id = equipmentCount.Id,
                        EquipmentId = equipmentCount.Equipment.Id,
                        EquipmentName = equipmentCount.Equipment.Name,
                        AvailableCount = equipmentCount.AvailableCount

                    };
                    equipmentCountVMList.Add(ecVM);
                }
                return new JsonResult(equipmentCountVMList);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            return new JsonResult(new { success = false, message = "Error. Please check values entered " + errorMessage });
        }

        public async Task<IActionResult> OnGetSelectedRecordAsync(int id)
        {
            return new JsonResult(await _context.EquipmentCount.Where(x => x.Id == id).FirstOrDefaultAsync());
        }

        public async Task<IActionResult> OnPostSaveAsync(EquipmentCount EquipmentCount)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new { success = false, message = "Error. Please check values entered" });
            }
            if (EquipmentCount.Id > 0)
            {
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Updated + EntityName + " Name: " + EquipmentCount.EquipmentId, UserTypeValues.Staff);
                _context.Attach(EquipmentCount).State = EntityState.Modified;
            }
            else
            {
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Added + EntityName + " Name: " + EquipmentCount.EquipmentId, UserTypeValues.Staff);
                _context.EquipmentCount.Add(EquipmentCount);
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

            EquipmentCount = await _context.EquipmentCount.FindAsync(id);

            if (EquipmentCount != null)
            {
                _context.EquipmentCount.Remove(EquipmentCount);
                await _context.SaveChangesAsync();
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Deleted + EntityName + " Name: " + EquipmentCount.EquipmentId, UserTypeValues.Staff);
                return new JsonResult(new { success = true, message = "Deleted successfully" });
            }
            return new JsonResult(new { success = false, message = "No such record found to delete" });

        }
    }
}
