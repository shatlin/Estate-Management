using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MDM.Models;

namespace MDM.Pages
{

    public class DownloadEmail : PageModel
    {
        private readonly ILogger<ErrorModel> _logger;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        private readonly DB _clientDbContext;
        public DownloadEmail(ILogger<ErrorModel> logger, IWebHostEnvironment env, IConfiguration configuration,DB clientDbContext)
        {
            _logger = logger;
            _env = env;
            _configuration = configuration;
            _clientDbContext = clientDbContext;
        }

        public async Task<IActionResult> OnGet(int mailId)
        {
            try
            {
              //  string email =  _clientDbContext.MemberEmailXref.Where(x => x.Id == mailId).FirstOrDefault().Body;

            string downloadFileName = "Email_"+ mailId + ".html";

            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write("");//  writer.Write(email);
                writer.Flush();
            stream.Position = 0;
            return File(stream, "text/html", downloadFileName);
            }
            catch (Exception ex)
            {
                  _logger.LogInformation("Exception while downloading email " + ex.Message + " inner exception " + DateTime.Now);
            }

            return null;
        }

       
    }
}
