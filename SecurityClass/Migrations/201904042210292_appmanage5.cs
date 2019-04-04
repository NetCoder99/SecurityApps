namespace SecurityClass.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appmanage5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("Security.AppSystems", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("Security.AppSystems", "UpdateDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("Security.AppSystems", "UpdateDate");
            DropColumn("Security.AppSystems", "CreateDate");
        }
    }
}
