namespace SecurityClass.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class approles3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("Security.AspNetRoles", "AppSystem_Id", c => c.String(maxLength: 128));
            CreateIndex("Security.AspNetRoles", "AppSystem_Id");
            AddForeignKey("Security.AspNetRoles", "AppSystem_Id", "Security.AppSystems", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("Security.AspNetRoles", "AppSystem_Id", "Security.AppSystems");
            DropIndex("Security.AspNetRoles", new[] { "AppSystem_Id" });
            DropColumn("Security.AspNetRoles", "AppSystem_Id");
        }
    }
}
