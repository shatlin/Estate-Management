using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MDM.Models;
using MDM.Helper;
using MDM.Services;

namespace MDM.Pages.Client.Account
{
    [AllowAnonymous]
    public partial class IndexModel : PageModel
    {
        private readonly DB _clientDbContext;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<IndexModel> _logger;
        private readonly IEmailCreator _emailCreator;
        private readonly IConfiguration _configuration;

        public IndexModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            ILogger<IndexModel> logger, IEmailCreator emailCreator, DB clientDbContext, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailCreator = emailCreator;
            _clientDbContext = clientDbContext;
            _configuration = configuration;

        }


        #region Bindings

     

  

        #endregion
     

        public async Task<IActionResult> OnGetAsync()
        {
           
            return Page();
        }



  

    

    

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            
            return Page();

        }

    }
}
