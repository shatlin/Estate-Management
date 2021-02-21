using Microsoft.AspNetCore.Authorization;
using System;

namespace MDM.Pages.Client.Account
{
    [AllowAnonymous]
    internal class idPassportAttribute : Attribute
    {
    }
}