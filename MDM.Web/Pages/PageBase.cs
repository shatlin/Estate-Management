﻿using System;
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
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using MDM.Services;

namespace MDM.Pages
{
    public class PageBase :  PageModel
    {
        private IActivity _activity;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        protected IMemoryCache _cache;
        protected  ILogger<PageBase> _logger;
        protected  UserManager<ApplicationUser> _userManager;
        protected  DB _db;
        protected  SignInManager<ApplicationUser> _signInManager;
        protected string PageName = "Page Base";
        private readonly IEmailCreator _emailCreator;

        public PageBase(SignInManager<ApplicationUser> signInManager,
            ILogger<PageBase> logger,
            UserManager<ApplicationUser> userManager, DB db,IMemoryCache cache, IWebHostEnvironment env, IEmailCreator emailCreator, IConfiguration configuration, IActivity activity)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailCreator = emailCreator;
            _cache=cache;
            _db = db;
            _configuration = configuration;
            _activity = activity;
            _env = env;

        }

    

        public override async Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context,
                                                      PageHandlerExecutionDelegate next)
        {
            SetViewData(PageName);
            if (context.HandlerMethod.MethodInfo.Name == "OnGetAsync")
            {
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Accessed + PageName);
            }
            else if (context.HandlerMethod.MethodInfo.Name == "OnPostAsync")
            {
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Updated + PageName);
            }
            
            await next.Invoke();
        }

      
        public override void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
            if (context.HandlerMethod.MethodInfo.Name == "OnGet")
            {
                 _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Accessed + PageName);
            }
            else if (context.HandlerMethod.MethodInfo.Name == "OnPost")
            {
                 _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Updated + PageName);
            }

            SetViewData(PageName);
        }

        public void SetViewData(string entityname)
        {
            PageName=entityname;
            ViewData["Page"] = PageName;
            ViewData["Title"] = PageName;
        }
      
    }
}
