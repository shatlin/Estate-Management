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
using WISA.Services;

namespace WISA.Pages.Manage
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
        public Address PhysicalAddress { get; set; }

        [BindProperty]
        public Address PostalAddress { get; set; }


        //New Classes

        public class MemberDivision
        {
            public bool IsSelected { get; set; }
            public int Id { get; set; }
            public string Name { get; set; }
        }

        [BindProperty]
        public List<MemberDivision> MemberDivisionList { get; set; }

        public async Task GetAllDivisionsAsync(int? memberid)
        {
            var selectedMemberDivisionList = await _context.DivisionMemberXref.Where(x => x.MemberId == memberid).ToListAsync();
            MemberDivisionList = new List<MemberDivision>();
            var allDivisions = _context.Division.ToList();
            foreach (var Division in allDivisions)
            {
                var found = false;
                foreach (var selectedDivision in selectedMemberDivisionList)
                {
                    if (Division.Id == selectedDivision.DivisonId)
                    {
                        MemberDivisionList.Add(new MemberDivision { IsSelected = true, Id = selectedDivision.Id, Name = Division.Name });
                        found = true;
                    }
                }
                if (found == false)
                {
                    MemberDivisionList.Add(new MemberDivision { IsSelected = false, Id = Division.Id, Name = Division.Name });
                }

            }

        }

        public class MemberAffliation
        {
            public bool IsSelected { get; set; }
            public int? Id { get; set; }
            public string Name { get; set; }
            public string MemberSpecificAffliationName { get; set; }
            public string MemberNumber { get; set; }
        }

        [BindProperty]
        public List<MemberAffliation> MemberAffliationList { get; set; }

        public async Task GetAllAffliationsAsync(int? memberid)
        {
            var selectedMemberAffliationList = await _context.MemberAffliationXref.Where(x => x.MemberId == memberid).ToListAsync();
            MemberAffliationList = new List<MemberAffliation>();
            var allAffliations = _context.Affliation.ToList();
            foreach (var Affliation in allAffliations)

            {
                var found = false;
                foreach (var selectedAffliation in selectedMemberAffliationList)
                {
                    if (Affliation.Id == selectedAffliation.AffliationId)
                    {
                        MemberAffliationList.Add(new MemberAffliation { IsSelected = true, Id = selectedAffliation.Id, Name = Affliation.Name, MemberSpecificAffliationName = selectedAffliation.MemberSpecificAffliationName, MemberNumber = selectedAffliation.MemberNumber });
                        found = true;
                    }
                }
                if (found == false)
                {
                    MemberAffliationList.Add(new MemberAffliation { IsSelected = false, Id = Affliation.Id, Name = Affliation.Name, MemberSpecificAffliationName = string.Empty, MemberNumber = string.Empty });
                }

            }

        }


        public class MemberDisability
        {
            public bool IsSelected { get; set; }
            public int? Id { get; set; }
            public string Name { get; set; }
            public int? DisabilityLevelId { get; set; }
        }

        [BindProperty]
        public List<MemberDisability> MemberDisabilityList { get; set; }

        [BindProperty]
        public List<IFormFile> IDDocuments { get; set; }

        [BindProperty]
        public List<IFormFile> Certificates { get; set; }

        [BindProperty]
        public List<IFormFile> ProofofDWS { get; set; }

        [BindProperty]
        public List<IFormFile> ProofOfReg { get; set; }

        [BindProperty]
        public List<IFormFile> ProofOfPayment { get; set; }


        public async Task GetAllDisabilitiesAsync(int? memberid)
        {
            var selectedMemberDisabilityList = await _context.DisabilityMemberXref.Where(x => x.MemberId == memberid).ToListAsync();
            MemberDisabilityList = new List<MemberDisability>();
            var allDisabilities = _context.Disability.ToList();
            foreach (var Disability in allDisabilities)

            {
                var found = false;
                foreach (var selectedDisability in selectedMemberDisabilityList)
                {
                    if (Disability.Id == selectedDisability.DisabilityId)
                    {
                        MemberDisabilityList.Add(new MemberDisability { IsSelected = true, Id = Disability.Id, Name = Disability.Name, DisabilityLevelId = selectedDisability.DisabilityLevelId });
                        found = true;
                    }
                }
                if (found == false)
                {
                    MemberDisabilityList.Add(new MemberDisability { IsSelected = false, Id = Disability.Id, Name = Disability.Name, DisabilityLevelId = 0 });
                }

            }

        }


        public class MemberInvolvement
        {
            public bool IsSelected { get; set; }
            public int Id { get; set; }
            public string Name { get; set; }
        }

        [BindProperty]
        public List<MemberInvolvement> MemberInvolvementList { get; set; }

        public async Task GetAllInvolvementsAsync(int? memberid)
        {
            var selectedMemberInvolvementList = await _context.InvolvementMemberXref.Where(x => x.MemberId == memberid).ToListAsync();
            MemberInvolvementList = new List<MemberInvolvement>();
            var allInvolvements = _context.Involvement.ToList();
            foreach (var Involvement in allInvolvements)
            {
                var found = false;
                foreach (var selectedInvolvement in selectedMemberInvolvementList)
                {
                    if (Involvement.Id == selectedInvolvement.InvolvementId)
                    {
                        MemberInvolvementList.Add(new MemberInvolvement { IsSelected = true, Id = Involvement.Id, Name = Involvement.Name });
                        found = true;
                    }
                }
                if (found == false)
                {
                    MemberInvolvementList.Add(new MemberInvolvement { IsSelected = false, Id = Involvement.Id, Name = Involvement.Name });
                }
            }

        }

        [BindProperty]
        public List<MemberQualificationXref> MemberQualificationList { get; set; }

        [BindProperty]
        public List<EmploymentMemberXref> MemberEmploymentList { get; set; }

        [BindProperty]
        public List<MemberFileXref> MemberFileList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {

            ViewData["ApplicaitonUserId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["ClientBranchId"] = new SelectList(_context.ClientBranch, "Id", "Name");
            ViewData["TitleId"] = new SelectList(_context.Title, "Id", "Name");
            ViewData["EthnicityId"] = new SelectList(_context.Ethnicity, "Id", "Name");
            ViewData["HighestQualitificationId"] = new SelectList(_context.Qualification, "Id", "Name");
            ViewData["HomeLanguageId"] = new SelectList(_context.Language, "Id", "Name");
            ViewData["ClientBranchId"] = new SelectList(_context.ClientBranch, "Id", "Name");
            ViewData["MembershipTypeId"] = new SelectList(_context.MembershipType, "Id", "Name");
            ViewData["MemberLevelId"] = new SelectList(_context.MemberLevel, "Id", "Name");
            ViewData["MemberStatusId"] = new SelectList(_context.MemberStatus, "Id", "Name");
            ViewData["MemberTeamId"] = new SelectList(_context.MemberTeam, "Id", "Name");
            ViewData["MembershipTypeId"] = new SelectList(_context.MembershipGrade, "Id", "Name");
            //  ViewData["NationalityId"] = new SelectList(_context.Nationality, "Id", "Name");
            ViewData["OccupationId"] = new SelectList(_context.Occupation, "Id", "Name");
            ViewData["OrganizationId"] = new SelectList(_context.Organization, "Id", "Name");
            ViewData["OrganizationStructureId"] = new SelectList(_context.OrganizationStructure, "Id", "Name");
            ViewData["OwnerClientUserId"] = new SelectList(_context.ClientUser, "Id", "ApplicaitonUserId");
            ViewData["PreferredAppointmentTimeId"] = new SelectList(_context.PreferredContactTime, "Id", "Name");
            ViewData["ReferralTypeId"] = new SelectList(_context.ReferralType, "Id", "Name");
            ViewData["TransactionCurrencyid"] = new SelectList(_context.Currency, "Id", "Name");
            ViewData["VolunteerWorkHoursId"] = new SelectList(_context.VolunteerHours, "Id", "Name");
            ViewData["GenderId"] = new SelectList(_context.Gender, "Id", "Name");
            ViewData["YesNoList"] = new SelectList(new YesNoLookup().YesNoList(), nameof(YesNoLookup.Id), nameof(YesNoLookup.Name));
            ViewData["QualificationCategoryId"] = new SelectList(_context.QualificationCategory.ToList(), nameof(QualificationCategory.Id), nameof(QualificationCategory.Name));
            ViewData["QualificationTypeId"] = new SelectList(_context.QualificationType.ToList(), nameof(QualificationType.Id), nameof(QualificationType.Name));
            ViewData["EnrolmentCategoryId"] = new SelectList(_context.QualificationEnrolmentCategory.ToList(), nameof(QualificationEnrolmentCategory.Id), nameof(QualificationEnrolmentCategory.Name));
            ViewData["EmploymentCategoryId"] = new SelectList(_context.EmploymentCategory.ToList(), nameof(EmploymentCategory.Id), nameof(EmploymentCategory.Name));
            ViewData["ProvinceId"] = new SelectList(_context.State.ToList(), nameof(State.Id), nameof(State.Name));
            ViewData["DisabilityLevelId"] = new SelectList(_context.DisabilityLevel.ToList(), nameof(DisabilityLevel.Id), nameof(DisabilityLevel.Name));
            ViewData["FileTypeId"] = new SelectList(_context.FileType.ToList(), nameof(FileType.Id), nameof(FileType.Name));
            ViewData["CountryId"] = new SelectList(_context.Country.ToList(), nameof(Country.Id), nameof(Country.Name));

            if (id == null)
            {
                return Page();
            }

            MemberQualificationList = await _context.MemberQualificationXref.Include(m => m.QualificationType).Where(x => x.MemberId == id).ToListAsync();
            MemberEmploymentList = await _context.EmploymentMemberXref.Include(m => m.EmploymentCategory).Where(x => x.MemberUserId == id).ToListAsync();
            MemberFileList = await _context.MemberFileXref.Include(m => m.FileType).Where(x => x.RelatedEntityId == id && x.RelatedToId == (int)RelatedToEnum.Member ).ToListAsync();
            PhysicalAddress = _context.Address.Where(x => x.RelatedEntityId == id && x.RelatedToId == (int)RelatedToEnum.Member && x.AddressTypeId == 2).FirstOrDefault();
            PostalAddress = _context.Address.Where(x => x.RelatedEntityId == id && x.RelatedToId == (int)RelatedToEnum.Member && x.AddressTypeId == 1).FirstOrDefault();

            await GetAllDivisionsAsync(id);
            await GetAllAffliationsAsync(id);
            await GetAllDisabilitiesAsync(id);
            await GetAllInvolvementsAsync(id);

            MemberUser = await _context.MemberUser
                .Include(m => m.ApplicationUser)
                .Include(m => m.ApplicationUser.Gender)
                .Include(m => m.ApplicationUser.Title)
                .Include(m => m.ClientBranch)
                .Include(m => m.Ethnicity)
                .Include(m => m.HighestQualitification)
                .Include(m => m.HomeLanguage)
                .Include(m => m.MemberBranch)
                .Include(m => m.MembershipType)
                .Include(m => m.MemberLevel)
                .Include(m => m.MemberStatus)
                .Include(m => m.MemberTeam)
                .Include(m => m.MembershipGrade)
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


            return Page();
        }
    }
}