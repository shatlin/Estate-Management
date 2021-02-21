using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MM.ClientModels;

namespace WISA.Pages.Member
{
    public class MemberModel : PageModel
    {

        private readonly ClientDbContext _context;

        public MemberModel(MM.ClientModels.ClientDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MemberUser MemberUser { get; set; }

        [BindProperty]
        public ApplicationUser ApplicationUser { get; set; }


        public IActionResult OnGet()
        {
            ViewData["ClientBranchId"] = new SelectList(_context.ClientBranch, "Id", "Name");
            ViewData["EthnicityId"] = new SelectList(_context.Ethnicity, "Id", "Name");
            ViewData["HighestQualitificationId"] = new SelectList(_context.Qualification, "Id", "Id");
            ViewData["HomeLanguageId"] = new SelectList(_context.Language, "Id", "Name");
            ViewData["MemberBranchId"] = new SelectList(_context.MemberBranch, "Id", "Description");
            ViewData["MembershipTypeId"] = new SelectList(_context.MembershipType, "Id", "Description");
            ViewData["MemberLevelId"] = new SelectList(_context.MemberLevel, "Id", "Description");
            ViewData["MemberStatusId"] = new SelectList(_context.MemberStatus, "Id", "Name");
            ViewData["MemberTeamId"] = new SelectList(_context.MemberTeam, "Id", "Description");
            ViewData["MembershipTypeId"] = new SelectList(_context.MembershipGrade, "Id", "Name");
            ViewData["CountryId"] = new SelectList(_context.Country, "Id", "Id");
            ViewData["OccupationId"] = new SelectList(_context.Occupation, "Id", "Name");
            ViewData["OrganizationId"] = new SelectList(_context.Organization, "Id", "Description");
            ViewData["OrganizationStructureId"] = new SelectList(_context.OrganizationStructure, "Id", "Description");
            ViewData["OwnerClientUserId"] = new SelectList(_context.ClientUser, "Id", "ApplicaitonUserId");
            ViewData["PreferredAppointmentTimeId"] = new SelectList(_context.PreferredContactTime, "Id", "Name");
            ViewData["ReferralTypeId"] = new SelectList(_context.ReferralType, "Id", "Name");
            ViewData["TransactionCurrencyid"] = new SelectList(_context.Currency, "Id", "Code");
            ViewData["VolunteerWorkHoursId"] = new SelectList(_context.VolunteerHours, "Id", "Name");
            ViewData["TitleId"] = new SelectList(_context.Title, "Id", "Name");
            return Page();
        }
    }
}