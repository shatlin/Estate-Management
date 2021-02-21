using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MM.Pages.Client.Account
{
    [AllowAnonymous]
    public class SetPasswordConfirmationModel : PageModel
    {
        public void OnGet()
        {

        }
    }
}
