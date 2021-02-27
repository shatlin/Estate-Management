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

namespace MDM.Pages
{
    public class IndexModel :  PageBase
    {

        public IndexModel(SignInManager<ApplicationUser> signInManager,ILogger<PageBase> logger,
            UserManager<ApplicationUser> userManager, DB db, IMemoryCache cache):base(signInManager,
            logger,userManager,db, cache)
        {
        }

        [BindProperty]
        public TaskItem taskItem { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
           SetViewData(PageNames.Home);

           ViewData[Lookups.priorities] = _cache.GetOrCreate(
           Lookups.priorities, c =>{ return new SelectList(_db.Priority.ToList(), nameof(Priority.Id), nameof(Priority.Name)); });

            ViewData[Lookups.categories] = _cache.GetOrCreate(
            Lookups.categories, c => { return new SelectList(_db.Category.ToList(), nameof(Category.Id), nameof(Category.Name)); });

            ViewData[Lookups.taskitemtypes] = _cache.GetOrCreate(
            Lookups.taskitemtypes, c => { return new SelectList(_db.TaskItemType.ToList(), nameof(TaskItemType.Id), nameof(TaskItemType.Name)); });

            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                return Page();
            }
             return LocalRedirect("/Account/Login");
        }

        public IActionResult OnPostAsync()
        {
           _db.Add(taskItem);
           _db.SaveChanges();
            SetViewData(PageNames.Home);
            return Page();
        }


    }
}
