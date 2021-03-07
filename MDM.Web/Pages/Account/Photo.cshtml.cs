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
using Microsoft.AspNetCore.Http;
using System.IO;

namespace MDM.Pages
{
    [ValidateAntiForgeryToken]
    public class PhotoModel : PageBase
    {


        public PhotoModel(SignInManager<ApplicationUser> signInManager,
         ILogger<PageBase> logger,
         UserManager<ApplicationUser> userManager, DB db, IMemoryCache cache, IWebHostEnvironment env, IEmailCreator emailCreator, IConfiguration configuration, IActivity activity, IEmailRecipients emailRecipients) : base(signInManager,
          logger, userManager, db, cache, env, emailCreator, configuration, activity, emailRecipients)
        {
            PageName = "Photo";
            EntityName = "Photo";
        }

        public IFormFile Photo { get; set; }

        public void GetLookups()
        {

        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {


            return Page();

        }

        public async Task<IActionResult> OnPostAsync()
        {
            await UploadFile(Photo);
            return Page();
        }

        public async Task UploadFile(IFormFile file)
        {
            var user = await _userManager.GetUserAsync(User);
            string filePath=string.Empty;
            if (file.Length > 0)
            {
                string newfilename = file.FileName.Substring(file.FileName.LastIndexOf('.'));

                newfilename = user.Id + newfilename;
                filePath = Path.Combine(_env.ContentRootPath + "\\wwwroot" + "\\images" + "\\profile\\");
                if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);
                filePath = Path.Combine(filePath, newfilename);

                if (System.IO.File.Exists(filePath)) System.IO.File.Delete(filePath);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);

                }
                    var filepathtoStrore= "../images/profile/"+ newfilename;
                    user.Photo = filepathtoStrore;
                    await _userManager.UpdateAsync(user);
            }


        }

        public async Task<IActionResult> OnPostSave()
        {

            return new JsonResult(new { success = true, message = MMMessages.SavedSuccessfully });
        }


    }
}
