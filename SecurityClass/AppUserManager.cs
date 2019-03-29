using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SecurityClass.DbConnections;
using SecurityClass.Models;

namespace SecurityClass
{
    class AppUserManager : UserManager<AppUser>
    {
        public AppUserManager(IUserStore<AppUser> store) : base(store)
        { }

    }
}

//public static AppUserManager Create((IdentityFactoryOptions<AppUserManager> options, IOwinContext context)
//        {
//    var manager = new AppUserManager(new UserStore<AppUser>(context.Get<UserAccountDB>()));
//    return manager;
//}


//var userManager = new UserManager<AppUser>(new UserStore<AppUser>((id_context)));