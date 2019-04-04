namespace SecurityClass.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appmanage2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("Security.AppSystems", "UpdateDate", c => c.DateTime(nullable: false));
            DropColumn("Security.AppSystems", "UodateDate");
        }
        
        public override void Down()
        {
            AddColumn("Security.AppSystems", "UodateDate", c => c.DateTime(nullable: false));
            DropColumn("Security.AppSystems", "UpdateDate");
        }
    }
}
