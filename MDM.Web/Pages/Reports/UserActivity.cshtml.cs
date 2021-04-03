using MDM.Helper;
using MDM.Models;
using MDM.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MDM.Pages
{

    public class UserActivityModel : PageBase
    {
        #region Constructor


        public UserActivityModel(SignInManager<ApplicationUser> signInManager,
      ILogger<PageBase> logger,
      UserManager<ApplicationUser> userManager, DB db, IMemoryCache cache, IWebHostEnvironment env, IEmailCreator emailCreator, IConfiguration configuration, IActivity activity, IEmailRecipients emailRecipients) : base(signInManager,
       logger, userManager, db, cache, env, emailCreator, configuration, activity, emailRecipients)
        {
            PageName = PageNames.useractivityPage;
        }

        #endregion

        #region Bindings



        [BindProperty]
        public string UserId { get; set; }

        [BindProperty]
        public string UserFullName { get; set; }

        [BindProperty]
        public string Activity { get; set; }

        [BindProperty]

        [Required(ErrorMessage = "Please select From Date")]
        public DateTime From { get; set; }

        [BindProperty]

        [Required(ErrorMessage = "Please select To Date")]
        public DateTime To { get; set; }

        public List<UserActivity> Activities { get; set; }

        #endregion


        public IActionResult OnGetAsync()
        {
            From = DateTime.Now;
            To=DateTime.Now;
            SetViewData();
            return Page();
        }



        public void SetViewData()
        {
            var Users = _userManager.Users;
            ViewData["UserId"] = new SelectList(Users.ToList(), nameof(ApplicationUser.Id), nameof(ApplicationUser.FullName));
        }

        public IActionResult OnPost()
        {


            if (ModelState.IsValid)
            {

                if (string.IsNullOrEmpty(UserId) && string.IsNullOrEmpty(Activity))
                {
                    Activities = _db.UserActivity.Where(x=>x.CreatedOn >= From.Date && x.CreatedOn <= To.Date).ToList();
                }
                else if(string.IsNullOrEmpty(UserId) && !string.IsNullOrEmpty(Activity))
                {
                    Activities = _db.UserActivity.Where(x => x.ActivityDetail.Contains(Activity) && x.CreatedOn >= From.Date && x.CreatedOn <= To.Date).ToList();
                }
                else if (!string.IsNullOrEmpty(UserId) && string.IsNullOrEmpty(Activity))
                {
                    Activities = _db.UserActivity.Where(x => x.UserId==UserId && x.CreatedOn >= From.Date && x.CreatedOn <= To.Date).ToList();
                }
                else if (!string.IsNullOrEmpty(UserId) && string.IsNullOrEmpty(Activity))
                {
                    Activities = _db.UserActivity.Where(x => x.ActivityDetail.Contains(Activity) && x.CreatedOn >= From.Date && x.CreatedOn <= To.Date).ToList();
                }
                else
                {
                    Activities = _db.UserActivity.Where(x => x.UserId == UserId  && x.ActivityDetail.Contains(Activity) && x.CreatedOn >= From.Date && x.CreatedOn <= To.Date).ToList();
                }

                SetViewData();
                return Page();
            }
            else
            {

                //_logger.LogInformation(string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)));
                SetViewData();
                return Page();
            }


        }



    }
}

