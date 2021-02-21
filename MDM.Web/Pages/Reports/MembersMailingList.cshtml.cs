﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MM.ClientModels;
using MM.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WISA.Services;

namespace MM.Pages.Report
{
    [Authorize(Policy = MMPolicies.AllowUserAccess)]
    public class MembersMailingListModel : PageModel
    {
        #region Constructor

        private readonly ClientDbContext _clientDbContext;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<MembersMailingListModel> _logger;
        private readonly IEmailCreator _emailCreator;
        private readonly IConfiguration _configuration;
        private IActivity _activity;
        private string EntityName = "Members Mailing List";

        public MembersMailingListModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            ILogger<MembersMailingListModel> logger, IEmailCreator emailCreator, ClientDbContext clientDbContext, IConfiguration configuration, IActivity activity)
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
        public IList<ApplicationIndividualVM> ApplicationIndividualVMList { get; set; }



        #endregion

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnGetListAsync()
        {
            ApplicationIndividualVMList = new List<ApplicationIndividualVM>();

            await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Accessed + EntityName, UserTypeValues.Staff);

            var members = await _clientDbContext.MemberUser
                .Include(x => x.MemberStatus)
                .Include(x => x.ApplicationUser)
                .Include(x => x.ApplicationUser.Gender)
                .Include(x => x.ApplicationUser.Title)
                .ToListAsync();


            int i = 0;
            int d = 0;
            string countryname = string.Empty;
            foreach (var member in members)
            {
                if(member.MemberStatus!=null && member.MemberStatus.Name.ToUpper()=="ACTIVE")
                {
                try
                {
                    i++;

                    d = member.Id;
                    ApplicationIndividualVM avm = new ApplicationIndividualVM();

                    avm.MemberCode = member.MemberCode;
                    avm.FullName = member.ApplicationUser.FullName;
                    avm.Email = member.ApplicationUser.Email;

                    ApplicationIndividualVMList.Add(avm);
                }
                catch (Exception ex)
                {

                    _logger.LogError("Exception at row" + i + " Member Id " + d);
                }
                }
            }



            return new JsonResult(ApplicationIndividualVMList);
        }



    }
}