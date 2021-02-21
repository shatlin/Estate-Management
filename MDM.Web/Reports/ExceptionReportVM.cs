using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MM.ClientModels;
using MM.Helper;
using MM.Pages.Client;
using Newtonsoft.Json;

namespace MM.ClientModels
{
    public class ExceptionReportVM
    {
        public List<ExceptionReportModel> RedRecords { get; set; }
        public List<ExceptionReportModel> YellowRecords { get; set; }
        public List<ExceptionReportModel> GreenRecords { get; set; }

        private readonly ClientDbContext _context;
        private readonly ILogger<ExceptionReportVM> _logger;
        private ClientDbContext context;
      

        public ExceptionReportVM(ClientDbContext context)
        {
            _context = context;
           
        }

  

        public ExceptionReportVM GetExceptionReportCore()
        {
            ExceptionReportVM exceptionReport = new ExceptionReportVM(_context);
            int differenceInDays = 0;
            DateTime today = DateTime.Now;

            exceptionReport.RedRecords = new List<ExceptionReportModel>();
            exceptionReport.YellowRecords = new List<ExceptionReportModel>();
            exceptionReport.GreenRecords = new List<ExceptionReportModel>();

            var applicantsList = _context.MemberUser.
                Include(x => x.MemberStatus).
                Include(x => x.MembershipGrade).
                  Include(x => x.MembershipType).
                Include(x => x.ApplicationUser).
                Where(x => x.MemberStatus.Name == "Applicant").ToList();

            int i=0;
            int memberid=0;
            foreach (var entity in applicantsList)
            {
                i++;
                try
                {
                    ExceptionReportModel exceptionReportModel = new ExceptionReportModel();
                    exceptionReportModel.MemberId = entity.Id;
                    memberid=entity.Id;
                    exceptionReportModel.URL = @"/Manage/Individual/?id=" + entity.Id;
                    exceptionReportModel.FullName = entity.ApplicationUser == null ? null : entity.ApplicationUser.FullName;
                    exceptionReportModel.IDNumber = entity.IDNumber;
                    exceptionReportModel.MembershipNumber = entity.MemberCode;
                    exceptionReportModel.MembershipGrade = entity.MembershipGrade == null ? null : entity.MembershipGrade.Name;
                    exceptionReportModel.MembershipType = entity.MembershipType == null ? null : entity.MembershipType.Name;
                    exceptionReportModel.MembershipStatus = entity.MemberStatus == null ? null : entity.MemberStatus.Name;
                    exceptionReportModel.DateApplicationReceived = entity.ApplicationreceivedDate == null ? null : entity.ApplicationreceivedDate.GetFormattedDate();
                    exceptionReportModel.PaymentReminder1Date = entity.PaymentReminder1Date == null ? null : entity.PaymentReminder1Date.GetFormattedDate();
                    exceptionReportModel.PaymentReminder2Date = entity.PaymentReminder2Date == null ? null : entity.PaymentReminder2Date.GetFormattedDate();
                    exceptionReportModel.PaymentReminder3Date = entity.PaymentReminder3Date == null ? null : entity.PaymentReminder3Date.GetFormattedDate();
                    exceptionReportModel.CreatedOn = entity.CreatedOn == null ? null : entity.CreatedOn.GetFormattedDate();

                    if (exceptionReportModel.DateApplicationReceived != null)
                    {
                        if (exceptionReportModel.DateApplicationReceived.Trim().Length > 0)
                        {
                            differenceInDays = (today - Convert.ToDateTime(exceptionReportModel.DateApplicationReceived)).Days;
                        }
                        else
                        {
                            differenceInDays = 0;
                        }
                    }
                    else
                    {
                        differenceInDays = 0;
                    }

                    exceptionReportModel.NumberofDays = differenceInDays;

                    if (differenceInDays >= 0 && differenceInDays < 15)
                    {
                        exceptionReportModel.RagInd = "Green";
                        exceptionReport.GreenRecords.Add(exceptionReportModel);
                    }
                    else if (differenceInDays >= 15 && differenceInDays < 37)
                    {
                        exceptionReportModel.RagInd = "Amber";
                        exceptionReport.YellowRecords.Add(exceptionReportModel);
                    }
                    else if (differenceInDays >= 37)
                    {
                        exceptionReportModel.RagInd = "Red";
                        exceptionReport.RedRecords.Add(exceptionReportModel);
                    }
                    else
                    {
                        exceptionReportModel.RagInd = "Red";
                        exceptionReport.RedRecords.Add(exceptionReportModel);
                    }
                }
                catch (Exception ex)
                {

                    _logger.LogError("Exception Occured at Record "+ i + ": Member Id "+memberid );
                }
            }
            exceptionReport.RedRecords = exceptionReport.RedRecords.OrderByDescending(p => p.NumberofDays).ToList();
            exceptionReport.YellowRecords = exceptionReport.YellowRecords.OrderByDescending(p => p.NumberofDays).ToList();
            exceptionReport.GreenRecords = exceptionReport.GreenRecords.OrderByDescending(p => p.NumberofDays).ToList();
            return exceptionReport;
        }

        public async Task<ExceptionReportVM> GetExceptionReport()
        {
            return GetExceptionReportCore();
        }
    }


}