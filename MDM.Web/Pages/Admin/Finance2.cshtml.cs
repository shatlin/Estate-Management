using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MM.ClientModels;
using MM.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Web;
using WISA.Services;

namespace MM.Pages.Client.Admin
{
    [Authorize(Policy = MMPolicies.AllowSetUp)]
    public class Finance2Model : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private UserManager<ApplicationUser> _userManager;
        private readonly ILogger<Finance2Model> _logger;
        private IActivity _activity;
        private string EntityName = "Pastel Integration - Non Individual";
        private readonly IEmailCreator _emailCreator;
        private readonly ClientDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        public Finance2Model(
           SignInManager<ApplicationUser> signInManager,
            ILogger<Finance2Model> logger, IActivity activity, IWebHostEnvironment env, RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager,
             ClientDbContext context, IEmailCreator emailCreator, IConfiguration configuration)
        {
            _signInManager = signInManager;
            _logger = logger;
            _activity = activity;
            _roleManager = roleManager;
            _userManager = userManager;
            _emailCreator = emailCreator;
            _context = context;
            _env = env;
            _configuration = configuration;

        }

        public class Error
        {
            public int rowNum;
            public string membercode;
            public string balance;
            public string errorMessage;
        }

        [BindProperty]
        public List<Error> ErrorList { get; set; }

        [BindProperty]
        public Notification notification { get; set; }

        [BindProperty]
        public bool? ErrorInOperation { get; set; }

        [BindProperty]
        public IFormFile PastelFile { get; set; }



        public async Task<IActionResult> OnGetAsync(int? id = null)
        {
            ErrorInOperation = false;
            await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Accessed + EntityName, UserTypeValues.Staff);
            return Page();
        }

        public async Task<FileContentResult> OnGetExportAsync()
        {
            string[] displayColumns = { "Membership Number", "Account Balance" };
            string[] columnsToRemove = { };
            var Organizations = await _context.Organization.Include(x => x.MemberStatus).Where(x => x.MemberStatus.Name == "Active" || (x.AccountBalance != null && x.AccountBalance != 0)).Select(p => new { p.OrgMemberCode, AccountBalance = p.AccountBalance == null ? 0.00M : p.AccountBalance }).ToListAsync();

            notification = new Notification { message = "Account balances downloaded successfully", notificationtype = "success" };
            return File(ExcelHelper.ExportExcel(Organizations, false, displayColumns, columnsToRemove, ""), GlobalVariables.ExcelFileContenttType, "CRM NonIndividual Balances " + HelperMethods.GetDateStamp() + ".xlsx");

        }

        public async Task<FileContentResult> OnGetExportDetailAsync()
        {
            string[] displayColumns = { "Membership Number", "Account Balance","Status","Name" };
            string[] columnsToRemove = { };
            var Organizations = await _context.Organization.Include(x => x.MemberStatus).Where(x => x.MemberStatus.Name == "Active" || (x.AccountBalance != null && x.AccountBalance != 0)).Select(p => new { p.OrgMemberCode, AccountBalance = p.AccountBalance == null ? 0.00M : p.AccountBalance
                , Status = p.MemberStatus == null ? "" : p.MemberStatus.Name,
                Name = p.Name
            }).ToListAsync();

            notification = new Notification { message = "Account balances downloaded successfully", notificationtype = "success" };
            return File(ExcelHelper.ExportExcel(Organizations, false, displayColumns, columnsToRemove, ""), GlobalVariables.ExcelFileContenttType, "Detailed CRM NonIndividual Balances" + HelperMethods.GetDateStamp() + ".xlsx");

        }


        public async Task<IActionResult> OnPostAsync()
        {

            ErrorInOperation = false;
            UploadFile(PastelFile);

            ErrorList = new List<Error>();

            ExcelHelper excelHelper = new ExcelHelper();
            var Data = ExcelHelper.GetDataFromExcel(Path.Combine(_env.ContentRootPath + "\\" + _configuration["StoredFilesPath"], "Finance", "Finance2.xlsx"));
            string membercode = string.Empty;
            int i = 1;
            int errorcount = 0;
            int successcount=0;
            var organizations = await _context.Organization.ToListAsync();

            foreach (DataRow row in Data.Rows)
            {
                membercode = row["Membership Number"].ToString();
                if (string.IsNullOrEmpty(membercode))
                {
                    ErrorList.Add(new Error { rowNum=i,membercode=membercode,balance= row["Account Balance"].ToString(),errorMessage= "Membership Number is empty" });
                    _logger.LogInformation("Error while importing balances at row " + i + ".Membership Number was empty");
                    ErrorInOperation = true;
                    errorcount++;
                }
                else
                {
                    var organization = organizations.Where(x => x.OrgMemberCode == membercode).FirstOrDefault();
                    if (organization == null)
                    {
                        ErrorList.Add(new Error { rowNum = i, membercode = membercode, balance = row["Account Balance"].ToString(), errorMessage = "Could not find Member with Membership Number " + membercode });
                        _logger.LogInformation("Error while importing balances at row " + i + ".Could not find Member with Membership Number " + membercode);
                        errorcount++;
                    }
                    else
                    {
                        decimal? accountbalanceoftheCompany = null;
                        try
                        {
                            accountbalanceoftheCompany = Convert.ToDecimal(row["Account Balance"].ToString());
                        }
                        catch
                        {
                        }
                        if (accountbalanceoftheCompany == null)
                        {

                            ErrorList.Add(new Error { rowNum = i, membercode = membercode, balance = row["Account Balance"].ToString(), errorMessage = "Account Balance not in correct decimal format" });
                            _logger.LogInformation("Error while importing balances at row " + i + " Account Balance not in correct decimal format :" + row["Membership Number"].ToString());
                            errorcount++;
                        }
                        else
                        {
                            organization.AccountBalance=accountbalanceoftheCompany;
                            _context.Organization.Update(organization);
                            successcount++;
                        }

                    }
                }
                i++;
            }
            _context.SaveChanges();
            await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Updated + EntityName, UserTypeValues.Staff);
            if(errorcount>0)
            {
            notification = new Notification { message = "Errors during Upload ."+ successcount+" of "+ i+" balances updated successfully. "+errorcount +"Uploads failed ." , notificationtype = "danger" };
            }
            else
            {
                 notification = new Notification { message = i+" balances updated successfully.No errors in upload" , notificationtype = "success" };
            }

            return Page();
        }

        public async Task UploadFile(IFormFile file)
        {

            if (file.Length > 0)
            {
                var filePath = Path.Combine(_env.ContentRootPath + "\\" + _configuration["StoredFilesPath"], "Finance");
                if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);
                filePath = Path.Combine(filePath, "Finance2.xlsx");
                if (System.IO.File.Exists(filePath)) System.IO.File.Delete(filePath);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }

        }
    }
}

