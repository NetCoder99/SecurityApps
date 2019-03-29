using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SecurityClass.DbConnections;
using SecurityClass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityClass.Classes
{
    public class SecUserManager
    {
        public static void CreateUser(AppUser appUser)
        {
            UserStore<AppUser> userStore = new UserStore<AppUser>(new SqlExpIdentity());
            using (var userManager = new UserManager<AppUser>(userStore))
            {
                IdentityResult r1 = userManager.Create(appUser, "password");
                if (r1.Errors.Count() > 0)
                {
                    string e1 = r1.Errors.ToList()[0];
                    throw new Exception(e1);
                }
            }
        }

        public static void DeleteUser(AppUser appUser)
        {
            UserStore<AppUser> userStore = new UserStore<AppUser>(new SqlExpIdentity());
            using (var userManager = new UserManager<AppUser>(userStore))
            {
                AppUser tmpUser = userManager.FindByName(appUser.UserName);
                IdentityResult r1 = userManager.Delete(tmpUser);
                if (r1.Errors.Count() > 0)
                {
                    string e1 = r1.Errors.ToList()[0];
                    throw new Exception(e1);
                }
            }
        }


    }
}
