namespace SecurityClass.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secure6 : DbMigration
    {
        public override void Up()
        {
            DropColumn("Security.AspNetRoles", "UserId");
            AddColumn("Security.AspNetRoles", "RoleId", c => c.Int(identity: true));
        }
        
        public override void Down()
        {
            DropColumn("Security.AspNetRoles", "RoleId");
            AddColumn("Security.AspNetRoles", "UserId", c => c.Int(identity: true));
        }
    }
}
