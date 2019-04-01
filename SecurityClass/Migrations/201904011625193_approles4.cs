namespace SecurityClass.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class approles4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Security.AspNetRoles", "AppSystem_Id", "Security.AppSystems");
            AddForeignKey("Security.AspNetRoles", "AppSystem_Id", "Security.AppSystems", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("Security.AspNetRoles", "AppSystem_Id", "Security.AppSystems");
            AddForeignKey("Security.AspNetRoles", "AppSystem_Id", "Security.AppSystems", "Id");
        }
    }
}
