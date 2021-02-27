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

namespace MDM.Pages
{
    public class PageBase :  PageModel
    {

        protected IMemoryCache _cache;
        protected  ILogger<PageBase> _logger;
        protected  UserManager<ApplicationUser> _userManager;
        protected  DB _db;
        protected  SignInManager<ApplicationUser> _signInManager;
        protected string EntityName = "Base";

        public PageBase(SignInManager<ApplicationUser> signInManager,
            ILogger<PageBase> logger,
            UserManager<ApplicationUser> userManager, DB db,IMemoryCache cache)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _db = db;
            _cache = cache;

        }

     
        public void SetViewData(string entityname)
        {
            EntityName=entityname;
            ViewData["Page"] = EntityName;
            ViewData["Title"] = EntityName;
        }
      


    }
}
