using Microsoft.AspNetCore.Authorization;
using System;

namespace MM.Pages.Client.Account
{
    [AllowAnonymous]
    internal class idPassportAttribute : Attribute
    {
    }
}