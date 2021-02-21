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
using WISA.Services;

namespace WISA.Web.Pages.Member
{
    [Authorize(Policy = MMPolicies.AllowMemberAccess)]
    public class MemberHomeModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ClientDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;




        public MemberHomeModel(SignInManager<ApplicationUser> signInManager,
            ILogger<IndexModel> logger,
            UserManager<ApplicationUser> userManager, ClientDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
        }

        [BindProperty]
        public decimal AccountBalance { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                MemberUser memberUser = _context.MemberUser.Where(x => x.ApplicaitonUserId == user.Id).FirstOrDefault();

                if (memberUser == null)
                {
                    // return RedirectToPage("/Account/Login");
                    return LocalRedirect("/Account/Login");
                }
                if (memberUser.AccountBalanceOftheCompany != null)
                {
                    AccountBalance = Convert.ToDecimal(memberUser.AccountBalanceOftheCompany);
                }
                else
                {
                    AccountBalance = 0.00M;
                }
                return Page();
            }
            return LocalRedirect("/Account/Login");
        }
    }
}
