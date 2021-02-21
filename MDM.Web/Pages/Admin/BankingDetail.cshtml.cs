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
using Microsoft.Extensions.Logging;
using MM.ClientModels;
using MM.Helper;
using Newtonsoft.Json;
using WISA.Services;

namespace MM.Pages.Client
{
    [Authorize(Policy = MMPolicies.AllowSetUp)]
    public class BankingDetailModel : PageModel
    {
        private readonly ClientDbContext _context;
        private readonly ILogger<BankingDetailModel> _logger;
        private IActivity _activity;
        private string EntityName = "Banking Detail";

        public BankingDetailModel(ClientDbContext context, ILogger<BankingDetailModel> logger, IActivity activity)
        {
            _context = context;
            _activity = activity;
            _logger = logger;
        }



        [BindProperty]
        public BankingDetail BankingDetail { get; set; }

        [ViewData]
        public SelectList AccountTypes { get; set; }

        [BindProperty]
        public List<AccountType> AccountTypeList { get; set; }
        
        private string errorMessage;

        // called first time the page is loaded.
        public IActionResult OnGet()
        {
            AccountTypeList = _context.AccountType.ToList();
            AccountTypes = new SelectList(AccountTypeList, nameof(AccountType.Id), nameof(AccountType.Name));
            return Page();
        }

        // called to load and refresh grid
        public async Task<IActionResult> OnGetListAsync()
        {
            var blist = _context.BankingDetail.Include(x=>x.AccountType).ToList();
            List <BankingDetailVM> bankingDetailVMList = new List<BankingDetailVM>();
           
            try
            {
                foreach (var bankingDetail in blist)
                {
                    BankingDetailVM bdVM = new BankingDetailVM
                    {
                        Id = bankingDetail.Id,
                        AccountName= bankingDetail.AccountName,
                        AccountTypeId = bankingDetail.AccountTypeId,
                        AccountTypeName = bankingDetail.AccountType.Name,
                        BankName = bankingDetail.BankName,
                        BranchName = bankingDetail.BranchName,
                        AccountNumber = bankingDetail.AccountNumber,
                        RoutingCode = bankingDetail.RoutingCode
                    };
                    bankingDetailVMList.Add(bdVM);
                }
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Accessed + EntityName, UserTypeValues.Staff);
                return new JsonResult(bankingDetailVMList);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            return new JsonResult(new { success = false, message = "Error. Please check values entered "+ errorMessage });
        }

        public async Task<IActionResult>  OnGetSelectedRecordAsync(int id)
        {
            return new JsonResult(await _context.BankingDetail.Where(x=>x.Id==id).FirstOrDefaultAsync());
        }
    
        public async Task<IActionResult> OnPostSaveAsync()
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new { success = false, message = "Error. Please check values entered" });
            }
            if (BankingDetail.Id > 0)
            {
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Updated + EntityName + " Name: " + BankingDetail.AccountName, UserTypeValues.Staff);
                _context.Attach(BankingDetail).State = EntityState.Modified;
            }
            else
            {
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Added + EntityName + " Name: " + BankingDetail.AccountName, UserTypeValues.Staff);
                _context.BankingDetail.Add(BankingDetail);
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

            BankingDetail = await _context.BankingDetail.FindAsync(id);

            if (BankingDetail != null)
            {
                _context.BankingDetail.Remove(BankingDetail);
                await _context.SaveChangesAsync();
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Deleted + EntityName + " Name: " + BankingDetail.AccountName, UserTypeValues.Staff);
                return new JsonResult(new { success = true, message = "Deleted successfully" });
            }
            return new JsonResult(new { success = false, message = "No such record found to delete" });

        }
    }
}
