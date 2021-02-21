using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MM.ClientModels;
using MM.Helper;
using WISA.Services;

namespace MM.Pages.Admin
{
    [Authorize(Policy = MMPolicies.AllowSetUp)]
    public class AdminHome2Model : PageModel
    {
        private ClientDbContext _context;
        private readonly ILogger<AdminHome2Model> _logger;
        private IActivity _activity;
        private string EntityName = "Dashboard";
        public AdminHome2Model(ClientDbContext context, ILogger<AdminHome2Model> logger, IActivity activity)
        {
            _context = context;
            _activity = activity;
            _logger = logger;
        }

      


      
        public async Task<IActionResult> OnGetAsync()
        {
            await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Accessed + EntityName, UserTypeValues.Staff);
            return Page();
        }


      



        

       


    }
}
