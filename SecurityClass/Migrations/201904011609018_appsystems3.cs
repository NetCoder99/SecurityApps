namespace SecurityClass.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appsystems3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("Security.AspNetUserRoles", "UserRoleId", c => c.Int(identity: true));
        }
        
        public override void Down()
        {
            DropColumn("Security.AspNetUserRoles", "UserRoleId");
        }
    }
}
