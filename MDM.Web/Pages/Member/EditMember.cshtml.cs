using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MM.ClientModels;

namespace  WISA.Web.Pages.Manage
{
    public class EditMemberModel : PageModel
    {
        private readonly ClientDbContext _context;

        public EditMemberModel(ClientDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MemberUser MemberUser { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MemberUser = await _context.MemberUser
                .Include(m => m.ApplicationUser)
                .Include(m => m.ClientBranch)
                .Include(m => m.Ethnicity)
                .Include(m => m.HighestQualitification)
                .Include(m => m.HomeLanguage)
                .Include(m => m.MemberBranch)
                .Include(m => m.MemberCategory)
                .Include(m => m.MemberLevel)
                .Include(m => m.MemberStatus)
                .Include(m => m.MemberTeam)
                .Include(m => m.MembershipType)
                .Include(m => m.Country)
                .Include(m => m.Occupation)
                .Include(m => m.Organization)
                .Include(m => m.OrganizationStructure)
                .Include(m => m.OwnerClientUser)
                .Include(m => m.PreferredAppointmentTime)
                .Include(m => m.ReferralType)
                .Include(m => m.TransactionCurrency)
                .Include(m => m.VolunteerWorkHours).FirstOrDefaultAsync(m => m.Id == id);

            if (MemberUser == null)
            {
                return NotFound();
            }
           ViewData["ApplicaitonUserId"] = new SelectList(_context.Users, "Id", "Id");
           ViewData["ClientBranchId"] = new SelectList(_context.ClientBranch, "Id", "Name");
           ViewData["EthnicityId"] = new SelectList(_context.Ethnicity, "Id", "Name");
           ViewData["HighestQualitificationId"] = new SelectList(_context.Qualification, "Id", "Id");
           ViewData["HomeLanguageId"] = new SelectList(_context.Language, "Id", "Name");
           ViewData["MemberBranchId"] = new SelectList(_context.MemberBranch, "Id", "Description");
           ViewData["MemberCategoryId"] = new SelectList(_context.MemberCategory, "Id", "Description");
           ViewData["MemberLevelId"] = new SelectList(_context.MemberLevel, "Id", "Description");
           ViewData["MemberStatusId"] = new SelectList(_context.MemberStatus, "Id", "Name");
           ViewData["MemberTeamId"] = new SelectList(_context.MemberTeam, "Id", "Description");
           ViewData["MembershipTypeId"] = new SelectList(_context.MembershipType, "Id", "Name");
           ViewData["CountryId"] = new SelectList(_context.Country, "Id", "Id");
           ViewData["OccupationId"] = new SelectList(_context.Occupation, "Id", "Name");
           ViewData["OrganizationId"] = new SelectList(_context.Organization, "Id", "Description");
           ViewData["OrganizationStructureId"] = new SelectList(_context.OrganizationStructure, "Id", "Description");
           ViewData["OwnerClientUserId"] = new SelectList(_context.ClientUser, "Id", "ApplicaitonUserId");
           ViewData["PreferredAppointmentTimeId"] = new SelectList(_context.PreferredContactTime, "Id", "Name");
           ViewData["ReferralTypeId"] = new SelectList(_context.ReferralType, "Id", "Name");
           ViewData["TransactionCurrencyid"] = new SelectList(_context.Currency, "Id", "Code");
           ViewData["VolunteerWorkHoursId"] = new SelectList(_context.VolunteerHours, "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MemberUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberUserExists(MemberUser.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MemberUserExists(int id)
        {
            return _context.MemberUser.Any(e => e.Id == id);
        }
    }
}
