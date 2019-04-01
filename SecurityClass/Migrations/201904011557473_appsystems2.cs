namespace SecurityClass.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appsystems2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("Security.AppSystems", "AppId", c => c.Int(nullable: false, identity: true));
        }
        
        public override void Down()
        {
            DropColumn("Security.AppSystems", "AppId");
        }
    }
}
