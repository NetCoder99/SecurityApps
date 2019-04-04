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
    public class SecUserRoleManager
    {
        public static void AddUserToRole(AppUser appUser, AppRole appRole)
        {
            UserStore<AppUser> userStore = new UserStore<AppUser>(new SqlExpIdentity());
            using (var userManager = new UserManager<AppUser>(userStore))
            {
                AppUser tmpUser = userManager.FindByName(appUser.UserName);
                IdentityResult r1 = userManager.AddToRole(tmpUser.Id, appRole.Name);
                if (r1.Errors.Count() > 0)
                {
                    string e1 = r1.Errors.ToList()[0];
                    throw new Exception(e1);
                }
                else
                {
                    //return userManager.rol
                }
            }
        }

        public static List<AppUser> GetUsersInRole(AppRole appRole)
        {
            UserStore<AppUser> userStore = new UserStore<AppUser>(new SqlExpIdentity());
            using (var userManager = new UserManager<AppUser>(userStore))
            {
                List<AppUser> appUsers = (from user in userManager.Users
                                          where user.Roles.Any(r => r.RoleId == appRole.Id)
                                          select user).ToList();
                return appUsers;
            }
        }

    }
}
