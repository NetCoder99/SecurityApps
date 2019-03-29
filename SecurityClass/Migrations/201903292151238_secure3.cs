namespace SecurityClass.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secure3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("Security.AspNetRoles", "CreateDate");
            DropColumn("Security.AspNetUsers", "UserId");
            DropColumn("Security.AspNetUsers", "CreateDate");
        }
        
        public override void Down()
        {
            AddColumn("Security.AspNetUsers", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("Security.AspNetUsers", "UserId", c => c.Int(nullable: false, identity: true));
            AddColumn("Security.AspNetRoles", "CreateDate", c => c.DateTime(nullable: false));
        }
    }
}
