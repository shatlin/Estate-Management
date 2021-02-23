using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MDM.Models;

namespace MDM.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly DB _db;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private string EntityName = "Dashboard";

        public IndexModel(SignInManager<ApplicationUser> signInManager,
            ILogger<IndexModel> logger,
            UserManager<ApplicationUser> userManager, DB db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _db = db;
            ViewData["Page"] = EntityName;
            ViewData["Title"] = EntityName;
        }


        public async Task<IActionResult> OnGetAsync()
        {
           
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                return Page();
            }
             return LocalRedirect("/Account/Login");
        }
    }
}
