namespace SecurityClass.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userrole1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("Security.AspNetUserRoles", "CreateDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("Security.AspNetUserRoles", "CreateDate");
        }
    }
}
