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
          
            var a = await _db.InvoiceFiles.Select(n=>new{n.TrustAccountId,n.Notes }).ToListAsync();
            List<TrustAccount> data= await _db.TrustAccount.OrderBy(c => c.Month).ThenBy(c => c.Id).ToListAsync();
      
            data[0].runningtotal= data[0].amount;

            for (int i = 0; i < data.Count(); i++)
            {
                if(i>0)
                { 
                data[i].runningtotal= data[i].amount +data[i-1].runningtotal;
                }
                var elements = a.Where(s => s.TrustAccountId == data[i].Id);
                if (elements != null && elements.Count() > 0)
                {
                    data[i].InvoicesAdded = "Yes";
                }
                else
                {
                    data[i].InvoicesAdded = "No";
                }
               
            }
            return new JsonResult(data);
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
                   // filePath = Path.Combine(_env.ContentRootPath + "\\wwwroot" + "\\images" + "\\profile\\");
                    var filePath = Path.Combine(_env.ContentRootPath ,"wwwroot", "invoices", id);
                    if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);
                    filePath = Path.Combine(filePath, file);

                    if (System.IO.File.Exists(filePath)) System.IO.File.Delete(filePath);
                    var filepathToStore = Path.Combine("invoices", id, file);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);

                     
                            InvoiceFiles invoiceFiles = new InvoiceFiles();
                            invoiceFiles.TrustAccountId=Convert.ToInt32(id);
                            invoiceFiles.FilePath = filepathToStore;
                            invoiceFiles.FileName = file;
                            invoiceFiles.FileTypeId = FileTypevalues.Invoice;
                         
                            await _db.InvoiceFiles.AddAsync(invoiceFiles);
                       
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

            var sss = _db.InvoiceFiles.Where(x => x.TrustAccountId == id).Select(x => x.FilePath);
            foreach (var str in sss)
            {
                ss.Add(str);
            }
            return new JsonResult(ss);
            
        }

    }
}
