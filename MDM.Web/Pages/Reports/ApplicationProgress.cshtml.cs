using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MM.ClientModels;
using WISA.Services;
using ClosedXML.Excel;
using ClosedXML.Utils;
using ClosedXML.Attributes;
using System.Data;
using System.IO;
using MM.Helper;
using Microsoft.Extensions.Logging;

namespace MM.Pages.Client
{
    [Authorize(Policy = MMPolicies.AllowSetUp)]
    public class ApplicationProgressModel : PageModel
    {
        private ClientDbContext _context;
        private readonly IAuthorizationService _authorizationService;
        private readonly ILogger<ApplicationProgressModel> _logger;
        private IActivity _activity;
        private string EntityName = "Application Progress";

        [BindProperty]
        public ExceptionReportVM ExceptionReportVM { get; set; }

        public ApplicationProgressModel(ClientDbContext context, IAuthorizationService authorizationService, ILogger<ApplicationProgressModel> logger, IActivity activity)
        {
            _context = context;
            _authorizationService = authorizationService;
            _activity = activity;
            _logger = logger;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            ExceptionReportVM = await new ExceptionReportVM(_context).GetExceptionReport();
            await _activity.AddAsync(User.GetUserId(), User.GetEmail(), MMMessages.Accessed + EntityName, UserTypeValues.Staff);
            return Page();
        }

        public async Task<FileContentResult> OnGetExportAsync()
        {


            string[] displayColumns = {"Full Name", "ID Number", "Membership Number", "Membership Grade", "Membership Type", "Membership Status", "Date Created","Application Received","Request 1 Date","Request 2 Date","Request 3 Date", "URL", "Number of Days","Rag Indicator","Member Id"};


            string[] columnsToRemove = { "URL"};

            ExceptionReportVM = await new ExceptionReportVM(_context).GetExceptionReport();
            List<ExceptionReportModel> lstexceptionReportModel = new List<ExceptionReportModel>();
            foreach (ExceptionReportModel reddata in ExceptionReportVM.RedRecords)
                lstexceptionReportModel.Add(reddata);
            foreach (ExceptionReportModel yellowdata in ExceptionReportVM.YellowRecords)
                lstexceptionReportModel.Add(yellowdata);
            foreach (ExceptionReportModel greendata in ExceptionReportVM.GreenRecords)
                lstexceptionReportModel.Add(greendata);

               
            return File(ExcelHelper.ExportExcel(lstexceptionReportModel, true, displayColumns, columnsToRemove, ""), GlobalVariables.ExcelFileContenttType, "Application Progress Report " + HelperMethods.GetDateStamp() + ".xlsx");


        }
   
}
}
