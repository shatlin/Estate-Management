using Microsoft.AspNetCore.Authorization;
using System;

namespace MDM.Pages.Account
{
    [AllowAnonymous]
    internal class idPassportAttribute : Attribute
    {
    }
}