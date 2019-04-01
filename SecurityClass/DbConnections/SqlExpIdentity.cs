using Microsoft.AspNet.Identity.EntityFramework;
using SecurityClass.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityClass.DbConnections
{
    class SqlExpIdentity : IdentityDbContext
    {
        public SqlExpIdentity()
        { this.Database.Connection.ConnectionString = GetSqlConnectionStr(); }

        public DbSet<AppUser> appUsers { get; set; }
        public DbSet<AppRole> appRoles { get; set; }
        public DbSet<AppSystem> appSystems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("Security");
        }

        private static string GetSqlConnectionStr()
        {
            return @"Data Source=.\SQLEXPRESS;Initial Catalog=Security;Integrated Security=True;";

            //var c1 = ConfigurationManager.ConnectionStrings["AdWorks16Exp"];
            //return c1.ConnectionString;
        }

    }
}
