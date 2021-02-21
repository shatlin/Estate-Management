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

namespace MDM.Pages
{

    public class Download : PageModel
    {
        private readonly ILogger<ErrorModel> _logger;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public Download(ILogger<ErrorModel> logger, IWebHostEnvironment env, IConfiguration configuration)
        {
            _logger = logger;
            _env = env;
            _configuration = configuration;
        }

        public async Task<IActionResult> OnGet(string fileName)
        {

            try
            {
                fileName = _env.ContentRootPath  + _configuration["StoredFilesPath"].ToString() + @"\" + fileName;
                _logger.LogInformation("Attempting to download " + fileName + " at " + DateTime.Now);
                MemoryStream memory = new MemoryStream();
                using (var stream = new FileStream(fileName, FileMode.Open))
                {
                    await stream.CopyToAsync(memory);
                }
                memory.Position = 0;
                _logger.LogInformation(fileName + " is downloaded at " + DateTime.Now);
                return File(memory, MediaTypeNames.Application.Octet, Path.GetFileName(fileName));
            }
            catch (Exception ex)
            {
                  _logger.LogInformation("Exception while downloading file "+ fileName+"_"  + ex.Message + " inner exception " + DateTime.Now);
            }

            return null;
        }

        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats.officedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }
    }
}
