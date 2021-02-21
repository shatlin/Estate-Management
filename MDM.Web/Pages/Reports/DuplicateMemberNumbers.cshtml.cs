using Microsoft.AspNetCore.Authorization;
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
    public class DuplicateMemberNumbers : PageModel
    {
        #region Constructor

        private readonly ClientDbContext _clientDbContext;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<DuplicateMemberNumbers> _logger;
        private readonly IEmailCreator _emailCreator;
        private readonly IConfiguration _configuration;
        private IActivity _activity;
        private string EntityName = "Duplicates";

        public DuplicateMemberNumbers(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            ILogger<DuplicateMemberNumbers> logger, IEmailCreator emailCreator, ClientDbContext clientDbContext, IConfiguration configuration, IActivity activity)
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

        public IList<DuplicatesVM> Records { get; set; }

        [BindProperty]
        public IList<DuplicatesVM> DuplicatesList { get; set; }

        #endregion

        public async Task<IActionResult> OnGetAsync()
        {

            Records = new List<DuplicatesVM>();

            await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Accessed + EntityName, UserTypeValues.Staff);

            var members = await _clientDbContext.MemberUser
                .Include(x => x.ApplicationUser)
                .ToListAsync();

            // var organizations = await _clientDbContext.Organization
            //      .ToListAsync();

            foreach (var member in members)
            {
                DuplicatesVM record = new DuplicatesVM();
                record.Id = member.Id;
                record.MemberNumber=member.MemberCode;
                record.FullName = member.ApplicationUser == null ? "" : member.ApplicationUser.FullName;
                Records.Add(record);
            }

            // foreach (var organization in organizations)
            // {

            //     DuplicatesVM record = new DuplicatesVM();
            //     record.Id = organization.Id;
            //     record.MemberNumber=organization.OrgMemberCode;
            //     record.FullName = organization.Name;
            //     record.RecordType = "Organization";
            //     Records.Add(record);
            // }

            string membernumber =string.Empty;
            int duplicatecount =0;
            DuplicatesList=new List<DuplicatesVM>();

            foreach ( var record in Records)
            {
                membernumber=record.MemberNumber;
                duplicatecount = Records.Where(x=>x.MemberNumber==membernumber).Count();
                if(duplicatecount>1)
                {
                    DuplicatesList.Add(record);
                }
            }
         
            return Page();
        }

    }
}