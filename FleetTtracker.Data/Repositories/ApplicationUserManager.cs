using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using PowerEvent.Model;

namespace PowerEvent.Data
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        private readonly PowerEventDbContext _context;

        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
           
        }
 
        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var appDbContext = context.Get<PowerEventDbContext>();
            var appUserManager = new ApplicationUserManager(new UserStore<ApplicationUser>(appDbContext));

            return appUserManager;
        }

    }
}
