using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MM.ClientModels;
using MM.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Web;
using WISA.Services;

namespace MM.Pages.Client.Admin
{
    [Authorize(Policy = MMPolicies.AllowSuperUser)]
    public class AddUserModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private UserManager<ApplicationUser> _userManager;
        private readonly ILogger<AddUserModel> _logger;
        private readonly IEmailCreator _emailCreator;
        private readonly ClientDbContext _context;
        private IActivity _activity;
        private string EntityName = "Add User";

        public AddUserModel(
           SignInManager<ApplicationUser> signInManager,
            RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager,
             ClientDbContext context, IEmailCreator emailCreator, ILogger<AddUserModel> logger, IActivity activity)
        {
            _signInManager = signInManager;
            _logger = logger;
            _roleManager = roleManager;
            _userManager = userManager;
            _emailCreator = emailCreator;
            _context = context;
            _activity = activity;

        }


        [BindProperty]
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [BindProperty]
        public ClientUser ClientUser { get; set; }

        [BindProperty]
        public string SelectedRadio { get; set; }

        [BindProperty]
        public ApplicationUser AppUser { get; set; }


        [BindProperty]
        public Notification notification { get; set; }

        [BindProperty]
        public bool? ErrorInOperation { get; set; }


        [BindProperty]
        public List<SystemRole> SystemRolesList { get; set; }

        [BindProperty]
        public List<SystemClaim> SystemClaimsList { get; set; }

        public void SetViewData()
        {
            ViewData["TitleId"] = new SelectList(_context.Title, nameof(Title.Id), nameof(Title.Name));
            ViewData["GenderId"] = new SelectList(_context.Gender, nameof(Gender.Id), nameof(Gender.Name));
            GetAllRolesAndClaims();
        }


        public async Task<IActionResult> OnGetAsync()
        {
            ErrorInOperation = false;
            SetViewData();
            await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Accessed + EntityName, UserTypeValues.Staff);
            return Page();
        }


        public void GetAllRolesAndClaims()
        {
            SystemRolesList = new List<SystemRole>();
            SetSystemClaimsList();
            var allRolesInSystem = _roleManager.Roles.ToList().OrderBy(x => x.Name);
            foreach (var role in allRolesInSystem)
            {
                if (role.Name == MMRoles.LimitedAdminAccessRole || role.Name == MMRoles.SuperUserRole ||
                    role.Name == MMRoles.AdminFullAccessRole || role.Name == MMRoles.AdminReadAccessRole)
                {

                    SystemRolesList.Add(new SystemRole { IsSelected = false, id = role.Id, Name = role.Name });
                }
            }
        }

        private void SetSystemClaimsList()
        {
            SystemClaimsList = new List<SystemClaim>();
            SystemClaimsList.Add(new SystemClaim { IsSelected = false, Type = MMClaimTypes.Event });
            SystemClaimsList.Add(new SystemClaim { IsSelected = false, Type = MMClaimTypes.Membership });
            SystemClaimsList.Add(new SystemClaim { IsSelected = false, Type = MMClaimTypes.Training });
            SystemClaimsList.Add(new SystemClaim { IsSelected = false, Type = MMClaimTypes.Finance });
            SystemClaimsList.Add(new SystemClaim { IsSelected = false, Type = MMClaimTypes.NewsLetter });
            SystemClaimsList.Add(new SystemClaim { IsSelected = false, Type = MMClaimTypes.Donations });
        }

        public async Task<bool> SetRoles()
        {

            #region Add NewRoles And Claims of Selected User

            await _userManager.AddToRoleAsync(AppUser, SelectedRadio);
            await _userManager.AddToRoleAsync(AppUser, MMRoles.ClientUserRole);

            var selectedRole = _roleManager.FindByNameAsync(SelectedRadio).Result;

            if (selectedRole.Name == MMRoles.LimitedAdminAccessRole)
            {
                foreach (var claim in SystemClaimsList)
                {
                    if (claim.IsSelected)
                    {
                        await _userManager.AddClaimAsync(AppUser, new Claim(claim.Type, MMClaimValues.Create));
                        await _userManager.AddClaimAsync(AppUser, new Claim(claim.Type, MMClaimValues.Read));
                        await _userManager.AddClaimAsync(AppUser, new Claim(claim.Type, MMClaimValues.Update));
                        await _userManager.AddClaimAsync(AppUser, new Claim(claim.Type, MMClaimValues.Delete));
                    }
                }
            }

            #endregion

            return true;
        }
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {

            if (ModelState.IsValid)
            {
                AppUser.Email = Email;
                AppUser.UserName = Email;
                AppUser.UserTypeId = 1;

                var result = await _userManager.CreateAsync(AppUser, AppUser.Pwd);

                if (result.Succeeded)
                {
                    ClientUser.ApplicaitonUserId = AppUser.Id;
                    ClientUser.CreatedOn = DateTime.Now;
                    ClientUser.ModifiedOn = DateTime.Now;
                    var loggedinUserAppId = _userManager.GetUserId(User);
                    var loggedinUserClientId = _context.ClientUser.Where(x => x.ApplicaitonUserId == loggedinUserAppId).FirstOrDefault().Id;
                    ClientUser.CreatedBy = loggedinUserClientId;
                    ClientUser.ModifiedBy = loggedinUserClientId;

                    _context.ClientUser.Add(ClientUser);
                    await _context.SaveChangesAsync();
                    await SetRoles();

                    _logger.LogInformation("User created a new account with password.");
                    await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Added + EntityName + " Name: " + AppUser.FirstName, UserTypeValues.Staff);

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(AppUser);
                    code = HttpUtility.UrlEncode(code);
                    string callbackUrl = Url.Page("/Account/ConfirmEmail",
                       pageHandler: null,
                       values: new { userId = AppUser.Id, code = code, returnUrl = returnUrl },
                       protocol: Request.Scheme);

                    await _emailCreator.SendEmailAsync("ConfirmEmail", AppUser.Email, AppUser.FullName, "WISA: Confirm your email", "Confirm Email", callbackUrl);
                    notification = new Notification { message = "User Added Successfully", notificationtype = "success" };
                    return LocalRedirect("/Admin/EditUser?Id=" + ClientUser.Id);
                }
                else
                {

                    string errors=string.Empty;

                    foreach (var error in result.Errors)
                    {
                        _logger.LogInformation("Error=" + error.Code + ", Description= " + error.Description);
                        errors+=error.Description+".";
                    }
                    notification = new Notification { message = errors, notificationtype = "danger" };
                }

            }
            else
            {
                foreach (var modelStateKey in ViewData.ModelState.Keys)
                {
                    var value = ViewData.ModelState[modelStateKey];

                    foreach (var error in value.Errors)
                    {
                        _logger.LogInformation("Key=" + modelStateKey + ", Error= " + error.ErrorMessage);
                    }
                }
                notification = new Notification { message = "Error while Adding User", notificationtype = "danger" };
            }


            SetViewData();
            return Page();

        }
    }
}

