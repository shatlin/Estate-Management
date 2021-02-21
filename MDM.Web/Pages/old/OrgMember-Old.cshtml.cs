using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MM.ClientModels;

namespace WISA.Pages.Manage
{
    public class OrgMemberOldModel : PageModel
    {

        private readonly ClientDbContext _context;

        public OrgMemberOldModel(MM.ClientModels.ClientDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MemberUser MemberUser { get; set; }

        [BindProperty]
        public ApplicationUser ApplicationUser { get; set; }

        [BindProperty]
        public OrgMemberVM OrgMemberVM { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //MemberUser = await _context.MemberUser
            //    .Include(m => m.ApplicationUser)
            //     .Include(m => m.ApplicationUser.Gender)
            //      .Include(m => m.ApplicationUser.Title)
            //    .Include(m => m.ClientBranch)
            //    .Include(m => m.Ethnicity)
            //    .Include(m => m.HighestQualitification)
            //    .Include(m => m.HomeLanguage)
            //    .Include(m => m.MemberBranch)
            //    .Include(m => m.MemberCategory)
            //    .Include(m => m.MemberLevel)
            //    .Include(m => m.MemberStatus)
            //    .Include(m => m.MemberTeam)
            //    .Include(m => m.MembershipType)
            //    .Include(m => m.Nationality)
            //    .Include(m => m.Occupation)
            //    .Include(m => m.Organization)
            //    .Include(m => m.OrganizationStructure)
            //    .Include(m => m.OwnerClientUser)
            //    .Include(m => m.PreferredAppointmentTime)
            //    .Include(m => m.ReferralType)
            //    .Include(m => m.TransactionCurrency)
            //    .Include(m => m.VolunteerWorkHours).FirstOrDefaultAsync(m => m.Id == id);

            //if (MemberUser == null)
            //{
            //    return NotFound();
            //}
            ViewData["ApplicaitonUserId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["ClientBranchId"] = new SelectList(_context.ClientBranch, "Id", "Name");
            ViewData["TitleId"] = new SelectList(_context.Title, "Id", "Name");
            ViewData["EthnicityId"] = new SelectList(_context.Ethnicity, "Id", "Name");
            ViewData["HighestQualitificationId"] = new SelectList(_context.Qualification, "Id", "Name");
            ViewData["HomeLanguageId"] = new SelectList(_context.Language, "Id", "Name");
            ViewData["ClientBranchId"] = new SelectList(_context.ClientBranch, "Id", "Name");
            ViewData["MemberCategoryId"] = new SelectList(_context.MemberCategory, "Id", "Name");
            ViewData["MemberLevelId"] = new SelectList(_context.MemberLevel, "Id", "Name");
            ViewData["MemberStatusId"] = new SelectList(_context.MemberStatus, "Id", "Name");
            ViewData["MemberTeamId"] = new SelectList(_context.MemberTeam, "Id", "Name");
            ViewData["MembershipTypeId"] = new SelectList(_context.MembershipType, "Id", "Name");
            ViewData["NationalityId"] = new SelectList(_context.Country, "Id", "Name");
            ViewData["OccupationId"] = new SelectList(_context.Occupation, "Id", "Name");
            ViewData["OrganizationId"] = new SelectList(_context.Organization, "Id", "Name");
            ViewData["OrganizationStructureId"] = new SelectList(_context.OrganizationStructure, "Id", "Name");
            ViewData["OwnerClientUserId"] = new SelectList(_context.ClientUser, "Id", "ApplicaitonUserId");
            ViewData["PreferredAppointmentTimeId"] = new SelectList(_context.PreferredContactTime, "Id", "Name");
            ViewData["ReferralTypeId"] = new SelectList(_context.ReferralType, "Id", "Name");
            ViewData["TransactionCurrencyid"] = new SelectList(_context.Currency, "Id", "Name");
            ViewData["VolunteerWorkHoursId"] = new SelectList(_context.VolunteerHours, "Id", "Name");
            ViewData["GenderId"] = new SelectList(_context.Gender, "Id", "Name");
            return Page();
        }
    }
}