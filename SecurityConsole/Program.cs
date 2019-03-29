using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using SecurityClass.Classes;
using SecurityClass.Models;

namespace SecurityConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("---- Application Started -----");


            CreateRole();

            WriteLine("---- Application Finished -----");
            ReadKey();
        }

        public static void CreateRole()
        {
            try
            {
                AppRole appRole = new AppRole("Role1");
                SecRoleManager.CreateRole(appRole);
                WriteLine($"{appRole.RoleName} was created.");
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
        }


        public static void DeleteUser()
        {
            try
            {
                AppUser appUser = new AppUser();
                appUser.Email = "anyone@nowhere.com";
                appUser.UserName = "AnyOneElse2";
                SecUserManager.DeleteUser(appUser);
                WriteLine($"{appUser.UserName} was deleted.");
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
        }

        public static void CreateUser()
        {
            try
            {
                AppUser appUser = new AppUser();
                appUser.Email = "anyone@nowhere.com";
                appUser.UserName = "AnyOneElse2";
                SecUserManager.CreateUser(appUser);
                WriteLine($"{appUser.UserName} was created.");
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
        }


    }
}
