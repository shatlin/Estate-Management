using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;

namespace MM.ClientModels
{
    public class ApplicationRoleStore<TRole> : RoleStore<TRole>
         where TRole : ApplicationRole
    {
        public ApplicationRoleStore(ClientDbContext context)
        : base(context)
        {
        }

    }
}