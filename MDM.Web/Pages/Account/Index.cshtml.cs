using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MM.ClientModels;
using MM.Helper;
using WISA.Services;

namespace MM.Pages.Client.Account
{
    [AllowAnonymous]
    public partial class IndexModel : PageModel
    {
        private readonly ClientDbContext _clientDbContext;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<IndexModel> _logger;
        private readonly IEmailCreator _emailCreator;
        private readonly IConfiguration _configuration;

        public IndexModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            ILogger<IndexModel> logger, IEmailCreator emailCreator, ClientDbContext clientDbContext, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailCreator = emailCreator;
            _clientDbContext = clientDbContext;
            _configuration = configuration;

        }


        #region Bindings

        [BindProperty]
        public ApplicationIndividualVM ApplicationIndividualVM { get; set; }

        [BindProperty]
        public Address PhysicalAddress { get; set; }

        [BindProperty]
        public Address PostalAddress { get; set; }

        #endregion
        public void SetApplicationIndividual(MemberUser memberUser, string Email, string phoneNumber)
        {
            ApplicationIndividualVM = new ApplicationIndividualVM();
            ApplicationIndividualVM.Id = memberUser.Id;
            ApplicationIndividualVM.Email = Email;
            ApplicationIndividualVM.ApplicationUserId = memberUser.ApplicaitonUserId;
            ApplicationIndividualVM.MobilePhone = phoneNumber;
            ApplicationIndividualVM.TitleId = memberUser.ApplicationUser.TitleId;
            ApplicationIndividualVM.FirstName = memberUser.ApplicationUser.FirstName;
            ApplicationIndividualVM.LastName = memberUser.ApplicationUser.LastName;
            ApplicationIndividualVM.BirthDay = memberUser.ApplicationUser.BirthDay;
            ApplicationIndividualVM.GenderId = memberUser.ApplicationUser.GenderId;
            ApplicationIndividualVM.Notes = memberUser.Notes;

            if (PhysicalAddress != null)
            {
                ApplicationIndividualVM.PhysicalAddressLine1 = PhysicalAddress.AddressLine1;
                ApplicationIndividualVM.PhysicalAddressLine2 = PhysicalAddress.AddressLine2;
                ApplicationIndividualVM.PhysicalSuburb = PhysicalAddress.Suburb;
                ApplicationIndividualVM.PhysicalCity = PhysicalAddress.CityName;
                ApplicationIndividualVM.PhysicalProvince = PhysicalAddress.Province;
                ApplicationIndividualVM.PhysicalCountryId = PhysicalAddress.CountryId;
                ApplicationIndividualVM.PhysicalPostalCode = PhysicalAddress.PostalCode;
            }
            if (PostalAddress != null)
            {
                ApplicationIndividualVM.PostalAddressLine1 = PostalAddress.AddressLine1;
                ApplicationIndividualVM.PostalAddressLine2 = PostalAddress.AddressLine2;
                ApplicationIndividualVM.PostalSuburb = PostalAddress.Suburb;
                ApplicationIndividualVM.PostalCity = PostalAddress.CityName;
                ApplicationIndividualVM.PostalProvince = PostalAddress.Province;
                ApplicationIndividualVM.PostalCountryId = (int?)PostalAddress.CountryId;
                ApplicationIndividualVM.PostalPostalCode = PostalAddress.PostalCode;
            }

        }

        public async Task<IActionResult> OnGetAsync()
        {
            await SetViewData();
            return Page();
        }



        public async Task SetViewData()
        {
            MemberUser memberUser = new MemberUser();
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                memberUser = await _clientDbContext.MemberUser
                    .Include(m => m.ApplicationUser)
                    .Include(m => m.ApplicationUser.Gender)
                    .Include(m => m.ApplicationUser.Title)
                   .FirstOrDefaultAsync(m => m.ApplicaitonUserId == user.Id);

                PhysicalAddress = _clientDbContext.Address.Where(x => x.RelatedEntityId == memberUser.Id && x.RelatedToId == (int)RelatedToEnum.Staff && x.AddressTypeId == 2).FirstOrDefault();
                PostalAddress = _clientDbContext.Address.Where(x => x.RelatedEntityId == memberUser.Id && x.RelatedToId == (int)RelatedToEnum.Staff && x.AddressTypeId == 1).FirstOrDefault();

                SetApplicationIndividual(memberUser, user.Email,user.PhoneNumber);
            }
            ViewData["Titles"] = new SelectList(_clientDbContext.Title.ToList(), nameof(Title.Id), nameof(Title.Name));
            ViewData["Genders"] = new SelectList(_clientDbContext.Gender.ToList(), nameof(Gender.Id), nameof(Gender.Name));

            ViewData["Provinces"] = new SelectList(_clientDbContext.State.ToList(), nameof(State.Id), nameof(State.Name));
            ViewData["Countries"] = new SelectList(_clientDbContext.Country.ToList(), nameof(Country.Id), nameof(Country.Name));
            ViewData["YesNoList"] = new SelectList(new YesNoLookup().YesNoList(), nameof(YesNoLookup.Id), nameof(YesNoLookup.Name));

        }

        public async Task<ClientUser> UpdateClientUser(string appUserId)
        {
            ClientUser ClientUser = await _clientDbContext.ClientUser.FirstOrDefaultAsync(m => m.ApplicaitonUserId == appUserId);
            PhysicalAddress = _clientDbContext.Address.Where(x => x.RelatedEntityId == ClientUser.Id && x.RelatedToId == (int)RelatedToEnum.Staff  && x.AddressTypeId == 2).FirstOrDefault();
            PostalAddress = _clientDbContext.Address.Where(x => x.RelatedEntityId == ClientUser.Id && x.RelatedToId == (int)RelatedToEnum.Staff  && x.AddressTypeId == 1).FirstOrDefault();

            if (PhysicalAddress == null)
            {
                PhysicalAddress = new Address();
                PhysicalAddress.RelatedEntityId = ClientUser.Id;
                PhysicalAddress.RelatedToId = (int)RelatedToEnum.Staff ;
                PhysicalAddress.AddressTypeId = (int)AddressTypeEnum.Physical;
                PhysicalAddress.AddressLine1 = ApplicationIndividualVM.PhysicalAddressLine1;
                PhysicalAddress.AddressLine2 = ApplicationIndividualVM.PhysicalAddressLine2;
                PhysicalAddress.Suburb = ApplicationIndividualVM.PhysicalSuburb;
                PhysicalAddress.Province = ApplicationIndividualVM.PhysicalProvince;
                PhysicalAddress.PostalCode = ApplicationIndividualVM.PhysicalPostalCode;
                PhysicalAddress.CountryId = ApplicationIndividualVM.PhysicalCountryId;
                await _clientDbContext.Address.AddAsync(PhysicalAddress);
            }
            else
            {
                PhysicalAddress.RelatedEntityId = ClientUser.Id;
                PhysicalAddress.RelatedToId = (int)RelatedToEnum.Staff ;
                PhysicalAddress.AddressTypeId = (int)AddressTypeEnum.Physical;
                PhysicalAddress.AddressLine1 = ApplicationIndividualVM.PhysicalAddressLine1;
                PhysicalAddress.AddressLine2 = ApplicationIndividualVM.PhysicalAddressLine2;
                PhysicalAddress.Suburb = ApplicationIndividualVM.PhysicalSuburb;
                PhysicalAddress.Province = ApplicationIndividualVM.PhysicalProvince;
                PhysicalAddress.PostalCode = ApplicationIndividualVM.PhysicalPostalCode;
                PhysicalAddress.CityName = ApplicationIndividualVM.PhysicalCity;
                PhysicalAddress.CountryId = ApplicationIndividualVM.PhysicalCountryId;
                _clientDbContext.Address.Update(PhysicalAddress);
            }

            if (PostalAddress == null)
            {
                PostalAddress = new Address();
                PostalAddress.RelatedEntityId = ClientUser.Id;
                PostalAddress.RelatedToId = (int)RelatedToEnum.Staff;
                PostalAddress.AddressTypeId = (int)AddressTypeEnum.Postal;
                PostalAddress.AddressLine1 = ApplicationIndividualVM.PostalAddressLine1;
                PostalAddress.AddressLine2 = ApplicationIndividualVM.PostalAddressLine2;
                PostalAddress.Suburb = ApplicationIndividualVM.PostalSuburb;
                PostalAddress.Province = ApplicationIndividualVM.PostalProvince;
                PostalAddress.PostalCode = ApplicationIndividualVM.PostalPostalCode;
                PostalAddress.CityName = ApplicationIndividualVM.PostalCity;
                PostalAddress.CountryId = ApplicationIndividualVM.PostalCountryId;
                await _clientDbContext.Address.AddAsync(PostalAddress);
            }
            else
            {
                PostalAddress.RelatedEntityId = ClientUser.Id;
                PostalAddress.RelatedToId = (int)RelatedToEnum.Staff;
                PostalAddress.AddressTypeId = (int)AddressTypeEnum.Postal;
                PostalAddress.AddressLine1 = ApplicationIndividualVM.PostalAddressLine1;
                PostalAddress.AddressLine2 = ApplicationIndividualVM.PostalAddressLine2;
                PostalAddress.Suburb = ApplicationIndividualVM.PostalSuburb;
                PostalAddress.Province = ApplicationIndividualVM.PostalProvince;
                PostalAddress.PostalCode = ApplicationIndividualVM.PostalPostalCode;
                PostalAddress.CityName = ApplicationIndividualVM.PostalCity;
                PostalAddress.CountryId = ApplicationIndividualVM.PostalCountryId;
                _clientDbContext.Address.Update(PostalAddress);
            }

            await _clientDbContext.SaveChangesAsync();

            return ClientUser;
        }

        public async Task<ApplicationUser> UpdateApplicationUser()
        {
            ApplicationUser AppUser = await _userManager.GetUserAsync(User);

            try
            {
                AppUser.FirstName = ApplicationIndividualVM.FirstName;
                AppUser.LastName = ApplicationIndividualVM.LastName;
                AppUser.BirthDay = ApplicationIndividualVM.BirthDay;
                AppUser.PhoneNumber = ApplicationIndividualVM.MobilePhone;
                AppUser.TitleId = Convert.ToInt32(ApplicationIndividualVM.TitleId);
                AppUser.GenderId = Convert.ToInt32(ApplicationIndividualVM.GenderId);
                var result = await _userManager.UpdateAsync(AppUser);

                var test = result.Errors;
                if (result.Succeeded)
                {

                }
                return AppUser;
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception Occured while Updating Application User |" + ex.Message);
            }
            return null;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ApplicationUser AppUser = new ApplicationUser();
            AppUser = await UpdateApplicationUser();
            await UpdateClientUser(AppUser.Id);
            await SetViewData();
            return Page();

        }

    }
}
