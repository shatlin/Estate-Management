using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MDM.Models;
using MDM.Helper;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using MDM.Services;

namespace MDM.Pages.Client
{
    [AllowAnonymous]
    public class StartModel : PageModel
    {


        private readonly RoleManager<ApplicationRole> _roleManager;
        private UserManager<ApplicationUser> _userManager;
        private readonly DB _context;
        private readonly ILogger<StartModel> _logger;
        public StartModel(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager,
            DB context, ILogger<StartModel> logger)
        {

            _roleManager = roleManager;
            _userManager = userManager;

            _context = context;
            _logger = logger;
        }

        public PageResult OnGet()
        {
            return Page();
        }

        #region optimized
        public async Task<IActionResult> SetUpRoles()
        {
            using (DB db = new DB())
            {

                var role = new ApplicationRole(MDMRoles.SuperUser);
                await _roleManager.CreateAsync(role);
                await _roleManager.AddClaimAsync(role, new Claim(MDMClaimTypes.SuperUser, MDMClaimValues.Access));
                await _roleManager.AddClaimAsync(role, new Claim(MDMClaimTypes.Event, MDMClaimValues.Create));
                await _roleManager.AddClaimAsync(role, new Claim(MDMClaimTypes.Event, MDMClaimValues.Read));
                await _roleManager.AddClaimAsync(role, new Claim(MDMClaimTypes.Event, MDMClaimValues.Update));
                await _roleManager.AddClaimAsync(role, new Claim(MDMClaimTypes.Event, MDMClaimValues.Delete));

                await _roleManager.AddClaimAsync(role, new Claim(MDMClaimTypes.Finance, MDMClaimValues.Create));
                await _roleManager.AddClaimAsync(role, new Claim(MDMClaimTypes.Finance, MDMClaimValues.Read));
                await _roleManager.AddClaimAsync(role, new Claim(MDMClaimTypes.Finance, MDMClaimValues.Update));
                await _roleManager.AddClaimAsync(role, new Claim(MDMClaimTypes.Finance, MDMClaimValues.Delete));
                await _roleManager.AddClaimAsync(role, new Claim(MDMClaimTypes.NewsLetter, MDMClaimValues.Create));
                await _roleManager.AddClaimAsync(role, new Claim(MDMClaimTypes.NewsLetter, MDMClaimValues.Read));
                await _roleManager.AddClaimAsync(role, new Claim(MDMClaimTypes.NewsLetter, MDMClaimValues.Update));
                await _roleManager.AddClaimAsync(role, new Claim(MDMClaimTypes.NewsLetter, MDMClaimValues.Delete));

                await _roleManager.AddClaimAsync(role, new Claim(MDMClaimTypes.SetUp, MDMClaimValues.Create));
                await _roleManager.AddClaimAsync(role, new Claim(MDMClaimTypes.SetUp, MDMClaimValues.Read));
                await _roleManager.AddClaimAsync(role, new Claim(MDMClaimTypes.SetUp, MDMClaimValues.Update));
                await _roleManager.AddClaimAsync(role, new Claim(MDMClaimTypes.SetUp, MDMClaimValues.Delete));
                await _roleManager.AddClaimAsync(role, new Claim(MDMClaimTypes.Report, MDMClaimValues.Access));

                role = new ApplicationRole(MDMRoles.Admin);
                await _roleManager.CreateAsync(role);
                await _roleManager.AddClaimAsync(role, new Claim(MDMClaimTypes.AdminUser, MDMClaimValues.Access));
                await _roleManager.AddClaimAsync(role, new Claim(MDMClaimTypes.Event, MDMClaimValues.Create));
                await _roleManager.AddClaimAsync(role, new Claim(MDMClaimTypes.Event, MDMClaimValues.Read));
                await _roleManager.AddClaimAsync(role, new Claim(MDMClaimTypes.Event, MDMClaimValues.Update));
                await _roleManager.AddClaimAsync(role, new Claim(MDMClaimTypes.Event, MDMClaimValues.Delete));

                await _roleManager.AddClaimAsync(role, new Claim(MDMClaimTypes.Finance, MDMClaimValues.Create));
                await _roleManager.AddClaimAsync(role, new Claim(MDMClaimTypes.Finance, MDMClaimValues.Read));
                await _roleManager.AddClaimAsync(role, new Claim(MDMClaimTypes.Finance, MDMClaimValues.Update));
                await _roleManager.AddClaimAsync(role, new Claim(MDMClaimTypes.Finance, MDMClaimValues.Delete));
                await _roleManager.AddClaimAsync(role, new Claim(MDMClaimTypes.NewsLetter, MDMClaimValues.Create));
                await _roleManager.AddClaimAsync(role, new Claim(MDMClaimTypes.NewsLetter, MDMClaimValues.Read));
                await _roleManager.AddClaimAsync(role, new Claim(MDMClaimTypes.NewsLetter, MDMClaimValues.Update));
                await _roleManager.AddClaimAsync(role, new Claim(MDMClaimTypes.NewsLetter, MDMClaimValues.Delete));
      
                await _roleManager.AddClaimAsync(role, new Claim(MDMClaimTypes.SetUp, MDMClaimValues.Create));
                await _roleManager.AddClaimAsync(role, new Claim(MDMClaimTypes.SetUp, MDMClaimValues.Read));
                await _roleManager.AddClaimAsync(role, new Claim(MDMClaimTypes.SetUp, MDMClaimValues.Update));
                await _roleManager.AddClaimAsync(role, new Claim(MDMClaimTypes.SetUp, MDMClaimValues.Delete));
                await _roleManager.AddClaimAsync(role, new Claim(MDMClaimTypes.Report, MDMClaimValues.Access));

                role = new ApplicationRole(MDMRoles.Admin);
                await _roleManager.CreateAsync(role);

                await _roleManager.AddClaimAsync(role, new Claim(MDMClaimTypes.Event, MDMClaimValues.Read));
           
                await _roleManager.AddClaimAsync(role, new Claim(MDMClaimTypes.Finance, MDMClaimValues.Read));
                await _roleManager.AddClaimAsync(role, new Claim(MDMClaimTypes.NewsLetter, MDMClaimValues.Read));
             
                await _roleManager.AddClaimAsync(role, new Claim(MDMClaimTypes.Report, MDMClaimValues.Access));

             
            }
            return new JsonResult(new { success = false, message = "Error. Please check values entered" });
        }

        public async Task<IActionResult> CreateUsers()
        {

            using (DB db = new DB())
            {
                try
                {
                    var AppUser = new ApplicationUser
                    {
                        Email = "training@MDM.org.za",
                        UserName = "training@MDM.org.za",
                        FirstName = "Anita",
                        LastName = "Pillay",
                       
                        EmailConfirmed = true,
                        IsActive = true,
                        UserTypeId = 1
                    };
                    var result = await _userManager.CreateAsync(AppUser, "anitap");

                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(AppUser, MDMRoles.Admin);
                        //_context.ClientUser.Add(new ClientUser { ApplicaitonUserId = AppUser.Id, PrimaryContact = false, BillingContact = false, DesignationId = null, ReferralTypeId = null, Notes = string.Empty, IsInternalUser = true, TermsAccepted = true, IsActive = true, CreatedOn = DateTime.Now, ModifiedOn = DateTime.Now });
                        _context.SaveChanges();
                    }
                }
                catch
                {

                }
               



            }
            return new JsonResult(new { success = false, message = "Error. Please check values entered" });
        }

        private void Rollback()
        {
            foreach (var entry in _context.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified; //Revert changes made to deleted entity.
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                }
            }
        }


  

     

        #endregion





        public async Task<IActionResult> OnPostRun()
        {

            await SetUpRoles();
            _logger.LogInformation("Roles Created");
           
            _logger.LogInformation("Client Organization Created");
            await CreateUsers();
            _logger.LogInformation("Users  Created");

            return Page();
        }

   

        public async Task<IActionResult> OnPostLogResults()
        {


            return Page();
        }

  

    
    }
}




