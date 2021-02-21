using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MM.ClientModels;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MM.Helper
{

    public class ApplicationSignInManager<Tuser> : SignInManager<Tuser>
        where Tuser:ApplicationUser
    {
        private readonly UserManager<Tuser> _userManager;
        private readonly ClientDbContext _dbContext;
        private readonly IHttpContextAccessor _contextAccessor;

        public ApplicationSignInManager(UserManager<Tuser> userManager,
            IHttpContextAccessor contextAccessor,
            IUserClaimsPrincipalFactory<Tuser> claimsFactory,
            IOptions<IdentityOptions> optionsAccessor,
            ILogger<SignInManager<Tuser>> logger,
            ClientDbContext dbContext,
            IAuthenticationSchemeProvider schemeProvider,IUserConfirmation<Tuser> userConfirmation
            )
            : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemeProvider,userConfirmation)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _contextAccessor = contextAccessor ?? throw new ArgumentNullException(nameof(contextAccessor));
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
    }

    public class ApplicationRoleManager<TRole> : RoleManager<TRole>
         where TRole : ApplicationRole
    {
        private readonly ClientDbContext _dbContext;

        public ApplicationRoleManager(ApplicationRoleStore<TRole> roleStore,
            IEnumerable<IRoleValidator<TRole>> roleValidators, ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors, ILogger<RoleManager<TRole>> logger, ClientDbContext dbContext) 
            : base(roleStore,roleValidators, keyNormalizer, errors, logger)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
    }

    public class ApplicationUserManager<Tuser> : UserManager<Tuser>
          where Tuser : ApplicationUser
    {
        private readonly ClientDbContext _dbContext;

        public ApplicationUserManager(ApplicationUserStore<Tuser,ApplicationRole,int> userStore, IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<Tuser> passwordHasher,
            IEnumerable<IUserValidator<Tuser>> userValidators,
            IEnumerable<IPasswordValidator<Tuser>> passwordValidators, ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<Tuser>> logger, ClientDbContext dbContext) :
            base(userStore, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors,
                services, logger)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
    }

    public partial class IdentityHelper
    {
        public UserManager<ApplicationUser> GetUserManager(ClientDbContext clientDbContext)
        {
            var userStore = new ApplicationUserStore<ApplicationUser, ApplicationRole, int>(clientDbContext);

            IPasswordHasher<ApplicationUser> hasher = new PasswordHasher<ApplicationUser>();
            var validator = new UserValidator<ApplicationUser>();
            var validators = new List<UserValidator<ApplicationUser>> { validator };
            ILogger<UserManager<ApplicationUser>> logger = new Logger<UserManager<ApplicationUser>>(new LoggerFactory());
            var userManager = new UserManager<ApplicationUser>(userStore, null, hasher, validators, null, null, null, null, logger);

            // Set-up token providers.
            IUserTwoFactorTokenProvider<ApplicationUser> tokenProvider = new EmailTokenProvider<ApplicationUser>();
            userManager.RegisterTokenProvider("Default", tokenProvider);
            IUserTwoFactorTokenProvider<ApplicationUser> phoneTokenProvider = new PhoneNumberTokenProvider<ApplicationUser>();
            userManager.RegisterTokenProvider("PhoneTokenProvider", phoneTokenProvider);
            return userManager;
        }

        public RoleManager<ApplicationRole> GetRoleManager(ClientDbContext clientDbContext)
        {
            ILogger<RoleManager<ApplicationRole>> logger = new Logger<RoleManager<ApplicationRole>>(new LoggerFactory());
            var validator = new RoleValidator<ApplicationRole>();
            var validators = new List<RoleValidator<ApplicationRole>> { validator };
            var errorDescribers = new IdentityErrorDescriber();
            var roleStore = new ApplicationRoleStore<ApplicationRole>(clientDbContext);
            var roleManager = new RoleManager<ApplicationRole>(roleStore, validators, null, errorDescribers, logger);
            return roleManager;
        }

    }
}
