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
    public class PlanMasterModel : PageModel
    {
        private readonly ClientDbContext _context;
        private readonly ILogger<PlanMasterModel> _logger;
        private IActivity _activity;
        private string EntityName = "PlanMaster";

        public PlanMasterModel(ClientDbContext context, ILogger<PlanMasterModel> logger, IActivity activity)
        {
            _context = context;
            _activity = activity;
            _logger = logger;
        }


        [BindProperty]
        public PlanMaster PlanMaster { get; set; }

        [ViewData]
        public SelectList MemberShipTypeList { get; set; }

        [ViewData]
        public SelectList PaymentMethods { get; set; }

        [BindProperty]
        public List<MembershipType> MembershipTypeList { get; set; }

        [BindProperty]
        public List<PaymentSetting> PaymentMethodList { get; set; }

        private string errorMessage;

        // called first time the page is loaded.
        public IActionResult OnGet()
        {
            MembershipTypeList = _context.MembershipType.ToList();
            MemberShipTypeList = new SelectList(MembershipTypeList, nameof(MembershipType.Id), nameof(MembershipType.Name));

            PaymentMethodList = _context.PaymentSetting.ToList();
            PaymentMethods = new SelectList(PaymentMethodList, nameof(PaymentSetting.Id), nameof(PaymentSetting.Name));
            
            return Page();

        }

        // called to load and refresh grid
        public async Task<IActionResult> OnGetListAsync()
        {
           
            var PlanMasterList = _context.PlanMaster.Include(x => x.PaymentMethod).Include(x=>x.MembershipType).ToList();
            List <PlanMasterVM> PlanMasterVMList = new List<PlanMasterVM>();
            try
            {
                foreach (var planMaster in PlanMasterList)
                {
                    PlanMasterVM pmVM = new PlanMasterVM
                    {
                        Id = PlanMaster.Id,
                        Name = PlanMaster.Name,
                        Description = PlanMaster.Description,
                        MembershipTypeId = PlanMaster.MembershipType.Id,
                        MembershipTypeName = PlanMaster.MembershipType.Name,
                        IsLimited = PlanMaster.IsLimited,
                        LimitToMemberCount = PlanMaster.LimitToMemberCount,
                        ApplyTaxSettings = PlanMaster.ApplyTaxSettings,
                        PaymentMethodId = PlanMaster.PaymentMethod.Id,
                        PaymentMethodName = PlanMaster.PaymentMethod.Name,
                        CanPublicApply = PlanMaster.CanPublicApply,
                    };
                    PlanMasterVMList.Add(pmVM);
                }
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Accessed + EntityName, UserTypeValues.Staff);
                return new JsonResult(PlanMasterVMList);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            return new JsonResult(new { success = false, message = "Error. Please check values entered "+ errorMessage });
        }

        public async Task<IActionResult>  OnGetSelectedRecordAsync(int id)
        {
            return new JsonResult(await _context.PlanMaster.Where(x=>x.Id==id).FirstOrDefaultAsync());
        }
    
        public async Task<IActionResult> OnPostSaveAsync(PlanMaster PlanMaster)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new { success = false, message = "Error. Please check values entered" });
            }
            if (PlanMaster.Id > 0)
            {
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Updated + EntityName + " Name: " + PlanMaster.Name, UserTypeValues.Staff);
                _context.Attach(PlanMaster).State = EntityState.Modified;
            }
            else
            {
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Added + EntityName + " Name: " + PlanMaster.Name, UserTypeValues.Staff);
                _context.PlanMaster.Add(PlanMaster);
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

            PlanMaster = await _context.PlanMaster.FindAsync(id);

            if (PlanMaster != null)
            {
                _context.PlanMaster.Remove(PlanMaster);
                await _context.SaveChangesAsync();
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Deleted + EntityName + " Name: " + PlanMaster.Name, UserTypeValues.Staff);
                return new JsonResult(new { success = true, message = "Deleted successfully" });
            }
            return new JsonResult(new { success = false, message = "No such record found to delete" });

        }
    }
}
