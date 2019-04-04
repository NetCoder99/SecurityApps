namespace SecurityClass.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appmanage1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("Security.AppSystems", "UodateDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("Security.AppSystems", "UodateDate");
        }
    }
}
