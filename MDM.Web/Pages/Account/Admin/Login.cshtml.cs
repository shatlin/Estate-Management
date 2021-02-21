using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MM.ClientModels;
using WISA.Services;
using System.Security.Claims;

namespace MM.Pages.Client.Admin.Account
{
    [AllowAnonymous]
    public class AdminLoginModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ClientDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<AdminLoginModel> _logger;
        private IActivity _activity;
        public AdminLoginModel(SignInManager<ApplicationUser> signInManager,
            ILogger<AdminLoginModel> logger,
            UserManager<ApplicationUser> userManager, ClientDbContext context, IActivity activity)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
            _activity = activity;
        }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        [Required]
        [EmailAddress]
        [BindProperty]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [BindProperty]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        [BindProperty]
        public bool RememberMe { get; set; }

        [BindProperty]
        public bool isMember { get; set; }

        [BindProperty]
        public Notification notification { get; set; }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl = returnUrl ?? Url.Content("~/");

            //var user = await _userManager.GetUserAsync(User);
            //if (user != null)
            //{
            //    await RedirectUser(user, returnUrl);
            //}
            //else
            //{
            //// Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
            //}

        }

        public async Task<IActionResult> RedirectUser(ApplicationUser user, string returnUrl)
        {
            var roles = await _userManager.GetRolesAsync(user);

            if (roles.Contains(MMRoles.SuperUserRole) || roles.Contains(MMRoles.AdminFullAccessRole))
            {
                return RedirectToPage("/Admin/Index");
            }
            else if (roles.Contains(MMRoles.ClientUserRole))
            {
                return RedirectToPage("/Manage/Index");
            }
            else
            {
                return RedirectToPage(returnUrl);
            }
        }
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("/Index");

            var user = await _userManager.FindByEmailAsync(Email);

            if (user != null && user.UserTypeId != UserTypeValues.Staff)
            {
                notification = new Notification { message = "Authentication failed. Please use Member Login Page", notificationtype = NotificationTypeValues.danger };
                isMember = true;
                return Page();
            }
            isMember = false;

            if (ModelState.IsValid)
            {

                var result = await _signInManager.PasswordSignInAsync(Email, Password, RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");

                    await _activity.AddAsync(user.Id, user.Email, MMMessages.LoggedIn, UserTypeValues.Staff);

                    var roles = await _userManager.GetRolesAsync(user);
                    if (roles.Contains(MMRoles.SuperUserRole) || roles.Contains(MMRoles.AdminFullAccessRole))
                    {
                        return LocalRedirect("~/Admin");
                    }
                    else if (roles.Contains(MMRoles.ClientUserRole))
                    {
                        return LocalRedirect("~/Manage/ListIndividual");
                    }
                    else
                    {
                        return RedirectToPage("/Index");
                    }
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    notification = new Notification { message = "Invalid login attempt", notificationtype = NotificationTypeValues.danger };
                    return Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
