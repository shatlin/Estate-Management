using Microsoft.AspNetCore.Authorization;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using MM.ClientModels;
using Microsoft.Extensions.Logging;

namespace MM.Pages.Client.Account
{
    [AllowAnonymous]
    public class RegisterConfirmationModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _sender;
        private readonly ILogger<RegisterConfirmationModel> _logger;
        public RegisterConfirmationModel(UserManager<ApplicationUser> userManager, IEmailSender sender, ILogger<RegisterConfirmationModel> logger)
        {
            _userManager = userManager;
            _sender = sender;
            _logger = logger;
        }

        public string Email { get; set; }

        public bool DisplayConfirmAccountLink { get; set; }

        public string EmailConfirmationUrl { get; set; }

        public async Task<IActionResult> OnGetAsync(string email, string returnUrl = null)
        {
            if (email == null)
            {
                _logger.LogInformation("No email provided to confirm");
                return RedirectToPage("/Index");
            }

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                _logger.LogInformation("Could not find user with email " + email);
                return NotFound($"Unable to load user with email '{email}'.");
            }

            Email = email;

            // Once you add a real email sender, you should remove this code that lets you confirm the account


            var userId = await _userManager.GetUserIdAsync(user);

            _logger.LogInformation("User Id to confirm email is " + userId);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            _logger.LogInformation("GenerateEmailConfirmationTokenAsync generatd successfully. code is " + code);

            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            _logger.LogInformation("code after Base64UrlEncode is " + code);

            EmailConfirmationUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                protocol: Request.Scheme);


            return Page();
        }
    }
}
