namespace SecurityClass.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appmanage7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Security.AppSystems", "CreateDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("Security.AppSystems", "CreateDate", c => c.DateTime(nullable: false));
        }
    }
}
