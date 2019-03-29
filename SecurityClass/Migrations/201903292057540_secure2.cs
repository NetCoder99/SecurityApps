namespace SecurityClass.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secure2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("Security.AspNetRoles", "CreateDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("Security.AspNetRoles", "CreateDate");
        }
    }
}
