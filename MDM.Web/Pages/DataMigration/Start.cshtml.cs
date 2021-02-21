using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MM.ClientModels;
using MM.Helper;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using WISA.Services;

namespace MM.Pages.Client
{
    [AllowAnonymous]
    public class StartModel : PageModel
    {


        private readonly RoleManager<ApplicationRole> _roleManager;
        private UserManager<ApplicationUser> _userManager;
        private readonly ClientDbContext _context;
        private readonly ILogger<StartModel> _logger;
        public StartModel(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager,
            ClientDbContext context, ILogger<StartModel> logger)
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
            using (ClientDbContext db = new ClientDbContext())
            {

                var role = new ApplicationRole(MMRoles.SuperUserRole);
                await _roleManager.CreateAsync(role);
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.SuperUser, MMClaimValues.Access));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.Event, MMClaimValues.Create));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.Event, MMClaimValues.Read));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.Event, MMClaimValues.Update));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.Event, MMClaimValues.Delete));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.Membership, MMClaimValues.Create));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.Membership, MMClaimValues.Read));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.Membership, MMClaimValues.Update));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.Membership, MMClaimValues.Delete));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.Training, MMClaimValues.Create));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.Training, MMClaimValues.Read));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.Training, MMClaimValues.Update));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.Training, MMClaimValues.Delete));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.Finance, MMClaimValues.Create));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.Finance, MMClaimValues.Read));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.Finance, MMClaimValues.Update));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.Finance, MMClaimValues.Delete));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.NewsLetter, MMClaimValues.Create));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.NewsLetter, MMClaimValues.Read));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.NewsLetter, MMClaimValues.Update));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.NewsLetter, MMClaimValues.Delete));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.Donations, MMClaimValues.Create));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.Donations, MMClaimValues.Read));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.Donations, MMClaimValues.Update));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.Donations, MMClaimValues.Delete));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.SetUp, MMClaimValues.Create));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.SetUp, MMClaimValues.Read));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.SetUp, MMClaimValues.Update));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.SetUp, MMClaimValues.Delete));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.Report, MMClaimValues.Access));

                role = new ApplicationRole(MMRoles.AdminFullAccessRole);
                await _roleManager.CreateAsync(role);
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.AdminUser, MMClaimValues.Access));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.Event, MMClaimValues.Create));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.Event, MMClaimValues.Read));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.Event, MMClaimValues.Update));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.Event, MMClaimValues.Delete));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.Membership, MMClaimValues.Create));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.Membership, MMClaimValues.Read));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.Membership, MMClaimValues.Update));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.Membership, MMClaimValues.Delete));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.Training, MMClaimValues.Create));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.Training, MMClaimValues.Read));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.Training, MMClaimValues.Update));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.Training, MMClaimValues.Delete));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.Finance, MMClaimValues.Create));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.Finance, MMClaimValues.Read));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.Finance, MMClaimValues.Update));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.Finance, MMClaimValues.Delete));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.NewsLetter, MMClaimValues.Create));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.NewsLetter, MMClaimValues.Read));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.NewsLetter, MMClaimValues.Update));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.NewsLetter, MMClaimValues.Delete));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.Donations, MMClaimValues.Create));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.Donations, MMClaimValues.Read));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.Donations, MMClaimValues.Update));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.Donations, MMClaimValues.Delete));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.SetUp, MMClaimValues.Create));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.SetUp, MMClaimValues.Read));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.SetUp, MMClaimValues.Update));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.SetUp, MMClaimValues.Delete));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.Report, MMClaimValues.Access));

                role = new ApplicationRole(MMRoles.AdminReadAccessRole);
                await _roleManager.CreateAsync(role);

                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.Event, MMClaimValues.Read));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.Membership, MMClaimValues.Read));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.Training, MMClaimValues.Read));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.Finance, MMClaimValues.Read));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.NewsLetter, MMClaimValues.Read));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.Donations, MMClaimValues.Read));
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.Report, MMClaimValues.Access));

                role = new ApplicationRole(MMRoles.NoAdminRole);
                await _roleManager.CreateAsync(role);

                role = new ApplicationRole(MMRoles.LimitedAdminAccessRole);
                await _roleManager.CreateAsync(role);

                role = new ApplicationRole(MMRoles.ClientUserRole);
                await _roleManager.CreateAsync(role);
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.ClientUser, MMClaimValues.Access));

                role = new ApplicationRole(MMRoles.MemberRole);
                await _roleManager.CreateAsync(role);
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.MemberUser, MMClaimValues.Access));

                role = new ApplicationRole(MMRoles.ContactRole);
                await _roleManager.CreateAsync(role);
                await _roleManager.AddClaimAsync(role, new Claim(MMClaimTypes.ContactUser, MMClaimValues.Access));
            }
            return new JsonResult(new { success = false, message = "Error. Please check values entered" });
        }

        public async Task<IActionResult> CreateUsers()
        {

            using (ClientDbContext db = new ClientDbContext())
            {
                try
                {
                    var AppUser = new ApplicationUser
                    {
                        Email = "training@wisa.org.za",
                        UserName = "training@wisa.org.za",
                        FirstName = "Anita",
                        LastName = "Pillay",
                        TitleId = 2,
                        GenderId = 2,
                        EmailConfirmed = true,
                        IsActive = true,
                        UserTypeId = 1
                    };
                    var result = await _userManager.CreateAsync(AppUser, "anitap");

                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(AppUser, MMRoles.ClientUserRole);
                        _context.ClientUser.Add(new ClientUser { ApplicaitonUserId = AppUser.Id, PrimaryContact = false, BillingContact = false, DesignationId = null, ReferralTypeId = null, Notes = string.Empty, IsInternalUser = true, TermsAccepted = true, IsActive = true, CreatedOn = DateTime.Now, ModifiedOn = DateTime.Now });
                        _context.SaveChanges();
                    }
                }
                catch
                {

                }
                try
                {
                    var AppUser = new ApplicationUser
                    {
                        Email = "wisa@wisa.org.za",
                        UserName = "wisa@wisa.org.za",
                        FirstName = "Evelyn",
                        LastName = "Ramphomane",
                        TitleId = 2,
                        GenderId = 2,
                        EmailConfirmed = true,
                        IsActive = true,
                        UserTypeId = 1
                    };
                    var result = await _userManager.CreateAsync(AppUser, "evelyn");

                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(AppUser, MMRoles.AdminFullAccessRole);
                        await _userManager.AddToRoleAsync(AppUser, MMRoles.ClientUserRole);
                        _context.ClientUser.Add(new ClientUser { ApplicaitonUserId = AppUser.Id, PrimaryContact = false, BillingContact = false, DesignationId = null, ReferralTypeId = null, Notes = string.Empty, IsInternalUser = true, TermsAccepted = true, IsActive = true, CreatedOn = DateTime.Now, ModifiedOn = DateTime.Now });
                        _context.SaveChanges();
                    }
                }
                catch
                {
                }


                try
                {
                    var AppUser = new ApplicationUser
                    {
                        Email = "system@wisa.org.za",
                        UserName = "system@wisa.org.za",
                        FirstName = "System",
                        LastName = "Admin",
                        TitleId = 1,
                        GenderId = 1,
                        EmailConfirmed = true,
                        IsActive = true,
                        UserTypeId = 1
                    };
                    var result = await _userManager.CreateAsync(AppUser, "systema");

                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(AppUser, MMRoles.SuperUserRole);
                        await _userManager.AddToRoleAsync(AppUser, MMRoles.AdminFullAccessRole);
                        await _userManager.AddToRoleAsync(AppUser, MMRoles.ClientUserRole);
                        _context.ClientUser.Add(new ClientUser { ApplicaitonUserId = AppUser.Id, PrimaryContact = false, BillingContact = false, DesignationId = null, ReferralTypeId = null, Notes = string.Empty, IsInternalUser = true, TermsAccepted = true, IsActive = true, CreatedOn = DateTime.Now, ModifiedOn = DateTime.Now });
                        _context.SaveChanges();
                    }
                }
                catch
                {
                }

                try
                {
                    var AppUser = new ApplicationUser
                    {
                        Email = "falcon@wisa.org.za",
                        UserName = "falcon@wisa.org.za",
                        FirstName = "falcon",
                        LastName = "crmadmin",
                        TitleId = 1,
                        GenderId = 1,
                        EmailConfirmed = true,
                        IsActive = true,
                        UserTypeId = 1
                    };
                    var result = await _userManager.CreateAsync(AppUser, " crmadmin");

                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(AppUser, MMRoles.SuperUserRole);
                        await _userManager.AddToRoleAsync(AppUser, MMRoles.AdminFullAccessRole);
                        await _userManager.AddToRoleAsync(AppUser, MMRoles.ClientUserRole);
                        _context.ClientUser.Add(new ClientUser { ApplicaitonUserId = AppUser.Id, PrimaryContact = false, BillingContact = false, DesignationId = null, ReferralTypeId = null, Notes = string.Empty, IsInternalUser = true, TermsAccepted = true, IsActive = true, CreatedOn = DateTime.Now, ModifiedOn = DateTime.Now });
                        _context.SaveChanges();
                    }
                }
                catch
                {
                }

                try
                {
                    var AppUser = new ApplicationUser
                    {
                        Email = "Optimise@wisa.org.za",
                        UserName = "Optimise@wisa.org.za",
                        FirstName = "Optimise",
                        LastName = "CRM",
                        TitleId = 1,
                        GenderId = 1,
                        EmailConfirmed = true,
                        IsActive = true,
                        UserTypeId = 1
                    };
                    var result = await _userManager.CreateAsync(AppUser, "Optimise");

                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(AppUser, MMRoles.SuperUserRole);
                        await _userManager.AddToRoleAsync(AppUser, MMRoles.AdminFullAccessRole);
                        await _userManager.AddToRoleAsync(AppUser, MMRoles.ClientUserRole);
                        _context.ClientUser.Add(new ClientUser { ApplicaitonUserId = AppUser.Id, PrimaryContact = false, BillingContact = false, DesignationId = null, ReferralTypeId = null, Notes = string.Empty, IsInternalUser = true, TermsAccepted = true, IsActive = true, CreatedOn = DateTime.Now, ModifiedOn = DateTime.Now });
                        _context.SaveChanges();
                    }
                }
                catch
                {
                }


                try
                {
                    var AppUser = new ApplicationUser
                    {
                        Email = "WISADevelopment@wisa.org.za",
                        UserName = "WISADevelopment@wisa.org.za",
                        FirstName = "WISA Development",
                        LastName = "Admin",
                        TitleId = 1,
                        GenderId = 1,
                        EmailConfirmed = true,
                        IsActive = true,
                        UserTypeId = 1
                    };
                    var result = await _userManager.CreateAsync(AppUser, "WISADevelopment");

                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(AppUser, MMRoles.SuperUserRole);
                        await _userManager.AddToRoleAsync(AppUser, MMRoles.AdminFullAccessRole);
                        await _userManager.AddToRoleAsync(AppUser, MMRoles.ClientUserRole);
                        _context.ClientUser.Add(new ClientUser { ApplicaitonUserId = AppUser.Id, PrimaryContact = false, BillingContact = false, DesignationId = null, ReferralTypeId = null, Notes = string.Empty, IsInternalUser = true, TermsAccepted = true, IsActive = true, CreatedOn = DateTime.Now, ModifiedOn = DateTime.Now });
                        _context.SaveChanges();
                    }
                }
                catch
                {
                }

                try
                {
                    var AppUser = new ApplicationUser
                    {
                        Email = "DevAccountUser@wisa.org.za",
                        UserName = "DevAccountUser@wisa.org.za",
                        FirstName = "wisa.dev",
                        LastName = "DevAccountUser",
                        TitleId = 1,
                        GenderId = 1,
                        EmailConfirmed = true,
                        IsActive = true,
                        UserTypeId = 1
                    };
                    var result = await _userManager.CreateAsync(AppUser, "DevAccountUser");

                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(AppUser, MMRoles.SuperUserRole);
                        await _userManager.AddToRoleAsync(AppUser, MMRoles.AdminFullAccessRole);
                        await _userManager.AddToRoleAsync(AppUser, MMRoles.ClientUserRole);
                        _context.ClientUser.Add(new ClientUser { ApplicaitonUserId = AppUser.Id, PrimaryContact = false, BillingContact = false, DesignationId = null, ReferralTypeId = null, Notes = string.Empty, IsInternalUser = true, TermsAccepted = true, IsActive = true, CreatedOn = DateTime.Now, ModifiedOn = DateTime.Now });
                        _context.SaveChanges();
                    }
                }
                catch
                {
                }


                try
                {
                    var AppUser = new ApplicationUser
                    {
                        Email = "admin@wisa.org.za",
                        UserName = "admin@wisa.org.za",
                        FirstName = "Melissa",
                        LastName = "Wheal",
                        TitleId = 2,
                        GenderId = 2,
                        IsActive = true,
                        EmailConfirmed = true,
                        UserTypeId = 1
                    };
                    var result = await _userManager.CreateAsync(AppUser, "melissa");

                    if (result.Succeeded)
                    {
                        await _userManager.AddClaimAsync(AppUser, new Claim(MMClaimTypes.Report, MMClaimValues.Access));
                        await _userManager.AddToRoleAsync(AppUser, MMRoles.ClientUserRole);
                        _context.ClientUser.Add(new ClientUser { ApplicaitonUserId = AppUser.Id, PrimaryContact = false, BillingContact = false, DesignationId = null, ReferralTypeId = null, Notes = string.Empty, IsInternalUser = true, TermsAccepted = true, IsActive = true, CreatedOn = DateTime.Now, ModifiedOn = DateTime.Now });
                        _context.SaveChanges();
                    }
                }
                catch
                {
                }

                try
                {
                    var AppUser = new ApplicationUser
                    {
                        Email = "membership@wisa.org.za",
                        UserName = "membership@wisa.org.za",
                        FirstName = "Patrick",
                        LastName = "Sebopelo",
                        TitleId = 1,
                        GenderId = 1,
                        IsActive = true,
                        EmailConfirmed = true,
                        UserTypeId = 1
                    };
                    var result = await _userManager.CreateAsync(AppUser, "patricks");

                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(AppUser, MMRoles.SuperUserRole);
                        await _userManager.AddToRoleAsync(AppUser, MMRoles.AdminFullAccessRole);
                        await _userManager.AddToRoleAsync(AppUser, MMRoles.ClientUserRole);
                        _context.ClientUser.Add(new ClientUser { ApplicaitonUserId = AppUser.Id, PrimaryContact = false, BillingContact = false, DesignationId = null, ReferralTypeId = null, Notes = string.Empty, IsInternalUser = true, TermsAccepted = true, IsActive = true, CreatedOn = DateTime.Now, ModifiedOn = DateTime.Now });
                        _context.SaveChanges();
                    }
                }
                catch
                {
                }


                try
                {
                    var AppUser = new ApplicationUser
                    {
                        Email = "raegan@wisa.org.za",
                        UserName = "raegan@wisa.org.za",
                        FirstName = "Reagan",
                        LastName = "Maistry",
                        TitleId = 1,
                        GenderId = 1,
                        IsActive = true,
                        EmailConfirmed = true,
                        UserTypeId = 1
                    };
                    var result = await _userManager.CreateAsync(AppUser, "reagan");

                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(AppUser, MMRoles.ClientUserRole);
                        _context.ClientUser.Add(new ClientUser { ApplicaitonUserId = AppUser.Id, PrimaryContact = false, BillingContact = false, DesignationId = null, ReferralTypeId = null, Notes = string.Empty, IsInternalUser = true, TermsAccepted = true, IsActive = true, CreatedOn = DateTime.Now, ModifiedOn = DateTime.Now });
                        _context.SaveChanges();
                    }
                }
                catch
                {
                }

                try
                {
                    var AppUser = new ApplicationUser
                    {
                        Email = "debtors@wisa.org.za",
                        UserName = "debtors@wisa.org.za",
                        FirstName = "Sarah",
                        LastName = "Biya",
                        TitleId = 2,
                        GenderId = 2,
                        IsActive = true,
                        EmailConfirmed = true,
                        UserTypeId = 1
                    };
                    var result = await _userManager.CreateAsync(AppUser, "sarahb");

                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(AppUser, MMRoles.LimitedAdminAccessRole);
                        await _userManager.AddToRoleAsync(AppUser, MMRoles.ClientUserRole);
                        _context.ClientUser.Add(new ClientUser { ApplicaitonUserId = AppUser.Id, PrimaryContact = false, BillingContact = false, DesignationId = null, ReferralTypeId = null, Notes = string.Empty, IsInternalUser = true, TermsAccepted = true, IsActive = true, CreatedOn = DateTime.Now, ModifiedOn = DateTime.Now });
                        _context.SaveChanges();
                    }
                }
                catch
                {
                }

                try
                {
                    var AppUser = new ApplicationUser
                    {
                        Email = "support@wisa.org.za",
                        UserName = "support@wisa.org.za",
                        FirstName = "Talent",
                        LastName = "Khumalo",
                        TitleId = 2,
                        GenderId = 2,
                        EmailConfirmed = true,
                        IsActive = true,
                        UserTypeId = 1
                    };
                    var result = await _userManager.CreateAsync(AppUser, "talent");

                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(AppUser, MMRoles.AdminFullAccessRole);
                        await _userManager.AddToRoleAsync(AppUser, MMRoles.ClientUserRole);
                        _context.ClientUser.Add(new ClientUser { ApplicaitonUserId = AppUser.Id, PrimaryContact = false, BillingContact = false, DesignationId = null, ReferralTypeId = null, Notes = string.Empty, IsInternalUser = true, TermsAccepted = true, IsActive = true, CreatedOn = DateTime.Now, ModifiedOn = DateTime.Now });
                        _context.SaveChanges();
                    }
                }
                catch
                {
                }

                try
                {
                    var AppUser = new ApplicationUser
                    {
                        Email = "Adrie@wisa.org.za",
                        UserName = "Adrie@wisa.org.za",
                        FirstName = "Adrie",
                        LastName = "Krugel",
                        TitleId = 1,
                        IsActive = false,
                        GenderId = 1,
                        UserTypeId = 1
                    };
                    var result = await _userManager.CreateAsync(AppUser, "Adriek");

                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(AppUser, MMRoles.NoAdminRole);
                        await _userManager.AddToRoleAsync(AppUser, MMRoles.ClientUserRole);
                        _context.ClientUser.Add(new ClientUser { ApplicaitonUserId = AppUser.Id, PrimaryContact = false, BillingContact = false, DesignationId = null, ReferralTypeId = null, Notes = string.Empty, IsInternalUser = true, TermsAccepted = true, IsActive = false, CreatedOn = DateTime.Now, ModifiedOn = DateTime.Now });
                        _context.SaveChanges();
                    }
                }
                catch
                {
                }


                try
                {
                    var AppUser = new ApplicationUser
                    {
                        Email = "Jabu@wisa.org.za",
                        UserName = "Jabu@wisa.org.za",
                        FirstName = "Jabu",
                        LastName = "Ndzumo",
                        TitleId = 1,
                        GenderId = 1,
                        IsActive = false,

                        UserTypeId = 1
                    };
                    var result = await _userManager.CreateAsync(AppUser, "JabuNdzumo");

                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(AppUser, MMRoles.NoAdminRole);
                        await _userManager.AddToRoleAsync(AppUser, MMRoles.ClientUserRole);
                        _context.ClientUser.Add(new ClientUser { ApplicaitonUserId = AppUser.Id, PrimaryContact = false, BillingContact = false, DesignationId = null, ReferralTypeId = null, Notes = string.Empty, IsInternalUser = true, TermsAccepted = true, IsActive = false, CreatedOn = DateTime.Now, ModifiedOn = DateTime.Now });
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

        public async Task<IActionResult> AddMembershipHistoryToOrganization()
        {
            string memberidentifier = string.Empty;
            ExcelHelper excelHelper = new ExcelHelper();
            var Data = ExcelHelper.GetDataFromExcel(Path.Combine(Directory.GetCurrentDirectory(), "DataMigration", "oc_membership.xlsx"));

            var organizations = _context.Organization.Select(x => new { x.Id, x.OrgMemberCode, x.Name }).ToList();
            int i = 0;

            foreach (DataRow row in Data.Rows)
            {
                memberidentifier = row["oc_nonindividualmember"].ToString();
                var org = organizations.Where(x => x.Name == memberidentifier).FirstOrDefault();
                if (memberidentifier == "Cederberg Municipality")
                {

                }
                if (org == null)
                {
                    memberidentifier = row["new_employertmp"].ToString();
                    org = organizations.Where(x => x.Name == memberidentifier).FirstOrDefault();
                }

                if (org == null)
                {
                    memberidentifier = row["new_membershipnrmember"].ToString();
                    org = organizations.Where(x => x.OrgMemberCode == memberidentifier).FirstOrDefault();
                }

                if (org != null)
                {
                    i++;
                    try
                    {
                        OrganizationMemberShipHistory orghistory = new OrganizationMemberShipHistory();
                        orghistory.OrganizationId = org.Id;
                        orghistory.IsActive = StateCode(row["statecode"].ToString());

                        string status = row["oc_reasonforchange"].ToString();

                        if (!string.IsNullOrEmpty(status))
                        {
                            orghistory.MemberShipChangeReasonId = statuscode(status);
                        }
                        else
                        {
                            orghistory.MemberShipChangeReasonId = statuscode(row["statuscode"].ToString());
                        }

                        if (orghistory.MemberShipChangeReasonId == null)
                        {

                        }
                        orghistory.OrganizationTypeId = OrganizationTypeId(row["oc_membershipcategory"].ToString());
                        orghistory.OrganizationGradeId = OrganizationGradeId(row["oc_membershiptype"].ToString());
                        orghistory.MemberShipChangeReasonId = statuscode(row["statuscode"].ToString());
                        orghistory.StartDate = GetDate(row["oc_fromdate"].ToString());
                        orghistory.EndDate = GetDate(row["oc_todate"].ToString());
                        orghistory.Notes = row["oc_notes"].ToString();
                        orghistory.CreatedBy = UserId(row["createdby"].ToString());
                        orghistory.CreatedOn = GetDate(row["createdon"].ToString());
                        orghistory.ModifiedBy = UserId(row["modifiedby"].ToString());
                        orghistory.ModifiedOn = GetDate(row["modifiedon"].ToString());

                        await _context.OrganizationMemberShipHistory.AddAsync(orghistory);
                        if (i % 300 == 0)
                        {
                            await _context.SaveChangesAsync();
                        }

                    }
                    catch (Exception ex)
                    {
                        Rollback();
                        _logger.LogError(" Exception while adding history To Individual: " + ex.Message + " Inner Exception " + ex.InnerException);
                    }
                }

            }
            await _context.SaveChangesAsync();
            return new JsonResult(new { success = false, message = "Error. Please check values entered" });
        }

        public async Task<IActionResult> AddMembershipHistoryToIndividuals()
        {


            ExcelHelper excelHelper = new ExcelHelper();
            var Data = ExcelHelper.GetDataFromExcel(Path.Combine(Directory.GetCurrentDirectory(), "DataMigration", "oc_membership.xlsx"));

            var members = _context.MemberUser.Include(x => x.ApplicationUser).Select(x => new { x.Id, x.MemberCode, x.ApplicationUser.FullName }).ToList();
            string memberidentifier = string.Empty;

            int i = 0;

            foreach (DataRow row in Data.Rows)
            {
                memberidentifier = row["oc_member"].ToString();
                var member = members.Where(x => x.FullName == memberidentifier).FirstOrDefault();

                if (member == null)
                {
                    memberidentifier = row["new_initialstmp"].ToString();
                    member = members.Where(x => x.FullName == memberidentifier).FirstOrDefault();
                }

                if (member == null)
                {
                    memberidentifier = row["new_membershipnrmember"].ToString();
                    member = members.Where(x => x.MemberCode == memberidentifier).FirstOrDefault();
                }

                if (member != null)
                {
                    try
                    {
                        i++;

                        IndividualMemberShipHistory indhistory = new IndividualMemberShipHistory();
                        indhistory.MemberId = member.Id;
                        indhistory.IsActive = StateCode(row["statecode"].ToString());

                        string status = row["oc_reasonforchange"].ToString();

                        if (!string.IsNullOrEmpty(status))
                        {
                            indhistory.MemberShipChangeReasonId = statuscode(status);
                        }
                        else
                        {
                            indhistory.MemberShipChangeReasonId = statuscode(row["statuscode"].ToString());
                        }

                        if (indhistory.MemberShipChangeReasonId == null)
                        {

                        }
                        indhistory.MembershipTypeId = MembershipTypeId(row["oc_membershipcategory"].ToString());
                        indhistory.MemberShipGradeId = MembershipGradeId(row["oc_membershiptype"].ToString());
                        indhistory.MemberShipChangeReasonId = statuscode(row["statuscode"].ToString());
                        indhistory.StartDate = GetDate(row["oc_fromdate"].ToString());
                        indhistory.EndDate = GetDate(row["oc_todate"].ToString());
                        indhistory.Notes = row["oc_notes"].ToString();
                        indhistory.CreatedBy = UserId(row["createdby"].ToString());
                        indhistory.CreatedOn = GetDate(row["createdon"].ToString());
                        indhistory.ModifiedBy = UserId(row["modifiedby"].ToString());
                        indhistory.ModifiedOn = GetDate(row["modifiedon"].ToString());

                        await _context.IndividualMemberShipHistory.AddAsync(indhistory);
                        if (i % 500 == 0)
                        {
                            await _context.SaveChangesAsync();
                        }

                    }
                    catch (Exception ex)
                    {
                        Rollback();
                        _logger.LogError(" Exception while adding history To Individual: " + ex.Message + " Inner Exception " + ex.InnerException);
                    }
                }

            }

            await _context.SaveChangesAsync();
            return new JsonResult(new { success = false, message = "Error. Please check values entered" });
        }

        public IActionResult GetAllMembers()
        {
            using (ClientDbContext db = new ClientDbContext())
            {


            }

            var members = _context.MemberUser.Select(x => new { x.Id, x.Email, x.MemberCode }).ToList();
            using (StreamWriter outputFile = new StreamWriter("c:\\temp\\members.csv"))
            {
                foreach (var member in members)
                {
                    outputFile.WriteLine(member.Id + "," + member.Email + "," + member.MemberCode);
                }
            }

            return new JsonResult(new { success = false, message = "Error. Please check values entered" });
        }

        public async Task<IActionResult> CreateClientOrganization()
        {
            using (ClientDbContext db = new ClientDbContext())
            {
                try
                {
                    await _context.ClientOrganization.AddAsync(new ClientOrganization
                    {
                        Name = "WISA",
                        AgreedToTerms = true,
                        DateSettingId = 6,
                        TimeFormatId = 1,
                        ClientTimeZoneId = 38,
                        CurrencyId = 133,
                        ClientOrganizationTypeId = 15,
                        CurrencyDecimalPlaces = 3,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now
                    });

                    await _context.SaveChangesAsync();

                }
                catch { }

            }
            return new JsonResult(new { success = false, message = "Error. Please check values entered" });
        }

        public async Task<IActionResult> CreateNonIndividuals()
        {
            using (ClientDbContext db = new ClientDbContext())
            {
                ExcelHelper excelHelper = new ExcelHelper();
                var Data = ExcelHelper.GetDataFromExcel(Path.Combine(Directory.GetCurrentDirectory(), "DataMigration", "account.xlsx"));


                int i = 0;
                foreach (DataRow row in Data.Rows)
                {
                    Organization org = new Organization();

                    i++;
                    try
                    {
                        org.MemberStatusId = MemberStatusId(row["ec_membershipstatus"].ToString());
                        org.OrgMemberCode = row["ec_membershipnumber"].ToString();

                        Organization orgExist = _context.Organization.Where(x => x.OrgMemberCode == org.OrgMemberCode).FirstOrDefault();
                        if (orgExist != null)
                            continue;

                        org.RegistrationNumber = row["ec_companyregistrationnumber"].ToString();
                        org.TaxNumber = row["ec_companyvatnumber"].ToString();
                        org.AccountBalance = GetDecimal(row["ec_accountbalance"].ToString());
                        org.OrganizationGradeId = OrganizationGradeId(row["ec_membershiptype"].ToString()); ////////////////////////
                        org.OrganizationTypeId = OrganizationTypeId(row["ec_nonindividualmembercategories"].ToString()); ////////////////////


                        org.IsAdminFeePaid = GetBoolean(row["ec_adminfee"].ToString());
                        org.AdminfeePaymentReceivedDate = GetDate(row["ec_admminfeepaidon"].ToString());
                        org.IsInvoiceSent = GetBoolean(row["ec_invoivesent"].ToString());
                        org.IsmemberFeePaid = GetBoolean(row["ec_memberfee"].ToString());
                        org.MemberfeePaymentReceivedDate = GetDate(row["ec_memberfeedatepaid"].ToString());
                        org.IsCertificatePosted = GetBoolean(row["ec_postcertificate"].ToString());
                        org.PostCertificateTracking = row["ec_postcertificatetracking"].ToString();
                        org.AmountDueAsAtDate = GetDate(row["ec_amountdueasat1"].ToString());
                        org.StartDate = GetDate(row["ec_startdate"].ToString());
                        org.EndDate = GetDate(row["ec_enddate"].ToString());
                        org.ClientBranchId = GetOrgBranch(row["territoryid"].ToString());
                        org.IsMembershipFeeInvoicedToCompany = GetBoolean(row["ec_membershipfeeinvoicedtoyourcompany"].ToString());
                        org.PublishCompanyInAnnualMemberDirectory = GetBoolean(row["ec_canwepublishesyourdetails1"].ToString());
                        org.IsTermAccepted = GetBooleanNonNull(row["ec_declarationacceptence"].ToString());
                        org.AmountWrittenOff = GetDecimal(row["new_amountwrittenoffni"].ToString());
                        org.DatetWrittenOff = GetDate(row["new_datedebtwrittenoffni"].ToString());
                        org.SentforGradingDate = GetDate(row["new_sentforgradingnim"].ToString());
                        org.GradingCompletedDate = GetDate(row["new_gradingcompletednim"].ToString());
                        org.IsCertificateUploaded = GetBoolean(row["new_certificateuploadednim"].ToString());
                        org.CertificateAndwelcomeLetterEmailedDate = GetDate(row["new_emailcertificateandwelcomeletternim"].ToString());
                        org.PostingofCertificateDate = GetDate(row["new_certificatepostednim"].ToString());
                        org.ProformaInvoiceEmailedDate = GetDate(row["new_proformainvoiceemailednim"].ToString());
                        org.ProofofPaymentReceivedDate = GetDate(row["new_proofofpaymentreceivednim"].ToString());
                        org.TaxInvoicEmailedDate = GetDate(row["new_taxinvoiceemailednim"].ToString());
                        org.IsApplicationFormComplete = GetBoolean(row["new_applicationformcompletenim"].ToString());
                        org.PaymentReminder1Date = GetDate(row["new_paymentreminder1nim"].ToString());
                        org.PaymentReminder2Date = GetDate(row["new_paymentreminder2nim"].ToString());
                        org.PaymentReminder3Date = GetDate(row["new_paymentreminder3nim"].ToString());
                        org.CancelapplicationNopayDate = GetDate(row["new_cancelappnopaymentnim"].ToString());
                        org.CertificateAndwelcomeLetterEmailedDate = GetDate(row["new_emailcertificatewelcomeletternimdate"].ToString());
                        org.ApplicationReceivedDate = GetDate(row["new_dateapplicationreceived"].ToString());
                        org.Request2MemberFee = GetDate(row["new_request2memberfee"].ToString());
                        org.Request3MemberFee = GetDate(row["new_request3memberfee"].ToString());
                        org.ApplicationCancelledMemberfeeNotpaidDate = GetDate(row["new_applicationcancelled_nonpayment_mfee"].ToString());
                        org.Description = row["description"].ToString();
                        org.TransactionCurrencyid = 216;
                        org.PhoneNumber = row["telephone1"].ToString();
                        org.IsCreditOnHold = GetBoolean(row["creditonhold"].ToString());
                        org.ModifiedOn = GetDate(row["modifiedon"].ToString());
                        org.Name = row["name"].ToString().Replace("~~", ",");
                        org.WebSite = row["websiteurl"].ToString();
                        org.CreatedOn = GetDate(row["createdon"].ToString());
                        org.SecondaryPhoneNumber = row["telephone2"].ToString();
                        org.OriginalSystemRecordId = row["accountid"].ToString();
                        org.AccountBalanceBase = GetDecimal(row["ec_accountbalance_base"].ToString());
                        org.ContactPersonName = row["new_contactpeson"].ToString();
                        org.PrimaryContactName = row["primarycontactid"].ToString();
                        org.CreatedBy = UserId(row["createdby"].ToString());
                        org.ModifiedBy = UserId(row["modifiedby"].ToString());
                        org.OwnerClientUserId = UserId(row["ownerid"].ToString());



                        await db.Organization.AddAsync(org);
                        await db.SaveChangesAsync();
                        #region OrgAddress

                        Address PhysicalAddress = new Address();

                        PhysicalAddress.RelatedEntityId = org.Id;
                        PhysicalAddress.RelatedToId = (int)RelatedToEnum.Organization;
                        PhysicalAddress.AddressTypeId = (int)AddressTypeEnum.Physical;

                        PhysicalAddress.AddressLine1 = row["address1_line1"].ToString();
                        if (!string.IsNullOrEmpty(PhysicalAddress.AddressLine1))
                        {
                            PhysicalAddress.AddressLine1 = PhysicalAddress.AddressLine1.Replace("$~$", "\n");
                            PhysicalAddress.AddressLine1 = PhysicalAddress.AddressLine1.Replace("~~", ",");
                        }
                        PhysicalAddress.AddressLine2 = row["address1_line2"].ToString();
                        if (!string.IsNullOrEmpty(PhysicalAddress.AddressLine2))
                        {
                            PhysicalAddress.AddressLine2 = PhysicalAddress.AddressLine2.Replace("$~$", "\n");
                            PhysicalAddress.AddressLine2 = PhysicalAddress.AddressLine2.Replace("~~", ",");
                        }
                        PhysicalAddress.AddressLine3 = row["address1_line3"].ToString();
                        if (!string.IsNullOrEmpty(PhysicalAddress.AddressLine3))
                        {
                            PhysicalAddress.AddressLine3 = PhysicalAddress.AddressLine3.Replace("$~$", "\n");
                            PhysicalAddress.AddressLine3 = PhysicalAddress.AddressLine3.Replace("~~", ",");
                            PhysicalAddress.Suburb = PhysicalAddress.AddressLine3;
                        }
                        PhysicalAddress.CityName = row["address1_city"].ToString();
                        if (!string.IsNullOrEmpty(PhysicalAddress.CityName))
                        {
                            PhysicalAddress.CityName = PhysicalAddress.CityName.Replace("$~$", "\n");
                            PhysicalAddress.CityName = PhysicalAddress.CityName.Replace("~~", ",");
                        }
                        PhysicalAddress.Province = row["address1_stateorprovince"].ToString();
                        if (!string.IsNullOrEmpty(PhysicalAddress.Province))
                        {
                            PhysicalAddress.Province = PhysicalAddress.Province.Replace("$~$", "\n");
                            PhysicalAddress.Province = PhysicalAddress.Province.Replace("~~", ",");
                        }
                        PhysicalAddress.StateId = GetMemberProvinceId(PhysicalAddress.Province);

                        PhysicalAddress.CountryName = row["address1_country"].ToString();
                        if (!string.IsNullOrEmpty(PhysicalAddress.CountryName))
                        {
                            PhysicalAddress.CountryName = PhysicalAddress.CountryName.Replace("$~$", "\n");
                            PhysicalAddress.CountryName = PhysicalAddress.CountryName.Replace("~~", ",");
                        }
                        if (PhysicalAddress.StateId == null)
                        {
                            PhysicalAddress.StateId = GetMemberProvinceId(PhysicalAddress.CountryName);
                        }
                        PhysicalAddress.CountryId = CountryId(PhysicalAddress.CountryName);
                        PhysicalAddress.PostalCode = row["address1_postalcode"].ToString();
                        PhysicalAddress.CreatedBy = UserId(row["createdby"].ToString());
                        PhysicalAddress.ModifiedBy = UserId(row["modifiedby"].ToString());

                        await db.Address.AddAsync(PhysicalAddress);


                        Address PostalAddress = new Address();
                        PostalAddress.RelatedEntityId = org.Id;
                        PostalAddress.RelatedToId = (int)RelatedToEnum.Organization;
                        PostalAddress.AddressTypeId = (int)AddressTypeEnum.Postal;
                        PostalAddress.AddressLine1 = row["address2_line1"].ToString();
                        if (!string.IsNullOrEmpty(PostalAddress.AddressLine1))
                        {
                            PostalAddress.AddressLine1 = PostalAddress.AddressLine1.Replace("$~$", "\n");
                            PostalAddress.AddressLine1 = PostalAddress.AddressLine1.Replace("~~", ",");
                        }
                        PostalAddress.AddressLine2 = row["address2_line2"].ToString();
                        if (!string.IsNullOrEmpty(PostalAddress.AddressLine2))
                        {
                            PostalAddress.AddressLine2 = PostalAddress.AddressLine2.Replace("$~$", "\n");
                            PostalAddress.AddressLine2 = PostalAddress.AddressLine2.Replace("~~", ",");
                        }
                        PostalAddress.AddressLine3 = row["address2_line3"].ToString();
                        if (!string.IsNullOrEmpty(PostalAddress.AddressLine3))
                        {
                            PostalAddress.AddressLine3 = PostalAddress.AddressLine3.Replace("$~$", "\n");
                            PostalAddress.AddressLine3 = PostalAddress.AddressLine3.Replace("~~", ",");
                            PostalAddress.Suburb = PostalAddress.AddressLine3;
                        }
                        PostalAddress.CityName = row["address2_city"].ToString();
                        if (!string.IsNullOrEmpty(PostalAddress.CityName))
                        {
                            PostalAddress.CityName = PostalAddress.CityName.Replace("$~$", "\n");
                            PostalAddress.CityName = PostalAddress.CityName.Replace("~~", ",");
                        }
                        PostalAddress.Province = row["address2_stateorprovince"].ToString();
                        if (!string.IsNullOrEmpty(PostalAddress.Province))
                        {
                            PostalAddress.Province = PostalAddress.Province.Replace("$~$", "\n");
                            PostalAddress.Province = PostalAddress.Province.Replace("~~", ",");
                        }
                        PostalAddress.StateId = GetMemberProvinceId(PostalAddress.Province);
                        PostalAddress.CountryName = row["address2_country"].ToString();
                        if (!string.IsNullOrEmpty(PostalAddress.CountryName))
                        {
                            PostalAddress.CountryName = PostalAddress.CountryName.Replace("$~$", "\n");
                            PostalAddress.CountryName = PostalAddress.CountryName.Replace("~~", ",");
                        }
                        if (PostalAddress.StateId == null)
                        {
                            PostalAddress.StateId = GetMemberProvinceId(PostalAddress.CountryName);
                        }
                        PostalAddress.CountryId = CountryId(PostalAddress.CountryName);
                        PostalAddress.PostalCode = row["address2_postalcode"].ToString();
                        PostalAddress.CreatedBy = UserId(row["createdby"].ToString());
                        PostalAddress.ModifiedBy = UserId(row["modifiedby"].ToString());

                        await db.Address.AddAsync(PostalAddress);


                        #endregion

                        //MemberUser Member = new MemberUser();

                        ////Member.ApplicaitonUserId = Member.Id.ToString();
                        ////Member.JobTitle = row["new_jobtitle"].ToString();
                        ////Member.MobilePhone = row["new_mobile1"].ToString();
                        ////Member.Email = row["emailaddress1"].ToString();
                        ////Member.FAXNumber = row["fax"].ToString();
                        ////Member.MemberStatus.Name = row["statuscode"].ToString();
                        ////Member.MemberCommunicationPreference = row["preferredcontactmethodcode"].ToString();


                        #region add Core businesses
                        bool? ec_consultants = GetBoolean(row["ec_consultants"].ToString());
                        bool? ec_groundwatermanagement = GetBoolean(row["ec_groundwatermanagement"].ToString());
                        bool? ec_laboratoryservices = GetBoolean(row["ec_laboratoryservices"].ToString());
                        bool? ec_researchanddevelopment = GetBoolean(row["ec_researchanddevelopment"].ToString());
                        bool? ec_waterinfrastructure = GetBoolean(row["ec_waterinfrastructure"].ToString());
                        bool? ec_waterwastewatermanagement = GetBoolean(row["ec_waterwastewatermanagement"].ToString());
                        bool? ec_industrialminewatermanagement = GetBoolean(row["ec_industrialminewatermanagement"].ToString());


                        if (ec_consultants == true)
                        {
                            await db.OrganizationBusinessXref.AddAsync(
                                new OrganizationBusinessXref
                                {
                                    BusinessId = 1,
                                    OrganizationId = org.Id,
                                    CreatedBy = org.CreatedBy,
                                    ModifiedBy = org.ModifiedBy,
                                    CreatedOn = DateTime.Now,
                                    ModifiedOn = DateTime.Now
                                });
                        }
                        if (ec_groundwatermanagement == true)
                        {
                            await db.OrganizationBusinessXref.AddAsync(
                                new OrganizationBusinessXref
                                {
                                    BusinessId = 2,
                                    OrganizationId = org.Id,
                                    CreatedBy = org.CreatedBy,
                                    ModifiedBy = org.ModifiedBy,
                                    CreatedOn = DateTime.Now,
                                    ModifiedOn = DateTime.Now
                                });
                        }
                        if (ec_laboratoryservices == true)
                        {
                            await db.OrganizationBusinessXref.AddAsync(
                                new OrganizationBusinessXref
                                {
                                    BusinessId = 3,
                                    OrganizationId = org.Id,
                                    CreatedBy = org.CreatedBy,
                                    ModifiedBy = org.ModifiedBy,
                                    CreatedOn = DateTime.Now,
                                    ModifiedOn = DateTime.Now
                                });
                        }
                        if (ec_researchanddevelopment == true)
                        {
                            await db.OrganizationBusinessXref.AddAsync(
                                new OrganizationBusinessXref
                                {
                                    BusinessId = 4,
                                    OrganizationId = org.Id,
                                    CreatedBy = org.CreatedBy,
                                    ModifiedBy = org.ModifiedBy,
                                    CreatedOn = DateTime.Now,
                                    ModifiedOn = DateTime.Now
                                });
                        }
                        if (ec_waterinfrastructure == true)
                        {
                            await db.OrganizationBusinessXref.AddAsync(
                                new OrganizationBusinessXref
                                {
                                    BusinessId = 5,
                                    OrganizationId = org.Id,
                                    CreatedBy = org.CreatedBy,
                                    ModifiedBy = org.ModifiedBy,
                                    CreatedOn = DateTime.Now,
                                    ModifiedOn = DateTime.Now
                                });
                        }

                        if (ec_waterwastewatermanagement == true)
                        {
                            await db.OrganizationBusinessXref.AddAsync(
                                new OrganizationBusinessXref
                                {
                                    BusinessId = 6,
                                    OrganizationId = org.Id,
                                    CreatedBy = org.CreatedBy,
                                    ModifiedBy = org.ModifiedBy,
                                    CreatedOn = DateTime.Now,
                                    ModifiedOn = DateTime.Now
                                });
                        }

                        if (ec_industrialminewatermanagement == true)
                        {
                            await db.OrganizationBusinessXref.AddAsync(
                                new OrganizationBusinessXref
                                {
                                    BusinessId = 7,
                                    OrganizationId = org.Id,
                                    CreatedBy = org.CreatedBy,
                                    ModifiedBy = org.ModifiedBy,
                                    CreatedOn = DateTime.Now,
                                    ModifiedOn = DateTime.Now
                                });
                        }
                        #endregion

                        //#region add Communications
                        //bool? new_postmagazine = GetBoolean(row["new_postingofmagazine"].ToString());
                        //bool? donotfax = GetBoolean(row["donotfax"].ToString());
                        //bool? donotphone = GetBoolean(row["donotphone"].ToString());
                        //bool? donotbulkpostalmail = GetBoolean(row["donotbulkpostalmail"].ToString());
                        //bool? donotemail = GetBoolean(row["donotemail"].ToString());
                        //bool? donotsendmm = GetBoolean(row["donotsendmm"].ToString());
                        //bool? donotpostalmail = GetBoolean(row["donotpostalmail"].ToString());
                        //bool? followemail = GetBoolean(row["followemail"].ToString());
                        //bool? donotbulkemail = GetBoolean(row["donotbulkemail"].ToString());

                        //if (new_postmagazine == true)
                        //{
                        //    await db.MemberUser.AddAsync(
                        //        new MemberUser
                        //        {

                        //            Id = Member.Id,
                        //            DonotSendMassMarketing = false,
                        //            CreatedBy = Member.CreatedBy,
                        //            ModifiedBy = Member.ModifiedBy,
                        //            CreatedOn = DateTime.Now,
                        //            ModifiedOn = DateTime.Now
                        //        }) ;
                        //}

                        //if (donotfax == true)
                        //{
                        //    await db.MemberUser.AddAsync(
                        //        new MemberUser
                        //        {

                        //            Id = Member.Id,
                        //            DonotFax = false,
                        //            CreatedBy = Member.CreatedBy,
                        //            ModifiedBy = Member.ModifiedBy,
                        //            CreatedOn = DateTime.Now,
                        //            ModifiedOn = DateTime.Now
                        //        });
                        //}

                        //if (donotphone == true)
                        //{
                        //    await db.MemberUser.AddAsync(
                        //        new MemberUser
                        //        {

                        //            Id = Member.Id,
                        //            DonotPhone = false,
                        //            CreatedBy = Member.CreatedBy,
                        //            ModifiedBy = Member.ModifiedBy,
                        //            CreatedOn = DateTime.Now,
                        //            ModifiedOn = DateTime.Now
                        //        });
                        //}

                        //if (donotbulkpostalmail == true)
                        //{
                        //    await db.MemberUser.AddAsync(
                        //        new MemberUser
                        //        {

                        //            Id = Member.Id,
                        //            DonotBulkPostalMail = false,
                        //            CreatedBy = Member.CreatedBy,
                        //            ModifiedBy = Member.ModifiedBy,
                        //            CreatedOn = DateTime.Now,
                        //            ModifiedOn = DateTime.Now
                        //        });
                        //}

                        //if (donotemail == true)
                        //{
                        //    await db.MemberUser.AddAsync(
                        //        new MemberUser
                        //        {

                        //            Id = Member.Id,
                        //            DoNotEmail = false,
                        //            CreatedBy = Member.CreatedBy,
                        //            ModifiedBy = Member.ModifiedBy,
                        //            CreatedOn = DateTime.Now,
                        //            ModifiedOn = DateTime.Now
                        //        });
                        //}

                        //if (donotsendmm == true)
                        //{
                        //    await db.MemberUser.AddAsync(
                        //        new MemberUser
                        //        {

                        //            Id = Member.Id,
                        //            DonotSendMassMarketing = false,
                        //            CreatedBy = Member.CreatedBy,
                        //            ModifiedBy = Member.ModifiedBy,
                        //            CreatedOn = DateTime.Now,
                        //            ModifiedOn = DateTime.Now
                        //        });
                        //}

                        //if (donotpostalmail == true)
                        //{
                        //    await db.MemberUser.AddAsync(
                        //        new MemberUser
                        //        {

                        //            Id = Member.Id,
                        //            DonotpostalMail = false,
                        //            CreatedBy = Member.CreatedBy,
                        //            ModifiedBy = Member.ModifiedBy,
                        //            CreatedOn = DateTime.Now,
                        //            ModifiedOn = DateTime.Now
                        //        });
                        //}

                        //if (followemail == true)
                        //{
                        //    await db.MemberUser.AddAsync(
                        //        new MemberUser
                        //        {

                        //            Id = Member.Id,
                        //            FollowEmail = false,
                        //            CreatedBy = Member.CreatedBy,
                        //            ModifiedBy = Member.ModifiedBy,
                        //            CreatedOn = DateTime.Now,
                        //            ModifiedOn = DateTime.Now
                        //        });
                        //}

                        //if (donotbulkemail == true)
                        //{
                        //    await db.MemberUser.AddAsync(
                        //        new MemberUser
                        //        {

                        //            Id = Member.Id,
                        //            DonotBulkEmail = false,
                        //            CreatedBy = Member.CreatedBy,
                        //            ModifiedBy = Member.ModifiedBy,
                        //            CreatedOn = DateTime.Now,
                        //            ModifiedOn = DateTime.Now
                        //        });
                        //}

                        if (i % 300 == 0)
                        {
                            await db.SaveChangesAsync();
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(org.OrgMemberCode + " Failed :Exception:" + ex.Message + "Inner Exception:" + ex.InnerException);
                    }
                }

                await db.SaveChangesAsync();
            }

            return new JsonResult(new { success = false, message = "Error. Please check values entered" });
        }

        public async Task<IActionResult> AddNotesToIndividuals()
        {
            using (ClientDbContext db = new ClientDbContext())
            {


            }

            int i = 0;
            ExcelHelper excelHelper = new ExcelHelper();
            var Data = ExcelHelper.GetDataFromExcel(Path.Combine(Directory.GetCurrentDirectory(), "DataMigration", "annotation_contactXref.xlsx"));

            var members = _context.MemberUser.Select(x => new { x.Id, x.MemberCode }).ToList();

            foreach (var member in members)
            {


                DataRow[] NotesRows = Data.Select("orgmemberNumber='" + member.MemberCode + "'");

                foreach (DataRow notes in NotesRows)
                {

                    i++;
                    try
                    {
                        var isDocument = GetBoolean(notes["isDocument"].ToString());
                        if (isDocument == false)
                        {
                            MemberNotesXref mnotes = new MemberNotesXref();
                            mnotes.RelatedEntityId = member.Id;
                            mnotes.RelatedToId = (int)RelatedToEnum.Member;
                            mnotes.Subject = notes["subject"].ToString();

                            if (!string.IsNullOrEmpty(mnotes.Subject))
                            {
                                mnotes.Subject = mnotes.Subject.Replace("$~$", "<br>");
                                mnotes.Subject = mnotes.Subject.Replace("~~", ",");
                            }
                            mnotes.Notes = notes["notetext"].ToString();
                            if (!string.IsNullOrEmpty(mnotes.Notes))
                            {
                                mnotes.Notes = mnotes.Notes.Replace("$~$", "<br>");
                                mnotes.Notes = mnotes.Notes.Replace("~~", ",");
                            }
                            mnotes.CreatedBy = UserId(notes["createdby"].ToString());
                            mnotes.CreatedOn = GetDate(notes["createdon"].ToString());
                            mnotes.ModifiedBy = UserId(notes["modifiedby"].ToString());
                            mnotes.ModifiedOn = GetDate(notes["modifiedon"].ToString());

                            await _context.MemberNotesXref.AddAsync(mnotes);
                            if (i % 1000 == 0)
                            {
                                await _context.SaveChangesAsync();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Rollback();
                        _logger.LogError(" Exception while adding Notes To Individual: " + ex.Message + " Inner Exception " + ex.InnerException);
                    }
                }

            }
            await _context.SaveChangesAsync();
            return new JsonResult(new { success = false, message = "Error. Please check values entered" });
        }

        public async Task<IActionResult> AddFilesToIndividuals()
        {
            using (ClientDbContext db = new ClientDbContext())
            {


            }
            int i = 0;
            ExcelHelper excelHelper = new ExcelHelper();
            var Data = ExcelHelper.GetDataFromExcel(Path.Combine(Directory.GetCurrentDirectory(), "DataMigration", "annotation_contactXref.xlsx"));
            var members = _context.MemberUser.Select(x => new { x.Id, x.MemberCode }).ToList();

            foreach (var member in members)
            {


                DataRow[] FilesRows = Data.Select("orgmemberNumber='" + member.MemberCode + "'");

                foreach (DataRow files in FilesRows)
                {
                    i++;
                    try
                    {
                        var isDocument = GetBoolean(files["isDocument"].ToString());
                        if (isDocument == true)
                        {
                            MemberFileXref mfiles = new MemberFileXref();
                            mfiles.RelatedEntityId = member.Id;
                            mfiles.RelatedToId = (int)RelatedToEnum.Member;
                            mfiles.Subject = files["subject"].ToString();
                            if (!string.IsNullOrEmpty(mfiles.Subject))
                            {
                                mfiles.Subject = mfiles.Subject.Replace("$~$", "\n");
                                mfiles.Subject = mfiles.Subject.Replace("~~", ",");
                            }
                            mfiles.Notes = files["notetext"].ToString();
                            if (!string.IsNullOrEmpty(mfiles.Notes))
                            {
                                mfiles.Notes = mfiles.Notes.Replace("$~$", "\n");
                                mfiles.Notes = mfiles.Notes.Replace("~~", ",");
                            }
                            mfiles.FileTypeId = null;
                            mfiles.FileName = files["filename"].ToString();
                            mfiles.FileExtension = null;
                            mfiles.FilePath = files["filepath"].ToString();
                            mfiles.CreatedBy = UserId(files["createdby"].ToString());
                            mfiles.CreatedOn = GetDate(files["createdon"].ToString());
                            mfiles.ModifiedBy = UserId(files["modifiedby"].ToString());
                            mfiles.ModifiedOn = GetDate(files["modifiedon"].ToString());

                            await _context.MemberFileXref.AddAsync(mfiles);
                            if (i % 1000 == 0)
                            {
                                await _context.SaveChangesAsync();
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                        Rollback();
                        _logger.LogError(" Exception while adding files to individual: " + ex.Message + " Inner Exception " + ex.InnerException);
                    }
                }

            }
            await _context.SaveChangesAsync();
            return new JsonResult(new { success = false, message = "Error. Please check values entered" });
        }

        public async Task<IActionResult> AddNotesToNonIndividuals()
        {
            int i = 0; ;
            using (ClientDbContext db = new ClientDbContext())
            {

            }
            ExcelHelper excelHelper = new ExcelHelper();
            var Data = ExcelHelper.GetDataFromExcel(Path.Combine(Directory.GetCurrentDirectory(), "DataMigration", "annotation_accountXref.xlsx"));
            var organizations = _context.Organization.Select(x => new { x.Id, x.OrgMemberCode }).ToList();

            foreach (var org in organizations)
            {


                DataRow[] NotesRows = Data.Select("orgmemberNumber='" + org.OrgMemberCode + "'");

                foreach (DataRow notes in NotesRows)
                {
                    i++;
                    try
                    {
                        var isDocument = GetBoolean(notes["isDocument"].ToString());
                        if (isDocument == false)
                        {
                            MemberNotesXref mnotes = new MemberNotesXref();
                            mnotes.RelatedEntityId = org.Id;
                            mnotes.RelatedToId = (int)RelatedToEnum.Organization;
                            mnotes.Subject = notes["subject"].ToString();
                            if (!string.IsNullOrEmpty(mnotes.Subject))
                            {
                                mnotes.Subject = mnotes.Subject.Replace("$~$", "<br>");
                                mnotes.Subject = mnotes.Subject.Replace("~~", ",");
                            }
                            mnotes.Notes = notes["notetext"].ToString();
                            if (!string.IsNullOrEmpty(mnotes.Notes))
                            {
                                mnotes.Notes = mnotes.Notes.Replace("$~$", "<br>");
                                mnotes.Notes = mnotes.Notes.Replace("~~", ",");
                            }
                            mnotes.CreatedBy = UserId(notes["createdby"].ToString());
                            mnotes.CreatedOn = GetDate(notes["createdon"].ToString());
                            mnotes.ModifiedBy = UserId(notes["modifiedby"].ToString());
                            mnotes.ModifiedOn = GetDate(notes["modifiedon"].ToString());

                            await _context.MemberNotesXref.AddAsync(mnotes);
                            if (i % 1000 == 0)
                            {
                                await _context.SaveChangesAsync();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Rollback();
                        _logger.LogError(" Exception while adding Notes To Non Individual: " + ex.Message + " Inner Exception " + ex.InnerException);
                    }
                }
            }
            await _context.SaveChangesAsync();
            return new JsonResult(new { success = false, message = "Error. Please check values entered" });
        }

        public async Task<IActionResult> AddFilesToNonIndividuals()
        {
            int i = 0;
            using (ClientDbContext db = new ClientDbContext())
            {

            }
            ExcelHelper excelHelper = new ExcelHelper();
            var Data = ExcelHelper.GetDataFromExcel(Path.Combine(Directory.GetCurrentDirectory(), "DataMigration", "annotation_accountXref.xlsx"));
            var organizations = _context.Organization.Select(x => new { x.Id, x.OrgMemberCode }).ToList();

            foreach (var org in organizations)
            {


                DataRow[] FilesRows = Data.Select("orgmemberNumber='" + org.OrgMemberCode + "'");

                foreach (DataRow files in FilesRows)
                {
                    i++;
                    try
                    {
                        var isDocument = GetBoolean(files["isDocument"].ToString());
                        if (isDocument == true)
                        {
                            MemberFileXref mfiles = new MemberFileXref();
                            mfiles.RelatedEntityId = org.Id;
                            mfiles.RelatedToId = (int)RelatedToEnum.Organization;
                            mfiles.Subject = files["subject"].ToString();
                            if (!string.IsNullOrEmpty(mfiles.Subject))
                            {
                                mfiles.Subject = mfiles.Subject.Replace("$~$", "\n");
                                mfiles.Subject = mfiles.Subject.Replace("~~", ",");
                            }
                            mfiles.Notes = files["notetext"].ToString();
                            if (!string.IsNullOrEmpty(mfiles.Notes))
                            {
                                mfiles.Notes = mfiles.Notes.Replace("$~$", "\n");
                                mfiles.Notes = mfiles.Notes.Replace("~~", ",");
                            }
                            mfiles.FileTypeId = null;
                            mfiles.FileName = files["filename"].ToString();
                            mfiles.FileExtension = null;
                            mfiles.FilePath = files["filepath"].ToString();
                            mfiles.CreatedBy = UserId(files["createdby"].ToString());
                            mfiles.CreatedOn = GetDate(files["createdon"].ToString());
                            mfiles.ModifiedBy = UserId(files["modifiedby"].ToString());
                            mfiles.ModifiedOn = GetDate(files["modifiedon"].ToString());


                            await _context.MemberFileXref.AddAsync(mfiles);

                            if (i % 1000 == 0)
                            {
                                await _context.SaveChangesAsync();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Rollback();
                        _logger.LogError(" Exception while adding files To Non Individual: " + ex.Message + " Inner Exception " + ex.InnerException);
                    }
                }

            }
            await _context.SaveChangesAsync();
            return new JsonResult(new { success = false, message = "Error. Please check values entered" });
        }

        public async Task<IActionResult> CreateIndividuals()
        {

            _logger.LogInformation("Create Individuals Iternation Started.Existing user count =" + _context.MemberUser.Count());
            int startIndex = 0;
            int s = 0;
            startIndex = _context.MemberUser.Count();
            ExcelHelper excelHelper = new ExcelHelper();
            int rowNum = 0;
            string email = string.Empty;

            Stopwatch sw2 = new Stopwatch();
            sw2.Start();

            Data = ExcelHelper.GetDataFromExcel(Path.Combine(Directory.GetCurrentDirectory(), "DataMigration", "contact.xlsx"));
            QualificationData = ExcelHelper.GetDataFromExcel(Path.Combine(Directory.GetCurrentDirectory(), "DataMigration", "ec_qualifications.xlsx"));
            EmploymentData = ExcelHelper.GetDataFromExcel(Path.Combine(Directory.GetCurrentDirectory(), "DataMigration", "ec_employmenthistory.xlsx"));
            AffiliationData = ExcelHelper.GetDataFromExcel(Path.Combine(Directory.GetCurrentDirectory(), "DataMigration", "ec_membershipaffiliations.xlsx"));
            VolunteerData = ExcelHelper.GetDataFromExcel(Path.Combine(Directory.GetCurrentDirectory(), "DataMigration", "ec_volunteer.xlsx"));
            EmailData = ExcelHelper.GetDataFromExcel(Path.Combine(Directory.GetCurrentDirectory(), "DataMigration", "email.xlsx"));
            RefereeData = ExcelHelper.GetDataFromExcel(Path.Combine(Directory.GetCurrentDirectory(), "DataMigration", "ec_referee.xlsx"));


            foreach (DataRow row in Data.AsEnumerable().Skip(startIndex).Take(400))
            {
                try
                {
                    rowNum = Data.Rows.IndexOf(row) + 2;
                    email = row["emailaddress1"].ToString();

                    if (string.IsNullOrEmpty(email) || email == "null")
                    {
                        email = row["emailaddress2"].ToString();

                        if (string.IsNullOrEmpty(email) || email == "null")
                        {
                            email = "emailempty" + rowNum + "@noemail.com";
                        }
                    }
                    var UserExists = await _userManager.FindByNameAsync(email);

                    if (UserExists != null)
                    {
                        int i = 1;
                        string newemail = string.Empty;
                        while (UserExists != null)
                        {
                            newemail = email.Replace("@", i + "@");
                            UserExists = await _userManager.FindByNameAsync(newemail);
                            i++;
                            if (i > 70) break;
                        }

                        email = newemail;
                    }
                    email = email.Replace("~`~", "");
                    var AppUser = new ApplicationUser
                    {
                        Email = email,
                        UserName = email,
                        FirstName = GetNonEmptyString(row["firstname"].ToString()),
                        LastName = GetNonEmptyString(row["lastname"].ToString()),
                        TitleId = TitleId(row["salutation"].ToString()),
                        GenderId = GenderId(row["gendercode"].ToString()),
                        BirthDay = GetDate(row["birthdate"].ToString()),
                        PhoneNumber = row["mobilephone"].ToString(),
                        EmailConfirmed = true,
                        IsActive = true,
                        UserTypeId = 2
                    };

                    string pwd = row["ec_password"].ToString();
                    if (string.IsNullOrEmpty(pwd) || pwd.Length < 5)
                    {
                        pwd = "R@ndomP#d";
                    }
                    var result = await _userManager.CreateAsync(AppUser, pwd);


                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(AppUser, MMRoles.MemberRole);

                        MemberUser member = new MemberUser();
                        try
                        {
                            s++;
                            #region MemberData
                            member.isApplicationCompleted = true;
                            member.ApplicaitonUserId = AppUser.Id;
                            member.AccountBalanceOftheCompany = GetDecimal(row["ec_accountbalanceofthecompany"].ToString());
                            member.Accountbalanceofthecompany_base = GetDecimal(row["ec_accountbalanceofthecompany_base"].ToString());
                            member.AdminFee = GetBoolean(row["ec_adminfee"].ToString());
                            member.AdminfeePaymentReceivedDate = GetDate(row["new_adminfeepaymentreceiveddate"].ToString());
                            member.AdminFeeProofofpaymentReceivedDate = GetDate(row["new_adminfeedateproofofpaymentreceived"].ToString());
                            member.AdminfeeProofofpaymentSent = GetBoolean(row["new_adminfeeproofofpaymentsent"].ToString());
                            member.ApplicationCancelledMemberfeeNotpaidDate = GetDate(row["new_applicationcancelledmemberfeenotpaid"].ToString());
                            member.ApplicationFormComplete = GetBoolean(row["new_applicationformcomplete"].ToString());
                            member.ApplicationreceivedDate = GetDate(row["new_dateapplicationreceived"].ToString());

                            member.BusinessPhoneNumber = row["telephone1"].ToString();
                            member.CancelapplicationNopayDate = GetDate(row["new_cancelappnopay"].ToString());
                            member.CertificateAndwelcomeLetterEmailedDate = GetDate(row["new_emailcertificateandwelcomeletter"].ToString());
                            member.CertificateUploaded = GetBoolean(row["new_certificateuploaded"].ToString());
                            member.CompanyAddress = row["ec_companyaddress"].ToString();
                            member.CompanyName = row["ec_companyname"].ToString();
                            if (!string.IsNullOrEmpty(member.CompanyName))
                            {
                                member.CompanyName = member.CompanyName.Replace("~~", ",");
                            }

                            member.MemberCode = row["ec_membershipnumber"].ToString();
                            member.MembershipTypeId = MembershipTypeId(row["ec_membertype"].ToString());
                            member.MembershipGradeId = MembershipGradeId(row["ec_membershiptype"].ToString());
                            member.MemberStatusId = MemberStatusId(row["ec_membershipstatus"].ToString());

                            member.CompanyPhoneNumber2 = row["ec_companyphonenumber"].ToString();
                            member.CompanyPostalCode = row["ec_postalcode"].ToString();
                            member.OriginalSystemRecordId = row["contactid"].ToString();
                            member.CreatedBy = UserId(row["createdby"].ToString());
                            member.DonotBulkEmail = GetBoolean(row["donotbulkemail"].ToString());
                            member.DonotBulkPostalMail = GetBoolean(row["donotbulkpostalmail"].ToString());
                            member.DoNotEmail = GetBoolean(row["donotemail"].ToString());
                            member.DonotFax = GetBoolean(row["donotfax"].ToString());
                            member.DonotPhone = GetBoolean(row["donotphone"].ToString());
                            member.DonotpostalMail = GetBoolean(row["donotpostalmail"].ToString());
                            member.DonotSendMassMarketing = GetBoolean(row["donotsendmm"].ToString());
                            member.DoNotSMS = GetBoolean(row["ec_sms"].ToString());
                            member.DwscertificAteattached = GetBoolean(row["ec_dwscertificateattached"].ToString());
                            member.EmployerAddress = row["ec_employeraddress"].ToString();
                            member.EndDate = GetDate(row["ec_enddate"].ToString());
                            member.ExchangeRate = GetDecimal(row["exchangerate"].ToString());
                            member.FAXNumber = row["fax"].ToString();
                            member.FaxToEmail = row["ec_faxtoemail"].ToString();
                            member.FollowEmail = GetBoolean(row["followemail"].ToString());
                            member.GradingCompletedDate = GetDate(row["new_gradingcompleted"].ToString());
                            member.HomePhoneNumber = row["telephone2"].ToString();
                            member.IDAttached = GetBoolean(row["ec_idattached"].ToString());
                            member.IDNumber = row["ec_idnumber"].ToString();
                            member.Initials = row["ec_initials"].ToString();
                            member.InterestedInVolunteerWork = GetBoolean(row["ec_interestedinvolunteerwork"].ToString());
                            member.InvoiceSent = GetBoolean(row["ec_invoicesent"].ToString());
                            member.IsPrivate = GetBoolean(row["isprivate"].ToString());
                            member.JobTitle = row["jobtitle"].ToString();
                            member.LastUsedInCampaignDate = GetDate(row["lastusedincampaign"].ToString());
                            member.MemberBranchId = GetMemberBranch(row["ec_branchmembership"].ToString());
                            member.ClientBranchId = null;

                            member.MembershipFeeInvoicedToCompany = GetBoolean(row["ec_membershipfeeinvoicedtoyourcompany"].ToString());
                            member.MobilePhone = row["mobilephone"].ToString();
                            member.CreatedOn = GetDate(row["createdon"].ToString());
                            member.ModifiedOn = GetDate(row["modifiedon"].ToString());
                            member.New_Check = GetBoolean(row["new_check"].ToString());
                            member.PaymentReminder1Date = GetDate(row["new_paymentreminder1"].ToString());
                            member.PaymentReminder2Date = GetDate(row["new_paymentreminder2"].ToString());
                            member.PaymentReminder3Date = GetDate(row["new_paymentreminder3"].ToString());
                            member.PostingofCertificateDate = GetDate(row["new_postingofcertificate"].ToString());
                            member.ProformaInvoiceEmailedDate = GetDate(row["new_proformainvoiceemailed"].ToString());
                            member.ProformaInvoiceSentDate = GetDate(row["new_proformainvoicesentdate"].ToString());
                            member.ProofofPaymentReceived = GetBoolean(row["ec_proofofpayment"].ToString());
                            member.ProofofPaymentReceivedDate = GetDate(row["new_proofofpaymentreceived"].ToString());
                            member.ProofOfRegistrationAttached = GetBoolean(row["ec_proofofregistrationattached"].ToString());
                            member.PublishCompanyInAnnualMemberDirectory = GetBoolean(row["ec_publishcompanyintheannualmemberdirectory"].ToString());
                            member.QualificationAttached = GetBoolean(row["ec_qualificationattached"].ToString());
                            member.ReferralOther = row["ec_wheredidyouhearaboutwisa1"].ToString();
                            member.Request2MemberFee = GetDate(row["new_request2memberfee"].ToString());
                            member.Request3MemberFee = GetDate(row["new_request3memberfee"].ToString());
                            member.SecondaryEmail = row["emailaddress2"].ToString();
                            member.SentforGradingDate = GetDate(row["ec_sentforgrading"].ToString());
                            member.SpecialMember = GetBoolean(row["ec_specialmember"].ToString());
                            member.StartDate = GetDate(row["ec_startdate"].ToString());
                            member.TaxInvoicEemailedDate = GetDate(row["new_taxinvoiceemailed"].ToString());
                            member.TermAccepted = GetBoolean(row["ec_declarationacceptance"].ToString());
                            member.TotalCdpPointsCalculatedDate = GetDate(row["ec_totalcdppoints_date"].ToString());
                            member.VATNumber = row["ec_vatnumber"].ToString();
                            member.Email = AppUser.Email;
                            member.IsActive = true;
                            member.ModifiedBy = UserId(row["modifiedby"].ToString());
                            member.OwnerClientUserId = UserId(row["ownerid"].ToString());
                            member.ParentMemberName = row["parentcustomerid"].ToString();

                            if (!string.IsNullOrEmpty(member.ParentMemberName))
                            {
                                member.ParentMemberName = member.ParentMemberName.Replace("~~", ",");
                            }

                            member.Notes = row["description"].ToString();
                            member.FirstReminderSent = GetReminder(row["new_firstremindersent"].ToString());
                            member.SecondReminderSent = GetReminder(row["new_secondremindersent"].ToString());
                            member.ThirdReminderSent = GetReminder(row["new_thirdremindersent"].ToString());
                            member.TaxInvoiceSent = GetBoolean(row["new_taxinvoicesent"].ToString());
                            member.PostCertificateTracking = row["ec_postcertificatetracking"].ToString();
                            member.TotalCDPPoints = GetInt(row["ec_totalcdppoints"].ToString());
                            member.TotalCdppoints_State = GetBoolean(row["ec_totalcdppoints_state"].ToString());
                            member.ProofOfPaymentUploaded = GetBoolean(row["new_proofofpaymentapp"].ToString());
                            member.RefereeReport = GetBoolean(row["new_refereereport"].ToString());
                            member.CountryId = CountryId(row["ec_country"].ToString());
                            if (member.CountryId == null)
                            {
                                member.CountryId = NationalityId(row["ec_nationality"].ToString());
                            }


                            member.EthnicityId = EthnicityId(row["ec_ethnicity"].ToString());
                            member.HighestQualitificationId = QualificationId(row["oc_highestqualification"].ToString());
                            member.HomeLanguageId = HomeLanguageId(row["ec_homelanguage"].ToString());

                            member.OccupationId = OccupationId(row["ec_occupation"].ToString());
                            member.PreferredAppointmentTimeId = 1;
                            member.TransactionCurrencyid = 216;
                            member.ReferralTypeId = ReferralTypeId(row["ec_wheredidyouhearaboutwisa"].ToString());
                            member.ReferralOther = row["ec_wheredidyouhearaboutwisa1"].ToString();
                            member.DwsProcessControllerRegistrationName = row["ec_dwsprocesscontrollerregistrationname"].ToString();

                            string FullName = row["fullname"].ToString();

                            await _context.MemberUser.AddAsync(member);
                            await _context.SaveChangesAsync();

                            //member.VolunteerWorkHoursId = GetInt(row["ec_hoursavailableforvoluntarywork"].ToString());
                            // member.DwsProcessControllerRegistrationName = GetDecimal(row["ec_dwsprocesscontrollerregistration"].ToString());
                            //member.Will be in MemberaffliationXref = GetDecimal(row["ec_affiliations"].ToString());
                            //member.InterestedInVolunteerWork = GetBoolean(row["ec_volunteerwork"].ToString());
                            /*TODO*/

                            #endregion

                            #region MemberAddress

                            Address PhysicalAddress = new Address();

                            PhysicalAddress.RelatedEntityId = member.Id;
                            PhysicalAddress.RelatedToId = (int)RelatedToEnum.Member;
                            PhysicalAddress.AddressTypeId = (int)AddressTypeEnum.Physical;
                            PhysicalAddress.AddressLine1 = row["address1_line1"].ToString();
                            if (!string.IsNullOrEmpty(PhysicalAddress.AddressLine1))
                            {
                                PhysicalAddress.AddressLine1 = PhysicalAddress.AddressLine1.Replace("$~$", "\n");
                                PhysicalAddress.AddressLine1 = PhysicalAddress.AddressLine1.Replace("~~", ",");
                            }
                            PhysicalAddress.AddressLine2 = row["address1_line2"].ToString();
                            if (!string.IsNullOrEmpty(PhysicalAddress.AddressLine2))
                            {
                                PhysicalAddress.AddressLine2 = PhysicalAddress.AddressLine2.Replace("$~$", "\n");
                                PhysicalAddress.AddressLine2 = PhysicalAddress.AddressLine2.Replace("~~", ",");
                            }
                            PhysicalAddress.AddressLine3 = row["address1_line3"].ToString();
                            if (!string.IsNullOrEmpty(PhysicalAddress.AddressLine3))
                            {
                                PhysicalAddress.AddressLine3 = PhysicalAddress.AddressLine3.Replace("$~$", "\n");
                                PhysicalAddress.AddressLine3 = PhysicalAddress.AddressLine3.Replace("~~", ",");
                                PhysicalAddress.Suburb = PhysicalAddress.AddressLine3;
                            }


                            PhysicalAddress.CityName = row["address1_city"].ToString();
                            if (!string.IsNullOrEmpty(PhysicalAddress.CityName))
                            {
                                PhysicalAddress.CityName = PhysicalAddress.CityName.Replace("$~$", "\n");
                                PhysicalAddress.CityName = PhysicalAddress.CityName.Replace("~~", ",");
                            }
                            PhysicalAddress.Province = row["address1_stateorprovince"].ToString();

                            if (string.IsNullOrEmpty(PhysicalAddress.Province))
                            {
                                PhysicalAddress.Province = row["address1_country"].ToString();
                            }
                            if (!string.IsNullOrEmpty(PhysicalAddress.Province))
                            {
                                PhysicalAddress.Province = PhysicalAddress.Province.Replace("$~$", "\n");
                                PhysicalAddress.Province = PhysicalAddress.Province.Replace("~~", ",");
                            }
                            PhysicalAddress.StateId = GetMemberProvinceId(PhysicalAddress.Province);

                            PhysicalAddress.CountryName = row["address1_county"].ToString();
                            if (string.IsNullOrEmpty(PhysicalAddress.CountryName))
                            {
                                PhysicalAddress.CountryName = row["address1_country"].ToString();
                            }
                            if (!string.IsNullOrEmpty(PhysicalAddress.CountryName))
                            {
                                PhysicalAddress.CountryName = PhysicalAddress.CountryName.Replace("$~$", "\n");
                                PhysicalAddress.CountryName = PhysicalAddress.CountryName.Replace("~~", ",");
                            }
                            PhysicalAddress.CountryId = CountryId(PhysicalAddress.CountryName);
                            PhysicalAddress.PostalCode = row["address1_postalcode"].ToString();
                            PhysicalAddress.CreatedBy = UserId(row["createdby"].ToString());
                            PhysicalAddress.ModifiedBy = UserId(row["modifiedby"].ToString());

                            await _context.Address.AddAsync(PhysicalAddress);

                            Address PostalAddress = new Address();
                            PostalAddress.RelatedEntityId = member.Id;
                            PostalAddress.RelatedToId = (int)RelatedToEnum.Member;
                            PostalAddress.AddressTypeId = (int)AddressTypeEnum.Postal;
                            PostalAddress.AddressLine1 = row["address2_line1"].ToString();
                            if (!string.IsNullOrEmpty(PostalAddress.AddressLine1))
                            {
                                PostalAddress.AddressLine1 = PostalAddress.AddressLine1.Replace("$~$", "\n");
                                PostalAddress.AddressLine1 = PostalAddress.AddressLine1.Replace("~~", ",");
                            }
                            PostalAddress.AddressLine2 = row["address2_line2"].ToString();
                            if (!string.IsNullOrEmpty(PostalAddress.AddressLine2))
                            {
                                PostalAddress.AddressLine2 = PostalAddress.AddressLine2.Replace("$~$", "\n");
                                PostalAddress.AddressLine2 = PostalAddress.AddressLine2.Replace("~~", ",");
                            }
                            PostalAddress.AddressLine3 = row["address2_line3"].ToString();
                            if (!string.IsNullOrEmpty(PostalAddress.AddressLine3))
                            {
                                PostalAddress.AddressLine3 = PostalAddress.AddressLine3.Replace("$~$", "\n");
                                PostalAddress.AddressLine3 = PostalAddress.AddressLine3.Replace("~~", ",");
                                PostalAddress.Suburb = PostalAddress.AddressLine3;
                            }
                            PostalAddress.CityName = row["address2_city"].ToString();
                            if (!string.IsNullOrEmpty(PostalAddress.CityName))
                            {
                                PostalAddress.CityName = PostalAddress.CityName.Replace("$~$", "\n");
                                PostalAddress.CityName = PostalAddress.CityName.Replace("~~", ",");
                            }
                            PostalAddress.Province = row["address2_stateorprovince"].ToString();

                            if (!string.IsNullOrEmpty(PostalAddress.Province))
                            {
                                PostalAddress.Province = PostalAddress.Province.Replace("$~$", "\n");
                                PostalAddress.Province = PostalAddress.Province.Replace("~~", ",");
                            }
                            PostalAddress.StateId = GetMemberProvinceId(PostalAddress.Province);

                            PostalAddress.CountryName = row["address2_county"].ToString();
                            if (string.IsNullOrEmpty(PostalAddress.CountryName))
                            {
                                PostalAddress.CountryName = row["address2_country"].ToString();
                            }

                            if (!string.IsNullOrEmpty(PostalAddress.CountryName))
                            {
                                PostalAddress.CountryName = PostalAddress.CountryName.Replace("$~$", "\n");
                                PostalAddress.CountryName = PostalAddress.CountryName.Replace("~~", ",");
                            }
                            PostalAddress.CountryId = CountryId(PostalAddress.CountryName);

                            PostalAddress.PostalCode = row["address2_postalcode"].ToString();
                            PostalAddress.CreatedBy = UserId(row["createdby"].ToString());
                            PostalAddress.ModifiedBy = UserId(row["modifiedby"].ToString());

                            await _context.Address.AddAsync(PostalAddress);

                            #endregion

                            #region add Disability

                            DisabilityMemberXref Disable = new DisabilityMemberXref();

                            Disable.MemberId = member.Id;

                            bool? ec_seeing = GetBoolean(row["ec_seeing"].ToString());
                            bool? ec_hearing = GetBoolean(row["ec_hearing"].ToString());
                            bool? ec_communicating = GetBoolean(row["ec_communicating"].ToString());
                            bool? ec_walking = GetBoolean(row["ec_walking"].ToString());
                            bool? ec_remembering = GetBoolean(row["ec_remembering"].ToString());
                            bool? ec_selfcare = GetBoolean(row["ec_selfcare"].ToString());


                            if (ec_seeing == true)
                            {
                                await _context.DisabilityMemberXref.AddAsync(
                                    new DisabilityMemberXref
                                    {
                                        MemberId = member.Id,
                                        DisabilityId = 3,
                                        DisabilityLevelId = DisabilityId(row["ec_disabilityrating"].ToString()),
                                        CreatedBy = member.CreatedBy,
                                        ModifiedBy = member.ModifiedBy,
                                        CreatedOn = member.CreatedOn,
                                        ModifiedOn = member.ModifiedOn
                                    });

                            }

                            if (ec_hearing == true)
                            {
                                await _context.DisabilityMemberXref.AddAsync(
                               new DisabilityMemberXref
                               {
                                   MemberId = member.Id,
                                   DisabilityId = 1,
                                   DisabilityLevelId = DisabilityId(row["ec_disabilityrating1"].ToString()),
                                   CreatedBy = member.CreatedBy,
                                   ModifiedBy = member.ModifiedBy,
                                   CreatedOn = member.CreatedOn,
                                   ModifiedOn = member.ModifiedOn
                               });
                            }

                            if (ec_communicating == true)
                            {

                                await _context.DisabilityMemberXref.AddAsync(
                              new DisabilityMemberXref
                              {
                                  MemberId = member.Id,
                                  DisabilityId = 2,
                                  DisabilityLevelId = DisabilityId(row["ec_disabilityrating2"].ToString()),
                                  CreatedBy = member.CreatedBy,
                                  ModifiedBy = member.ModifiedBy,
                                  CreatedOn = member.CreatedOn,
                                  ModifiedOn = member.ModifiedOn
                              });
                            }

                            if (ec_walking == true)
                            {
                                await _context.DisabilityMemberXref.AddAsync(
                              new DisabilityMemberXref
                              {
                                  MemberId = member.Id,
                                  DisabilityId = 4,
                                  DisabilityLevelId = DisabilityId(row["ec_disabilityrating3"].ToString()),
                                  CreatedBy = member.CreatedBy,
                                  ModifiedBy = member.ModifiedBy,
                                  CreatedOn = member.CreatedOn,
                                  ModifiedOn = member.ModifiedOn
                              });
                            }

                            if (ec_remembering == true)
                            {
                                await _context.DisabilityMemberXref.AddAsync(
                              new DisabilityMemberXref
                              {
                                  MemberId = member.Id,
                                  DisabilityId = 5,
                                  DisabilityLevelId = DisabilityId(row["ec_disabilityrating4"].ToString()),
                                  CreatedBy = member.CreatedBy,
                                  ModifiedBy = member.ModifiedBy,
                                  CreatedOn = member.CreatedOn,
                                  ModifiedOn = member.ModifiedOn
                              });
                            }

                            if (ec_selfcare == true)
                            {
                                await _context.DisabilityMemberXref.AddAsync(
                              new DisabilityMemberXref
                              {
                                  MemberId = member.Id,
                                  DisabilityId = 6,
                                  DisabilityLevelId = DisabilityId(row["ec_disabilityrating5"].ToString()),
                                  CreatedBy = member.CreatedBy,
                                  ModifiedBy = member.ModifiedBy,
                                  CreatedOn = member.CreatedOn,
                                  ModifiedOn = member.ModifiedOn
                              });
                            }

                            #endregion

                            #region add Volunteer

                            DataRow[] voleRows = VolunteerData.Select("ec_member='" + FullName + "'");

                            string VolunteerHours = string.Empty;

                            foreach (DataRow volrow in voleRows)
                            {
                                string temp = volrow["ec_hoursavailableforvoluntarywork"].ToString();
                                if (!string.IsNullOrEmpty(temp))
                                {
                                    VolunteerHours = temp;
                                }
                                InvolvementMemberXref Vol = new InvolvementMemberXref();
                                Vol.MemberId = member.Id;
                                bool? ec_branchdivisioncommitteemember = GetBoolean(volrow["ec_branchdivisioncommitteemember"].ToString());
                                bool? ec_logistics = GetBoolean(volrow["ec_logistics"].ToString());
                                bool? ec_promotionsandmarketing = GetBoolean(volrow["ec_promotionsandmarketing"].ToString());
                                bool? ec_lookingforsponsors = GetBoolean(volrow["ec_lookingforsponsors"].ToString());
                                bool? ec_writingarticlespublication = GetBoolean(volrow["ec_writingarticlespublication"].ToString());
                                bool? ec_beingamentorandorspecialist = GetBoolean(volrow["ec_beingamentorandorspecialist"].ToString());
                                bool? ec_visitschoolsanduniversitiestopromotewisa = GetBoolean(volrow["ec_visitschoolsanduniversitiestopromotewisa"].ToString());
                                bool? ec_promotewisainbusinessgovernmentdepartment = GetBoolean(volrow["ec_promotewisainbusinessgovernmentdepartment"].ToString());
                                bool? ec_manamembershipdeskorexhibitionstand = GetBoolean(volrow["ec_manamembershipdeskorexhibitionstand"].ToString());
                                bool? ec_communityoutreachprojects = GetBoolean(volrow["ec_communityoutreachprojects"].ToString());
                                bool? ec_mediamentor = GetBoolean(volrow["ec_mediamentor"].ToString());

                                if (ec_branchdivisioncommitteemember == true)
                                {
                                    await _context.InvolvementMemberXref.AddAsync(
                                        new InvolvementMemberXref
                                        {

                                            InvolvementId = 1,
                                            MemberId = member.Id,
                                            CreatedBy = member.CreatedBy,
                                            ModifiedBy = member.ModifiedBy,
                                            CreatedOn = member.CreatedOn,
                                            ModifiedOn = member.ModifiedOn
                                        });
                                }

                                if (ec_logistics == true)
                                {
                                    await _context.InvolvementMemberXref.AddAsync(
                                        new InvolvementMemberXref
                                        {

                                            InvolvementId = 2,
                                            MemberId = member.Id,
                                            CreatedBy = member.CreatedBy,
                                            ModifiedBy = member.ModifiedBy,
                                            CreatedOn = member.CreatedOn,
                                            ModifiedOn = member.ModifiedOn
                                        });
                                }

                                if (ec_promotionsandmarketing == true)
                                {
                                    await _context.InvolvementMemberXref.AddAsync(
                                        new InvolvementMemberXref
                                        {

                                            InvolvementId = 3,
                                            MemberId = member.Id,
                                            CreatedBy = member.CreatedBy,
                                            ModifiedBy = member.ModifiedBy,
                                            CreatedOn = member.CreatedOn,
                                            ModifiedOn = member.ModifiedOn
                                        });
                                }


                                if (ec_writingarticlespublication == true)
                                {
                                    await _context.InvolvementMemberXref.AddAsync(
                                        new InvolvementMemberXref
                                        {

                                            InvolvementId = 4,
                                            MemberId = member.Id,
                                            CreatedBy = member.CreatedBy,
                                            ModifiedBy = member.ModifiedBy,
                                            CreatedOn = member.CreatedOn,
                                            ModifiedOn = member.ModifiedOn
                                        });
                                }

                                if (ec_beingamentorandorspecialist == true)
                                {
                                    await _context.InvolvementMemberXref.AddAsync(
                                        new InvolvementMemberXref
                                        {

                                            InvolvementId = 5,
                                            MemberId = member.Id,
                                            CreatedBy = member.CreatedBy,
                                            ModifiedBy = member.ModifiedBy,
                                            CreatedOn = member.CreatedOn,
                                            ModifiedOn = member.ModifiedOn
                                        });
                                }

                                if (ec_visitschoolsanduniversitiestopromotewisa == true)
                                {
                                    await _context.InvolvementMemberXref.AddAsync(
                                        new InvolvementMemberXref
                                        {

                                            InvolvementId = 6,
                                            MemberId = member.Id,
                                            CreatedBy = member.CreatedBy,
                                            ModifiedBy = member.ModifiedBy,
                                            CreatedOn = member.CreatedOn,
                                            ModifiedOn = member.ModifiedOn
                                        });
                                }

                                if (ec_promotewisainbusinessgovernmentdepartment == true)
                                {
                                    await _context.InvolvementMemberXref.AddAsync(
                                        new InvolvementMemberXref
                                        {

                                            InvolvementId = 7,
                                            MemberId = member.Id,
                                            CreatedBy = member.CreatedBy,
                                            ModifiedBy = member.ModifiedBy,
                                            CreatedOn = member.CreatedOn,
                                            ModifiedOn = member.ModifiedOn
                                        });
                                }

                                if (ec_manamembershipdeskorexhibitionstand == true)
                                {
                                    await _context.InvolvementMemberXref.AddAsync(
                                        new InvolvementMemberXref
                                        {

                                            InvolvementId = 8,
                                            MemberId = member.Id,
                                            CreatedBy = member.CreatedBy,
                                            ModifiedBy = member.ModifiedBy,
                                            CreatedOn = member.CreatedOn,
                                            ModifiedOn = member.ModifiedOn
                                        });
                                }

                                if (ec_communityoutreachprojects == true)
                                {
                                    await _context.InvolvementMemberXref.AddAsync(
                                        new InvolvementMemberXref
                                        {

                                            InvolvementId = 9,
                                            MemberId = member.Id,
                                            CreatedBy = member.CreatedBy,
                                            ModifiedBy = member.ModifiedBy,
                                            CreatedOn = member.CreatedOn,
                                            ModifiedOn = member.ModifiedOn
                                        });
                                }

                                if (ec_mediamentor == true)
                                {
                                    await _context.InvolvementMemberXref.AddAsync(
                                        new InvolvementMemberXref
                                        {

                                            InvolvementId = 10,
                                            MemberId = member.Id,
                                            CreatedBy = member.CreatedBy,
                                            ModifiedBy = member.ModifiedBy,
                                            CreatedOn = member.CreatedOn,
                                            ModifiedOn = member.ModifiedOn
                                        });
                                }

                                if (ec_lookingforsponsors == true)
                                {
                                    await _context.InvolvementMemberXref.AddAsync(
                                        new InvolvementMemberXref
                                        {

                                            InvolvementId = 11,
                                            MemberId = member.Id,
                                            CreatedBy = member.CreatedBy,
                                            ModifiedBy = member.ModifiedBy,
                                            CreatedOn = member.CreatedOn,
                                            ModifiedOn = member.ModifiedOn
                                        });
                                }


                                await _context.SaveChangesAsync();
                            }

                            member.VolunteerWorkHoursId = VolunteerId(VolunteerHours);
                            _context.MemberUser.Update(member);

                            #endregion

                            #region add DWS


                            DWSClassMemberXref DWS = new DWSClassMemberXref();
                            DWS.MemberId = member.Id;
                            bool? ec_classi = GetBoolean(row["ec_classi"].ToString());
                            bool? ec_classii = GetBoolean(row["ec_classii"].ToString());
                            bool? ec_classiii = GetBoolean(row["ec_classiii"].ToString());
                            bool? ec_classiv = GetBoolean(row["ec_classiv"].ToString());
                            bool? ec_classv = GetBoolean(row["ec_classv"].ToString());
                            bool? ec_classvi = GetBoolean(row["ec_classvi"].ToString());

                            if (ec_classi == true)
                            {
                                await _context.DWSClassMemberXref.AddAsync(
                                    new DWSClassMemberXref
                                    {

                                        DWSClassId = 1,
                                        ClassDate = GetDate(row["ec_datei"].ToString()),
                                        MemberId = member.Id,
                                        CreatedBy = member.CreatedBy,
                                        ModifiedBy = member.ModifiedBy,
                                        CreatedOn = member.CreatedOn,
                                        ModifiedOn = member.ModifiedOn
                                    });
                            }

                            if (ec_classii == true)
                            {
                                await _context.DWSClassMemberXref.AddAsync(
                                    new DWSClassMemberXref
                                    {

                                        DWSClassId = 2,
                                        ClassDate = GetDate(row["ec_dateii"].ToString()),
                                        MemberId = member.Id,
                                        CreatedBy = member.CreatedBy,
                                        ModifiedBy = member.ModifiedBy,
                                        CreatedOn = member.CreatedOn,
                                        ModifiedOn = member.ModifiedOn
                                    });
                            }

                            if (ec_classiii == true)
                            {
                                await _context.DWSClassMemberXref.AddAsync(
                                    new DWSClassMemberXref
                                    {

                                        DWSClassId = 3,
                                        MemberId = member.Id,
                                        ClassDate = GetDate(row["ec_dateiii"].ToString()),
                                        CreatedBy = member.CreatedBy,
                                        ModifiedBy = member.ModifiedBy,
                                        CreatedOn = member.CreatedOn,
                                        ModifiedOn = member.ModifiedOn
                                    });
                            }

                            if (ec_classiv == true)
                            {
                                await _context.DWSClassMemberXref.AddAsync(
                                    new DWSClassMemberXref
                                    {

                                        DWSClassId = 4,
                                        ClassDate = GetDate(row["ec_dateiv"].ToString()),
                                        MemberId = member.Id,
                                        CreatedBy = member.CreatedBy,
                                        ModifiedBy = member.ModifiedBy,
                                        CreatedOn = member.CreatedOn,
                                        ModifiedOn = member.ModifiedOn
                                    });
                            }

                            if (ec_classv == true)
                            {
                                await _context.DWSClassMemberXref.AddAsync(
                                    new DWSClassMemberXref
                                    {

                                        DWSClassId = 5,
                                        ClassDate = GetDate(row["ec_datev"].ToString()),
                                        MemberId = member.Id,
                                        CreatedBy = member.CreatedBy,
                                        ModifiedBy = member.ModifiedBy,
                                        CreatedOn = member.CreatedOn,
                                        ModifiedOn = member.ModifiedOn
                                    });
                            }

                            if (ec_classvi == true)
                            {
                                await _context.DWSClassMemberXref.AddAsync(
                                    new DWSClassMemberXref
                                    {

                                        DWSClassId = 6,
                                        ClassDate = GetDate(row["ec_datevi"].ToString()),
                                        MemberId = member.Id,
                                        CreatedBy = member.CreatedBy,
                                        ModifiedBy = member.ModifiedBy,
                                        CreatedOn = member.CreatedOn,
                                        ModifiedOn = member.ModifiedOn
                                    });
                            }




                            #endregion

                            #region add Qualification

                            DataRow[] QualificationRows = QualificationData.Select("ec_member='" + FullName + "'");

                            foreach (DataRow qualRow in QualificationRows)
                            {
                                MemberQualificationXref mqual = new MemberQualificationXref();
                                mqual.MemberId = member.Id;
                                mqual.MemberSpecificQualificationName = qualRow["ec_name"].ToString();
                                mqual.StudentNumber = qualRow["ec_studentnumber"].ToString();
                                mqual.InstituteName = qualRow["ec_institution"].ToString();
                                mqual.QualificationCategoryId = QualificationCategoryId(qualRow["ec_qualificationcategory"].ToString());
                                mqual.QualificationEnrolmentCategoryId = QualificationEnrolmentCategoryId(qualRow["ec_enrolmentcategory"].ToString());
                                mqual.QualificationFrom = GetDate(qualRow["ec_startdate"].ToString());
                                mqual.QualificationTill = GetDate(qualRow["ec_completiondate"].ToString());
                                mqual.QualificationTypeId = QualificationId(qualRow["ec_qualificationsid"].ToString());
                                mqual.CreatedBy = UserId(qualRow["createdby"].ToString());
                                mqual.CreatedOn = GetDate(qualRow["createdon"].ToString());
                                mqual.ModifiedBy = UserId(qualRow["modifiedby"].ToString());
                                mqual.ModifiedOn = GetDate(qualRow["modifiedon"].ToString());

                                await _context.MemberQualificationXref.AddAsync(mqual);
                            }
                            #endregion

                            #region add Employment

                            DataRow[] CheckeRows = EmploymentData.Select("ec_member='" + FullName + "'");

                            foreach (DataRow empRow in CheckeRows)
                            {
                                EmploymentMemberXref memph = new EmploymentMemberXref();
                                memph.MemberUserId = member.Id;
                                memph.Designation = empRow["ec_designation"].ToString();

                                if (!string.IsNullOrEmpty(memph.Designation))
                                {
                                    memph.Designation = memph.Designation.Replace("$~$", "\n");
                                    memph.Designation = memph.Designation.Replace("~~", ",");
                                }
                                memph.EmployerName = empRow["ec_employer"].ToString();
                                memph.CompanyTelephoneNumber = empRow["ec_companytelephonenumber"].ToString();
                                memph.CompanyEmail = empRow["ec_companyemail"].ToString();
                                memph.YourDuties = empRow["ec_duties"].ToString();


                                if (!string.IsNullOrEmpty(memph.YourDuties))
                                {
                                    memph.YourDuties = memph.YourDuties.Replace("$~$", "\n");
                                    memph.YourDuties = memph.YourDuties.Replace("~~", ",");
                                }
                                memph.StartDate = GetDate(empRow["ec_datestarted"].ToString());
                                memph.EndDate = GetDate(empRow["ec_dateleft"].ToString());
                                memph.EmploymentCategoryId = EmploymentCategoryId(empRow["ec_employerstatus"].ToString());
                                memph.CreatedBy = UserId(empRow["createdby"].ToString());
                                memph.CreatedOn = GetDate(empRow["createdon"].ToString());
                                memph.ModifiedBy = UserId(empRow["modifiedby"].ToString());
                                memph.ModifiedOn = GetDate(empRow["modifiedon"].ToString());

                                await _context.EmploymentMemberXref.AddAsync(memph);

                            }
                            #endregion

                            #region add Affiliation

                            DataRow[] AffeRows = AffiliationData.Select("ec_member='" + FullName + "'");

                            foreach (DataRow affRow in AffeRows)
                            {
                                MemberAffliationXref maffl = new MemberAffliationXref();
                                maffl.MemberId = member.Id;
                                maffl.AffliationId = AffliationId(affRow["ec_affiliations"].ToString());
                                if (maffl.AffliationId == 6)
                                {
                                    maffl.MemberSpecificAffliationName = affRow["ec_nameofinstitution"].ToString();
                                }
                                maffl.MemberNumber = affRow["ec_membernumber"].ToString();
                                //maffl.Description = affRow["ec_companyemail"].ToString();
                                //maffl.IsActiveAffliatedNow = GetBoolean(affRow["ec_duties"].ToString());
                                //maffl.AffliatedFrom = GetDate(affRow["ec_datestarted"].ToString());
                                //maffl.AffliatedTill = GetDate(affRow["ec_dateleft"].ToString());
                                maffl.CreatedBy = UserId(affRow["createdby"].ToString());
                                maffl.CreatedOn = GetDate(affRow["createdon"].ToString());
                                maffl.ModifiedBy = UserId(affRow["modifiedby"].ToString());
                                maffl.ModifiedOn = GetDate(affRow["modifiedon"].ToString());

                                await _context.MemberAffliationXref.AddAsync(maffl);

                            }
                            #endregion

                            #region add Referee

                            DataRow[] RefereeRows = RefereeData.Select("ec_member='" + FullName + "'");

                            foreach (DataRow refRow in RefereeRows)
                            {
                                MemberRefereeXref memref = new MemberRefereeXref();
                                memref.RelatedEntityId = member.Id;
                                memref.RelatedToId = (int)RelatedToEnum.Member;
                                memref.CellPhone = refRow["ec_cellphonenumber"].ToString();
                                memref.TelephoneNumber = refRow["ec_telephonenumber"].ToString();
                                memref.Email = refRow["ec_email"].ToString();
                                memref.Title = refRow["ec_title"].ToString();
                                memref.Initials = refRow["ec_initials"].ToString();
                                memref.FirstName = refRow["ec_name"].ToString();
                                memref.LastName = refRow["ec_surname"].ToString();
                                memref.NameOfEmployer = refRow["ec_nameofemployer"].ToString();
                                memref.PositionOfReferree = refRow["ec_positionofrefereeincompany"].ToString();
                                memref.ProfessionalRegistrationNumber = refRow["ec_professionalregistrationnumberofreferee"].ToString();
                                memref.CreatedBy = UserId(refRow["createdby"].ToString());
                                memref.CreatedOn = GetDate(refRow["createdon"].ToString());
                                memref.ModifiedBy = UserId(refRow["modifiedby"].ToString());
                                memref.ModifiedOn = GetDate(refRow["modifiedon"].ToString());

                                await _context.MemberRefereeXref.AddAsync(memref);

                            }
                            #endregion

                            #region link MemberToAccount

                            if (!string.IsNullOrEmpty(member.ParentMemberName))
                            {
                                Organization org = _context.Organization.Where(x => x.Name == member.ParentMemberName).FirstOrDefault();
                                if (org != null)
                                {
                                    member.ParentMemberid = org.Id;
                                    _context.MemberUser.Update(member);
                                }
                            }

                            #endregion

                            #region email

                            DataRow[] emailRows = EmailData.Select("regardingobjectid='" + FullName + "'");

                            foreach (DataRow emailRow in emailRows)
                            {
                                MemberEmailXref mexref = new MemberEmailXref();
                                mexref.RelatedEntityId = member.Id;
                                mexref.RelatedToId = (int)RelatedToEnum.Member;
                                mexref.From = emailRow["sender"].ToString();
                                mexref.To = emailRow["torecipients"].ToString();
                                mexref.CC = emailRow["cc"].ToString();
                                mexref.BCC = emailRow["bcc"].ToString();
                                mexref.Subject = emailRow["subject"].ToString();
                                if (!string.IsNullOrEmpty(mexref.Subject))
                                {
                                    mexref.Subject = mexref.Subject.Replace("$~$", "\n");
                                    mexref.Subject = mexref.Subject.Replace("~~", ",");
                                }
                                mexref.Body = emailRow["description"].ToString();
                                if (!string.IsNullOrEmpty(mexref.Body))
                                {
                                    mexref.Body = mexref.Body.Replace("$~$", "\n");
                                    mexref.Body = mexref.Body.Replace("~~", ",");
                                }
                                mexref.CreatedBy = UserId(emailRow["createdby"].ToString());
                                mexref.CreatedOn = GetDate(emailRow["createdon"].ToString());
                                mexref.ModifiedBy = UserId(emailRow["modifiedby"].ToString());
                                mexref.ModifiedOn = GetDate(emailRow["modifiedon"].ToString());
                                await _context.MemberEmailXref.AddAsync(mexref);

                            }

                            #endregion email

                            if (s % 200 == 0)
                            {
                                await _context.SaveChangesAsync();

                            }
                            // _logger.LogInformation("Iteration " + s + "-Created member with Id " + member.MemberCode);
                        }
                        catch (Exception ex)
                        {
                            Rollback();
                            _logger.LogError(rowNum + " Row: Exception while adding Member: " + email + " " + ex.Message + " Inner Exception " + ex.InnerException);
                        }
                    }
                    else
                    {
                        Rollback();
                        _logger.LogError(rowNum + " Row: Failed while adding App User: " + email + " " + result.Errors.FirstOrDefault().Description);
                    }
                }
                catch (Exception ex2)
                {
                    Rollback();
                    _logger.LogError(rowNum + " Row: Exception while adding App User: " + email + " " + ex2.Message + " Inner Exception " + ex2.InnerException);
                }
            }
            await _context.SaveChangesAsync();
            sw2.Stop();
            // _logger.LogInformation("Total Members Created so far |" + _context.MemberUser.Count() + "|Time Taken for this iteration |" + string.Format("{0}m:{1}s", sw2.Elapsed.Minutes, sw2.Elapsed.Seconds));
            _logger.LogInformation("Create Individuals Iteration Completed. User count =" + _context.MemberUser.Count() + "|Time Taken for this iteration |" + string.Format("{0}m:{1}s", sw2.Elapsed.Minutes, sw2.Elapsed.Seconds));
            return new JsonResult(new { success = false, message = "Error. Please check values entered" });
        }

        #endregion


        DataTable Data = new DataTable();
        DataTable QualificationData = new DataTable();
        DataTable EmploymentData = new DataTable();
        DataTable AffiliationData = new DataTable();
        DataTable VolunteerData = new DataTable();
        DataTable EmailData = new DataTable();
        DataTable RefereeData = new DataTable();


        public async Task<IActionResult> OnPostRun()
        {

            await SetUpRoles();
            _logger.LogInformation("Roles Created");
            await CreateClientOrganization();
            _logger.LogInformation("Client Organization Created");
            await CreateUsers();
            _logger.LogInformation("Users  Created");

            return Page();
        }

        public async Task<IActionResult> OnPostNotesAndFiles()
        {
            await AddMembershipHistoryToIndividuals();
            _logger.LogInformation("AddMembershipHistoryToIndividuals Added");

            await AddMembershipHistoryToOrganization();
            _logger.LogInformation("AddMembershipHistoryToOrganization Added");

            await AddFilesToNonIndividuals();
            _logger.LogInformation("files to non individuals Added");

            await AddNotesToNonIndividuals();
            _logger.LogInformation("Notes to non individuals Added");

            await AddFilesToIndividuals();
            _logger.LogInformation("Files to individuals Added");

            await AddNotesToIndividuals();
            _logger.LogInformation("Notes to individuals Added");



            return Page();
        }

        public async Task<IActionResult> OnPostLogResults()
        {


            _logger.LogInformation("MemberUsers=" + _context.MemberUser.Count().ToString());
            _logger.LogInformation("WISA Users=" + _context.ClientUser.Count().ToString());
            _logger.LogInformation("Asp Net Users=" + _userManager.Users.Count().ToString());
            _logger.LogInformation("Organizations=" + _context.Organization.Count().ToString());
            _logger.LogInformation("Member Files=" + _context.MemberFileXref.Count().ToString());
            _logger.LogInformation("Member Notes=" + _context.MemberNotesXref.Count().ToString());
            _logger.LogInformation("Address=" + _context.Address.Count().ToString());
            _logger.LogInformation("Organization Business=" + _context.OrganizationBusinessXref.Count().ToString());
            _logger.LogInformation("Disability=" + _context.DisabilityMemberXref.Count().ToString());
            _logger.LogInformation("Involvement=" + _context.InvolvementMemberXref.Count().ToString());
            _logger.LogInformation("DWS=" + _context.DWSClassMemberXref.Count().ToString());
            _logger.LogInformation("Qualification=" + _context.MemberQualificationXref.Count().ToString());
            _logger.LogInformation("Employment=" + _context.EmploymentMemberXref.Count().ToString());
            _logger.LogInformation("Affliation=" + _context.MemberAffliationXref.Count().ToString());
            _logger.LogInformation("Referree=" + _context.MemberRefereeXref.Count().ToString());
            _logger.LogInformation("Email=" + _context.MemberEmailXref.Count().ToString());

            return Page();
        }

        public async Task<IActionResult> OnPostFix()
        {

            //var organizations=_context.Organization.Where(x=>x.PrimaryContactId==null).ToList();
            //var individuals=_context.MemberUser.Include(x=>x.ApplicationUser).ToList();

            //int i=0;
            //foreach(var org in organizations)
            //{
            //    i++;
            //    var primarycontactname=org.PrimaryContactName.Replace("Mr ","");
            //    primarycontactname = primarycontactname.Replace("Mrs ", "");
            //    primarycontactname = primarycontactname.Replace("Ms ", "");

            //    var contactpersonname = org.ContactPersonName;
            //    contactpersonname = contactpersonname.Replace("Mr ", "");
            //    contactpersonname = contactpersonname.Replace("Mrs ", "");
            //    contactpersonname = contactpersonname.Replace("Ms ", "");

            //    if(string.IsNullOrEmpty(primarycontactname))
            //        primarycontactname= contactpersonname;

            //    var primaryindividual=individuals.Where(x=>x.ApplicationUser.FullName==primarycontactname).FirstOrDefault();
            //    if(primaryindividual != null)
            //    {
            //        org.PrimaryContactId= primaryindividual.Id;
            //    }

            //    var contactindividual = individuals.Where(x => x.ApplicationUser.FullName == contactpersonname).FirstOrDefault();
            //    if (contactindividual != null)
            //    {
            //        org.ContactPersonId = contactindividual.Id;
            //    }

            //    _context.Organization.Update(org);
            //    if(i%100==0)
            //    {
            //        _context.SaveChanges();
            //    }
            //}
            //_context.SaveChanges();

            //var appuser = _userManager.FindByEmailAsync("rhoher@lg-naoh2o.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sales@organicmatters.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("christine@aqa-scientific.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("borlandj@mweb.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kirsty.carden@uct.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("coetzeemaa@tut.ac.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("gideon.devilliers@bigengroup.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("pengelbr@telkomsa.net").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("laubscher@waterconsultants.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("erik@gls.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("odendaalpiet@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("gowater@mweb.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tpitman@iafrica.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sandra.redelinghuys@engenoil.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("wrross8@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ivan@bergstan.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("iqc@absamail.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("fvduuren@iafrica.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ron.steenderen@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("awood@srk.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("jmakhubo@wssa.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mwatkins@dpiplastics.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("moloir@dwa.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("gunter.rencken@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("laurain@iafrica.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("smitch2503@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("gjgjuby@carollo.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("fiona.ellis@umgeni.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nonkululeko.chiliza@umgeni.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mpasimakhaba@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ldewet@waterlab.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tiby.mozes.tmc@icon.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("gideon.tredoux@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sarendze@randwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kopung@intekom.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mphor@lepelle.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("o.pollmann@scensu.de").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nmgadi@mandelametro.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nsinyanya@mandelametro.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("godongwanab@cput.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mpumimkolo@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("colbar18@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("aquarius@iway.na").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("chricois@telkomsa.net").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("natasia@alabbott.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("werner.rossle@capetown.gov.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("carolash@iafrica.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("astrochm@iafrica.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("karl-heinz.riedel@sasol.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lab@midvaalwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mabotha@lantic.net").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("freds@figc.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("chris@herold7.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("adceronio@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("hsnyman@golder.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("raheath@golder.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("zimdollars@ntlworld.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mkomape@marblehall.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("cczmutamba@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("massoudshaker9@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("amali@iliso.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kl@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("jmkileshye-onema@waternetonline.org").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("adelinah.moseme@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("jac@virtualconsulting.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("a.phungula@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty917@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("oraps.v@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("jburke@srk.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("amcassa@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mabupretty@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("p.r.mohlala@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Tshepis.maja@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mhinsch@srk.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("a_palazzo@buckman.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sharon.clark@bhpbilliton.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("pmoseme@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nakedir@polokwane.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("amanda@phsconsulting.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("agnes.bogopa@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("susan@aquar.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ntwampes@cput.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("saskiabuning@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sarasparks7@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("baloyim@dwa.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("gamma@lantic.net").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("moshidis@dwa.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("eulainemas@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("bevpretorius@mweb.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("len@dekkerbiotech.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("smofokeng@proteachemicals.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("musa@gandlati.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("pieter@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("gcwalisile.kunene@umgeni.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nokuthula.mvelase08@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("siphelele.ndaba@ugu.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("landa.oosthuizen@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("pontshoma@mintek.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ekapangaziwiri@csir.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tendaisawu@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("danie.wium@aurecongroup.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("suebar@iafrica.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("aldu.legrange@bigengroup.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("pdamafakir@golder.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kpietersen@mweb.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("marlene@watergroup.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Siobhan.Jackson1@durban.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("meyerv@dwa.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tankisop@gges.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("roger@pasgc.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nombasamsebi@hotmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("zan1901@webmail.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("jeanmarcmk@yahoo.co.uk").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mabotha1@lantic.net").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("BrisleyM@dwa.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("DuPreezM@boschprojects.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("makhafolat32@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("zmbunquka@bgcma.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nkambtt@unisa.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("michelle.peters@debeersgroup.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("juliet@africaahead.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("shakerha@mweb.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("eksts@mweb.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mosimat@erwat.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("moteben@dwa.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mandlam@wrc.org.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("laetitia.slabbert@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty1551@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("eaventer@lantic.net").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("moodie@mweb.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sibongiled@bloemwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("aswanepo@randwater.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("thomasga@iucma.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("jenniferm@iucma.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("gaebees@dwa.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("bmusvoto@yahoo.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("AIsmail@srk.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mark.webb@ssis.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("elize.mare@mogalecity.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("encube@randwater.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("John.Ndiritu@wits.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty1751@noemail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("jacky@mjwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("valerien@wrc.org.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("troisc@ukzn.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lizelle@maxal.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("bernadetteazzie19@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("debbie.trollip@umgeni.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("eimank@wrc.org.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("admin@groundtruth.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lcoetser@srk.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("hejacobs@sun.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("siphumelele.mdletshe@umgeni.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("thuang@hatch.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("swastis23@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("amaartens@buckman.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("janine.adams@nmmu.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mswart@randwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ntombifuthi@gcis.gov.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("admawanda@yahoo.ca").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("hhmodels@intekom.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("jacolette@exigent.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mampiti@savannahsa.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("wstrydom@csir.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("carlos.bezuidenhout@nwu.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("hermien@pentatoro.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("linda.jewell@wits.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("thabisam@emanti.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("laughingh2o@icon.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mthoencube@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kamaliea@cput.ac.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Sarah.Letshwene@dpw.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ossin@telkomsa.net").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("dalove@golder.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nishani@dut.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("patricial@polokwane.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("govenddm@eskom.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("clive.garcin@uct.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nazley.govender@umgeni.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Baojin.Zhao@WorleyParsons.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("guy@pegasys.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("durgapk@eskom.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lebohang.hanyane@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("christan@erwat.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mahlanguln3@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("karen.chetty@lonmin.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("hlanga.kuwe@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nalini.moodley@eskom.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emrava@buckman.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mafihle@lepapata.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("pjallison@sci-techconsultingservices.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("qhakij@dwa.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("htsbtn69@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lebogang.moffat@ekurhuleni.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("joeyvanderwalt1@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kingofking@webmail.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sonelvw@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty2469@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("neil@phathamanzi.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("maryamasaid@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tletsoal@randwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nmuller@amatolawater.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("jo.burgess.wrc@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("roddan@ukzn.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("jacqui@rheochem.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ndodana.nleya@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("c.mack@cesnet.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("zukimbolekwa@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty2535@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("jb4@sun.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("shirang73@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("henry.roman@dst.gov.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ritva.muhlbauer@angloamerican.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sashbraja@yahoo.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sdmhlanga@uj.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("z.cukic@telkomsa.net").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("martin@mdte.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("carolz@ceezet.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mmakgae@geoscience.org.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("msteyn@csir.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("charles.reeve@wyg.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("gos@sun.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mark@markvr.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("henri-salter69@hotmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("antoinettebaker@outlook.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("esempe@sedibengwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty2765@noemail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty2773@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("steenkampj@swartland.org.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("oyekolas@cput.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("delene.bartie@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("unathij@emanti.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("chamunorwat@yahoo.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mosekic@dws.gov.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kea@iafrica.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("pmoodley@golder.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mias.vanderwalt@bigenafrica.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("hpienaar@csir.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("laher.ayeshah@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nthabs@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("olufemi.fasemore@hitachi-eu.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mshapi@mut.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("yungaburra@hotmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("r.krause@ru.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tshepoma@mintek.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("amelius@arkateq.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kevinwall468@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ronniem@wrp.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("corneliusruiters07@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mclaasse86@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("adesola.ilemobade@wits.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sasol@vgc.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tgbarnard@uj.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kousaro@uj.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mulalo.murigwathoho@umgeni.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("svens@cybersmart.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("wox@live.co.uk").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("asanda.maku@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Tshidzumban185@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("elena.cholokh@intershore-africa.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("akpor2006@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("shopewell@gibb.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("michele.kruger@mkctsolutions.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("fayebalfour@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nleat@randwater.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lobanga1@hotmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("bbf2ng@yahoo.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("carin@cbss.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("teboho.mofokeng@aurecongroup.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("headwater@cdm.org.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("thavrin.manickum@umgeni.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("csvino@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ndlovun4@dwa.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("aiyegoroO@arc.agric.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("trudy.theron-beukes@windhoekcc.org.na").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ongacu@gibb.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Marle.Kunneke@westerncape.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mantoo@kgalagadi.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tpmakgatho@webmail.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("fmchibwa@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("carla.leroux@eskom.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("the4vans@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("shanna.nienaber@hotmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("I.Jacobs-Mata@cgiar.org").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("taurai7@yahoo.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("adabula@gibb.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("marieke@aqualinks.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nqunqas@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty3304@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("johan@ugu.org.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("gmanzane@randwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kojomens2@hotmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kgananemm@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Ig445578@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("yandiswa.pambaniso@veolia.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sophiar@vut.ac.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("laryek1@yahoo.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mngenia@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("vosat@ufs.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lusandakisa@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("bernellev@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("karen.jordaan20@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kenosi.namane@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("giftmbatsane@webmail.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mabunda.sinegugu@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("dyllonrandall@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("cdavids@wamsys.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty3555@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nico.allers14@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mmaphefot@eseta.org.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mboweniz@dwa.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("franclynsamuel@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("moletjim@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tshikilap@dwa.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nape.madiseng@ekurhuleni.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("gajun@dwa.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("bongi.ntuli24@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("pri7801@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty3652@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("pearlmzobe@hotmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("boniwen@dwa.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("fanyana@vut.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("wynand@aqualime.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mifrancois@webmail.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("MohapiN@dws.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mthiyanet@dwa.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("michelleh28@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("chabalalas@dws.gov.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("johnz@wrc.org.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty3738@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mosoanep@dwa.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("joyce.kayombo@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty3771@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emuzenda@uj.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("chesap@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tmashifana@uj.ac.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mmekoakcm@tut.ac.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("jojozia@dwa.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("maletsatsi.mapesela@aurecongroup.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("makgatoma@sekhukhune.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("JosiahN@wanconsulting.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("shonin@emfuleni.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lsingo@randwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("molamodi@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nmagwaza@mhlathuze.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("azizm@cput.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("neehalmooruth@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sannie.mabe@sabs.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("rmeissner@csir.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("aneesa.haroon@live.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("schimuti@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sarlet@dralta.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Antheajoann.adams@capetown.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("bongeka.mpukumpa@capetown.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty3974@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("blaauwsharalene@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("fransiscoseptember@drakenstein.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("hadjirapeck@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("rachel.makungo@univen.ac.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("fhumulanimathivha@univen.ac.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("20418876@student.nwu.ac.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("pinkiess21@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kathyk@prentec.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("phakamaa@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mathabo.kgosana@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("debbiedejager@yahoo.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("rmoutloali@uj.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("thabs1@hotmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("keneiloes@mintek.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("hadifelemachaba@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty4111@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("maserolem@lepelle.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lebos@lepelle.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kyss.louw@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("iris.tshoga@mailbox.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mbulidp@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("buyisilemthalane@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("hakhesab3@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("khanyo.mngoma@webmail.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mabo4536@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("unathibikitsha@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ammgoqi@webmail.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty4148@noemail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mvogts@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mahlangujoyce@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("aluwani@tzaneen.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("bassie@live.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("idavalerie2010@yahoo.fr").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("fsutton@srk.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("zanele.dladla@eskom.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mokoenal@dwa.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("singodd@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("hannah.baleta@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("pmambo@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("zmateta@rustenburg.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lungile.cele@ugu.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("jocelyne.mwabi@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("hmokgalaka@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sitholespr@yahoo.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("maebanaorienda@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("jaden414@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("linetteferreira@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mmametja@randwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("bianca.peterson777@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty4243@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("debbietemie@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Ayanda.Shabalala@ump.ac.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("bbrand@unisa.ac.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("millicent.julius@sabs.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nndwammbielelwani@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("dineorampedi@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sipmajali@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("pillayr@dws.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("guzenephd@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("evamuinamia@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("paulette@hydroscience.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mokgadi2010@live.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("gmadzivire@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("precious.r@webmail.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("myandiswa@webmail.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mohapikp@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("annahnkholise@ymail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nemapatemuthuhadini@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("bertha.seloane@mbombela.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("asnemza@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("matlamd1@unisa.ac.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mamphidenivi@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("marcia.theblessedone@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nemandiwelivhu@webmail.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("masalaa@eskom.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("suvrithar@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("samantha.lei.daniels@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Sookrajn@umdm.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("khumbudhavu@yahoo.co.uk").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("yolanda.ngcauzele@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("rambanimurendeni@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("elmarie.knoetze@ekwms.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nefalea@dwa.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("khongelani.mongwe@outlook.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("dzagamuhangwi@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sameerakissoon@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kgosanat@dws.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("themas@dwa.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Theresa.moonsamy@durban.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("madamombec@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("hangwiv@yahoo.co.uk").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("shalatimasonganye@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("serina.companie@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("VermaakN2@dws.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kulsum.kondiah@wits.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ihaines@wwf.org.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ncapayim@dwa.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lcbapela@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kalikikambanda@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("zandberg.dot@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("melissa@wisa.org.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("legotlok@dws.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("silindile.mtshali@umgeni.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("morapelis@dwa.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("marakam@dwa.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("geotoseen@yahoo.co.uk").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("blessedmokoena@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lauren.arendse@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sheilaruto@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kholofelotsheoga@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("madlalan@dwa.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("salojohope@yahoo.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nvdwalt@randwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("liandib73@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("jade@somkhele.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("suranie.prinsloo@nwu.ac.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nmsmoseri@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lleshilo70@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("trudy.phathu@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nelisiweivilakazi@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("presantha@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("alainkamika2@yahoo.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("arlenevanstaden@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("joannafatch@sun.ac.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kuse46@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("rachelk@pdna.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty4571@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sonto.makhubu@eskom.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("brendada24@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("motham@webmail.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("agnes.maenhout@wateropleidingen.nl").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ndakalakop@namwater.com.na").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("taidobaleni@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tendani.mudau@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("vhmukhumo@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tshipala.lufuno@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tssape@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("shipikib@namwater.com.na").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("leratooc@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("roxiedevoss@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty4616@noemail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("cathhughes79@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("haikaliv@namwater.com.na").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("wadzanai85@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("khetsiwevuyi@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("madonnavezi@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("methulak@dwa.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("phindyk@hotmail.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("khanyilesne@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("preh.nasha@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("rasewete4@webmail.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kevin.winter@uct.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("chantel.molefe83@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("danusia.green@drakenstein.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty4680@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("vmaiyana@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nkosiboo@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("zizikdlamini@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tebogomamasai@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ngwepe@webmail.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lucy.billy@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("conzaza@webmail.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("vonganicory@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("khosielubisi@webmail.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("rembue99@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("diforas@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("vbvbaloyi@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("pnkalanga@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mojulie@webmail.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("thanyiwater@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mapulamongadi@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mhlulani89@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("julia.mclachlan@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("janet.chunderduri@durban.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("segaville@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lerato.baloyi@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lpillai@gibb.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("thembisile.mahlangu6@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("211510328@stu.ukzn.ac.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("rosanne.naidoo.rn@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kpsmfra@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("NonhlanhlaK@wrc.org.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("anzavhudziki@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lindiwe.masina@dlacdm.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("razaknasreen@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("evidence.simango@digbywells.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("pheliavb@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("radeshni.moodley@smec.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mpumi.matsebula@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nonkululeko.ndlovu@umgeni.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tbods.rs@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("thule.phetha@umgeni.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nombuso.mbele@umgeni.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("riona.patak@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ngobeniry@webmail.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("jayj@dwa.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty4833@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("motlalepulam@lepelle.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("bsilwana@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("gwizac@eskom.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tmtirelo@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nonjabulom@mafahleni.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nyikopc@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("pmamba@randwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("carolinewallington@icloud.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("marianca@sun.ac.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("15668304@sun.ac.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("15337154@sun.ac.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("francinahm@lepelle.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kgabo.moganedi@ul.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nontoqwabe14@webmail.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty4887@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nompilo.khumalo@umgeni.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("palesalerara@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty4897@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("asingh@uj.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("slindokuhlelanga@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty4905@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mthethwahsf@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("pertuniabrown@webmail.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("amosadeniyi7@yahoo.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nosipiwen@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nomvu.zikalala@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("15326683@sun.ac.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Unsubscribed").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("uskepe@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("paballo.rakosa@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sekar@ecosoil.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("teddy.molewa@lephalale.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("johanna.vandeventer@purolite.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty4940@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ellahramarumo@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nlselowa@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ilonkah@btw.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("dmashabe@randwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("joshua.edokpayi@univen.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("corinne@headstreamwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mulrix@mweb.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("cnazdmg@webmail.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("iikganyago@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("perinav@talbot.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("niprinsl@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nhanhatyala@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mangadita@hotmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mamohau.maleka@sasol.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("keitumetse.totouwe1@angloamerican.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("xantheboo@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ntswaki@wisa.org.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sphsihlejezile@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sandisiwemathonsif@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("npthusini@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("21209228@dut4life.ac.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("madumafar@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mhlongosj@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sthamkhize@rocketmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("clindilemajola@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty5017@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("khozagirly@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("20913935@dut4life.ac.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("phahlasinethemba@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("amanest23@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("yolandi@erwat.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mamolokonatasha@rocketmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("pumzag@amathole.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nolundi.magoloza@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ksbomela@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("gwaxulal@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("maiter@amathole.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("molwantwaj@iucma.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mbathal@iucma.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("skumar1@csir.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tqwaqwa@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("jleshomo@geoscience.org.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nomthethok2@amathole.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("netshiendeulun@dws.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nomthethok3@amathole.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("phindam@amathole.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("zy.kunene@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("xuzazintle@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("zifikilen@amathole.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("dastilenondumiso@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("thobeka.ncwadi@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("SNmhambi@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("acrisp@live.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mabuelad@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mantham@eskom.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("njilirose@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("maxobong.N@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mongezim1@amathole.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nmadolo88@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nmbatsha@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nxodol@dwa.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nyiko@erwat.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("siibuea@polytechnic.edu.na").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("gina@csvwater.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("aetale@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("amuth@mandelametro.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mhoosain3@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tsholojantjies@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("morongwamafogo@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("gweley@dwa.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("odojones@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("m2albertyn@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("maria.theresa.lourens@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("melanie.tiran@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("melissa.heunis@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("priyanka@ecochempumps.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("arleneb@ncp.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("maryke.lange@angloamerican.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("pcswartbooi@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sanele.simelane@durban.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kslatter@mweb.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sgxulu@mhlathuze.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("marisao@idc.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("zandileverna@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Lester@wisa.org.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("neziswa@malutiwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("njabu@sun.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mdunak@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("natasha.mukalenga@aecom.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("charmaine.mudau@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("alettaatt@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("rluti@hotmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lindiwendabana4@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("bntwana@plaas.org.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("shalatim@lepelle.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("anelle@nuwater.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("fayjumbie12@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lekomap@dwa.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mphelamt@eskom.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("annahaubold@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("thulisilemsimanga@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("finkymadigele@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("jsoondarjee@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("philanderj@dwa.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("n.odume@ru.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("wambui.kamau@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nmncube@zululand.org.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ngetitm@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("carol.simelane@sibanyegold.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ruthr@lepelle.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("elsabe@testit-labs.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("vhonani.rerani@univen.ac.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mariana@biosaense.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("thobekambatani@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lynsey02@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("pettienyakudya@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("moniquesham@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("dolphinmogajane@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mariam@westech-inc.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("prudencembenama@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("dibakwanel@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("karessa.pillay@umgeni.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("innocentia.erdogan@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("joana.doutor@rhdhv.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ncubeb@cput.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("icmalulu@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("jabu1@wisa.org.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("adriekrugel@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nina.viljoen@capetown.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mtilok@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("keboihile@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mreichling@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("cindy@wellsworx.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lsatimburwa@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("pgovender@mna-sa.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("karshneechetty@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("henriettahnn@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tayana.raper@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kelleyswana90@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lungi.zuma@durban.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nantale@hotmail.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("daveshinipadayachee@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("esaivani.naicker@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("robkirk@mweb.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kevin.harding@wits.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mashaufunanani@yahoo.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("itu230@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("angelinahmoekwa@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mabuselaevelyn@yahoo.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("carolfad@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("maria.shabalala@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("vanessaweber5@yahoo.fr").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("anya.eilers@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("louise.bryson@aurecongroup.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ntshicilela@makana.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mgqubas@dwa.gov.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("delialatee@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("michellepieterse8@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("marthalinswart69@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("elfredamanho@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("henry2@overbergwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("henry3@overbergwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nox.ntuli202@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("brigittemelly@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lakesh.maharaj@umgeni.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("thuli.mwelase@ugu.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("huruma.mollel@ul.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("thobekilezikhali@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("maphindyntanzi@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("z.sithole@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("RLalloo@csir.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("enaas@alveowater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("fikile.xaki@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("hrmakelane@hsrc.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("s215305833@nmmu.ac.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tchokwe@randwater.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("rabedzt@eskom.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tmlouw@sun.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("jean.mulopo2@wits.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mmashian@randwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nmungwe@randwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kncokazi@randwater.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("cstarkey@randwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mmaguban@randwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tganose@randwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sarashagovender@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("dee.mutukwa@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kylene.moodley@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tafadzwa_marara@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("poppylinah92@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lesegoselowa@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("dmoima@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("pepedimotsepe1@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("coetzeevidette@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("pretorius.lulu@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("velile.chili@umgeni.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("renu.kumari678@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mzizian@webmail.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("silengem09@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("msemenya9@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("pmachevele@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sejabaledijohanna@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mandabanokuthula@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lauren.a.dell@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("suma.mulamattathil@ul.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("anoesjkam2@tshwane.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("z.gqumani@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emmat@bloemwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("fulufhelor@bloemwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nomsam@bloemwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("azizis@unisa.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("zmbata@mna-sa.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("meligthelm@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mabel.mphahlele@ul.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("bongekam@amathole.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("jkampalall@toyota.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("matamts@unisa.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("okesa@ufs.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("hlengiwe.mkhize@dpw.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nabuweyanoordien@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("dashvallabh@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("l.mokitlane@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("3050512@myuwc.ac.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("remigbede@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("margokanam@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kopukgopong@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("desiree.sehlapelo@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("wendym@tshwane.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("jlindzay@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ntgamede@randwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("psera@randwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("fsotywam@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nsishi@randwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("alubega@randwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sharon.redemeyer@uct.ac.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("truyens@borda-africa.org").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("idahmbiya88@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("edwardnxumalo@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("hunadim@lepelle.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("thuthuzelwa@live.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("andiswab2@amathole.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("andiswab5@amathole.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("andiswab6@amathole.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("linahnskhosana@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("molokomorethe@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ndlovukazi826@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("teballo.phala96@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("zaneleandile@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("luthandoamanda@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("samnaidoo24@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("humanianelisa@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("molatelo132@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mosetlhanam7@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("maphutikgwadi@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("educationkhosa@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("zamantuli@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lz.nanasele@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("keitumetse.maupye12@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mosibudif@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ramphisac@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("luluubisse@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("seipatimofokeng16@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kpmokubane@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lira.lakes@webmail.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("moosleereneiloe.rn@2gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tlangelanimk@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("rorisang5563@nokiamail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mapharikeetse@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("evunanain@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("zanele.mpha1@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mbalikn@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("marumaitumeleng@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("morongwa96@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("phatimamabunda@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kgolofelonkele6@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("thandilicious4@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("esdhlamini@gsibande.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("shirley.vanniekerk@mogalecity.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mdzekem55@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty5806@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nontobekothwala2014@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty5816@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("palesam@merveng.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("funeka@elundini.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty5830@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("viwema@amathole.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emakola@emagalemdm.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sdlamini@okhahlamba.org.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("domsilem@donnhauser.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("zodwa.ntuli@mondeni.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("stephen.mohokona@nsg.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("bmolomo@emogalelm.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("bukelwa@elundini.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty5850@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lesedi.m@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("thulilefaya@ndwedwe.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kharivhal@mutale.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sindisiwe@joburg.org.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty5859@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty5860@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty5862@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("hlungwanen@ntambanana.org.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("zungun@ntambanana.org.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mandisa.mdzeke@mogalecity.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("siyandak@amathole.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("fmhiti@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("cmotha@emogalelm.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nomsa@glm.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty5875@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lengwatm@nkagaladm.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ntsang@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("rehloem@glm.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sibongilemk@amathole.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("christa.liebenberg@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("dhavuk@arc.agric.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("corinne1@headstreamwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("babechemist01@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty5918@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("besterMi@eskom.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("rudi.botha@aurecongroup.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("linda.downsborough@monash.edu").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tuyeniinga@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("reg.applause@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("londekamahlanza3@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mmanyuchi@hit.ac.zw").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mathumbapz@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("bontle@midvaalwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("moropengrc@tut.ac.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("samus3@student.monash.edu").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty5945@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty5946@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ngblul001@myuct.ac.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty5948@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ElishaS@mintek.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tebitendwasyl@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("fikile.xaki@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ree-ann.jagmohun@smec.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty5971@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sheenas@dut.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("terisha.naicker@aecom.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("jackelyn.naidoo@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("phindile.mbhele@umgeni.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("prisha.sukdeo@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nontokozo.zondi@umgeni.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("305625@students.wits.ac.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("adelem@mintek.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tshepi.lehutjo@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("roelien@aqualytic.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("skhamisa@golder.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6011@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("u04413547@tuks.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mulalomuk@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kaaolsen@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mpfunzenir@mintek.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("wayne.truter@up.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("michelle@geoscience.org.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("henschel@saeon.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6042@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("pmokorosi@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("zolisa@wspgroup.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6061@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6062@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6064@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6068@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mapulam582@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6072@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6075@noemail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6080@noemail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("pnemaxwi@geoscience.org.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6083@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Enez.Nickall@wspgroup.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6087@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("info@pasgc.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("afouche2@ages-group.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("gschreiner@csir.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("helen@delta-h.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tsmith@slrconsulting.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6111@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nadia@assaf.org.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("fundie1@hotmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sarah.lebetle@ekurhuleni.go.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nesenganimj@tut.ac.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sililoagness-musutu@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mvandabav@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6138@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("neo@erwat.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("monique.bekkenutte@waternetwerk.nl").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("jeremy.biddle@bluewaterbio.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kbiko2@randwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("zedbirungi@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6150@noemail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("luhlelona.lina@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("blies@dwa.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6154@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("vanessa@anatech.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("213567989@ukzn.ac.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("AloiuosC@lepelle.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6182@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("c.chikozho@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6205@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6211@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sithebeayanda15@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("antoinetteb@ncp.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6218@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nnanad@bloemwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("idahd@magalieswater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("neo1@erwat.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6228@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("eldidy@sobek.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kbiko7@randwater.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("MFWhaley@nmisa.org").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6249@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("linda.frew@improchem.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("LorraineBasson@makana.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("liane.hocking2@za.festo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ogcilitshana@ufh.ac.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sindi.getyeza@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("hgieske@hhdelfland.nl").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("cezanne.gonsior@za.endress.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("peter@lecoafrica.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kbiko9@randwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sylviam2@inkomaticma.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6292@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6312@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ndabap@uthungulu.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("liane.hocking2@za.festo.co").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("jjabane-bauwens@proteachemicals.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6341@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("claire@biomimicrysa.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("jansevanrensburgl@dwa.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sjikele@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ybailey@srk.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("njovanovic@csir.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("jubasec@dwa.go.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kabinid@dwa.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("pkachienga@cmra.org.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lesegom@magalieswater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Mpetjane.Kgole@eskom.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("unity.kgongoana@aecom.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sylviam3@inkomaticma.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("khathalib@andm.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6379@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6384@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kibiiy@yahoo.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("konin@emalahlenilm.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6397@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("martha.kotze@lanxess.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("atkuvarega@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sylvia.leabile@ssis.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6419@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6426@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("stanleyl@wrc.org.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ione.loots@up.ac.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6448@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6456@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kbiko8@randwater.ca.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("gmadzivire@uwc.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lmagwenya@randwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("khailel3@inkomaticma.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sylviam5@inkomaticma.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("pamahlas@randwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6482@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6487@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("enquiries@krugerlowveld.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lesegom3@magalieswater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kbiko19@randwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("joubertmd2@tut.ac.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6514@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6516@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("dudus73@live.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kbiko9@randwater.ca.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mauni5@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("smanamathela@uwc.ac.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Mogashte@eskom.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("thando@ymail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("knel@confpro.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nani.mangoale@sasol.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kbiko20@randwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("pauline@erwat.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6546@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("maritzrenee@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6556@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6558@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Angelinamashego@vodamail.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("priscam@eseta.org.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kbiko11@randwater.ca.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lerato.mashua@sembcorp.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6574@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("elanoar.matabane@aecom.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("khosi.mathenjwa@sembcorp.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("hlatshwayofo3@dwa.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6587@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6588@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("jhlapane4@wssa.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lesegom4@magalieswater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sylviam8@inkomaticma.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("msnawater@limpopo.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("matshubenil@webmail.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ligegetalifhani@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("dmatumba@salga.org.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kbiko12@randwater.ca.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sylviam9@inkomaticma.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6608@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nonhlanhlam@eseta.org.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nmazibuk@randwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6613@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mbedzita@vhembe.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("neo14@erwat.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("neo15@erwat.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("pelz2@webmail.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("antoinetteb3@ncp.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mcikekan@dwa.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6629@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mdlelenik@webmail.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("neo16@erwat.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kbiko22@randwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kbiko13@randwater.ca.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("smntungwa@mhlathuze.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lesegom6@magalieswater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6678@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kbiko25@randwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kbiko26@randwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("neo19@erwat.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lerato.makgola@eskom.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kbiko27@randwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6702@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kbiko29@randwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6705@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kbiko31@randwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kbiko32@randwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6711@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("monininc@eskom.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tebogo.monnat@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("morto02@vwsa.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mmakutsoane@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Joe1@vut.ac.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("phinduviv@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("joyce.motha@sembcorp.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lesegom9@magalieswater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kbiko16@randwater.ca.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("masepekwa1@webmail.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nmsezane@tcta.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6755@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mtimunyepj@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6758@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kgomotsom@vut.ac.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("victor@victormunnik.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("julietm@win-sa.org.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Noziphom@vut.ac.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("knaicker@golder.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nanin@eskom.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("noluvuyo.nanto@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nndashe@salga.org.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kbiko36@randwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("neo22@erwat.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6805@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6808@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ndidzun@webmail.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6811@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kbiko38@randwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6821@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kbiko39@randwater.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6826@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6828@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6844@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lab@zamangwane.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6853@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lesegom12@magalieswater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6860@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("200806690@ufh.ac.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kbiko40@randwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sibahle.gumede@mail.weir").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("rwayibc@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("neo23@erwat.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("admin3@wisa.org.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Nokubonga.Nxumalo@durban.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("1gcinass@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Nokuthula.Nzima@capetown.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6894@noemail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kbiko44@randwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("germybella@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nparasnath@dow.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("rolene.pvalphen@ase.com.na").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6911@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("agnesp@vut.ac.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("TshidiP@gsibande.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kbiko47@randwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("asha@3smedia.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kbiko48@randwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("rrahaman@csir.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("RajkumarY@dwa.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6944@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("raletjm@dwa.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6948@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kholofelo.ramafemo@tzaneen.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("noko.ramasenya@aecom.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty6953@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("RamugondoH@dwa.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sylviam13@inkomaticma.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("rataurj@eskom.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kbiko49@randwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sara.rhoton@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("eddie.riddell@sanparks.org").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("annelie@green-cape.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("liane.hocking6@za.festo.co").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kbiko50@randwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("SomtshengulaP5@andm.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("masepekwa2@webmail.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty7000@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kbiko52@randwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("MPHO@SCIENTIST.COM").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty7015@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty7020@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("shaiM2@dwa.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tamsyns@wrc.org.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Afomsok7@namwater.com.na").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("elizabeth@3smedia.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tsibanda@unisa.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lab@amangwane.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kbiko53@randwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("melissa.siko@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("luyandas@amajuba.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ssipunzi@makana.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("zamas@wrp.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("khailel18@inkomaticma.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kbiko56@randwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty7063@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Joyce.Sithole@dpw.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty7065@noemail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty7069@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sarah-s@iafrica.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("martie.smit@clariant.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("smithj1@dwa.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty7081@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("liane.hocking7@za.festo.co").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kbiko58@randwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty7100@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lebohangt@watersolsa.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("selemelat1@hotmail.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("jmthomas@ihi.or.tz").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("neo26@erwat.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tlowanac@dwa.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("anne-marie.tosserams@vng.nl").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lungilet@eseta.org.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kbiko59@randwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("jhlapane9@wssa.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty7143@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("udert@eawag.ch").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("carola@csvwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("rita@csvwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("a.vanzuylen13@nwp.nl").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("adie@waterconcepts.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty7174@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mel@sustento.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("zondin@sisonkedm.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lesegom14@magalieswater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tzondi@wssa.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty7193@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("molabalebohang@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mark@cyanolakes.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("daniel.elchami@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("rashikabholanath@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nkele.dorah13@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ngwanarams@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("khumaloroldah@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("molapojaphtaline@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lena.heinrich@isleutilities.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("rhendric@randwater.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("moitshepitshepi@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("zandi.jingxi@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("marieks.swart@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("claraleevanwyk@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sshekwa@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("zoe.gebhardt@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lucia.laboratory@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sihle@rheochem.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("oumachieng@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("rwdzviti@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("earllewis777@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("spushana03@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("heleenlindeque@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("karabo.chadzingwa@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kedibonemokgokong@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nizowinnie@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("rokhsareh.akbarzadeh@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("notty.libala@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("siebanipc@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sdzikiti@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("evamary333@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("catsmart14@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ramganesh.presidency@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("faianef@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("andisiwe.bangisa@capetown.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mantopi@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("susan.shi@lansenchem.com.cn").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("buhlebuhle0@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sipumlevinqishe27@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("martin.souwitzsky@dpw.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("zethugumede@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ing.laura.ranieri@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kundai.chihambakwe@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("keabetswemoothai@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("beckygweshe@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("morufemakhudu@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nqobilemgoza2@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("manjushas@wrc.org.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kefiloemakhafula@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mahesha.001@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("znoklunga09@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("rachaellitiya@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("charnechristoffels25@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ojosundayfayomi3@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lloyd.fisherjeffes@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("john.okedi@uct.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nonsokoli@yahoo.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("gloreeng@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lusungu.nkoma61@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("hcl@bleufuture.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("matuthiv@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("limakatsot27@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ntmzobe@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ksrsudhakar11@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("zhangl@unisa.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("chilops@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("thandiwe.mpala@monash.edu").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("8iancavndle@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("takazim383@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("cordelia.dlamini@umgeni.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("malatjimt@webmail.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("aneshena@yahoo.co.uk").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("4humulani@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tholisongulube@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ngcalav@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("phateka@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("gsihlali@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("geninonkanyiso@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("chandre.truter@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nomakulalindani@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("taogunyoku@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sadaiict@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("wilma199@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ruth.s.cottingham@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("audreyvanya3@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("zuluannah@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("wuping@tianrun.com.cn").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sibahlendzala@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("bridgette.vanleeve@murrob.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("thobilemasinga3@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("blutsing@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ffinlayson@avistatech.co.uk").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("waberskinskih@boschstemele.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ZMbuzi@bgcma.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty7519@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mark@connsfilters.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Vicky.Visser@ddsa.za.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("RitaR@dcmh.org.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("info@water-leaks.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("debbie-viljoen@idexx.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty7528@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty7532@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Zandile.Mfeka@unilever.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Nicolette@utility-systems.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emma1@watersa.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("icbrink@sun.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("cmoleboge.077@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("jvanwyk@wamsys.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mlambon@kingcetshwayo.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ijeytd@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ahmed01abeer@yahoo.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tamakhetha@outlook.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nosibusisombali@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("atunyiswa@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("bontlez14@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("thembisaxolo88@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("anelemaduna@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tbakholise@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lindyjay27@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nxusa.nomandla@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mahangani@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("revoniad@lepelle.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tsumbif@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("muthelopfunzo@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("stepphh@live.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sfunde.ndulini@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("200415328@ufh.ac.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("quality@tshegofentse.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("khathumuedi@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mbathat@iucma.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("dineobopape3@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("simbisai.zhanje@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("marikav@law.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nomvuyisoluti@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("xolelwambambo25@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nina.rivers@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Liezl@livinglands.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Courtney.Burns@capetown.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Jessica.Dunstan@capetown.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty7644@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("heather@prodogy.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ratdw@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lorraine.dibetle@mogalecity.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("velkushnova@ukzn.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty7661@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sisanda.dalasile@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("rampersadhraneeka@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Julie@ERWAT.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("castillohernandezj@ufs.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kochiwemiti@me.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("renniemwenje@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emutsakatira19@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("chueneh@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("farah.adams18@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("cathrine.mutambirwa@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("valentinagovender04@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("basetsana.dube93@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("margymatthew@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty7695@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("manickums13@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tshetee@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ntokozothobekile@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tshegozoe@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("harrychiririwa@yahoo.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nelisa.gaxela@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("DECRogers@stmeec.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ledilengoepe94@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("muchajk@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("matshekoelisa@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("molopapretty@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mashianokeroselyn@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ntuli101@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sindindima@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("reena.dawnarain@kznedtea.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty7742@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("zsuzsanna.rothschild@mfa.gov.hu").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("attila.erdos@mfa.gov.hu").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kgabom@polokwane.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("floramakgoba36@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kekulumphonyana@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("erooyen@bgcma.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("joshuagorimbo@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mewers06@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mleratosha@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("thandeka.thwala@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("pwsn.jhb.region@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("scqhubi@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sibongilesha@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lytany04@yahoo.fr").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("njames@amatolawater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nlungile@amatolawater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("matloubridget01@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("anelilegibixego@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("dsipunzi2@amatolawater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ymsutu@amatolawater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nnohayi@csir.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ncamorah@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nooen@dws.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kmaphakela@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mulalom1@lepelle.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nncamy17@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("aureliave@me.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("khathunen@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("matapamoloto@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("magail.mukansi@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("obrieng@ukzn.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("bmadonsela@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ntloko80@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("angelique@akashairrigation.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mphathutshedzo@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("cmulopo@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mjoysibanda@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mpongwanancumisa@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("govendert9@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("jutta@wkcsa.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("qmkabile@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("azilenqombolo@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("joylera16@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("zakiti@icloud.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("zamanyanda.mdlalose.zm@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mik_kns@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("spblignault@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("dmakgatho2@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mabasa.victor@tuks.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("karabomngomezulu@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kevinkeen2011@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lumkamanzini0@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ayoelegs@yahoo.co.uk").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("u15137296@tuks.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mamain94@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("cindisihle@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("osemeikhianosi@yahoo.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("jjpotgieter@yahoo.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("u15322298@tuks.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("u16384475@tuks.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("rjprospero.inc@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("u14278295@tuks.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("u11119072@tuks.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("u16145802@tuks.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("u12004121@tuks.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("gershan.barnard@live.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("u13371062@tuks.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("vdmlendl@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("amkalumba@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("musevenzodavid@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("beechipanda@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("theomachaba@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("u13145194@tuks.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("dapi@webmail.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("jessika.bohlmann@gmail.com").Result; appuser.TitleId = 2; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sean.patrick@up.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("malven.tunhuma@up.ac.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tinmuv@hotmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("jbolukaotot@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("u16285353@tuks.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("phoradcalvin@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("u11272164@tuks.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("u16001797@tuks.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mpoyialain@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("u13243153@tuks.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("levy0761410815@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("dsmoyorov@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("gmbubou@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("johan.ferreira@up.ac.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Bukhog19@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("u16067305@tuks.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("u12045897@tuks.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("u27398359@tuks.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("shivambucavin@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("anikebello1@gmail.com").Result; appuser.TitleId = 2; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("michaela@firmcc.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mthokozisi.thwala@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("jainathanson@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("janpswart1@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("matthys.dippenaar@up.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("cmasocha@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("u29463794@tuks.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("skosanamoses@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Chantelniebuhr1@gmail.com").Result; appuser.TitleId = 2; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("septiens@ukzn.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("englatina.assis@hotmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("u15177298@tuks.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kgaogelo.baloyi@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("KEAMOGETSWE.KHOZA2@GMAIL.COM").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("amin.jami5@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("thembin@wrc.org.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mashaba224sepedi@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Rhynhardtlambrechts@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("evahp@wrc.org.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("portia.bangerezako@sanlam.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty8117@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mary-jane.bopape@weathersa.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("magalie.bourblanc@cirad.fr").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nhlanhlac@wrc.org.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("janetdaniel04@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("dominique.darmendrail@anr.fr").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ntswaki@i4water.org").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("cynthiad@wrc.org.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("annamarikok@gmail.com").Result; appuser.TitleId = 2; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Lerato.dube@dst.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty8143@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("shameelae@jse.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty8151@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("thobileg@wrc.org.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("n.gola1@sanbi.org.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty8155@noemail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("catherine.greengrass@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("thokozani28@live.co.uk").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Larna@eventoptions.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty8171@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("shomangsebenzani@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty8193@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty8195@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty8196@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty8197@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("n.mbona@sanbi.org.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ntombi.mchuba@dst.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("meg.mclaren@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("rmelamu@theinnovationhub.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("awelani2012@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("gracem@wrc.org.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("NKWAMZAXOLISA@GMAIL.COM").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mackmasanja2@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("u120345421@tuks.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("pamg@ign.ku.dk").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nmgwenya@trusense-eu.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("patriciamj@daff.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("angelosyiannou91@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("bapelap18@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lebepecalvin@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("spencermoropa@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mandy@becon.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("PCNdaki@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("legendadz@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sihlenyangiwe@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("chabalala164@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty8254@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("claude.marais@averda.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("fdzmukororira@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("thobimkhize@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty8268@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("u14183383@tuks.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("moelapt@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kobela.mokgohloa@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty8276@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("virginiam@wrc.org.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("dikeledidk@wrc.org.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("siphiwen@bloemwater.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mrefilwe@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("phindim@olwaziniconsulting.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty8293@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty8296@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("takiemky8@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("pmuvhali@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("PMyeki@thedti.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("cnimanya@waterforpeople.org").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty8313@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("boitumelonkatlo@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("jnormand@usaid.gov").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nsnren001@myuct.ac.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("pntshotsho@csir.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nyatlsm@unisa.ac.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("vanessa.otto-mentz@santam.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("karinbreytenbach@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("phelemj@webmail.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sebagala14@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("juliamunroe2@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("akininda@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sluuram@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("halenyane@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("freshmasindi@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lmatjeni@randwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("maalikmogal@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mjnephewcompany@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kgrimmer@gibb.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tandekambandezi@hotmail.co.uk").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("zhumindo@hotmail.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("jean@greendoorgroup.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("namisa.dlamini@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lungile.mlondo@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nkosiayanda3@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("smgwebi24@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("zamanda7@yahoo.ca").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nfunke@csir.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("prudence@sobusaconsultants.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("stanleyrapetsoa5@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("terrencemcineka@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nicole@compex.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("qondile.khedama@mangaung.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty8432@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty8433@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ntombi.tm@lg.fs.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty8460@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tinashepatience@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nomvulaa.magagula@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("shonhiwa8@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Tsepho.Shongwe@mbombela.gov.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("adewumi_adeyeye@yahoo.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("technical@rheochem.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mayor@knysna.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mayor@stellenbosch.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mayor@bvm.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mayor.mayor@capetown.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("bmonametsi@wuc.bw").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("linda@pamun.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty8498@noemail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Bongimpilo.mkhize@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mayor@twk.org.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nicky@enviros.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty8537@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sarahr@wrc.org.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tumisang.sebitloane@dst.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mohlalalamapitsi@yahoo.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("karishma.singh@sas.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("yvonnes@wrc.org.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mariams@wrc.org.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Mamohlodingt@wrc.org.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ondelaty@joburg.org.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("clarissakruger@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("AvdMerwe@thedti.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("marrielle.van.der@kwrwater.nl").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty8580@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty8581@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nicolenev@wrc.org.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Coleenvogel@wits.ac.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("simon@impact-freewater.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nozicput@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mtec.dr@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("PHlabela@csir.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("u16005466@tuks.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("carina.almeida@tecnico.ulisboa.pt").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty8629@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("e.bertone@griffith.edu.au").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("eddie.riddell1@sanparks.org").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("leratom@erwat.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ella@erwat.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Waheeda.Bala@wits.ac.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tgbarnard1@uj.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("zainab.rinquest@capetown.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("szwane18@yahoo.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("PCmarais2@erwat.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lmavimbela@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("PCmarais3@erwat.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mototseke@yahoo.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("juliusmpubanerakgetse@yahoo.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ngobenikenneth@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ralphd@erwat.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("les.rams126@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kamogelo.ndlovu@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ydumisa@yahoo.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("evidence209@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("obakeng.matseke@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("promisemarther@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("info@waterbok.org").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Annelize.DeVilliers@westerncape.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty8695@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Helen.Davies@westerncape.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Karen.Shippey@westerncape.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Magdalena.Griesel@westerncape.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Wilna.Kloppers@westerncape.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("cnonkwelo@uj.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("rebecca@greendoorgroup.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("william.msimanga@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tshepomo@erwat.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("dipuo.im@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mapontsho1@erwat.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mathomu1@erwat.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("pcbenoni1@erwat.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("khangaril@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("letlhara.laka@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kelebogilekeabetswe@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("melitamodiba@yahoo.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("manzinims@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Mapontsho3@ERWAT.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Mapontsho4@ERWAT.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mane.mqoqi@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tembimadondo@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("patriciamasango@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ntombenhle@saawu.org.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lalitha@dut.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("MarapeMV@tut.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("cmarais@environment.gov.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("GPreston@environment.gov.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("cronjer@dwa.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Jeanine.Burger@eskom.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Josephm2@vut.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Ntlakanipho.Nkontwana@gauteng.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Agnes.Vumazonke@gauteng.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mm@umzinyathi.gov.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("yvonne.mathonsi@ilembe.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("fezeka.boyi@dedea.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("luckys@mintek.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kobusv@erwat.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("dilotsego.dodo@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kobusv2@erwat.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kobusv3@erwat.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kobusv4@erwat.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("oudi.modisha@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sandilemofokeng@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("erwat7031@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sandilemofokeng1@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mafikalushaba@gmai.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("magayiyanaandile@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sandilemofokeng2@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mphom@erwat.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("bvmagujwa@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("khomotsomohlala211@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("majoress.lorraine@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("bmmamoribula@yahoo.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("bokamosokgethego2010@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("luckynonyana1@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("timothyphasha@ymail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sinenhlanhla@erwat.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("rpott@sun.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("vuledzani@mpumamanzi.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lisa.andrews@iwahq.org").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("suzijael@hotmail.com").Result; appuser.TitleId = 7; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ayati_bi@modares.ac.ir").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mirianazubuike@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("yetim19@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("oncc@live.com.pt").Result; appuser.TitleId = 7; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ychauke@randwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Rochelle.coetzee@capetown.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kirsten.devette@iwahq.org").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("jdrewnow@pg.gda.pl").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("maja.ekblad@chemeng.lth.se").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("farry4real2k@yahoo.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emma.faltstrom@nsva.se").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nfeleza@randwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("fell.jessical@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty9018@noemail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("adhellany@hotmail.com").Result; appuser.TitleId = 7; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty9029@noemail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sylvana.hochet@arup.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("arlinda.ibrahimllari@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("janavi@greenmatter.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("hesam_kamyab@yahoo.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("franciska@koehn-nielsen.de").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("guenter.langergraber@boku.ac.at").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mirjamlawens@gmx.de").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("debbie.leyland1@aurecongroup.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty9063@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty9065@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("dmahemba@nairobiwater.co.ke").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mahlayeyem@dws.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kefilwem@magalieswater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty9083@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("MaryGoldM@gsibande.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mathibekl@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nkele75@hotmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("k.mgaba@ru.ac.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Tmobe@csir.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty9107@noemail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Prudence.Mononyane@tia.org.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("masego.montwedi@ul.ac.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mmabathom@magalieswater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("viola@erwat.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sindy.mthimkhulu@monash.edu").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ntombim@eseta.org.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("muirirwe@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nabateesasylvia@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("whidaad.nazier@capetown.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mulweli@award.org.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nyamela.namso7@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("liudmylaodud90@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("waleolas2002@yahoo.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty9158@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("jana.spath@umu.se").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sarah.tibatemwa@iwahq.org").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("rtsotetsi@randwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("selsson@live.com.pt").Result; appuser.TitleId = 7; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("VWagura@nairobiwater.co.ke").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("csupeyo@nairobiwater.co.ke").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ewangui@nairobiwater.co.ke").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("SUSANNUTHU09@GMAIL.COM").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Reneciaw@eseta.org.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mohseyam@yahoo.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("fmatwewe@ihi.or.tz").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("u11231913@tuks.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("carla.hudson@thenbf.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sheenas1@dut.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("juniamn@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Yaasin.Naidoo@capetown.gov.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("bbadi@amatolawater.co.za").Result; appuser.TitleId = 2; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ntombym1@yahoo.co.uk").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("susanlrisko@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("matsie18@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("moniquevanrhyn773@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("owen@alabbott.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mahendra17sona@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("anjadup1@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("elaine.govender@uct.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("francistoiler@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("matandakhwalo911@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("jenny@cwenga.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("elander.khoza@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("hulisani@bluwatertechnologies.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ruth.lubisi93@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("adegokeadetunji8@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("masindifhatuwany@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("madzarambath@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sbarani416@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("yusuf.saboor1601@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("frances@3smedia.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("jclark@ages-group.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("alta@villagemail.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("maria.santos@angloamerican.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("secretary@birdlife.org.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nkagisengm@bloemwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("yvonne@bokonegasinc.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("trindard.makunike@international.gc.ca").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("caren.tar@chep.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("zandereen.coetzee@deltabec.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("delta.enviro@pixie.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("aivey@dpiplastics.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("joshual@specialised.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("farmersweekly@caxton.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("esti@gls.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("virginia.madike@tzaneen.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("jane@green-cape.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mapula@edams.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("chantel_icon@mics.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tarryn.quayle@iclei.org").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("p.chilonda@cgiar.org").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("estherd@jbmarks.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("noreen@rescuerod.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("projects@klomaceng.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nonkululeko.gcabashi@kpmg.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("vino@la-eng.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mayleen@lebone.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kohyejin@lgchem.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lauren.khoury@lonza.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("matildasiboza37@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("contact@miriammannak.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("theresa@mzanzitraining.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nadine.raepsaet@nmmu.ac.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("cseptember@parliament.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("suduplessis@biobox.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("admin@pkvalves.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("michelle.nel@iafrica.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lungile@projectliteracy.org.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("navishka@ecosafe.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("rowsa@rowsa.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sharlinev@rsvenco.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("epeens@tmsg.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("pam@sanaqua.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mist@stannes.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kmorris@sun.ac.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sarah@string.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mngxenge@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("collette@talisa.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("hsithole@saawu.org.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kelly.leroux@thermofisher.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("olga@theroserv.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("premi.mahadev@ugu.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("laura.gillions@fco.gov.uk").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("rowena@umvoto.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("jamesr@uj.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("shannon@utility-systems.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("eleonore@wettech-sa.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("washy@wrnyabeze.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("wendy@wwinc.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lungazn1@hotmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ntsibengmokoena@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nthabiseng2006@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("samitenaw@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("myranaik@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("phindile.cindi@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lungisile.madlala@umgeni.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("khill@piteau.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mendyzibuyile@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mngcle004@myuct.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("leeannsade@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("petro@prescali.co.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mnyawo@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mojemaye@ufh.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("hdbamaljr@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("adhishri@tlouconsult.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nadriaanse5@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mafielanekarabo@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("jacques.nie@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("bngomane1@theinnovationhub.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mothelerato@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("timlarayetan@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sstelli@randwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("3509590@myuwc.ac.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emmanueladikwuukpoju@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mxolisiintius@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nhlanhla.mnisi@yahoo.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tjipangandjarakf@iway.na").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mapholim@dws.gov.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("engsadc@iafrica.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kenneth.buthelezi@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("afikandlela@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("percymuhashi@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("a.chapagain@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("zabathwa.mzamane@durban.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("te.rasilingwane@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lutherkinga@yahoo.fr").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("daphneythwala@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ssiwilatabbie@yahoo.co.uk").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("deemutenga20@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Busisiwe.Zikalala@wika.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("amoahkid1@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("naickera@dws.gov.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("diilwesyamuntu@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("deidre.herbst@eskom.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sumaya.nassiep@eskom.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Cariens@multotec.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("shirley.mathe@dmr.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("rudzani.ramatsekisa@dmr.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("cdixon@mincosa.org.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ntoampm@eskom.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tarazrawhani@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("innocentr@reml.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("johane@ekogroup.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Eugene.FotsoSimo@aurecongroup.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("charleslucille@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("joodagabriel@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("t.ckulati@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("shokoevie@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sh.rouhani78@yahoo.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mailulagracious563@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("karaboramoshai470@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lmaistry14@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("anzanimadala@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mkizesimile@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Kelellomodipane97@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("carolpwiti@yahoo.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("reebamap@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("iortyomenoch@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lucas.nengovhela@optimumcoal.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("khithing@icloud.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ymyollie79@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("hameseme88@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("david.ikumi@uct.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mckhotso@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kingsleyebomah.ke@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("adesholawoye@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("paultshilombo0@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("uhunamuresolomon@hotmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mhiestermann@outlook.com").Result; appuser.TitleId = 2; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("caesarinem@bloemwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mamoketet@bloemwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nthabisengs@bloemwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lephogolemj@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("barrydk@aryx.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tebellolydia.tladi@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("siya.ngema05@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Stevens.Matseke@erwat.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Tmolokwe@nnr.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("edwardkarmah@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ngwenyataboka@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("rochelle.ria.g@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("felixdonkor2002@yahoo.co.uk").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("olafusidipo@yahoo.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tmabula88@live.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("admin@healthwatercompany.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("alicia.vandiemel@drakenstein.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("hillarry.hanns@capetown.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("pravin@udiengineering.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nsingothandie8@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("thembeka.mabaso@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("katlego@theroserv.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("khatabahled@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("henrymoketsi@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("amakamu38@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sebzanqai@gmail.com").Result; appuser.TitleId = 2; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("khathide.m87@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mnd@windhoekcc.org.na").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sphe.mbali@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mqondisimehlomakulu@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("praise.manyenga@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ltholo@csir.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lrapulana@csir.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lesego_thulo@yahoo.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nicole@redkiteconsulting.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("duckied24@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("daniella.faria007@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("yliee@randwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("bradley.skater.morris@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sddnae002@myuct.ac.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("jo.mcdonnell@hotmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tovenordberg1992@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("abdulazeezismail16@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("macdonald.m999@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("oisaemii@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mofokengexcellent@yahoo.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("chieduuzoma@hotmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("elaine@prescali.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kamkhatshwa@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kakwered@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sindallr@ukzn.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ndumisomavuso96321@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lindamahlalela@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("reitumetsemolaoa@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("jamatesun@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("james.cullis@aurecongroup.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("james.muindisi@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("NoncyG@nioh.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("labjuk@webmail.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("katea777@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("hazelwienand@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("cesteenberg2@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Natascha.hartlett@mitsubishicorp.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("dsg@italcham.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("omayor8@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nozizwe.sgwane@tongaat.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("SMazibuko@thedti.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tamaras@tecroveer.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("danaw@tshwane.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("makhosi@amis.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("wiss-1@pret.diplo.de").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Lee-Ann.Schmidt@ul.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mabuzajanet@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Duncan.rosie@porolite.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nadia@liundaiscience.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Lara.badenhorst@nviroteklabs.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("morne@accredicon.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("delphine.darling@lasec.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("218086182@stu.ukzn.ac.za").Result; appuser.TitleId = 2; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kmangurenje@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mopemalefane@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("fruw@cput.ac.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Cutty.rk@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("johan.enqvist@uct.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("georgeakintola540@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("penestertjale@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("SithembileM@gsibande.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("DhlaminiS@ukzn.ac.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Sikhufz@gmail.com").Result; appuser.TitleId = 2; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("induceddipole66@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("hayangaht@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("3562126@myuwc.ac.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("s211143944@mandela.ac.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("BHONJO@GMAIL.COM").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("clayton@soafrica.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lnnkambule16@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("bmayha@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mazalenizb@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kurimkansie@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("SBONISOM66@GMAIL.COM").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("allyssaperumal@hotmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mabila.africa@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("jeremiah_soji@yahoo.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("cordilourens@mweb.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Tony.Igboamalu@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("rotondwampaluli@gmail.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("pfananani.ramulifho@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sinetembaxoxo@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("manxiwanathenjiswa@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ekenadekehinde@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("isaacb.kudu@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nofemela@mut.ac.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("msukwini@dut.ac.za").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mchihambakwe@hotmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("boontu.buntu@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("gloria.zamadube.dube@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("krasposkujinga@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lmampuru@randwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("knetshif@randwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("daizymasemola@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("vumbonimanganyi@ymail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("dayanaidoo01@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("reneiloe@baas.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("201319546@student.uj.ac.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("takalanimakhani@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nhlanganiso.tshabalala@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("askhat@unisa.ac.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("melaphik@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("zbilibana@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Xolanisikhosana18@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emmanuelmarakalala@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("thomas@wingoc.com.na").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("rteffu@randwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kabelostenger@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("khalidmzml@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("charlotte.elize@gmail.com").Result; appuser.TitleId = 2; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("vashenmoodley@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("okwudilichukwudeh@yahoo.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mfundo8411@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("leratomafojanie@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("magrayowaes@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("swana.siphesihle9@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sigen.samson@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tshilidzir4@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("objid21@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Tshifura.rudzani@gmail.com").Result; appuser.TitleId = 2; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("elormezugbe.ee6@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("cibangwa@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("jabulile.mtamzeli@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ramoshow@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("frans.nonhlanhla@gmail.com").Result; appuser.TitleId = 2; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("michelle.andrews@meb.sg").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("susan1@aquar.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("thandeka.mthembu@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("rochellevelencia@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("michael.killick@capetown.gov.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("masegom@metsichem.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty10881@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("alexander.leppert@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("awalsdorff@csir.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("emailempty10891@noemail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("hattapascal@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("taaisymanyika@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nomawethunkosi@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Sherisaangel@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("siyanimarima@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("malokavanessa@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("gugulethu403@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("chiomamathapelo@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("pmclakoane@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ashmamhunze8023@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mathempho98@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lelodwam@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sharonm@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mukwadalesley@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("shongwemayibongwe@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("qc@midvaalwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nkobi.moleele@gmail.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("obichenduchidinma@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("jpauljac@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("bmtengwana360@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("manyatspc@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Namhladick1@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("christievanniekerk12@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mashavatich@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ishumael@outlook.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Rafeeqah.Kamish@gmail.com").Result; appuser.TitleId = 2; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kgovender@seaworld.org.za").Result; appuser.TitleId = 2; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ghnlwl1@yahoo.com").Result; appuser.TitleId = 2; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("omogopa@randwater.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ngalimmainsah@yahoo.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("noma.mahlutshana1@murrob.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nmkwananzi@classicmail.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mphomo@eseta.org.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ingeduvenhage@gmail.com").Result; appuser.TitleId = 2; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("piusiza@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("wandilesenzo@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("chikwaturemoses@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("otjale@srk.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Katekahananeil@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("jmpharoa@randwater.co.za").Result; appuser.TitleId = 2; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("shushenyams@gmail.com").Result; appuser.TitleId = 2; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ntombiniavela@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("vmassie@germanchambers.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("akanyang@projass.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("gen@rheochem.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("thobileg1@wrc.org.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("vanstadenmario@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("malatswanamm@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("thulanimlilwana@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("amatjian@randwater.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tlchipako@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("gjansenvanvuuren@proxawater.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("jjvrensburg@bvm.gov.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nalinblaze@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("shatlin@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("matavhini192@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("hansswartz1@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("chiserom@yahoo.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tafadzwa_mano@yahoo.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("CABDIWAHAB@GMAIL.COM").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("solomonowolabi11@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("madilongarofhiwateresa@mail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("chinyandura@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("charneappelman@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("georgina.herbert@aurecongroup.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("proceed.sibanda@osheqglobe.co.zw").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mmajola@randwater.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("keenan.heynes23@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("dvdncube@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kayodett@yahoo.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("l.mafu@yahoo.com").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("harrisvusimuzi3@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("robyn@omisolutions.co.za").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mafedi.tladi@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tendanir@samtak.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("yunusmadhi@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("otjale1@srk.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("jephreykekana1@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("munzhelelelufuno4@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("jasonay4u@yahoo.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mrcloete99@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("memelalunga@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sndlovu123@gmail.com").Result; appuser.TitleId = 3; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mngidi.wj@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("monwabisilanga@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("minenhlemchunu30@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("IJIEHSOLOMON@GMAIL.COM").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tchakounteu160@yahoo.fr").Result; appuser.TitleId = 2; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Senzo@Ibhongo.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("garos@saol.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("tmdina@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("NicoH@liquidosa.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("azakij@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("mudaukundani0@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ayandatsitsa@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("kumugejo@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("bongeka541@gmail.com").Result; appuser.TitleId = 2; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Njoko86@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nathanielpaday@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("moremirealeboga10@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("thabo@innovativeengineering.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("jroluremi@lautech.edu.ng").Result; appuser.TitleId = 4; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lazolab10@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("thutomotloung2@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("ntlangulasnawo@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("omosoane@rustenburg.gov.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("accounts@nemai.co.za").Result; appuser.TitleId = 2; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("yusuf.jajbhay@tuks.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("makhanya@riversforlife.org.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("martin.rhulani@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("amonzvanaka@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("nkwatenix@cput.ac.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("LSCHUBAR@RANDWATER.CO.ZA").Result; appuser.TitleId = 2; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sadley@projass.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("crescenschidanhika@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("anthony.singo1@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("lungilemaduna@yahoo.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("abongile.kume@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("northwest@lotshephe.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("albertus@malutsa.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("Sazi.Shange@newcastle.gov.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("solojnrsomba@icloud.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("sanele@duct.org.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("chizheve@oxfordtraining.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("silasiemtatie@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("akapoolufunmilayo@gmail.com").Result; appuser.TitleId = 2; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("itzhuwao@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("chris@mosagroup.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("hvngwato@gmail.com").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);
            //appuser = _userManager.FindByEmailAsync("brandon@sinvac.co.za").Result; appuser.TitleId = 1; await _userManager.UpdateAsync(appuser);


            //var memberuser = await _context.MemberUser.Where(x => x.Id == 109).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 136).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 152).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 166).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 249).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 310).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 383).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 386).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 395).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 400).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 401).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 404).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 449).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 484).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 486).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 500).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 525).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 590).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 639).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 700).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 711).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 726).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 727).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 738).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 754).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 842).FirstOrDefaultAsync(); memberuser.MemberBranchId = 6; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 933).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 964).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 1006).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 1013).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 1019).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 1072).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 1083).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 1095).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 1448).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 1449).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 1516).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 1653).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 1672).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 1674).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 1684).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 1731).FirstOrDefaultAsync(); memberuser.MemberBranchId = 3; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 1760).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 1801).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 1859).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 1889).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 1956).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 2017).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 2044).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 2049).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 2056).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 2090).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 2164).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 2217).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 2244).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 2351).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 2397).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 2419).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 2420).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 2440).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 2481).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 2482).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 2526).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 2569).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 2762).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 2905).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 2915).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 3001).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 3011).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 3089).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 3109).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 3147).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 3148).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 3191).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 3210).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 3227).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 3229).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 3254).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 3265).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 3273).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 3324).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 3332).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 3335).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 3405).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 3409).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 3694).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 3706).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 3729).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 3736).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 3762).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 3763).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 3770).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 3771).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 3825).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 3867).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 4023).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 4030).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 4045).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 4065).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 4116).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 4142).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 4172).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 4173).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 4196).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 4199).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 4203).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 4204).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 4213).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 4214).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 4240).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 4253).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 4254).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 4262).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 4276).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 4285).FirstOrDefaultAsync(); memberuser.MemberBranchId = 3; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 4291).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 4307).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 4314).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 4320).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 4343).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 4405).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 4433).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 4485).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 4502).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 4503).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 4504).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 4505).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 4509).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 4521).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 4538).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 4543).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 4581).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 4607).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 4620).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 4659).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 4695).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 4764).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 4813).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 4826).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 4830).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 4900).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 4919).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 4975).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5111).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5115).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5126).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5150).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5177).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5181).FirstOrDefaultAsync(); memberuser.MemberBranchId = 3; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5191).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5192).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5196).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5214).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5215).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5216).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5217).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5218).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5237).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5240).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5241).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5243).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5266).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5277).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5283).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5287).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5288).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5293).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5318).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5319).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5323).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5328).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5390).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5455).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5534).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5546).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5575).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5595).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5612).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5614).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5615).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5616).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5617).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5618).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5619).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5620).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5621).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5622).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5623).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5624).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5626).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5627).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5628).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5629).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5630).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5631).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5632).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5633).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5637).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5651).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5660).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5661).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5666).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5719).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5733).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5756).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5770).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 5774).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 6009).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 6128).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 6129).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 6205).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 6552).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 6663).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 6962).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 7109).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 7197).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 7206).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 7221).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 7227).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 7231).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 7239).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 7240).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 7272).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 7274).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 7277).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 7278).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 7289).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 7294).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 7359).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 7415).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 7421).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 7424).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 7426).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 7429).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 7430).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 7437).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 7447).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 7460).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 7469).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 7497).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 7501).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 7504).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 7540).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 7546).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 7561).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 7581).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 7593).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 7604).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 7675).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 7676).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 7677).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 7821).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 7909).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 7946).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 7975).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 8079).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 8221).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 8232).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 8282).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 8391).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 8600).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 8608).FirstOrDefaultAsync(); memberuser.MemberBranchId = 3; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 8706).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 8717).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 8826).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 9256).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 9258).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 9420).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 9461).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 9495).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 9500).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 9512).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 9525).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 9537).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 9779).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 9785).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 9800).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 9818).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 9847).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 9903).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 9919).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 10064).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 10073).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 10083).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 10121).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 10233).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 10277).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 10279).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 10280).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 10290).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 10303).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 10317).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 10357).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 10419).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 10436).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 10440).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 10455).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 10458).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 10499).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 10514).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 10518).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 10536).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 10594).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 10758).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 10760).FirstOrDefaultAsync(); memberuser.MemberBranchId = 3; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 10826).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 10841).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 10914).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 10917).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 10919).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 10920).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 10926).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 10959).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 10998).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 11005).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 11019).FirstOrDefaultAsync(); memberuser.MemberBranchId = 4; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 11021).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 11063).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 11112).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 11134).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 11144).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 11152).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 11155).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 11220).FirstOrDefaultAsync(); memberuser.MemberBranchId = 1; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 11250).FirstOrDefaultAsync(); memberuser.MemberBranchId = 4; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 11251).FirstOrDefaultAsync(); memberuser.MemberBranchId = 5; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 11253).FirstOrDefaultAsync(); memberuser.MemberBranchId = 5; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 11254).FirstOrDefaultAsync(); memberuser.MemberBranchId = 6; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();
            //memberuser = await _context.MemberUser.Where(x => x.Id == 11256).FirstOrDefaultAsync(); memberuser.MemberBranchId = 3; _context.MemberUser.Update(memberuser); await _context.SaveChangesAsync();


            return Page();
        }

        public async Task<IActionResult> OnPostIndividuals()
        {

            await CreateIndividuals();
            return Page();
        }

        public async Task<IActionResult> OnPostNonIndividuals()
        {

            _logger.LogInformation("Organizations Creation started");
            await CreateNonIndividuals();
            _logger.LogInformation("Organizations Created");
            return Page();
        }

        #region helpers

        public string GetNonEmptyString(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                value = " ";
            }
            if (!string.IsNullOrEmpty(value))
            {
                value = value.Replace("~~", ",");
            }
            return value;
        }

        public bool StateCode(string a) => a switch
        {
            "Active" => true,
            _ => false
        };

        public int? statuscode(string a) => a switch
        {
            "Active" => 3,
            "Change" => 10,
            "TMP Inactive - Resigned" => 11,
            "Applicant" => 2,
            "TMP Inactive - Suspended" => 8,
            "TMP Inactive - Deceased" => 4,
            "Inactive - Resigned" => 5,
            "Upgrade" => 9,
            "Resigned" => 5,
            "Resigned (Retired)" => 11,
            "Suspended â€“ account in arrears" => 7,
            "Suspended" => 8,
            "Deceased" => 4,
            _ => null
        };

        public int? MemberStatusId(string MemberStatusText) => MemberStatusText switch
        {
            "Application Cancelled" => 1,
            "Applicant" => 2,
            "Active" => 3,
            "Deceased" => 4,
            "Resigned" => 5,
            "Cancelled" => 6,
            "Suspended – account in arrears" => 7,
            "Suspended â€“ account in arrears" => 7,
            "Suspended" => 8,
            _ => null
        };

        public int? UserId(string a) => a switch
        {
            "Anita Pillay" => 1,
            "Evelyn Ramphomane" => 2,
            "System Admin" => 3,
            "falcon crmadmin" => 4,
            "Optimise CRM" => 5,
            "WISA Development Admin" => 6,
            "wisa.dev DevAccountUser" => 7,
            "Melissa Wheal" => 8,
            "Patrick Sebopelo" => 9,
            "Reagan Maistry" => 10,
            "Sarah Biya" => 11,
            "Talent Khumalo" => 12,
            "Adrie Krugel" => 13,
            "Jabu Ndzumo" => 14,
            _ => null
        };

        public int? VolunteerId(string a) => a switch
        {

            "1-5 hours per week" => 1,
            "6-10 hours per week" => 2,
            "11-15 hours per week" => 3,
            "16-20 hours per week" => 4,
            _ => null
        };

        public int? OrganizationGradeId(string OrganizationGradeText) => OrganizationGradeText switch
        {
            "Municipality" => 1,
            "Municipality Member" => 1,
            "Company Member" => 2,
            "Educational Institutions" => 3,
            "Educational Institution Member" => 3,
            "Media Member" => 4,
            "Patron Member" => 5,
            "Professional Members Association" => 6,
            "Water Board" => 7,
            "Local Authority" => 8,
            _ => null
        };

        public int? OrganizationTypeId(string a) => a switch
        {
            "Private" => 1,
            "Non-Individual Member" => 2,
            "Non Individual Member" => 2,
            "Water Service Provider" => 3,
            "Water Board" => 3,
            "Municipality" => 4,
            "Municipality Member" => 4,
            "Professional Member Association" => 5,
            "Professional Members Association" => 5,
            "Government Department" => 6,
            "Educational Institution" => 7,
            "Educational Institution Member" => 7,
            _ => null
        };

        public int? GetOrgBranch(string a) => a switch
        {
            "Gauteng" => 1,
            "Limpopo" => 2,
            "KwaZulu Natal" => 3,
            "Western Cape" => 4,
            "Central Regions: Free State~~ Northern Cape and North West Provinces" => 5,
            "Central Regions: Free State, Northern Cape and North West Provinces" => 5,
            "Eastern Cape" => 6,
            "Mpumalanga" => 7,
            "International" => 8,
            "Namibia" => 9,
            _ => null
        };

        public int? GetMemberBranch(string a) => a switch
        {
            "Central Regions" => 1,
            "Eastern Cape" => 2,
            "Gauteng" => 3,
            "International" => 4,
            "KwaZulu Natal" => 5,
            "KZN" => 5,
            "Kwa-Zulu Natal" => 5,
            "KwaZulu-Natal" => 5,
            "Kwazulu  Natal" => 5,
            "Limpopo" => 6,
            "Mpumalanga" => 7,
            "Namibia" => 8,
            "Western Cape" => 9,
            "Free State" => 10,
            "Head Office" => 11,
            "North West" => 12,
            "Northern  Cape" => 13,
            "Northern Cape" => 13,
            "Johannesburg" => 14,
            _ => null
        };

        public int? GetMemberProvinceId(string a) => a switch
        {
            " Gauteng~~ " => 3,
            " Gauteng,, " => 3,
            "Gauteng,, " => 3,
            " KwaZulu-Natal" => 4,
            "Kwazulu Natal"=>4,
            " Mpumalanga" => 6,
            "MP" => 6,
            "Cape" => 1,
            "Easten Cape" => 1,
            "Eastern" => 1,
            "Eastern  Cape" => 1,
            "EASTERN ACAPE" => 1,
            "eastern cape" => 1,
            "Eastern Cape" => 1,
            "Eastern Cape " => 1,
            "Eastern Cape Province" => 1,
            "Eastern Province" => 1,
            "Eastern province " => 1,
            "Eastern State" => 1,
            "EasternCape" => 1,
            "EASTRERN CAPE" => 1,
            "Eatern Cape" => 1,
            "Estern Cape" => 1,
            "EASTERN CAPE " => 1,
            "Free Cape" => 2,
            "Free State" => 2,
            "FREE STATE " => 2,
            "Freestate" => 2,
            "Free State " => 2,
            "FREE STATE" => 2,
            "Gaiteng" => 3,
            "Gau" => 3,
            "Gaueng" => 3,
            "Gautang" => 3,
            "Gauteng" => 3,
            "Gauteng " => 3,
            "GAUTENG PROVINCE" => 3,
            "Gauteng Province" => 3,
            "Gautent" => 3,
            "Guateng" => 3,
            "Guateng " => 3,
            "Johanesburg" => 3,
            "Johannesburg" => 3,
            "Kwa zlu Natal" => 4,
            "Kwa zulu Natal" => 4,
            "Kwa Zulu Natal " => 4,
            "Kwa-Zaulu Natal" => 4,
            "Kwazulu Natal Province" => 4,
            "kwazuku natal" => 4,
            "Kwazul Natal" => 4,
            "Kwazulu  Natal" => 4,
            "KwaZulu - Natal" => 4,
            "Kwazulu Nata" => 4,
            "KWA-ZULU NATA;L" => 4,
            "KwaZulu Natal" => 4,
            "Kwazulu- Natal" => 4,
            "Kwa-Zulu Natal" => 4,
            "Kwazulu Natal " => 4,
            "Kwa-Zulu Natal " => 4,
            "Kwazulu/Natal" => 4,
            "KwaZuluNatal" => 4,
            "KwaZulu-Natal" => 4,
            "KwaZulu-Natal " => 4,
            "Kwazulu-Natala" => 4,
            "Kwzulu Natal" => 4,
            "KwaZUlu-Natal" => 4,
            "Kwa Zulu Natal" => 4,
            "KwaZulu/Natal" => 4,
            "Kwazulu-Natal" => 4,
            "KwaZUlu-Natal " => 4,
            "Kwa-Zulu NAtal" => 4,
            "KwazuluNatal" => 4,
            "Gaureng" => 3,
            "Gauteng~~" => 3,
            "KZN" => 4,
            "Limburg" => 5,
            "Limpopo" => 5,
            "Limpopo " => 5,
            "Limpopo Province" => 5,
            "Limpopp" => 5,
            "LOBOMBO" => 5,
            "Lubombo" => 5,
            "LIMPOPO" => 5,
            "Mpumalang" => 6,
            "Mpumalanga" => 6,
            "Mpumalanga " => 6,
            "MPUMALANGA " => 6,
            "mpumalanga" => 6,
            "North West" => 7,
            "NORTH WEST" => 7,
            "north west " => 7,
            "North West province" => 7,
            "Northen Cape" => 8,
            "Northern" => 8,
            "Northern cape" => 8,
            "Northern  Cape" => 8,
            "Northern Cape" => 8,
            "Northern Cape " => 8,
            "Northern Cape Province" => 8,
            "Northwest" => 7,
            "North-West" => 7,
            "Northwest " => 7,
            "Northwest Province" => 7,
            "North West Province" => 7,
            "North West " => 7,
            "NORTHWEST" => 7,
            "NWProvince" => 7,
            "Polokwane" => 5,
            "Port Elizabeth" => 1,
            "Pretoria" => 3,
            "W Cape" => 9,
            "WC" => 9,
            "Western CApe" => 9,
            "Westen Cape" => 9,
            "western" => 9,
            "Western Cape" => 9,
            "Western Cape " => 9,
            "Western Cape (WC)" => 9,
            "Western Province" => 9,
            "Westerncape" => 9,
            "Wstern Cape" => 9,
            "Western cape" => 9,
            "western cape"=>9,

            _ => null
        };

        public int? NationalityId(string a) => a switch
        {
            "South African" => 1,
            _ => null
        };

        public int? CountryId(string a) => a switch
        {
            "South Africa" => 1,
            "Argentina" => 13,
            "Australia" => 16,
            "AUSTRALIA" => 16,
            "Western Australia" => 16,
            "Bangladesh" => 21,
            "Botswana" => 32,
            "CANADA" => 42,
            "Canada" => 42,
            "Czech Republic~~ Europe" => 62,
            "Czech Republic,, Europe" => 62,
            "Czech Republic, Europe" => 62,
            "DRC" => 53,
            "Dubai UAE" => 238,
            "Eswatini" => 74,
            "Ethiopia" => 75,
            "EUROPE" => 239,
            "France" => 80,
            "gauteng" => 1,
            "Germany" => 87,
            "Germiston" => 1,
            "India" => 107,
            "Iran" => 109,
            "IRELAND" => 111,
            "Italy" => 114,
            "Japan" => 116,
            "Johannesburg" => 1,
            "Kenia" => 120,
            "Kenya" => 120,
            "KOREA" => 210,
            "Kwazulu Natal " => 1,
            "Lesotho" => 128,
            "LESOTHO" => 128,
            "limpopo" => 1,
            "London   EC3V 0BG" => 239,
            "MALAWI" => 137,
            "Maputo" => 155,
            "Mozabique" => 155,
            "Mozambique" => 155,
            "Mpumalanga" => 1,
            "Namibia" => 2,
            "Namiibia" => 2,
            "NAMIBIA" => 2,
            "Netherlands" => 159,
            "New Zealand" => 161,
            "NG" => 164,
            "Nigeria" => 164,
            "NIGERIA" => 164,
            "Oman" => 170,
            "RSA" => 1,
            "SA" => 1,
            "SCOTLAND" => 198,
            "Soth Africa" => 1,
            "Sounth Africa" => 1,
            "Sourh Africa" => 1,
            "south  Africa" => 1,
            "South - Africa" => 1,
            "South Adrica" => 1,
            "South Affrica" => 1,
            "South Afica" => 1,
            "SOUTH AFRICA" => 1,
            "South African" => 1,
            "South African " => 1,
            "South Afrisca" => 1,
            "South Aftica" => 1,
            "South Aftrica" => 1,
            "South Arfrica" => 1,

            "South Arica" => 1,
            "SOUTH AUSTRALIA" => 16,
            "SouthAfrica" => 1,
            "South-Africa" => 1,
            "Southafrica " => 1,
            "Southe Africa" => 1,
            "Soutj Africa" => 1,
            "Soutjh Africa" => 1,
            "SRI LANKA" => 213,
            "Swaziland" => 217,
            "SWAZILAND" => 217,
            "SWEDEN" => 218,
            "SWITZERLAND" => 219,
            "Tanzania" => 223,
            "The Netherlands" => 159,
            "The Netherlands." => 159,
            "Trinidad and Tobago" => 230,
            "Tshaulu " => 1,
            "UK" => 239,
            "United Arab Emirates" => 238,
            "United Kingdom" => 239,
            "United Kingdom UK" => 239,
            "United States" => 241,
            "United States (USA)" => 241,
            "United States of America" => 241,
            "USA" => 241,
            "ZA" => 1,
            "Zimbabawe" => 258,
            "Zimbabwe" => 258,
            "ZIMBAMBWE" => 258,
            ".   The Netherlands" => 159,
            "Algeria " => 6,
            "Iraq " => 110,
            "Ethiopia " => 75,
            "Nigeria " => 164,
            "Tunisia " => 231,
            "India " => 107,
            "Ghana " => 88,
            "South Africa " => 1,
            "United Kingdom " => 239,
            "Uganda " => 236,
            "Angola " => 9,
            "Iran " => 109,
            "Hungary " => 105,
            "Malawi " => 137,
            "Malawi" => 137,
            "Burkina Faso " => 38,
            "Germany " => 87,
            "United States " => 241,
            "Switzerland " => 219,
            "Kenya " => 120,
            "Australia " => 16,
            "Poland " => 179,
            "Philippines " => 225,
            "Hong Kong " => 104,
            "Ireland " => 111,
            "Denmark " => 63,
            "Russian Federation " => 185,
            "Netherlands " => 159,
            "Belgium " => 24,
            "Benin " => 26,
            "Sweden " => 218,
            "Cameroon " => 41,
            "Albania " => 5,
            "Liberia " => 129,
            "Japan " => 116,
            "Finland " => 79,
            "Canada " => 42,
            "Pakistan " => 171,
            "Bangladesh " => 21,
            "Malaysia " => 138,
            "Greece " => 90,
            "Austria " => 17,
            "Lesotho " => 128,
            "Zimbabwe " => 258,
            "ZIMBABWE" => 258,
            "Nepal " => 158,
            "Ukraine " => 237,
            "Colombia " => 51,
            "Mexico " => 147,
            "South Korea " => 210,
            "Egypt " => 68,
            "China " => 48,
            "Botswana " => 32,
            "BOTSWANA" => 32,
            "Czech Republic,Europe" => 62,
            "Sweden" => 218,
            "NETHERLANDS" => 159,
            "south africa" => 1,
            "SOUTHAFRICA" => 1,
            "SOUTH AFICA" => 1,
            "SOUTH AFRICAN" => 1,
            "South  Africa" => 1,
            "SOUTH AFRICA " => 1,
            "Rsa" => 1,
            _ => null
        };

        public int? EthnicityId(string a) => a switch
        {
            "Black" => 1,
            "White" => 2,
            "Indian" => 3,
            "Coloured" => 4,
            "Asian" => 5,
            "Other" => 6,
            _ => null
        };

        public int? TitleId(string a) => a switch
        {
            "Mr" => 1,
            "MS" => 3,
            "Miss" => 3,
            "Mrs" => 2,
            "DR" => 4,
            "Prof" => 5,
            "M" => 1,
            "Adv" => 6,
            "Delete duplicate Mr" => 1,
            "Mr." => 1,
            "Me" => 1,
            "Professor" => 5,
            "Dr." => 4,
            "Prof." => 5,
            "Miss." => 3,
            "Ms." => 3,
            "Mrs." => 2,
            "Mr " => 1,
            "Advocate" => 6,
            "Proffessor" => 5,
            _ => null
        };

        public int? GenderId(string a) => a switch
        {
            "Male" => 1,
            "Female" => 2,
            _ => null
        };

        public int? QualificationId(string a) => a switch
        {
            "3year diploma/degree" => 3,
            "Masterâ€™s degree" => 7,
            "Honours degree" => 6,
            "Matric/Grade 12" => 1,
            "1 year diploma/certificate" => 2,
            "4year degree" => 4,
            "Dr/PHD degree" => 8,
            "Postgraduate diploma" => 5,
            _ => null
        };

        public int? DisabilityId(string a) => a switch
        {
            "No Difficulty" => 1,
            "Some Difficulty" => 2,
            "A lot of Difficulty" => 3,
            "Cannot do at all" => 4,
            "Cannot yet be determined" => 5,
            _ => null
        };

        public int? AffliationId(string a) => a switch
        {
            "ECSA" => 1,
            "IMESA" => 2,
            "IWA" => 3,
            "SACNASP" => 4,
            "SAICE" => 5,
            "Other" => 6,
            _ => null
        };

        public int? HomeLanguageId(string a) => a switch
        {
            "Afrikaans" => 2,
            "seTswana" => 4,
            "English" => 1,
            "isiTsonga" => 8,
            "isiZulu" => 6,
            "Other" => 9,
            "tshiVenda" => 5,
            "isiNdebele" => 7,
            "isiXhosa" => 10,
            "sePedi" => 11,
            "SiSwati" => 12,
            "seSotho" => 3,
            _ => null
        };

        public int? MembershipTypeId(string a) => a switch
        {
            "Individual Member" => 1,
            "Individual  Member" => 1,
            "Professional Process Controller" => 2,
            "Non Individual Member" => 3,
            "Non Members" => 4,
            "Primary Contact" => 5,
            "Additional Contacts" => 8,
            _ => null
        };

        public int? MembershipGradeId(string a) => a switch
        {
            "Professional Process Controller" => 1,
            "Member" => 2,
            "Affiliate" => 3,
            "Affiliate Member" => 3,
            "Associate Member" => 4,
            "Academic Member" => 5,
            "Academic" => 5,
            "Fellow" => 6,
            "Fellow Member" => 6,
            "Senior Fellow" => 7,
            "Senior Fellow Member" => 7,
            "Student Member" => 8,
            "Free Retired" => 9,
            "Honorary Member" => 10,
            "Media Member" => 11,
            "Retired Fellow" => 12,
            "Retired Fellow Member" => 12,
            "Retired Member" => 13,
            "Retired Free Member" => 13,
            "Retired Sen. Fellow" => 14,
            "Retired Senior Fellow Member" => 14,
            "Company Member" => 15,
            "Educational Institutions" => 16,
            "Educational Institution Member" => 16,
            "Patron Member" => 17,
            "Professional Members Association" => 18,
            "Non-Individual Member" => 19,
            "Local Authority" => 20,
            "Municipality Member" => 21,
            "Municipality" => 21,
            "Contact" => 22,
            _ => null

            /*



Water Board



*/
        };

        public int? ReferralTypeId(string a) => a switch
        {
            "WISA/eWISA web site" => 3,
            "Word of mouth." => 1,
            "WISA Event (conference~~ branch or division event)" => 4,
            "WISA/eWISA newsletter" => 2,
            "Other" => 5,
            _ => null
        };

        public int? OccupationId(string a) => a switch
        {
            "Full time student" => 3,
            "Engineer" => 7,
            "Academic" => 4,
            "Unemployed" => 1,
            "Researcher" => 5,
            "Other" => 15,
            "Scientist" => 6,
            "Process Controller" => 12,
            "Technician" => 9,
            "Self Employed" => 13,
            "Consultant" => 14,
            "Director / Manager (in water industry)" => 10,
            "Director / Manager (not in the water industry)" => 11,
            "Practitioner" => 8,
            "Retired â€“ not working" => 2,
            _ => null
        };

        public int? QualificationCategoryId(string a) => a switch
        {
            "Completed Qualifications" => 2,
            "Current Studies" => 1,
            _ => null
        };

        public int? QualificationEnrolmentCategoryId(string a) => a switch
        {
            "Full time" => 1,
            "Part Time" => 2,
            _ => null
        };

        public int? QualificationTypeId(string a) => a switch
        {
            "Completed Qualifications" => 2,
            "Current Studies" => 1,
            _ => null
        };

        public int? EmploymentCategoryId(string a) => a switch
        {
            "Current Employer" => 1,
            "Previous Employer" => 2,
            _ => null
        };

        //public int? FileTypeId(string a) => a switch
        //{
        //    "ID Document" => 1,
        //    "Certificates" => 2,
        //    "Proof of DWS" => 3,
        //    "Proof Of Registration" => 4,
        //    "Proof of payment" =>5,
        //    _ => null
        //};

        public bool? GetBoolean(string a) => a switch
        {
            "FALSE" => false,
            "False" => false,
            "TRUE" => true,
            "True" => true,
            _ => null
        };

        public bool GetBooleanNonNull(string a) => a switch
        {
            "FALSE" => false,
            "TRUE" => true,
            _ => false
        };

        public DateTime? GetDate(string a)
        {
            try
            {
                if (a.Length > 0) return Convert.ToDateTime(a);
            }
            catch
            {
                return null;
            }
            return null;
        }

        public int? GetInt(string a)
        {
            try
            {
                if (a.Length > 0) return Convert.ToInt32(a);
            }
            catch
            {
                return null;
            }
            return null;
        }

        public string GetEmail(string email, int rowNum)
        {
            if (string.IsNullOrEmpty(email))
            {
                return "emailempty" + rowNum + "@noemail.com";
            }
            return email;
        }

        public decimal? GetDecimal(string a)
        {
            try
            {
                if (a.Length > 0) return Convert.ToDecimal(a);
            }
            catch
            {
                return null;
            }
            return null;
        }

        public bool? GetReminder(string a)
        {
            try
            {
                if (a == "sent") return true;
                if (a == "null") return false;
                if (string.IsNullOrEmpty(a)) return null;
            }
            catch
            {
                return null;
            }
            return null;
        }

        #endregion
    }
}




