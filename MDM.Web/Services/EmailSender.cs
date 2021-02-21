using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
namespace Services.Email
{
    public class EmailSender : IEmailSender
    {


        // Our private configuration variables
        private string host;
        private int port;
        private bool enableSSL;
        private string userName;
        private string password;

        // Get our parameterized configuration
        public EmailSender(string host, int port, bool enableSSL, string userName, string password)
        {
            this.host = host;
            this.port = port;
            this.enableSSL = enableSSL;
            this.userName = userName;
            this.password = password;
        }

        //// Use our configuration to send the email by using SmtpClient
        //public Task SendEmailAsync(string email, string subject, string htmlMessage)
        //{
        //    var client = new SmtpClient(host, port)
        //    {
        //        Credentials = new NetworkCredential(userName, password),
        //        EnableSsl = enableSSL
        //    };

        //    return client.SendMailAsync(
        //          new MailMessage(userName, "shatlin@outlook.com", subject, htmlMessage) { IsBodyHtml = true }
        //      );
        //    //return client.SendMailAsync(
        //    //    new MailMessage(userName, email, subject, htmlMessage) { IsBodyHtml = true }
        //    //);
        //}

        public Task SendEmailAsync(string to, string subject, string body)
        {

            var mailMessage = new MailMessage();

            #region prod set up

            string[] emailaddresses = to.Split('|');

            string[] toAddresses = emailaddresses[0].Split(';');

            foreach (string toaddress in toAddresses)
            {
                if (toaddress.Length > 0)
                {
                    mailMessage.To.Add(toaddress);
                }
            }

            if (emailaddresses.Count() > 1)
            {
                string[] ccAddresses = emailaddresses[1].Split(';');
                foreach (string ccaddress in ccAddresses)
                {
                    if (ccaddress.Length > 0)
                    {
                        mailMessage.CC.Add(ccaddress);
                    }
                }
            }

            mailMessage.Bcc.Add("shatlin@gmail.com");
            mailMessage.Bcc.Add("ajivinister@gmail.com");

            #endregion prod set up

            #region dev set up
            //mailMessage.To.Clear();
            //mailMessage.CC.Clear();
            //mailMessage.To.Add("shatlin@outlook.com");
            ////mailMessage.To.Add("membership@wisa.org.za");
            ////mailMessage.To.Add("admin@wisa.org.za");
            ////mailMessage.Bcc.Add("shatlin@gmail.com");
            ////mailMessage.CC.Add("ajivinister@gmail.com");
            ////mailMessage.CC.Add("seshan@evolutio.co.za");
            ////mailMessage.CC.Add("sunil@evolutio.co.za");

            #endregion dev set up

            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = true;
            mailMessage.From = new MailAddress(userName);

            //using (MemoryStream ms = new MemoryStream(imagem))
            //{
            //    mailMessage.Attachments.Add(new Attachment(ms, "FILENAME"));
            //}

            var smtp = new SmtpClient(host, port)
            {
                Credentials = new NetworkCredential(userName, password),
                EnableSsl = enableSSL
            };

           return smtp.SendMailAsync(mailMessage);
          
        }
    }
}
