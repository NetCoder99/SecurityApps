namespace SecurityClass.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appmanage4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("Security.AppSystems", "CreateDate");
            DropColumn("Security.AppSystems", "UpdateDate");
        }
        
        public override void Down()
        {
            AddColumn("Security.AppSystems", "UpdateDate", c => c.DateTime(nullable: false));
            AddColumn("Security.AppSystems", "CreateDate", c => c.DateTime(nullable: false));
        }
    }
}
