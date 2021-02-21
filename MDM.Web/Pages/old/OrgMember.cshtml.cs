using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MM.ClientModels;
using MM.Helper;

namespace WISA.Pages.Manage
{
    public class OrgMemberModel : PageModel
    {

        private readonly ClientDbContext _context;

        public OrgMemberModel(MM.ClientModels.ClientDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MemberUser MemberUser { get; set; }

        [BindProperty]
        public ApplicationUser ApplicationUser { get; set; }

        [BindProperty]
        public Organization Organization { get; set; }

        [BindProperty]
        public Address PhysicalAddress { get; set; }

        [BindProperty]
        public Address PostalAddress { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Organization = await _context.Organization
            .Include(m => m.MemberStatus)
            .Include(m => m.OrganizationType)
            .Include(m => m.MemberShipType)
            .Include(m => m.TransactionCurrency)
            .Include(m => m.ClientBranch).FirstOrDefaultAsync(m => m.Id == id);

            if (Organization == null)
            {
                return NotFound();
            }
            ViewData["MemberStatusId"] = new SelectList(_context.MemberStatus, "Id", "Name");
            ViewData["OrganizationTypeId"] = new SelectList(_context.OrganizationType, "Id", "Name");
            ViewData["MemberShipTypeId"] = new SelectList(_context.MembershipType, "Id", "Name");
            ViewData["TransactionCurrencyId"] = new SelectList(_context.Currency, "Id", "Name");
            ViewData["ClientBranchId"] = new SelectList(_context.ClientBranch, "Id", "Name");
            return Page();
        }
    }
}