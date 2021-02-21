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
    public class ListNonIndividualModel : PageModel
    {
        private readonly ClientDbContext _context;
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<ListNonIndividualModel> _logger;
        private IActivity _activity;
        private string EntityName = "Non Individual Members List";

        public ListNonIndividualModel(ClientDbContext context, IAuthorizationService authorizationService, ILogger<ListNonIndividualModel> logger,
            UserManager<ApplicationUser> userManager, IActivity activity)
        {
            _context = context;
            _authorizationService = authorizationService;
            _userManager = userManager;
            _logger = logger;
            _activity = activity;
        }

        public List<OrgVM> OrgList { get; set; }

        public class OrgVM
        {
            public int id { get; set; }
            public string OrganizationGrade { get; set; }
            public string membershiptype { get; set; }
            public string name { get; set; }
            public string phonenumber { get; set; }
            public string secondaryphonenumber { get; set; }
            public string website { get; set; }
            public string orgmembercode { get; set; }
            public string memberstatus { get; set; }
            public decimal? accountbalance { get; set; }
            
        }

        public async Task<IActionResult> OnGetAsync()
        {
            await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Accessed + EntityName, UserTypeValues.Staff);
            return Page();
        }

        public async Task<IActionResult> OnGetListAsync()
        {
            OrgList = new List<OrgVM>();

            var orgs = await _context.Organization
                .Include(x => x.OrganizationGrade)
                .Include(x => x.OrganizationType)
                .Include(x => x.MemberStatus)
                .Select(p => new { p.Id, p.Name, p.OrgMemberCode, p.OrganizationGrade, p.OrganizationType, p.PhoneNumber, p.MemberStatus, p.AccountBalance }).ToListAsync();

            foreach (var org in orgs)
            {
                OrgList.Add(new OrgVM
                {
                    id = org.Id,
                    name = org.Name,
                    orgmembercode = org.OrgMemberCode,
                    OrganizationGrade = org.OrganizationGrade == null ? null : org.OrganizationGrade.Name,
                    membershiptype = org.OrganizationType == null ? null : org.OrganizationType.Name,
                    phonenumber = org.PhoneNumber,
                    memberstatus = org.MemberStatus == null ? null : org.MemberStatus.Name,
                    accountbalance = org.AccountBalance
                });

            }
            return new JsonResult(OrgList);
        }
    }
}
