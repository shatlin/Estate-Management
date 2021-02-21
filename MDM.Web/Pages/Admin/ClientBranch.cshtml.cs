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
    public class ClientBranchModel : PageModel
    {
        private ClientDbContext _context;
        private readonly IAuthorizationService _authorizationService;
        private readonly ILogger<ClientBranchModel> _logger;
        private IActivity _activity;
        private string EntityName = "Client Branch";

        public ClientBranchModel(ClientDbContext context, IAuthorizationService authorizationService, ILogger<ClientBranchModel> logger, IActivity activity)
        {
            _context = context;
            _authorizationService = authorizationService;
            _activity = activity;
            _logger = logger;
        }

        [BindProperty]
        public ClientBranch ClientBranch { get; set; }

        public async Task<IActionResult> OnGetListAsync()
        {
            await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Accessed + EntityName, UserTypeValues.Staff);
            return new JsonResult(await _context.ClientBranch.ToListAsync());
        }

        public async Task<IActionResult> OnGetSelectedRecordAsync(int id)
        {
            return new JsonResult(await _context.ClientBranch.Where(x => x.Id == id).FirstOrDefaultAsync());
        }

        public async Task<IActionResult> OnPostSaveAsync(ClientBranch ClientBranch)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new { success = false, message = MMMessages.Error_Please_check_values_entered });
            }
            var isAuthorized = await _authorizationService.AuthorizeAsync(User, MMPolicies.AllowSetupUpdate);

            if (!isAuthorized.Succeeded)
            {
                return new JsonResult(new { success = false, message = MMMessages.Authorization_failed });
            }

            if (ClientBranch.Id > 0)
            {
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Updated + EntityName + " Name: " + ClientBranch.Name, UserTypeValues.Staff);
                _context.Attach(ClientBranch).State = EntityState.Modified;
            }
            else
            {
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Added + EntityName + " Name: " + ClientBranch.Name, UserTypeValues.Staff);
                _context.ClientBranch.Add(ClientBranch);
            }
            await _context.SaveChangesAsync();
            return new JsonResult(new { success = true, message = MMMessages.SavedSuccessfully });
        }

        public async Task<IActionResult> OnGetDeleteAsync(int? id)
        {
            var isAuthorized = await _authorizationService.AuthorizeAsync(User, MMPolicies.AllowSetupDelete);

            if (!isAuthorized.Succeeded)
            {
                return new JsonResult(new { success = false, MMMessages.Authorization_failed });
            }
            if (id == null)
            {
                return new JsonResult(new { success = false, MMMessages.NoRecordToDelete });
            }
            ClientBranch = await _context.ClientBranch.FindAsync(id);

            if (ClientBranch != null)
            {
                _context.ClientBranch.Remove(ClientBranch);
                await _context.SaveChangesAsync();
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Deleted + EntityName + " Name: " + ClientBranch.Name, UserTypeValues.Staff);
                return new JsonResult(new { success = true, message = MMMessages.DeletedSuccessfully });
            }
            return new JsonResult(new { success = false, message = MMMessages.NoRecordToDelete });
        }
    }
}
