using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MM.ClientModels;
using WISA.Services;
using MM.Helper;
using System.Web;
using Microsoft.Extensions.Configuration;

namespace MM.Pages.Apply
{
    [AllowAnonymous]
    public class NonMemberModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ClientDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<NonMemberModel> _logger;
        private readonly IEmailCreator _emailCreator;
        private readonly IConfiguration _configuration;
        private IActivity _activity;
       // private string EntityName = "NonMember";
        public NonMemberModel(SignInManager<ApplicationUser> signInManager,
            ILogger<NonMemberModel> logger,
            UserManager<ApplicationUser> userManager, ClientDbContext context, IConfiguration configuration, IEmailCreator emailCreator, IActivity activity)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
            _emailCreator = emailCreator;
            _configuration = configuration;
            _activity = activity;
        }





        public string ReturnUrl { get; set; }


        [Required]
        [BindProperty]
        public string FirstName { get; set; }

        [Required]
        [BindProperty]
        public string LastName { get; set; }

        [Required]
        [BindProperty]
        public string MobileNumber { get; set; }

        [Required]
        [EmailAddress]
        [BindProperty]
        public string Email { get; set; }

        [Required]
        [BindProperty]
        public string IDNumber { get; set; }



        public IActionResult OnGetAsync(string returnUrl = null)
        {
            return Page();
        }

        public ApplicationUser CreateApplicationUser()
        {
            ApplicationUser AppUser = new ApplicationUser();
            try
            {
                AppUser.Email = Email;
                AppUser.UserName = Email;
                AppUser.FirstName = FirstName;
                AppUser.LastName = LastName;
                AppUser.BirthDay = DateTime.Now;
                AppUser.PhoneNumber = MobileNumber;
                AppUser.TitleId = 1;
                AppUser.GenderId = 1;
                AppUser.UserTypeId = 3;
                return AppUser;
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception Occured while Creating Application User |" + ex.Message);
            }
            return null;
        }


        public async Task<MemberUser> CreateMemberUser(string appUserId)
        {
            MemberUser MemberUser = new MemberUser();
            MemberUser.ApplicaitonUserId = appUserId;
            MemberUser.Initials =
            MemberUser.IDNumber = IDNumber;
            MemberUser.MobilePhone = MobileNumber;
            MemberUser.HomePhoneNumber = MobileNumber;
            MemberUser.Email = Email;
            MemberUser.CreatedOn = DateTime.Now;
            MemberUser.ModifiedOn = DateTime.Now;
            MemberUser.ApplicationreceivedDate = DateTime.Now;
            MemberUser.MemberStatusId = 2;
            MemberUser.MembershipTypeId = (int)MembershipTypeEnum.NonMembers;
            MemberUser.TermAccepted = false;
            MemberUser.IsActive = true;
            int MemberCode = 1;

            var lastMember = _context.MemberUser.OrderByDescending(x => x.Id).FirstOrDefault();
            if (lastMember != null)
            {
                MemberCode = Convert.ToInt32(_context.MemberUser.OrderByDescending(x => x.Id).FirstOrDefault().MemberCode) + 1;
            }
            MemberUser.MemberCode = MemberCode.ToString();
            _context.MemberUser.Add(MemberUser);
            await _context.SaveChangesAsync();
            return MemberUser;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("/Index");


            ApplicationUser AppUser = new ApplicationUser();
            MemberUser MemberUser = new MemberUser();

            if (ModelState.IsValid)
            {
                AppUser = CreateApplicationUser();

                string password = HelperMethods.GeneratePassword(10);
                //_logger.LogInformation("Password created for User:" + Email + " is " + password);

                var result = await _userManager.CreateAsync(AppUser, password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(AppUser, MMRoles.ContactRole);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                        //_logger.LogInformation("Model Error:" + error.Description);
                    }
                    return Page();
                }

                MemberUser = await CreateMemberUser(AppUser.Id);

                //_logger.LogInformation("Member with Id " + AppUser.Id + " and email address " + AppUser.Email + " Created Successfully");

                if (MemberUser == null)
                {
                    return Page();
                }

                var code = await _userManager.GenerateEmailConfirmationTokenAsync(AppUser);

                //_logger.LogInformation("GenerateEmailConfirmationTokenAsync Created Successfully");

                code = HttpUtility.UrlEncode(code);

                string callbackUrl = Url.Page("/Account/ConfirmEmail", pageHandler: null, values: new { userId = AppUser.Id, code = code, returnUrl = returnUrl }, protocol: Request.Scheme);

                //_logger.LogInformation("Call Back URL is " + callbackUrl);

               
                 string emailaddresses = EmailRecipients.GetEmailSenderList("ConfirmEmail", null,MemberUser.Email,(int)RelatedToEnum.Member,MemberUser.Id);
               
                await _emailCreator.SendEmailAsync("ConfirmEmail", emailaddresses, AppUser.FullName, "WISA: Confirm your email", "Confirm Email", callbackUrl);
                //_logger.LogInformation("ConfirmEmail is sent");


                emailaddresses = EmailRecipients.GetEmailSenderList("NewMember", "ind", MemberUser.Email,(int)RelatedToEnum.Member,MemberUser.Id);


                await _emailCreator.SendEmailAsync("NewMember", emailaddresses, "Evelyn", "WISA: New Non Member Joined", "New Non Member",
                    Url.Page("/Manage/Individual", pageHandler: null, values: new { id = MemberUser.Id }, protocol: Request.Scheme));

                //_logger.LogInformation("NewMember email is sent");
                //_logger.LogInformation("Redirecting to Page /Account/RegisterConfirmation");
                return RedirectToPage("/Account/RegisterConfirmation", new { email = AppUser.Email, returnUrl = returnUrl });

            }

            else
            {
                //_logger.LogInformation(string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)));
                return Page();
            }




        }
    }
}
