using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MDM.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Mvc.Rendering;
using MDM.Helper;
using Microsoft.AspNetCore.Hosting;
using MDM.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace MDM.Pages
{
    [ValidateAntiForgeryToken]
    public class OwnersModel :  PageBase
    {

       
        public OwnersModel(SignInManager<ApplicationUser> signInManager,
         ILogger<PageBase> logger,
         UserManager<ApplicationUser> userManager, DB db, IMemoryCache cache, IWebHostEnvironment env, IEmailCreator emailCreator, IConfiguration configuration, IActivity activity, IEmailRecipients emailRecipients) : base(signInManager,
          logger, userManager, db, cache, env, emailCreator, configuration, activity, emailRecipients)
        {
            PageName = "Owners";
            EntityName="Owners";
        }


        public void GetLookups()
        {
         
        }

        public IActionResult OnGetAsync(int? id)
        {
      
                return Page();
            
        }

        //public async Task<IActionResult> OnPostAsync()
        //{
           
        //    return Page();
        //}

      
        //public async Task<IActionResult> OnPostSave()
        //{
            
        //    return new JsonResult(new { success = true, message = MMMessages.SavedSuccessfully });
        //}


    }
}
