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
using Microsoft.AspNetCore.Http;
using System.IO;

namespace MDM.Pages
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class TrustAccountModel :  PageBase
    {

     
        public TrustAccountModel(SignInManager<ApplicationUser> signInManager,
         ILogger<PageBase> logger,
         UserManager<ApplicationUser> userManager, DB db, IMemoryCache cache, IWebHostEnvironment env, IEmailCreator emailCreator, IConfiguration configuration, IActivity activity, IEmailRecipients emailRecipients) : base(signInManager,
          logger, userManager, db, cache, env, emailCreator, configuration, activity, emailRecipients)
        {
            PageName = "Trust Account";
        }

      
        [BindProperty]
        public List<IFormFile> RelatedFiles { get; set; }

        public void GetLookups()
        {
         
        }

        public IActionResult OnGet()
        {
                return Page();
        }

        public async Task<IActionResult> OnGetListAsync()
        {
         List<TrustAccount> TrustAccounts;
        TrustAccounts = await _db.TrustAccount.OrderBy(c => c.Month).ThenBy(c => c.Id).ToListAsync();
            TrustAccounts[0].runningtotal= TrustAccounts[0].amount;

            for (int i = 1; i < TrustAccounts.Count(); i++)
            {
                TrustAccounts[i].runningtotal= TrustAccounts[i].amount +TrustAccounts[i-1].runningtotal;
            }
            return new JsonResult(TrustAccounts);
        }

        //public async Task<IActionResult> OnPostAsync()
        //{
           
        //    return Page();
        //}

      
        //public async Task<IActionResult> OnPostSave()
        //{
            
        //    return new JsonResult(new { success = true, message = MMMessages.SavedSuccessfully });
        //}

        public async Task<IActionResult> OnPostUploadAllFiles()
        {
            var files = Request.Form.Files;
            string id=string.Empty;
            foreach (var key in Request.Form.Keys)
            {
                if (key.Contains("id"))
                {
                    id = Request.Form["id"].ToString();
                }
            }

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    string file = string.Empty;
                    if (formFile.FileName.Length > 150)
                    {
                        file = formFile.FileName.Substring(formFile.FileName.Length - (formFile.FileName.Length - 150));
                    }
                    else
                    {
                        file = formFile.FileName;
                    }

                    var filePath = Path.Combine(_env.ContentRootPath + _configuration["StoredFilesPath"],"invoices", id);
                    if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);
                    filePath = Path.Combine(filePath, file);

                    if (System.IO.File.Exists(filePath)) System.IO.File.Delete(filePath);
                    var filepathToStore = Path.Combine("invoices", id, file);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);

                     
                            TrustAccountInvoiceFiles invoiceFiles = new TrustAccountInvoiceFiles();
                            invoiceFiles.TrustAccountId=Convert.ToInt32(id);
                            invoiceFiles.FilePath = filepathToStore;
                            invoiceFiles.FileName = file;
                            invoiceFiles.FileTypeId = FileTypevalues.Invoice;
                         
                            await _db.TrustAccountInvoiceFiles.AddAsync(invoiceFiles);
                       
                    }
                }
            }
            await _db.SaveChangesAsync();
            return new JsonResult(new { success = true, message = "Upload successful" });
        }

        public async Task<IActionResult> OnPostGetImages()
        {
           
            int id = 0;
            List<string> ss=new List<string>();
            foreach (var key in Request.Form.Keys)
            {
                if (key.Contains("id"))
                {
                    id = Convert.ToInt32(Request.Form["id"]);
                }
            }

            var sss = _db.TrustAccountInvoiceFiles.Where(x => x.TrustAccountId == id).Select(x => x.FilePath);
            foreach (var str in sss)
            {
                ss.Add(str);
            }
            return new JsonResult(ss);
            
        }

    }
}
