
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.IO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Mail;
using MDM.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace MDM.Services
{

    public interface IEmailCreator
    {
        Task<string> SendEmailAsync(string emailContentFile, string recipientEmail,
             string recipientName, string emailSubject, string buttonText, string url);
    }


    public class EmailCreator : IEmailCreator
    {
        //private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<EmailCreator> _logger;
        private readonly IConfiguration _configuration;
        private readonly IEmailSender _emailSender;
        private readonly IWebHostEnvironment _env;
        //private readonly DB _context;
        public EmailCreator(ILogger<EmailCreator> logger, IConfiguration configuration, IEmailSender emailSender,  IWebHostEnvironment env)
        {
            
            _logger = logger;
            _configuration = configuration;
            _emailSender = emailSender;
            _env = env;
            //_userManager = userManager;
            //_context = context;
        }

        public async Task<string> SendEmailAsync(string emailContentFile, string recipientEmail,
            string recipientName, string emailSubject, string buttonText, string url)
        {

            //_logger.LogInformation("SendEmailAsync: ContentRootPath is" + _env.ContentRootPath);
            //_logger.LogInformation("SendEmailAsync: EmailTemplates TemplatesPath is" + _configuration["EmailTemplates:TemplatesPath"].ToString());

            string emailTemplatesPath = _env.ContentRootPath + _configuration["EmailTemplates:TemplatesPath"].ToString();
            string emailmainTemplatePath = emailTemplatesPath + _configuration["EmailTemplates:MainTemplate"].ToString();
            string emailMainTemplate = File.ReadAllText(emailmainTemplatePath);
            emailContentFile = emailTemplatesPath + emailContentFile + ".html";
            //   _logger.LogInformation("emailContentFile is" + emailContentFile);

            string emailContent = File.ReadAllText(emailContentFile);
            // _logger.LogInformation("emailContent  is" + emailContent);
            emailContent = emailContent.Replace("[FullName]", recipientName);
            if (!string.IsNullOrEmpty(buttonText))
            {
                emailContent = emailContent.Replace("[ButtonText]", buttonText);
            }
            if (!string.IsNullOrEmpty(url))
            {
                emailContent = emailContent.Replace("[URLText]", url);
            }
            emailMainTemplate = emailMainTemplate.Replace("[EmailSubject]", emailSubject);
            emailMainTemplate = emailMainTemplate.Replace("[EmailBody]", emailContent);

            try
            {
                DB _context = new DB();
                int relatedToId = 0;
                int relatedEntityId = 0;

                string[] emailaddresses = recipientEmail.Split('|');
                string toAddresses = emailaddresses[0];
                string ccAddresses = emailaddresses[1];
                relatedToId = Convert.ToInt32(emailaddresses[2]);
                relatedEntityId = Convert.ToInt32(emailaddresses[3]);

                //string systemUserId = _userManager.FindByEmailAsync("system@MDM.org.za").Result.Id;
                //int createdById = _context.ClientUser.First(x => x.ApplicaitonUserId == systemUserId).Id;

                //await _context.MemberEmailXref.AddAsync(
                //     new MemberEmailXref


                //     {
                //         To = toAddresses,
                //         CC = ccAddresses,
                //         Body = emailMainTemplate,
                //         RelatedToId = relatedToId,
                //         RelatedEntityId = relatedEntityId,
                //         From = "notifications@miledownemanor.co.za",
                //         Subject = emailSubject,
                //         //CreatedBy = createdById,
                //         CreatedOn = DateTime.Now
                //     }
                //     );

               // await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Email sending failed " + ex.Message + " " + ex.InnerException+" Recipients: "+ recipientEmail + " emailContentFile: " + emailContentFile + " emailSubject: " + emailSubject);
            }

          
            await _emailSender.SendEmailAsync(recipientEmail, emailSubject, emailMainTemplate);
            return emailMainTemplate;
        }



    }


}
