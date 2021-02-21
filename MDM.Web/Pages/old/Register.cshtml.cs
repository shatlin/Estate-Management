using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MM.ClientModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Web;

using WISA.Services;

namespace MM.Pages.Client.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
         private readonly IEmailCreator _emailCreator;
        private readonly ClientDbContext _context;
        public RegisterModel(
           SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger, RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager,
              ClientDbContext context, IEmailCreator emailCreator)
        {
            _signInManager = signInManager;
            _logger = logger;
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
             _emailCreator=emailCreator;
        }

        [BindProperty]
        public ClientUser ClientUser { get; set; }

        [BindProperty]
        public ApplicationUser AppUser { get; set; }

        public class AppUserInputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        [ViewData]
        public SelectList ClientTitles { get; set; }

        [ViewData]
        public SelectList ClientDesignations { get; set; }

        [ViewData]
        public SelectList ClientGenders { get; set; }

        [ViewData]
        public SelectList ClientOrganizationGrades { get; set; }

        [ViewData]
        public SelectList ClientReferralTypes { get; set; }

        [BindProperty]
        public ClientOrganization ClientOrganization { get; set; }

        [ViewData]
        public SelectList OrgDateSettings { get; set; }

        [ViewData]
        public SelectList OrgTimeFormat { get; set; }

        [ViewData]
        public SelectList OrgTimeZone { get; set; }

        [ViewData]
        public SelectList OrgCurrency { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            OrgDateSettings = new SelectList(_context.DateSetting, nameof(DateSetting.Id), nameof(DateSetting.Name));
            OrgTimeFormat = new SelectList(_context.TimeFormat, nameof(TimeFormat.Id), nameof(TimeFormat.Name));
            OrgTimeZone = new SelectList(_context.ClientTimeZone, nameof(ClientTimeZone.Id), nameof(ClientTimeZone.Description));
            OrgCurrency = new SelectList(_context.Currency, nameof(Currency.Id), nameof(Currency.Name));
            ClientTitles = new SelectList(_context.Title, nameof(Title.Id), nameof(Title.Name));
            ClientDesignations = new SelectList(_context.Designation, nameof(Designation.Id), nameof(Designation.Name));
            ClientGenders = new SelectList(_context.Gender, nameof(Gender.Id), nameof(Gender.Name));
            ClientReferralTypes = new SelectList(_context.ReferralType, nameof(ReferralType.Id), nameof(ReferralType.Name));
            ClientOrganizationGrades = new SelectList(_context.ClientOrganizationGrade, nameof(ClientOrganzationType.Id), nameof(ClientOrganzationType.Name));
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }


        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                AppUser.UserName = AppUser.Email;
                AppUser.UserTypeId = 1;
                var result = await _userManager.CreateAsync(AppUser, AppUser.Pwd);

                if (result.Succeeded)
                {
                    _context.ClientOrganization.Add(ClientOrganization);
                    ClientUser.ApplicaitonUserId = AppUser.Id;
                    _context.ClientUser.Add(ClientUser);
                    await _context.SaveChangesAsync();
                    await _userManager.AddToRoleAsync(AppUser, MMRoles.SuperUserRole);
                    _logger.LogInformation("User created a new account with password.");
                    //  var host = _httpContextAccessor.HttpContext.Request.Host.Value;
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(AppUser);
                    code = HttpUtility.UrlEncode(code);
                    string callbackUrl = Url.Page("/Account/ConfirmEmail", pageHandler: null,
                        values: new { userId = AppUser.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailCreator.SendEmailAsync("ConfirmAccount",AppUser.Email,AppUser.FullName,"WISA: Confirm your email","Confirm Email",callbackUrl);

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = AppUser.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(AppUser, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return Page();
        }
    }
}

