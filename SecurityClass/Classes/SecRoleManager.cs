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
    public class SecRoleManager
    {
        public static AppRole GetRole(AppRole appRole)
        {
            RoleStore<AppRole> roleStore = new RoleStore<AppRole>(new SqlExpIdentity());
            using (var roleManager = new RoleManager<AppRole>(roleStore))
            {
                return roleManager.FindByName(appRole.Name);
            }
        }
        public static AppRole GetRoleByName(string roleName)
        {
            RoleStore<AppRole> roleStore = new RoleStore<AppRole>(new SqlExpIdentity());
            using (var roleManager = new RoleManager<AppRole>(roleStore))
            {
                return roleManager.FindByName(roleName);
            }
        }

        public static void DeleteRole(AppRole appRole)
        {

            RoleStore<AppRole> roleStore = new RoleStore<AppRole>(new SqlExpIdentity());
            using (var roleManager = new RoleManager<AppRole>(roleStore))
            {
                AppRole delRole = roleManager.FindByName(appRole.Name);
                DeleteRoleUsers(delRole);
                IdentityResult r1 = roleManager.Delete(delRole);
                if (r1.Errors.Count() > 0)
                {
                    string e1 = r1.Errors.ToList()[0];
                    throw new Exception(e1);
                }
            }
        }

        public static void DeleteRoleUsers(AppRole appRole)
        {
            RoleStore<AppRole> roleStore = new RoleStore<AppRole>(new SqlExpIdentity());
            using (var roleManager = new RoleManager<AppRole>(roleStore))
            {
                try
                {
                    appRole = roleManager.FindById(appRole.Id);
                    appRole.Users.Clear();
                    roleStore.Context.SaveChanges();
                }
                catch(Exception ex)
                { throw ex; }
            }
        }



    }
}
