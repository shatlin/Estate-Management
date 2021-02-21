using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MM.ClientModels;
using Newtonsoft.Json;
using WISA.Services;

namespace MM.Pages.Client
{
    [Authorize(Policy = MMPolicies.AllowMemberAccess)]
    public class MemberBankingDetailModel : PageModel
    {
        private readonly ClientDbContext _context;

        public MemberBankingDetailModel(ClientDbContext context)
        {
            _context = context;
        }



        [BindProperty]
        public MemberBankingDetail MemberBankingDetail { get; set; }


        [ViewData]
        public List<SelectListItem> Members { get; set; }

        [ViewData]
        public SelectList AccountTypes { get; set; }

        [BindProperty]
        public List<MemberUser> MembersList { get; set; }

        [BindProperty]
        public List<AccountType> AccountTypeList { get; set; }

        private string errorMessage;

        // called first time the page is loaded.
        public IActionResult OnGet()
        {
            MembersList = _context.MemberUser.Include(x=>x.ApplicationUser).ToList();

            Members = new List<SelectListItem>();

            foreach (var memberUser in MembersList)
            {
                Members.Add(new SelectListItem
                {
                    Value = memberUser.Id.ToString(),
                    Text = memberUser.ApplicationUser.FirstName
                });
            }

            AccountTypeList = _context.AccountType.ToList();
            AccountTypes = new SelectList(AccountTypeList, nameof(AccountType.Id), nameof(AccountType.Name));
            return Page();
        }

        // called to load and refresh grid
        public IActionResult OnGetList()
        {
            var mblist = _context.MemberBankingDetail.Include(x => x.Member.ApplicationUser).Include(x=>x.AccountType).ToList();
            List <MemberBankingDetailVM> MemberBankingDetailVMList = new List<MemberBankingDetailVM>();
           
            try
            {
                foreach (var MemberBankingDetail in mblist)
                {
                    MemberBankingDetailVM bdVM = new MemberBankingDetailVM
                    {
                        Id = MemberBankingDetail.Id,
                        MemberFirstName= MemberBankingDetail.Member.ApplicationUser.FirstName,
                        MemberLastName = MemberBankingDetail.Member.ApplicationUser.LastName,
                        AccountTypeId = MemberBankingDetail.AccountType.Id,
                        AccountTypeName = MemberBankingDetail.AccountType.Name,
                        BankName = MemberBankingDetail.BankName,
                        BranchName = MemberBankingDetail.BranchName,
                        AccountNumber = MemberBankingDetail.AccountNumber,
                        RoutingCode = MemberBankingDetail.RoutingCode
                    };
                    MemberBankingDetailVMList.Add(bdVM);
                }
                return new JsonResult(MemberBankingDetailVMList);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            return new JsonResult(new { success = false, message = "Error. Please check values entered "+ errorMessage });
        }

        public async Task<IActionResult>  OnGetSelectedRecordAsync(int id)
        {
            return new JsonResult(await _context.MemberBankingDetail.Where(x=>x.Id==id).FirstOrDefaultAsync());
        }
    
        public async Task<IActionResult> OnPostSaveAsync(MemberBankingDetail MemberBankingDetail)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new { success = false, message = "Error. Please check values entered" });
            }
            if (MemberBankingDetail.Id > 0)
            {
                _context.Attach(MemberBankingDetail).State = EntityState.Modified;
            }
            else
            {
                _context.MemberBankingDetail.Add(MemberBankingDetail);
            }
             await _context.SaveChangesAsync();
            return new JsonResult( new { success = true, message = "Saved successfully" });
        }

         public async Task<IActionResult> OnGetDeleteAsync(int? id)
        {

            if (id == null)
            {
                return new JsonResult(new { success = false, message = "No such record found to delete" });
            }

            MemberBankingDetail = await _context.MemberBankingDetail.FindAsync(id);

            if (MemberBankingDetail != null)
            {
                _context.MemberBankingDetail.Remove(MemberBankingDetail);
                await _context.SaveChangesAsync();
                return new JsonResult(new { success = true, message = "Deleted successfully" });
            }
            return new JsonResult(new { success = false, message = "No such record found to delete" });

        }
    }
}
