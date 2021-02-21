using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using NLog;
namespace MM.Pages
{
    public class IndexsModel : PageModel
    {
        private readonly ILogger<IndexsModel> _logger;

        public IndexsModel(ILogger<IndexsModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            _logger.LogInformation("HomePage method called!!!");  
            return Page();
        }
    }
}
