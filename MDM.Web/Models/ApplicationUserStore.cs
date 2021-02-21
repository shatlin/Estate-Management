using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MM.ClientModels
{
    public class ApplicationUserStore<TUser, TRole, TKey> : UserStore<TUser, TRole, ClientDbContext>
      where TUser : ApplicationUser
      where TRole : ApplicationRole
      where TKey : IEquatable<TKey>
    {
        public ApplicationUserStore(ClientDbContext context, IdentityErrorDescriber describer = null)
          : base(context, describer)
        {
        }

        public override Task<IdentityResult> CreateAsync(TUser user, CancellationToken cancellationToken = new CancellationToken())
        {
            return base.CreateAsync(user, cancellationToken);
        }

        public override Task<TUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            return EntityFrameworkQueryableExtensions.FirstOrDefaultAsync(Users, u => u.NormalizedUserName == normalizedUserName , cancellationToken);
        }

        public override Task<TUser> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            return EntityFrameworkQueryableExtensions.FirstOrDefaultAsync(Users, u => u.NormalizedEmail == normalizedEmail , cancellationToken);
        }


    }

}