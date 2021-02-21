using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MM.ClientModels;
namespace WISA.Services
{

    public class MMDailySchedulerService : IHostedService, IDisposable
    {

        private readonly ILogger<MMDailySchedulerService> _logger;
        private readonly IConfiguration _configuration;
        private Timer _timer;
        TimeSpan ScheduledTimespan;

        private readonly IEmailCreator _emailCreator;
       

        public MMDailySchedulerService(ILogger<MMDailySchedulerService> logger, IConfiguration configuration,
            IEmailCreator emailCreator)
        {
            _logger = logger;
            _configuration = configuration;
            _emailCreator = emailCreator;
           
        }


        //     private readonly ILogger<MMDailySchedulerService> _logger;
        //private readonly IConfiguration _configuration;
        //private Timer _timer;
        //TimeSpan ScheduledTimespan;
        //  private readonly UserManager<ApplicationUser> _userManager;
        //  private readonly ClientDbContext _context;
        //private readonly IEmailCreator _emailCreator;


        //public MMDailySchedulerService(ILogger<MMDailySchedulerService> logger, IConfiguration configuration,
        //    IEmailCreator emailCreator,UserManager<ApplicationUser> userManager,  ClientDbContext context)
        //{
        //    _logger = logger;
        //    _configuration = configuration;
        //    _emailCreator = emailCreator;
        //        _userManager = userManager;
        //    _context = context;
        //}

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Daily Scheduler Service running.");

            TimeSpan TimeOftheDay = TimeSpan.Parse(DateTime.Now.TimeOfDay.ToString("hh\\:mm"));
            string[] formats = { @"hh\:mm\:ss", "hh\\:mm" };
            string strTime = _configuration["Timer:StartTime"].ToString();

            var success = TimeSpan.TryParseExact(strTime, formats, CultureInfo.InvariantCulture, out ScheduledTimespan);
            TimeSpan delayTime = ScheduledTimespan >= TimeOftheDay
                                    ? ScheduledTimespan - TimeOftheDay    // When Scheduled Time for that day is not passed
                                    : new TimeSpan(24, 0, 0) - TimeOftheDay + ScheduledTimespan; // Passed - then Run Next day

            _timer = new Timer(DoWork, null, delayTime, new TimeSpan(24, 0, 0));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            SendEmailRemiders();
        }

        public void SendEmailRemiders()
        {
            ClientDbContext _context = new ClientDbContext();

            ExceptionReportVM exceptionReportVM = new ExceptionReportVM(_context).GetExceptionReportCore();

            string emailaddresses = string.Empty;

            #region send reminders
            foreach (var greenApplicants in exceptionReportVM.GreenRecords)
            {
                if (!string.IsNullOrEmpty(greenApplicants.DateApplicationReceived))
                {
                    if (string.IsNullOrEmpty(greenApplicants.PaymentReminder1Date))
                    {
                        if (greenApplicants.NumberofDays >= 7)
                        {
                            MemberUser memberUser = _context.MemberUser.Include(x => x.ApplicationUser).Where(x => x.Id == greenApplicants.MemberId).FirstOrDefault();
                            memberUser.FirstReminderSent = true;
                            memberUser.PaymentReminder1Date = DateTime.Now;
                            _context.Attach(memberUser).State = EntityState.Modified;
                            emailaddresses = EmailRecipients.GetEmailSenderList("FirstReminder", null, memberUser.Email, (int)RelatedToEnum.Member, memberUser.Id);
                            _emailCreator.SendEmailAsync("FirstReminder", emailaddresses, memberUser.ApplicationUser.FullName, "Reminder For Documents / Payment", null, null);
                            _context.SaveChanges();
                            Thread.Sleep(1000);
                        }
                    }
                }
            }

            foreach (var yellowApplicants in exceptionReportVM.YellowRecords)
            {
                if (!string.IsNullOrEmpty(yellowApplicants.DateApplicationReceived))
                {
                    if (string.IsNullOrEmpty(yellowApplicants.PaymentReminder2Date))
                    {
                        if (yellowApplicants.NumberofDays >= 15)
                        {
                            MemberUser memberUser = _context.MemberUser.Where(x => x.Id == yellowApplicants.MemberId).FirstOrDefault();
                            memberUser.SecondReminderSent = true;
                            memberUser.PaymentReminder2Date = DateTime.Now;
                            _context.Attach(memberUser).State = EntityState.Modified;
                            emailaddresses = EmailRecipients.GetEmailSenderList("SecondReminder", null, memberUser.Email, (int)RelatedToEnum.Member, memberUser.Id);
                            _emailCreator.SendEmailAsync("SecondReminder", emailaddresses, memberUser.ApplicationUser.FullName, "Annual membership fee due", null, null);
                            _context.SaveChanges();
                            Thread.Sleep(10000);
                        }
                    }
                }

            }

            foreach (var redApplicants in exceptionReportVM.RedRecords)
            {
                if (!string.IsNullOrEmpty(redApplicants.DateApplicationReceived))
                {
                    if (string.IsNullOrEmpty(redApplicants.PaymentReminder3Date))
                    {
                        if (redApplicants.NumberofDays >= 27)
                        {
                            MemberUser memberUser = _context.MemberUser.Where(x => x.Id == redApplicants.MemberId).FirstOrDefault();
                            memberUser.ThirdReminderSent = true;
                            memberUser.PaymentReminder3Date = DateTime.Now;
                            _context.Attach(memberUser).State = EntityState.Modified;
                            emailaddresses = EmailRecipients.GetEmailSenderList("ThirdReminder", null, memberUser.Email, (int)RelatedToEnum.Member, memberUser.Id);
                            _emailCreator.SendEmailAsync("ThirdReminder", emailaddresses, memberUser.ApplicationUser.FullName, "Reminder : Annual membership fee due", null, null);
                            _context.SaveChanges();
                            Thread.Sleep(10000);
                        }
                    }
                }

            }

            #endregion


        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
