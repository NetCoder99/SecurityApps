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
        public static void CreateRole(AppRole appRole)
        {
            RoleStore<AppRole> roleStore = new RoleStore<AppRole>(new SqlExpIdentity());
            using (var roleManager = new RoleManager<AppRole>(roleStore))
            {
                IdentityResult r1 = roleManager.Create(appRole);
                if (r1.Errors.Count() > 0)
                {
                    string e1 = r1.Errors.ToList()[0];
                    throw new Exception(e1);
                }
            }
        }


    }
}
