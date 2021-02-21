using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MM.ClientModels;
using MM.Helper;
using WISA.Services;

namespace WISA.Web.Admin
{
    [Authorize(Policy = MMPolicies.AllowSuperUser)]
    public class UserListModel : PageModel
    {
        private readonly ClientDbContext _context;
        private readonly ILogger<UserListModel> _logger;
        private IActivity _activity;
        private string EntityName = "Manage Users";

        public UserListModel(ClientDbContext context, ILogger<UserListModel> logger, IActivity activity)
        {
            _context = context;
            _activity = activity;
            _logger = logger;
        }

        public List<UserVM> UserList { get; set; }

        public class UserVM
        {

            public int id { get; set; }
            public string title { get; set; }
            public string emailid { get; set; }
            public string firstname { get; set; }
            public string lastname { get; set; }
            public string phonenumber { get; set; }

        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnGetListAsync()
        {
            UserList = new List<UserVM>();

            var Users = await _context.ClientUser
                .Include(x => x.ApplicationUser).Include(x => x.ApplicationUser.Title).ToListAsync();

            foreach (var user in Users)
            {
                UserList.Add(
                    new UserVM
                    {
                        id = user.Id,
                        title = user.ApplicationUser.Title == null ? null : user.ApplicationUser.Title.Name,
                        emailid = user.ApplicationUser.Email,
                        firstname = user.ApplicationUser.FirstName,
                        lastname = user.ApplicationUser.LastName,
                        phonenumber = user.ApplicationUser.PhoneNumber
                    });
            }
            await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Accessed + EntityName, UserTypeValues.Staff);
            return new JsonResult(UserList);
        }
    }
}
