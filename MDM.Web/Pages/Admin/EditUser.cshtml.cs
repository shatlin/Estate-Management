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
    [Authorize(Policy = MMPolicies.AllowSetUp)]
    public class EditUserModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private UserManager<ApplicationUser> _userManager;
        private readonly ILogger<EditUserModel> _logger;
        private IActivity _activity;
        private string EntityName = "Edit User";
        private readonly IEmailCreator _emailCreator;
        private readonly ClientDbContext _context;

        public EditUserModel(
           SignInManager<ApplicationUser> signInManager,
            ILogger<EditUserModel> logger, IActivity activity, RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager,
             ClientDbContext context, IEmailCreator emailCreator)
        {
            _signInManager = signInManager;
            _logger = logger;
            _activity = activity;
            _roleManager = roleManager;
            _userManager = userManager;
            _emailCreator = emailCreator;
            _context = context;

        }

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

            if (AppUser == null)
            {
                AppUser = _userManager.FindByIdAsync(ClientUser.ApplicaitonUserId).Result;
            }

            GetAllRolesAndClaims();
        }


        public async Task<IActionResult> OnGetAsync(int? id = null)
        {
            ErrorInOperation = false;

            if (id == null)
            {
                ErrorInOperation = true;
                notification = new Notification { message = "No id of User given to edit.Please try again with correct details", notificationtype = "danger" };
                return Page();
            }

            ClientUser = _context.ClientUser.Where(x => x.Id == id).FirstOrDefault();

            if (ClientUser == null)
            {
                ErrorInOperation = true;
                notification = new Notification { message = "User with Id " + id + " Not found", notificationtype = "danger" };
                return Page();
            }

            SetViewData();
            await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Accessed + EntityName, UserTypeValues.Staff);
            return Page();
        }


        public void GetAllRolesAndClaims()
        {
            SystemRolesList = new List<SystemRole>();
            SetSystemClaimsList();
            var allRolesInSystem = _roleManager.Roles.ToList().OrderBy(x => x.Name);
            ApplicationUser selectedAppUser = _userManager.FindByEmailAsync(AppUser.Email).Result;
            var rolesofSelectedUser = _userManager.GetRolesAsync(selectedAppUser).Result;

            foreach (var role in allRolesInSystem)
            {
                if (role.Name == MMRoles.LimitedAdminAccessRole || role.Name == MMRoles.SuperUserRole ||
                    role.Name == MMRoles.AdminFullAccessRole || role.Name == MMRoles.AdminReadAccessRole)
                {
                    if (rolesofSelectedUser.Contains(role.Name))
                    {
                        SystemRolesList.Add(new SystemRole { IsSelected = true, id = role.Id, Name = role.Name });

                        if (role.Name == MMRoles.LimitedAdminAccessRole)
                        {
                            var usersClaims = _userManager.GetClaimsAsync(selectedAppUser).Result;

                            foreach (var systemclaim in SystemClaimsList)
                            {
                                foreach (var userclaim in usersClaims)
                                {
                                    if (systemclaim.Type == userclaim.Type)
                                    {
                                        systemclaim.IsSelected = true;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        SystemRolesList.Add(new SystemRole { IsSelected = false, id = role.Id, Name = role.Name });
                    }
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
            ApplicationUser ApplicationUser = _userManager.FindByEmailAsync(AppUser.Email).Result;

            #region remove All Roles And Claims Of Selected User
            var userRoles = _userManager.GetRolesAsync(ApplicationUser).Result;
            await _userManager.RemoveFromRolesAsync(ApplicationUser, userRoles);
            var claims = _userManager.GetClaimsAsync(ApplicationUser).Result;
            foreach (var claim in claims)
            {
                await _userManager.RemoveClaimAsync(ApplicationUser, claim);
            }

            #endregion

            #region Add NewRoles And Claims of Selected User

            await _userManager.AddToRoleAsync(ApplicationUser, SelectedRadio);
            await _userManager.AddToRoleAsync(ApplicationUser, MMRoles.ClientUserRole);

            var selectedRole = _roleManager.FindByNameAsync(SelectedRadio).Result;

            if (selectedRole.Name == MMRoles.LimitedAdminAccessRole)
            {
                foreach (var claim in SystemClaimsList)
                {
                    if (claim.IsSelected)
                    {
                        await _userManager.AddClaimAsync(ApplicationUser, new Claim(claim.Type, MMClaimValues.Create));
                        await _userManager.AddClaimAsync(ApplicationUser, new Claim(claim.Type, MMClaimValues.Read));
                        await _userManager.AddClaimAsync(ApplicationUser, new Claim(claim.Type, MMClaimValues.Update));
                        await _userManager.AddClaimAsync(ApplicationUser, new Claim(claim.Type, MMClaimValues.Delete));
                    }
                }
            }

            #endregion

            return true;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ErrorInOperation = false;

            if (AppUser.Id != null)
            {
                ModelState.ClearValidationState("AppUser.Pwd");
                ModelState.MarkFieldValid("AppUser.Pwd");

                if (ModelState.IsValid)
                {
                    ApplicationUser applicationUser = await _userManager.FindByEmailAsync(AppUser.Email);
                    ClientUser = _context.ClientUser.Where(x => x.ApplicaitonUserId == applicationUser.Id).FirstOrDefault();

                    applicationUser.FirstName = AppUser.FirstName;
                    applicationUser.MiddleName = AppUser.MiddleName;
                    applicationUser.LastName = AppUser.LastName;
                    applicationUser.BirthDay = AppUser.BirthDay;
                    applicationUser.TitleId = AppUser.TitleId;
                    applicationUser.GenderId = AppUser.GenderId;
                    applicationUser.PhoneNumber = AppUser.PhoneNumber;
                    var result = await _userManager.UpdateAsync(applicationUser);
                    if (result.Succeeded)
                    {
                        await SetRoles();
                    }
                    notification = new Notification { message = "User Updated Successfully", notificationtype = "success" };

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
                    ErrorInOperation = true;
                    notification = new Notification { message = "Error while Updating User", notificationtype = "danger" };
                    return Page();
                }

            }
            else
            {
                ErrorInOperation = true;
                notification = new Notification { message = "Error while Updating User", notificationtype = "danger" };
                return LocalRedirect("/Admin/EditUser?Id=" + ClientUser.Id);
            }
            SetViewData();
            await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Updated + EntityName + " Name: " + AppUser.Email, UserTypeValues.Staff);
            return Page();
        }
    }
}

