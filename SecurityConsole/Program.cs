using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using SecurityClass.Classes;
using SecurityClass.Models;
using static SecurityConsole.ExceptionProcs;
using System.Data.Entity.Core;
using System.Data.Entity.Validation;

namespace SecurityConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("---- Application Started -----");


            AppSystem appSystem1 = SecSystemManager.GetAppByName("AdWorks");
            AppUser newUser = CreateUser("anyone8");
            //AppRole newRole = CreateRole(appSystem1, "role7");
            AppRole newRole = SecRoleManager.GetRoleByName("role7");
            AddUserToRole(newUser, newRole);

            //SecRoleManager.DeleteRoleUsers(newRole);


            //AppRole tmpRole = SecRoleManager.GetRoleByName("Role1");
            //SecRoleManager.DeleteRole(tmpRole);


            //AppSystem appSystem = CreateSystem("AdWorks", "Adventure Works CRUD application.");
            //AppUser newUser = CreateUser("anyone6");
            //AppRole newRole = CreateRole("role6");
            //AddUserToRole(newUser, newRole);

            WriteLine("---- Application Finished -----");
            ReadKey();
        }

        public static AppSystem CreateSystem(string sysName, string sysDesc)
        {
            try
            {
                AppSystem appSystem = new AppSystem();
                appSystem.Name = sysName;
                appSystem.Desc = sysDesc;
                appSystem = SecSystemManager.CreateApp(appSystem);
                WriteLine($"{appSystem.Name} was created.");
                return appSystem;
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
                return null;
            }

        }

        public static void AddUserToRole(AppUser appUser, AppRole appRole)
        {
            try
            {
                SecUserRoleManager.AddUserToRole(appUser, appRole);
                WriteLine($"{appUser.UserName} was added to role {appRole.Name}.");
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
            
        }

        public static void DeleteRole()
        {
            try
            {
                AppRole appRole = new AppRole("Role2");
                SecRoleManager.DeleteRole(appRole);
                WriteLine($"{appRole.Name} was deleted.");
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
        }


        public static AppRole CreateRole(AppSystem appSystem, string roleName)
        {
            try
            {
                AppRole appRole = new AppRole(roleName);
                SecSystemManager.AddRole(appSystem.Name, appRole);
                WriteLine($"{appRole.Name} was created.");
                return appRole;
            }
            catch (DbEntityValidationException ex)
            {
                WriteLine(GetExceptionMessage(ex));
                return null;
            }

            catch (Exception ex)
            {
                WriteLine(GetExceptionMessage(ex));
                return null;
            }
        }


        public static void DeleteUser()
        {
            try
            {
                AppUser appUser = new AppUser();
                appUser.Email = "anyone3@nowhere.com";
                appUser.UserName = "AnyOneElse3";
                SecUserManager.DeleteUser(appUser);
                WriteLine($"{appUser.UserName} was deleted.");
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
        }

        public static AppUser CreateUser(string userName)
        {
            try
            {
                AppUser appUser = new AppUser();
                appUser.Email = userName +"@nowhere.com";
                appUser.UserName = userName;
                appUser = SecUserManager.CreateUser(appUser, userName);
                WriteLine($"{appUser.UserName} was created.");
                return appUser;
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
                return null;
            }
        }



        

    }
}
