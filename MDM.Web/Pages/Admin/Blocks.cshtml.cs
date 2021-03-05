using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MDM.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Mvc.Rendering;
using MDM.Helper;
using Microsoft.AspNetCore.Hosting;
using MDM.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace MDM.Pages.Admin
{
  
    public class BlockModel : PageBase
    {

        private readonly IAuthorizationService _authorizationService;

        public BlockModel(SignInManager<ApplicationUser> signInManager, ILogger<PageBase> logger, UserManager<ApplicationUser> userManager, DB db, IMemoryCache cache, IWebHostEnvironment env, IEmailCreator emailCreator, IConfiguration configuration, IActivity activity, IEmailRecipients emailRecipients, IAuthorizationService authorizationService) : base(signInManager, logger, userManager, db, cache, env, emailCreator, configuration, activity, emailRecipients)
        {
            _authorizationService = authorizationService;
            PageName = PageNames.BlockPage;
        }

        [BindProperty]
        public IList<Block> Blocks { get; set; }

        [BindProperty]
        public Block Block { get; set; }


        public async Task<IActionResult> OnGetAsync()
        {
            Blocks=await _db.Block.ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnGetListAsync()
        {

            return new JsonResult(await _db.Block.ToListAsync());
        }

        public async Task<IActionResult> OnGetSelectedRecordAsync(int id)
        {
            return new JsonResult(await _db.Block.Where(x => x.Id == id).FirstOrDefaultAsync());
        }

        public async Task<IActionResult> OnPostSaveAsync(Block Block)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new { success = false, message = MMMessages.Error_Please_check_values_entered });
            }
            var isAuthorized = await _authorizationService.AuthorizeAsync(User, MDMPolicies.AllowAdmin);

            if (!isAuthorized.Succeeded)
            {
                return new JsonResult(new { success = false, message = MMMessages.Authorization_failed });
            }

            if (Block.Id > 0)
            {

                _db.Attach(Block).State = EntityState.Modified;
            }
            else
            {

                _db.Block.Add(Block);
            }
            await _db.SaveChangesAsync();
            return new JsonResult(new { success = true, message = MMMessages.SavedSuccessfully });
        }

        public async Task<IActionResult> OnGetDeleteAsync(int? id)
        {
            var isAuthorized = await _authorizationService.AuthorizeAsync(User, MDMPolicies.AllowAdmin);

            if (!isAuthorized.Succeeded)
            {
                return new JsonResult(new { success = false, MMMessages.Authorization_failed });
            }
            if (id == null)
            {
                return new JsonResult(new { success = false, MMMessages.NoRecordToDelete });
            }
            Block = await _db.Block.FindAsync(id);

            if (Block != null)
            {
                _db.Block.Remove(Block);
                await _db.SaveChangesAsync();

                return new JsonResult(new { success = true, message = MMMessages.DeletedSuccessfully });
            }
            return new JsonResult(new { success = false, message = MMMessages.NoRecordToDelete });
        }
    }
}
