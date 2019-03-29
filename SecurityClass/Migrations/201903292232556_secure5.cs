namespace SecurityClass.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secure5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("Security.AspNetRoles", "UserId", c => c.Int(identity: true));
            AddColumn("Security.AspNetRoles", "CreateDate", c => c.DateTime());
            AddColumn("Security.AspNetRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("Security.AspNetRoles", "Discriminator");
            DropColumn("Security.AspNetRoles", "CreateDate");
            DropColumn("Security.AspNetRoles", "UserId");
        }
    }
}
