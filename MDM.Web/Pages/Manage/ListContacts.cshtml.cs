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
    public class ListContactsModel : PageModel
    {
        private readonly ClientDbContext _context;
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<ListContactsModel> _logger;
        private IActivity _activity;
        private string EntityName = "Contact List";

        public ListContactsModel(ClientDbContext context, IAuthorizationService authorizationService, ILogger<ListContactsModel> logger,
            UserManager<ApplicationUser> userManager, IActivity activity)
        {
            _context = context;
            _authorizationService = authorizationService;
            _userManager = userManager;
            _logger = logger;
            _activity = activity;
        }

        [BindProperty]
        public List<UserVM> UserList { get; set; }


        [BindProperty]
        public UserVM userVM { get; set; }

        public class UserVM
        {
            public int id { get; set; }
            public string firstname { get; set; }
            public string lastname { get; set; }
            public string email { get; set; }
            public string mobilephone { get; set; }
            public string membershipcode { get; set; }
            public string idnumber { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Accessed + EntityName, UserTypeValues.Staff);
            return Page();
        }

        public async Task<IActionResult> OnGetDeleteAsync(int? id)
        {
            var isAuthorized = await _authorizationService.AuthorizeAsync(User, MMPolicies.AllowSetupDelete);

            if (!isAuthorized.Succeeded)
            {
                return new JsonResult(new { success = false, MMMessages.Authorization_failed });
            }
            if (id == null)
            {
                return new JsonResult(new { success = false, MMMessages.NoRecordToDelete });
            }
            MemberUser memuser = await _context.MemberUser.FindAsync(id);

            if (memuser != null)
            {
                var user = await _userManager.GetUserAsync(User);
                memuser.IsActive = false;
                //try
                //{
                //    memuser.ModifiedBy = _context.MemberUser.Where(x => x.ApplicaitonUserId == user.Id).FirstOrDefault().Id;
                //}
                //catch (Exception ex)
                //{s

                    
                //}
                memuser.ModifiedOn=DateTime.Now;
                _context.MemberUser.Update(memuser);
                await _context.SaveChangesAsync();
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Deleted + EntityName + "Contact: " + memuser.Email, UserTypeValues.Staff);
                return new JsonResult(new { success = true, message = MMMessages.DeletedSuccessfully });
            }

            return new JsonResult(new { success = false, message = MMMessages.NoRecordToDelete });
        }

        public async Task<IActionResult> OnGetListAsync()
        {
            UserList = new List<UserVM>();

            var users = await _context.MemberUser
                .Include(x => x.ApplicationUser)
                 .Where(x => x.MembershipTypeId == (int)MembershipTypeEnum.NonMembers)
                .Select(p => new
                {
                    p.Id,
                    p.ApplicationUser.FirstName,
                    p.ApplicationUser.LastName,
                    p.ApplicationUser.Email,
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
                    mobilephone = user.MobilePhone,
                    membershipcode=user.MemberCode,
                    idnumber = user.IDNumber
                });
            }
            
            return new JsonResult(UserList);
        }
    }
}