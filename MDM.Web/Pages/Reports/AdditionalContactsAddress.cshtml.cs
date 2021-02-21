using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MM.ClientModels;
using MM.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WISA.Services;

namespace MM.Pages.Report
{
    [Authorize(Policy = MMPolicies.AllowUserAccess)]
    public class AdditionalContactsAddressModel : PageModel
    {
        #region Constructor

        private readonly ClientDbContext _clientDbContext;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<AdditionalContactsAddressModel> _logger;
        private readonly IEmailCreator _emailCreator;
        private readonly IConfiguration _configuration;
        private IActivity _activity;
        private string EntityName = "Resigned Members";

        public AdditionalContactsAddressModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            ILogger<AdditionalContactsAddressModel> logger, IEmailCreator emailCreator, ClientDbContext clientDbContext, IConfiguration configuration, IActivity activity)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailCreator = emailCreator;
            _clientDbContext = clientDbContext;
            _configuration = configuration;
            _activity = activity;

        }
        #endregion

        #region Bindings

        [BindProperty]
        public IList<ApplicationIndividualVM> ApplicationIndividualVMList { get; set; }



        #endregion

        public IActionResult OnGet()
        {
            return Page();
        }

       public async Task<IActionResult> OnGetListAsync()
        {
            ApplicationIndividualVMList = new List<ApplicationIndividualVM>();

            await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Accessed + EntityName, UserTypeValues.Staff);

            var members = await _clientDbContext.MemberUser
                .Include(x => x.MemberStatus)
                .Include(x => x.ApplicationUser).Include(x => x.ApplicationUser.Title).
                Where(x => x.MembershipTypeId == 8)
                .ToListAsync();

            var addresses = await _clientDbContext.Address.Where(x => x.RelatedToId == (int)RelatedToEnum.Member).ToListAsync();


            int i = 0;
            int d = 0;
            string countryname = string.Empty;
            foreach (var member in members)
            {
                if(member.MemberStatus!=null && member.MemberStatus.Name.ToUpper()=="ACTIVE")
                {
                try
                {
                    i++;

                    d = member.Id;
                    ApplicationIndividualVM avm = new ApplicationIndividualVM();

                    avm.MemberCode = member.MemberCode;
                    avm.FullName = member.ApplicationUser.FullName;
                        avm.TitleName = member.ApplicationUser.Title == null ? null : member.ApplicationUser.Title.Name;
                        avm.CompanyName = member.CompanyName;

                    Address PhysicalAddress = addresses.FirstOrDefault(x => x.RelatedEntityId == member.Id && x.AddressTypeId == (int)AddressTypeEnum.Physical);
                    if (PhysicalAddress != null)
                    {
                        avm.PhysicalAddressLine1 = PhysicalAddress.AddressLine1;
                        avm.PhysicalAddressLine2 = PhysicalAddress.AddressLine2;
                            avm.PhysicalAddressLine3 = PhysicalAddress.AddressLine3;
                            avm.PhysicalSuburb = PhysicalAddress.Suburb;
                            avm.PhysicalCity = PhysicalAddress.CityName;
                            avm.PhysicalProvince = PhysicalAddress.Province;
                        avm.PhysicalPostalCode = PhysicalAddress.PostalCode;
                        avm.PhysicalCountryName=PhysicalAddress.Country!=null?PhysicalAddress.Country.Name:null;
                    }


                    Address PostalAddress = addresses.FirstOrDefault(x => x.RelatedEntityId == member.Id && x.AddressTypeId == (int)AddressTypeEnum.Postal);
                    if (PostalAddress != null)
                    {
                         avm.PostalAddressLine1 = PostalAddress.AddressLine1;
                        avm.PostalAddressLine2 = PostalAddress.AddressLine2;
                            avm.PostalAddressLine3 = PostalAddress.AddressLine3;
                            avm.PostalSuburb = PostalAddress.Suburb;
                            avm.PostalCity = PostalAddress.CityName;
                            avm.PostalProvince = PostalAddress.Province;
                        avm.PostalPostalCode = PostalAddress.PostalCode;
                        avm.PostalCountryName=PostalAddress.Country!=null?PostalAddress.Country.Name:null;
                    }

                    ApplicationIndividualVMList.Add(avm);
                }
                catch (Exception ex)
                {

                    _logger.LogError("Exception at row" + i + " Member Id " + d);
                }
                }
            }



            return new JsonResult(ApplicationIndividualVMList);
        }



    }
}