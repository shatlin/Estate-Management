using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MM.ClientModels;
using MM.Helper;
using WISA.Services;

namespace MM.Pages.Admin
{
    [Authorize(Policy = MMPolicies.AllowSetUp)]
    public class IndexdModel : PageModel
    {
        private ClientDbContext _context;
        private readonly ILogger<IndexdModel> _logger;
        private IActivity _activity;
        private string EntityName = "Dashboard";
        public IndexdModel(ClientDbContext context, ILogger<IndexdModel> logger, IActivity activity)
        {
            _context = context;
            _activity = activity;
            _logger = logger;
        }

        [BindProperty]
        public IList<Title> TitleList { get; set; }


        [ViewData]
        public bool AuthorizedForDelete { get; set; }

        [BindProperty]
        public Title Title { get; set; }

        public class MembersByMembershipType
        {
            public string TypeName { get; set; }
            public int TypeCount { get; set; }
        }

        public class MembersByYear
        {
            public string Year { get; set; }
            public int Count { get; set; }
        }

        public class MembersByBranch
        {
            public string Branch { get; set; }
            public int Count { get; set; }
        }

        public class MembersByDivision
        {
            public string Division { get; set; }
            public int Count { get; set; }
        }

        public class MembersByOccupation
        {
            public string Occupation { get; set; }
            public int Count { get; set; }
        }

        [BindProperty]
        public List<MembersByBranch> MembersByBranchList { get; set; }

        [BindProperty]
        public List<MembersByMembershipType> MembersByMembershipTypeList { get; set; }

        [BindProperty]
        public List<MembersByYear> MembersByYearList { get; set; }

        [BindProperty]
        public List<MembersByDivision> MembersByDivisionList { get; set; }

        [BindProperty]
        public List<MembersByOccupation> MembersByOccupationList { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var membershipTypeList = await _context.MembershipType.ToListAsync();

            List<string> selectedYears = _context.MemberUser.Select(x => x.ApplicationreceivedDate.Value.Year.ToString()).Distinct().OrderBy(p => p).ToList();

            MembersByMembershipTypeList = new List<MembersByMembershipType>();
            MembersByYearList = new List<MembersByYear>();
            MembersByBranchList = new List<MembersByBranch>();
            MembersByOccupationList = new List<MembersByOccupation>();

            MembersByBranchList = await _context.MemberUser.Include(x => x.ClientBranch).GroupBy(info => info.ClientBranch.Name)
                       .Select(group => new MembersByBranch
                       {
                           Branch = group.Key==null?"unspeficied":group.Key,
                           Count = group.Count()
                       })
                       .OrderBy(x => x.Branch).ToListAsync();



            MembersByOccupationList = await _context.MemberUser.Include(x => x.Occupation).GroupBy(info => info.Occupation.Name)
                     .Select(group => new MembersByOccupation
                     {
                         Occupation = group.Key==null?"unspeficied":group.Key,
                         Count = group.Count()
                     })
                     .OrderBy(x => x.Occupation).ToListAsync();

            foreach (MembershipType membershipType in membershipTypeList)
            {
                MembersByMembershipType mc = new MembersByMembershipType();
                mc.TypeName = membershipType.Name;
                mc.TypeCount = _context.MemberUser.Where(x => x.MembershipTypeId == membershipType.Id).Count();
                MembersByMembershipTypeList.Add(mc);
            }

            foreach (string year in selectedYears)
            {
                MembersByYear my = new MembersByYear();
                my.Year = year;
                if (year == null) my.Year = "Pre-2014";
                my.Count = _context.MemberUser.Where(x => x.ApplicationreceivedDate.Value.Year.ToString() == year).Count();
                MembersByYearList.Add(my);
            }

            await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Accessed + EntityName, UserTypeValues.Staff);
            return Page();
        }


      



        

       


    }
}
