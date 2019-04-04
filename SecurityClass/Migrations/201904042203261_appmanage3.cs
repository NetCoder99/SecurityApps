namespace SecurityClass.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appmanage3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Security.AppSystems", "UpdateDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("Security.AppSystems", "UpdateDate", c => c.DateTime(nullable: false));
        }
    }
}
