using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MM.ClientModels;
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
    //[Authorize(Policy = "SetUp")]
    public class EmailTestModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private UserManager<ApplicationUser> _userManager;
        private readonly ILogger<EmailTestModel> _logger;
        private readonly IEmailCreator _emailCreator;
        private readonly ClientDbContext _context;

        public EmailTestModel(
           SignInManager<ApplicationUser> signInManager,
            ILogger<EmailTestModel> logger, RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager,
             ClientDbContext context, IEmailCreator emailCreator)
        {
            _signInManager = signInManager;
            _logger = logger;
            _roleManager = roleManager;
            _userManager = userManager;
            _emailCreator = emailCreator;
            _context = context;

        }



        public ActionResult OnGet()
        {

            return Page();
        }



        public async Task<IActionResult> OnPostTestEmailAsync()
        {
            MemberUser memUser=_context.MemberUser.Include(x=>x.ApplicationUser).FirstOrDefault();
            //await _emailCreator.SendEmailAsync("ConfirmEmail", memUser.Email, memUser.ApplicationUser.FullName, "WISA: Confirm your email", "Confirm Email", "https://localhost:45533");
            //await _emailCreator.SendEmailAsync("FirstReminder", memUser.Email, memUser.ApplicationUser.FullName, "WISA: Reminder for Documents / Payments", null, null);
            //await _emailCreator.SendEmailAsync("SecondReminder", memUser.Email, memUser.ApplicationUser.FullName, "WISA: Annual Membership Fee Due", null, null);
            await _emailCreator.SendEmailAsync("ThirdReminder", memUser.Email, memUser.ApplicationUser.FullName, "WISA: Reminder to Pay Annual Membership Fee", null, null);
            await _emailCreator.SendEmailAsync("NewMember", memUser.Email, memUser.ApplicationUser.FullName, "WISA: New Member Joined", "New Member", "https://localhost:45533");
            return Page();
        }
    }
}

