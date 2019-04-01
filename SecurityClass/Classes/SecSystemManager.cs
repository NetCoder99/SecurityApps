using SecurityClass.DbConnections;
using SecurityClass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityClass.Classes
{
    public class SecSystemManager
    {
        public static AppSystem GetAppByGuid(string appId)
        {
            using (var dbContext = new SqlExpIdentity())
            {
                try
                { return dbContext.appSystems.Where(w=>w.Id == appId).FirstOrDefault(); }
                catch (Exception ex)
                { throw ex; }
            }
        }

        public static AppSystem GetAppById(int appId)
        {
            using (var dbContext = new SqlExpIdentity())
            {
                try
                { return dbContext.appSystems.Where(w => w.AppId == appId).FirstOrDefault(); }
                catch (Exception ex)
                { throw ex; }
            }
        }

        public static AppSystem GetAppByName(string appName)
        {
            using (var dbContext = new SqlExpIdentity())
            {
                try
                { return dbContext.appSystems.Where(w => w.Name == appName).FirstOrDefault(); }
                catch (Exception ex)
                { throw ex; }
            }
        }

        public static AppSystem CreateApp(AppSystem appSystem)
        {
            using (var dbContext = new SqlExpIdentity())
            {
                try
                {
                    dbContext.appSystems.Add(appSystem);
                    dbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return appSystem;
        }

        public static AppRole AddRole(string appName, AppRole appRole)
        {
            using (var dbContext = new SqlExpIdentity())
            {
                try
                {
                    AppSystem appSystem = dbContext.appSystems.Where(w=>w.Name == appName).FirstOrDefault();
                    if (appSystem == null) { throw new ArgumentNullException("AppName");  }
                    appSystem.AppRoles.Add(appRole);
                    dbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return appRole;
        }


    }
}
