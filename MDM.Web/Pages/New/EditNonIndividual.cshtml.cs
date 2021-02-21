using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MM.ClientModels;
using MM.Helper;
using WISA.Services;

namespace WISA.Pages.New
{
    [AllowAnonymous]
    public class EditNonIndividualModel : PageModel
    {

        public class MemberVM
        {
            public int MemberId { get; set; }
            public string FullName { get; set; }
            public string MembershipStatus { get; set; }
            public int? MembershipGradeId { get; set; }
            public string MembershipGrade { get; set; }
            public string Email { get; set; }
        }

        private readonly ClientDbContext _context;
        private readonly ILogger<EditNonIndividualModel> _logger;
        private IActivity _activity;
        private string EntityName = "Edit Non Individual";

        public EditNonIndividualModel(ClientDbContext context, ILogger<EditNonIndividualModel> logger, IActivity activity)
        {
            _context = context;
            _logger = logger;
            _activity = activity;
        }





        [BindProperty]
        public Organization Organization { get; set; }

        [BindProperty]
        public Address PhysicalAddress { get; set; }

        [BindProperty]
        public Address PostalAddress { get; set; }

        [BindProperty]
        public List<MemberVM> membervmlist { get; set; }

        [BindProperty]
        public List<OrganizationBusinessXref> OrganizationBusinessList { get; set; }

        [ViewData]
        public int? PrimaryContactId { get; set; }

        [ViewData]
        public string PrimaryContactName { get; set; }

        [ViewData]
        public int? ContactPersonId { get; set; }

        [ViewData]
        public string ContactPersonName { get; set; }

        public async Task GetBusinessesAsync(int? OrgId)
        {

            List<Business> businessList = await _context.Business.ToListAsync();
            OrganizationBusinessList = await _context.OrganizationBusinessXref.Include(x => x.Business).Where(x => x.OrganizationId == OrgId).ToListAsync();

            foreach (var business in businessList)
            {
                var found = false;
                foreach (var selectedbusiness in OrganizationBusinessList)
                {
                    if (selectedbusiness.BusinessId == business.Id)
                    {
                        selectedbusiness.IsSelected = true;
                        found = true;
                    }
                }
                if (found == false)
                {
                    OrganizationBusinessList.Add(new OrganizationBusinessXref { IsSelected = false, Business = business, BusinessId = business.Id, OrganizationId = OrgId });
                }
            }
            OrganizationBusinessList=OrganizationBusinessList.OrderBy(x=>x.BusinessId).ToList();
        }


        public async Task<IActionResult> SetViewData(int? id)
        {
            PhysicalAddress = _context.Address.Where(x => x.RelatedEntityId == id && x.RelatedToId == (int)RelatedToEnum.Organization && x.AddressTypeId == 2).FirstOrDefault();
            PostalAddress = _context.Address.Where(x => x.RelatedEntityId == id && x.RelatedToId == (int)RelatedToEnum.Organization && x.AddressTypeId == 1).FirstOrDefault();
            Organization = await _context.Organization
            .Include(m => m.MemberStatus)
            .Include(m => m.OrganizationGrade)
            .Include(m => m.OrganizationType)
            .Include(m => m.TransactionCurrency)
            .Include(m => m.ClientBranch).FirstOrDefaultAsync(m => m.Id == id);

            if (Organization == null)
            {
                return NotFound();
            }

            await GetBusinessesAsync(Organization.Id);

            membervmlist = _context.MemberUser.Include(x => x.ApplicationUser).Include(x => x.MembershipType).Include(x => x.MemberStatus)
                .Where(x => x.OrganizationId == Organization.Id)
                        .Select(x => new MemberVM
                        {
                            MemberId = x.Id,
                            FullName = x.ApplicationUser.FullName,
                            MembershipStatus = x.MemberStatus.Name,
                            MembershipGradeId = x.MembershipTypeId,
                            MembershipGrade = x.MembershipType.Name,
                            Email = x.ApplicationUser.Email,
                        }).ToList();

            MemberVM primaryContact = membervmlist.Where(x => x.MembershipGradeId == (int)MembershipTypeEnum.PrimaryContact).FirstOrDefault();

            if (primaryContact != null) { PrimaryContactId = primaryContact.MemberId; PrimaryContactName = primaryContact.FullName; }
            MemberVM ContactPerson = membervmlist.Where(x => x.MembershipGradeId == (int)MembershipTypeEnum.ContactPerson).FirstOrDefault();
            if (ContactPerson != null) { ContactPersonId = ContactPerson.MemberId; ContactPersonName = ContactPerson.FullName; }

            ViewData["MemberStatusId"] = new SelectList(_context.MemberStatus, "Id", "Name");
            ViewData["OrganizationGradeId"] = new SelectList(_context.OrganizationGrade, "Id", "Name");
            ViewData["MemberShipTypeId"] = new SelectList(_context.OrganizationType, "Id", "Name");
            ViewData["TransactionCurrencyId"] = new SelectList(_context.Currency, "Id", "Name");
            ViewData["ClientBranchId"] = new SelectList(_context.ClientBranch, "Id", "Name");
            ViewData["YesNoList"] = new SelectList(new YesNoLookup().YesNoList(), nameof(YesNoLookup.Id), nameof(YesNoLookup.Name));
            ViewData["ProvinceId"] = new SelectList(_context.State.ToList(), nameof(State.Id), nameof(State.Name));
            ViewData["CountryId"] = new SelectList(_context.Country.ToList(), nameof(Country.Id), nameof(Country.Name));
            return null;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            await SetViewData(id);
            await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Accessed + EntityName, UserTypeValues.Staff);
            return Page();
        }


        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                _context.Organization.Update(Organization);

                await _context.SaveChangesAsync();

                var physicalAddresstemp = _context.Address.Where(x => x.RelatedEntityId == Organization.Id && x.RelatedToId == (int)RelatedToEnum.Organization && x.AddressTypeId == 2).FirstOrDefault();
                var postalAddresstemp = _context.Address.Where(x => x.RelatedEntityId == Organization.Id && x.RelatedToId == (int)RelatedToEnum.Organization && x.AddressTypeId == 1).FirstOrDefault();


                if (physicalAddresstemp == null)
                {
                    PhysicalAddress.RelatedEntityId = Organization.Id;
                    PhysicalAddress.RelatedToId = (int)RelatedToEnum.Organization;
                    PhysicalAddress.AddressTypeId = (int)AddressTypeEnum.Physical;
                    await _context.Address.AddAsync(PhysicalAddress);
                }
                else
                {

                    physicalAddresstemp.AddressTypeId = (int)AddressTypeEnum.Physical;
                    physicalAddresstemp.AddressLine1 = PhysicalAddress.AddressLine1;
                    physicalAddresstemp.AddressLine2 = PhysicalAddress.AddressLine2;
                    physicalAddresstemp.Suburb = PhysicalAddress.Suburb;
                    physicalAddresstemp.Province = PhysicalAddress.Province;
                    physicalAddresstemp.PostalCode = PhysicalAddress.PostalCode;
                    physicalAddresstemp.CityName = PhysicalAddress.CityName;
                    physicalAddresstemp.CountryId = PhysicalAddress.CountryId;
                    _context.Address.Update(physicalAddresstemp);
                }


                if (postalAddresstemp == null)
                {
                    PostalAddress.RelatedEntityId = Organization.Id;
                    PostalAddress.RelatedToId = (int)RelatedToEnum.Organization;
                    PostalAddress.AddressTypeId = (int)AddressTypeEnum.Postal;
                    await _context.Address.AddAsync(PostalAddress);
                }
                else
                {

                    postalAddresstemp.AddressTypeId = (int)AddressTypeEnum.Postal;
                    postalAddresstemp.AddressLine1 = PostalAddress.AddressLine1;
                    postalAddresstemp.AddressLine2 = PostalAddress.AddressLine2;
                    postalAddresstemp.Suburb = PostalAddress.Suburb;
                    postalAddresstemp.Province = PostalAddress.Province;
                    postalAddresstemp.PostalCode = PostalAddress.PostalCode;
                    postalAddresstemp.CityName = PostalAddress.CityName;
                    postalAddresstemp.CountryId = PostalAddress.CountryId;
                    _context.Address.Update(postalAddresstemp);
                }

                var businesslist = await _context.OrganizationBusinessXref.Where(x => x.OrganizationId == Organization.Id).ToListAsync();
                _context.OrganizationBusinessXref.RemoveRange(businesslist);


                foreach (var orgbusiness in OrganizationBusinessList)
                {
                    if (orgbusiness.IsSelected==true)
                    {
                        await _context.OrganizationBusinessXref.AddAsync(orgbusiness);
                        await _context.SaveChangesAsync();
                    }
                }



                await _context.SaveChangesAsync();
            }
            else
            {
                _logger.LogInformation(string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)));

            }
            await SetViewData(Organization.Id);
            await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Updated + EntityName + " Name: " + Organization.Name, UserTypeValues.Staff);
            return Page();
        }


    }
}
