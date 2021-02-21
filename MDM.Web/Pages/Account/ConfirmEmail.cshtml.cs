using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using MDM.Models;
namespace MDM.Pages.Client.Account
{
    [AllowAnonymous]
    public class ConfirmEmailModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly ILogger<ConfirmEmailModel> _logger;

        public ConfirmEmailModel(UserManager<ApplicationUser> userManager, ILogger<ConfirmEmailModel> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(string userId, string code)
        {
            if (userId == null || code == null)
            {
                _logger.LogInformation("Confirm email failed. userId or code is null");
                return RedirectToPage("/Index");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                _logger.LogInformation($"Unable to load user with ID '{userId}'.");
                return NotFound($"Unable to load user with ID '{userId}'.");
            }
            code = HttpUtility.UrlDecode(code);
            var result = await _userManager.ConfirmEmailAsync(user, code);

            if (result.Succeeded)
            {
               
                    StatusMessage = "Email confirmed Successfully";
               
            }
            else
            {
                StatusMessage = "Error confirming your email.";
                _logger.LogInformation($"Errors in confirming email  address '{result.Errors}'.");
            }

            return Page();
        }
    }
}
