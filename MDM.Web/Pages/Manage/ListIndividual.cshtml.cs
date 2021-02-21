using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MM.ClientModels;
using MM.Helper;
using WISA.Services;

namespace WISA.Web.Pages.Manage
{
    [Authorize(Policy = MMPolicies.AllowUserAccess)]
    public class ListIndividualModel : PageModel
    {
        private readonly ClientDbContext _context;
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<ListIndividualModel> _logger;
        private IActivity _activity;
        private string EntityName = "Individual Members List";

        public ListIndividualModel(ClientDbContext context, IAuthorizationService authorizationService, ILogger<ListIndividualModel> logger,
            UserManager<ApplicationUser> userManager, IActivity activity)
        {
            _context = context;
            _authorizationService = authorizationService;
            _userManager = userManager;
            _logger = logger;
            _activity = activity;
        }


        public List<UserVM> UserList { get; set; }

        public class UserVM
        {
            public int id { get; set; }
            public string firstname { get; set; }
            public string lastname { get; set; }
            public string email { get; set; }
            public string companyname { get; set; }
            public string businessphone { get; set; }
            public decimal? accountbalance { get; set; }
            public string MembershipType { get; set; }
            public string mobilephone { get; set; }
            public string membershipcode { get; set; }
            public string idnumber { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Accessed + EntityName, UserTypeValues.Staff);
            return Page();
        }

        public async Task<IActionResult> OnGetListAsync()
        {
            UserList = new List<UserVM>();

            var users = await _context.MemberUser
                .Include(x => x.ApplicationUser)
                .Include(x => x.MembershipType)
                 .Where(x => x.ApplicationUser.UserTypeId == UserTypeValues.Member|| x.ApplicationUser.UserTypeId == UserTypeValues.Contact)
                .Select(p => new
                {
                    p.Id,
                    p.ApplicationUser.FirstName,
                    p.ApplicationUser.LastName,
                    p.ApplicationUser.Email,
                    p.CompanyName,
                    p.BusinessPhoneNumber,
                    p.AccountBalanceOftheCompany,
                    p.MembershipType,
                    p.MobilePhone,
                    p.MemberCode,
                    p.IDNumber
                }).ToListAsync();

            foreach (var user in users)
            {

                UserList.Add(new UserVM
                {
                    id = user.Id,
                    firstname = user.FirstName,
                    lastname = user.LastName,
                    email = user.Email,
                    companyname = user.CompanyName,
                    businessphone = user.BusinessPhoneNumber,
                    accountbalance = user.AccountBalanceOftheCompany,
                    MembershipType = user.MembershipType == null ? null : user.MembershipType.Name,
                    mobilephone = user.MobilePhone,
                    membershipcode = user.MemberCode,
                    idnumber = user.IDNumber
                });

            }
            return new JsonResult(UserList);
        }
    }
}