using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Web;
using DocumentFormat.OpenXml.ExtendedProperties;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MM.ClientModels;

namespace WISA.Pages.Member
{
    public class TestModel : PageModel
    {

        public class QVM
        {
            public int id { get; set; }
            public string institute { get; set; }
            public string name { get; set; }
          
        }

        public  class AVM
        {
            public int Id { get; set; }
            public string ApplicaitonUserId { get; set; }
            public string OwnerClientUserId { get; set; }
        }

        private readonly ClientDbContext _clientDbContext;

        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<ApplicationIndividualModel> _logger;
        private readonly IEmailSender _emailSender;

        public TestModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<ApplicationIndividualModel> logger, RoleManager<ApplicationRole> roleManager,
            IEmailSender emailSender, ClientDbContext clientDbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _clientDbContext = clientDbContext;
            _roleManager = roleManager;
        }




        [BindProperty]
        public AVM avm { get; set; }

        [BindProperty]
        public List<QVM> qvm { get; set; }



        // called first time the page is loaded.
        public IActionResult OnGet()
        {

            ViewData["Qualifications"] = new SelectList(_clientDbContext.Qualification.ToList(), nameof(Qualification.Id), nameof(Qualification.Name));

            ViewData["QualificationCategories"] = new SelectList(_clientDbContext.QualificationCategory.ToList(), nameof(QualificationCategory.Id), nameof(QualificationCategory.Name));

            ViewData["QualificationTypes"] = new SelectList(_clientDbContext.QualificationType.ToList(), nameof(QualificationType.Id), nameof(QualificationType.Name));

            ViewData["EnrolmentCategories"] = new SelectList(_clientDbContext.QualificationEnrolmentCategory.ToList(), nameof(QualificationEnrolmentCategory.Id), nameof(QualificationEnrolmentCategory.Name));

            return Page();
        }



        public async Task<IActionResult> OnPostAsync()
        //public IActionResult OnPostSave()
        {
              var s=qvm;
            if (!ModelState.IsValid)
            {
              
            }

            return new JsonResult(new { success = true, message = "Saved successfully" });
        }


    }
}