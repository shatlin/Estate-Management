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
    public class PromotionDetailModel : PageModel
    {
        private readonly ClientDbContext _context;
        private readonly ILogger<PromotionDetailModel> _logger;
        private IActivity _activity;
        private string EntityName = "PromotionDetail";

        public PromotionDetailModel(ClientDbContext context, ILogger<PromotionDetailModel> logger, IActivity activity)
        {
            _context = context;
            _activity = activity;
            _logger = logger;
        }



        [BindProperty]
        public PromotionDetail PromotionDetail { get; set; }

        [ViewData]
        public SelectList Promotions { get; set; }

        [ViewData]
        public SelectList Types { get; set; }

        [ViewData]
        public SelectList Levels { get; set; }

        [BindProperty]
        public List<PromotionMaster> PromotionList { get; set; }

        [BindProperty]
        public List<MemberShipGrade> TypeList { get; set; }

        [BindProperty]
        public List<MemberLevel> LevelList { get; set; }

        private string errorMessage;

        // called first time the page is loaded.
        public IActionResult OnGet()
        {
            PromotionList = _context.PromotionMaster.ToList();
            Promotions = new SelectList(PromotionList, nameof(PromotionMaster.Id), nameof(PromotionMaster.Name));

            TypeList = _context.MembershipGrade.ToList();
            Types = new SelectList(TypeList, nameof(MemberShipGrade.Id), nameof(MemberShipGrade.Name));

            LevelList = _context.MemberLevel.ToList();
            Levels = new SelectList(LevelList, nameof(MemberLevel.Id), nameof(MemberLevel.Name));
            return Page();
        }

        // called to load and refresh grid
        public async Task<IActionResult> OnGetListAsync()
        {
            var pdlist = _context.PromotionDetail.Include(x => x.PromotionMaster).Include(x=>x.MembershipGrade).Include(x => x.MemberLevel).ToList();
            List <PromotionDetailVM> PromotionDetailVMList = new List<PromotionDetailVM>();
           
            try
            {
                foreach (var promotionDetail in pdlist)
                {
                    PromotionDetailVM pdVM = new PromotionDetailVM
                    {
                        Id = PromotionDetail.Id,
                        PromotionMasterId= PromotionDetail.PromotionMaster.Id,
                        PromotionMasterName = PromotionDetail.PromotionMaster.Name,
                        MembershipGradeId = PromotionDetail.MembershipGrade.Id,
                        MembershipGradeName = PromotionDetail.MembershipGrade.Name,
                        MemberLevelId = PromotionDetail.MemberLevel.Id,
                        MemberLevelName = PromotionDetail.MemberLevel.Name,
                        DiscountPercentage = PromotionDetail.DiscountPercentage
   
                    };
                    PromotionDetailVMList.Add(pdVM);
                }
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Accessed + EntityName, UserTypeValues.Staff);
                return new JsonResult(PromotionDetailVMList);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            return new JsonResult(new { success = false, message = "Error. Please check values entered "+ errorMessage });
        }

        public async Task<IActionResult>  OnGetSelectedRecordAsync(int id)
        {
            return new JsonResult(await _context.PromotionDetail.Where(x=>x.Id==id).FirstOrDefaultAsync());
        }
    
        public async Task<IActionResult> OnPostSaveAsync(PromotionDetail PromotionDetail)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new { success = false, message = "Error. Please check values entered" });
            }
            if (PromotionDetail.Id > 0)
            {
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Updated + EntityName + " Name: " + PromotionDetail.PromotionMaster.Name, UserTypeValues.Staff);
                _context.Attach(PromotionDetail).State = EntityState.Modified;
            }
            else
            {
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Added + EntityName + " Name: " + PromotionDetail.PromotionMaster.Name, UserTypeValues.Staff);
                _context.PromotionDetail.Add(PromotionDetail);
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

            PromotionDetail = await _context.PromotionDetail.FindAsync(id);

            if (PromotionDetail != null)
            {
                _context.PromotionDetail.Remove(PromotionDetail);
                await _context.SaveChangesAsync();
                await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Deleted + EntityName + " Name: " + PromotionDetail.PromotionMaster.Name, UserTypeValues.Staff);
                return new JsonResult(new { success = true, message = "Deleted successfully" });
            }
            return new JsonResult(new { success = false, message = "No such record found to delete" });

        }
    }
}
