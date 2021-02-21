﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MM.ClientModels;
using MM.Helper;
using WISA.Services;

namespace MM.Pages.Client.Admin.Account
{
    [AllowAnonymous]
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LogoutModel> _logger;
        private IActivity _activity;
        public LogoutModel(SignInManager<ApplicationUser> signInManager, ILogger<LogoutModel> logger, IActivity activity)
        {
            _signInManager = signInManager;
            _logger = logger;
            _activity = activity;
        }


        public async Task<IActionResult> OnGetAsync()
        {
            await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.LoggedOut, UserTypeValues.Staff);
            return Page();
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToPage();
            }
        }
    }
}
