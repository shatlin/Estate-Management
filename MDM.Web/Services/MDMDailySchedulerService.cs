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
using MDM.Models;
namespace MDM.Services
{

    public class MDMDailySchedulerService : IHostedService, IDisposable
    {

        private readonly ILogger<MDMDailySchedulerService> _logger;
        private readonly IConfiguration _configuration;
        private Timer _timer;
        TimeSpan ScheduledTimespan;

        private readonly IEmailCreator _emailCreator;
       

        public MDMDailySchedulerService(ILogger<MDMDailySchedulerService> logger, IConfiguration configuration,
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
        //  private readonly DB _context;
        //private readonly IEmailCreator _emailCreator;


        //public MMDailySchedulerService(ILogger<MMDailySchedulerService> logger, IConfiguration configuration,
        //    IEmailCreator emailCreator,UserManager<ApplicationUser> userManager,  DB context)
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
            DB _context = new DB();

         


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
