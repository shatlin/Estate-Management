using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MDM.Models;
using MDM.Helper;
using MDM.Services;

namespace MDM.Pages.Admin
{
    [Authorize(Policy = MDMPolicies.AllowAdmin)]
    public class RoleModel : PageModel
    {
        private readonly DB _context;
        private readonly ILogger<RoleModel> _logger;
        private IActivity _activity;
        private string EntityName = "Role";
        private readonly RoleManager<ApplicationRole> _roleManager;


        public RoleModel(DB context, RoleManager<ApplicationRole> roleManager, ILogger<RoleModel> logger, IActivity activity)
        {
            _context = context;
            _activity = activity;
            _logger = logger;
            _roleManager = roleManager;
           
        }

        [BindProperty]
        public IList<ApplicationRole> RoleList { get; set; }

        [BindProperty]
        public ApplicationRole Role { get; set; }

        public async Task<IActionResult> OnGetListAsync()
        {
           
            return new JsonResult(await _roleManager.Roles.ToListAsync());
        }

        public async Task<IActionResult> OnGetSelectedRecordAsync(string id)
        {
            return new JsonResult(await _roleManager.FindByIdAsync(id));
        }


        public async Task<IActionResult> OnPostSaveAsync()
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new { success = false, message = "Error. Please check values entered" });
            }

            if (Role.Id=="0"|| string.IsNullOrEmpty(Role.Id))
            {
                if (!string.IsNullOrEmpty(Role.Name))
                {
                    IdentityResult result = null;
                    result = await _roleManager.CreateAsync(new ApplicationRole());
                    if (result.Succeeded)
                    {
                        
                        return new JsonResult(new { success = true, message = "Role Created successfully" });
                    }
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(Role.Name))
                {

                    ApplicationRole role = await _roleManager.FindByIdAsync(Role.Id);
                    if(role!=null)
                    {
                        role.Name = Role.Name;
                        IdentityResult result = await _roleManager.UpdateAsync(role);
                        if (result.Succeeded)
                        {
                            
                            return new JsonResult(new { success = true, message = "Role Created successfully" });
                        }
                        foreach (IdentityError error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
            }


          
            return new JsonResult(new { success = false, message = "Error creating roles. Please check values entered" });
        }


        public async Task<IActionResult> OnGetDeleteAsync(string id)
        {

            if (id == null)
            {
                return new JsonResult(new { success = false, message = "No such record found to delete" });
            }

            Role = await _roleManager.FindByIdAsync(id);

            if (Role != null)
            {
                await _roleManager.DeleteAsync(Role);
               
                return new JsonResult(new { success = true, message = "Deleted successfully" });
            }
            return new JsonResult(new { success = false, message = "No such record found to delete" });
        }
    }
}
