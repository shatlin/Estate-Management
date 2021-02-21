using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MM.ClientModels;

namespace MM.Pages
{
    public class TestedrModel : PageModel
    {
        private readonly ILogger<TestedrModel> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ClientDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;




        public TestedrModel(SignInManager<ApplicationUser> signInManager,
            ILogger<TestedrModel> logger,
            UserManager<ApplicationUser> userManager, ClientDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
        }

        [BindProperty]
        public decimal AccountBalance { get; set; }

        [Required]
        [EmailAddress]
        [BindProperty]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [BindProperty]
        public string Password { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
           
                return Page();
           
        }
    }
}
