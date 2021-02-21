using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MM.ClientModels;
using WISA.Services;

namespace WISA.Web.Pages.Member
{
    [Authorize(Policy = MMPolicies.AllowMemberAccess)]
    public class IndexModel : PageModel
    {
        private readonly ClientDbContext _context;

        public IndexModel(ClientDbContext context)
        {
            _context = context;
        }

        public List<UserVM> UserList { get; set; }

        public class UserVM
        {
            public int id { get; set; }
            public string email { get; set; }
            public string fullname { get; set; }
            public string companyname { get; set; }
            public string businessphone { get; set; }
            public decimal? accountbanlance { get; set; }
            public string MembershipType { get; set; }
            public string mobilephone { get; set; }
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnGetListAsync()
        {
            UserList = new List<UserVM>();

            var users = await _context.MemberUser
                .Include(x => x.ApplicationUser)
                .Include(x => x.MembershipType)
                .Select(p => new { p.Id, p.ApplicationUser.FullName, p.ApplicationUser.Email, p.CompanyName, p.BusinessPhoneNumber, p.AccountBalanceOftheCompany, p.MembershipType, p.MobilePhone }).ToListAsync();

            foreach (var user in users)
            {
                UserList.Add(new UserVM
                {
                    id = user.Id,
                    email = user.Email,
                    fullname = user.FullName,
                    companyname = user.CompanyName,
                    businessphone = user.BusinessPhoneNumber,
                    accountbanlance = user.AccountBalanceOftheCompany,
                    MembershipType = user.MembershipType.Name,
                    mobilephone = user.MobilePhone
                });

            }
            return new JsonResult(UserList);
        }
    }
}
