using SecurityClass.Builders;
using SecurityClass.DbConnections;
using SecurityClass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityClass.Classes
{
    public class SecAppManager
    {
        public static List<AppSystem> GetAppsAll()
        {
            using (var dbContext = new SqlExpIdentity())
            {
                try
                { return dbContext.appSystems.ToList(); }
                catch (Exception ex)
                { throw ex; }
            }
        }


        public static AppSystem GetAppByGuid(string appId)
        {
            using (var dbContext = new SqlExpIdentity())
            {
                try
                {
                    AppSystem appSystem = dbContext.appSystems.Where(w=>w.Id == appId).FirstOrDefault();
                    if (appSystem != null)
                    { appSystem.AppRoles.ToList(); }
                    return appSystem;
                }
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
                    appSystem.CreateDate = DateTime.Now;
                    appSystem.UpdateDate = DateTime.Now;
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

        public static AppSystem Update(AppSystem appSystem)
        {
            using (var dbContext = new SqlExpIdentity())
            {
                try
                {
                    AppSystem tmpSystem = dbContext.appSystems.Where(w => w.Id == appSystem.Id).FirstOrDefault();
                    if (tmpSystem == null)
                    {
                        tmpSystem = new AppBuilder().AppName(appSystem.Name).AppDesc(appSystem.Desc).Build();
                        tmpSystem = CreateApp(tmpSystem);
                    }
                    else
                    {
                        tmpSystem.Name = appSystem.Name != appSystem.Name ? tmpSystem.Name : appSystem.Name;
                        tmpSystem.Desc = appSystem.Desc != appSystem.Desc ? tmpSystem.Desc : appSystem.Desc;
                        tmpSystem.UpdateDate = DateTime.Now;
                        int updCount = dbContext.SaveChanges();
                    }

                    return tmpSystem;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
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
