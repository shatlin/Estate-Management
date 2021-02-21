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
    public class CompanyAddressModel : PageModel
    {
        #region Constructor

        private readonly ClientDbContext _clientDbContext;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<CompanyAddressModel> _logger;
        private readonly IEmailCreator _emailCreator;
        private readonly IConfiguration _configuration;
        private IActivity _activity;
        private string EntityName = "Resigned Members";

        public CompanyAddressModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            ILogger<CompanyAddressModel> logger, IEmailCreator emailCreator, ClientDbContext clientDbContext, IConfiguration configuration, IActivity activity)
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
        public IList<NonIndividualVM> NonIndividualVMList { get; set; }


        #endregion

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnGetListAsync()
        {
            NonIndividualVMList = new List<NonIndividualVM>();

            await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Accessed + EntityName, UserTypeValues.Staff);


            var nonindividuals = await _clientDbContext.Organization
                .Include(x => x.MemberStatus)
                .Include(x => x.OrganizationGrade)
                .Include(x => x.ClientBranch)
                .ToListAsync();

            var members = await _clientDbContext.MemberUser
                .Include(x => x.MembershipGrade)
                .Include(x => x.MemberStatus)
                .Include(x => x.MembershipType)
                .Include(x => x.MemberAddress)
                .Include(x => x.ApplicationUser)
                .Include(x => x.ApplicationUser.Gender)
                .Include(x => x.Ethnicity)
                .Include(x => x.Occupation)
                .Include(x => x.ClientBranch)
                .Where(x => x.MembershipTypeId >= 5)
                .ToListAsync();

            var addresses = await _clientDbContext.Address.Where(x => x.RelatedToId == (int)RelatedToEnum.Organization).ToListAsync();


            int i = 0;
            int d = 0;
            foreach (var nonindividual in nonindividuals)
            {
                if (nonindividual.MemberStatus != null && nonindividual.MemberStatus.Name.ToUpper() == "ACTIVE")
                {
                    try
                    {

                        i++;
                        d = nonindividual.Id;
                        NonIndividualVM nvm = new NonIndividualVM();


                        nvm.OrgMemberCode = nonindividual.OrgMemberCode;
                        nvm.Name = nonindividual.Name;

                        //Address PhysicalAddress = addresses.FirstOrDefault(x => x.RelatedEntityId == nonindividual.Id && x.AddressTypeId == (int)AddressTypeEnum.Physical);

                        Address PostalAddress = addresses.FirstOrDefault(x => x.RelatedEntityId == nonindividual.Id && x.AddressTypeId == (int)AddressTypeEnum.Postal);


                        //if (PhysicalAddress != null)
                        //{
                        //    nvm.PhysicalAddressLine1 = PhysicalAddress.AddressLine1;
                        //    nvm.PhysicalAddressLine2 = PhysicalAddress.AddressLine2;
                        //    nvm.PhysicalAddressLine3 = PhysicalAddress.AddressLine3;
                        //    nvm.PhysicalSuburb = PhysicalAddress.Suburb;
                        //    nvm.PhysicalCity = PhysicalAddress.CityName;
                        //    nvm.PhysicalProvince = PhysicalAddress.Province;
                        //    nvm.PhysicalPostalCode = PhysicalAddress.PostalCode;
                        //    nvm.PhysicalCountryName = PhysicalAddress.Country != null ? PhysicalAddress.Country.Name : null;
                        //}

                        if (PostalAddress != null)
                        {
                            nvm.PostalAddressLine1 = PostalAddress.AddressLine1;
                            nvm.PostalAddressLine2 = PostalAddress.AddressLine2;
                            nvm.PostalAddressLine3 = PostalAddress.AddressLine3;
                            nvm.PostalSuburb = PostalAddress.Suburb;
                            nvm.PostalCity = PostalAddress.CityName;
                            nvm.PostalProvince = PostalAddress.Province;
                            nvm.PostalPostalCode = PostalAddress.PostalCode;
                            nvm.PostalCountryName = PostalAddress.CountryName;
                        }


                        MemberUser PrimaryContact = members.FirstOrDefault(x => x.ParentMemberid == nonindividual.Id && x.MembershipTypeId == 5);

                        if (PrimaryContact != null)
                        {
                            ApplicationUser applicationUser = await _userManager.FindByEmailAsync(PrimaryContact.Email);
                            if (applicationUser != null)
                            {
                                nvm.PrimaryContact = applicationUser.FullName;
                            }
                        }

                        MemberUser ContactPerson = members.FirstOrDefault(x => x.ParentMemberid == nonindividual.Id && x.MembershipTypeId == 7);

                        if (ContactPerson != null)
                        {
                            ApplicationUser applicationUser = await _userManager.FindByEmailAsync(ContactPerson.Email);
                            if (applicationUser != null)
                            {
                                nvm.ContactPerson = applicationUser.FullName;
                            }
                            else
                            {
                                nvm.ContactPerson = nvm.PrimaryContact;
                            }
                        }
                        else
                        {
                            nvm.ContactPerson = nvm.PrimaryContact;
                        }
                        NonIndividualVMList.Add(nvm);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError("Exception at row" + i + " Organization Id " + d);
                    }
                }
            }



            return new JsonResult(NonIndividualVMList);
        }



    }
}