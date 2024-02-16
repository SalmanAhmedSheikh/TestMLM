using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace AspNetCoreHero.Boilerplate.Infrastructure.Identity
{
    public class CustomSignInManager<TUser> : SignInManager<TUser> where TUser : class
    {
        private readonly UserManager<TUser> _userManager;
        private readonly ApplicationDbContext _db;
        private readonly IHttpContextAccessor _contextAccessor;

        public CustomSignInManager(
            UserManager<TUser> userManager,
            IHttpContextAccessor contextAccessor,
            IUserClaimsPrincipalFactory<TUser> claimsFactory,
            IOptions<IdentityOptions> optionsAccessor,
            ILogger<SignInManager<TUser>> logger,
            IAuthenticationSchemeProvider schemes,
            IUserConfirmation<TUser> confirmation, 
            ApplicationDbContext dbContext)
            : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes, confirmation)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _contextAccessor = contextAccessor ?? throw new ArgumentNullException(nameof(contextAccessor));
            _db = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public override async Task<SignInResult> PasswordSignInAsync(TUser user, string password, bool isPersistent, bool lockoutOnFailure)
        {
            //skipped for readability reasons 
            var result = await base.PasswordSignInAsync(user, password, isPersistent, lockoutOnFailure);
            return result;
        }
    }

}
