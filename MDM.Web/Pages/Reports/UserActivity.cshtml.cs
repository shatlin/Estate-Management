using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MM.ClientModels;
using MM.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WISA.Services;

namespace MM.Pages.Reports
{
    [Authorize(Policy = MMPolicies.AllowSetUp)]
    public class UserActivityModel : PageModel
    {
        #region Constructor

        private readonly ClientDbContext _clientDbContext;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<UserActivityModel> _logger;
        private readonly IEmailCreator _emailCreator;
        private readonly IConfiguration _configuration;
        private IActivity _activity;
        private string EntityName = "User Activity";

        public UserActivityModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            ILogger<UserActivityModel> logger, IEmailCreator emailCreator, ClientDbContext clientDbContext, IConfiguration configuration, IActivity activity)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailCreator = emailCreator;
            _clientDbContext = clientDbContext;
            _configuration = configuration;
            _activity = activity;

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


        public async Task<IActionResult> OnGetAsync()
        {
            From = DateTime.Now;
            To=DateTime.Now;
            SetViewData();
            await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Accessed + EntityName, UserTypeValues.Staff);
            return Page();
        }



        public void SetViewData()
        {
            var Users = _userManager.Users.Where(x => x.UserTypeId == UserTypeValues.Staff && x.IsActive == true);
            ViewData["UserId"] = new SelectList(Users.ToList(), nameof(ApplicationUser.Id), nameof(ApplicationUser.FullName));
        }

        public IActionResult OnPost()
        {


            if (ModelState.IsValid)
            {

                if (string.IsNullOrEmpty(UserId) && string.IsNullOrEmpty(Activity))
                {
                    Activities = _clientDbContext.UserActivity.Where(x=>x.ActivityDate.Date >= From.Date && x.ActivityDate.Date <= To.Date).ToList();
                }
                else if(string.IsNullOrEmpty(UserId) && !string.IsNullOrEmpty(Activity))
                {
                    Activities = _clientDbContext.UserActivity.Where(x => x.ActivityDetail.Contains(Activity) && x.ActivityDate.Date >= From.Date && x.ActivityDate.Date <= To.Date).ToList();
                }
                else if (!string.IsNullOrEmpty(UserId) && string.IsNullOrEmpty(Activity))
                {
                    Activities = _clientDbContext.UserActivity.Where(x => x.UserId==UserId && x.ActivityDate.Date >= From.Date && x.ActivityDate.Date <= To.Date).ToList();
                }
                else if (!string.IsNullOrEmpty(UserId) && string.IsNullOrEmpty(Activity))
                {
                    Activities = _clientDbContext.UserActivity.Where(x => x.ActivityDetail.Contains(Activity) && x.ActivityDate.Date >= From.Date && x.ActivityDate.Date <= To.Date).ToList();
                }
                else
                {
                    Activities = _clientDbContext.UserActivity.Where(x => x.UserId == UserId  && x.ActivityDetail.Contains(Activity) && x.ActivityDate.Date >= From.Date && x.ActivityDate.Date <= To.Date).ToList();
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

