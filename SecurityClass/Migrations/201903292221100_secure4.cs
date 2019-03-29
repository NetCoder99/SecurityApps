namespace SecurityClass.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secure4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("Security.AspNetUserRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("Security.AspNetUsers", "UserId", c => c.Int(identity: true));
            AddColumn("Security.AspNetUsers", "CreateDate", c => c.DateTime());
            AddColumn("Security.AspNetUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("Security.AspNetUserClaims", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("Security.AspNetUserLogins", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("Security.AspNetUserLogins", "Discriminator");
            DropColumn("Security.AspNetUserClaims", "Discriminator");
            DropColumn("Security.AspNetUsers", "Discriminator");
            DropColumn("Security.AspNetUsers", "CreateDate");
            DropColumn("Security.AspNetUsers", "UserId");
            DropColumn("Security.AspNetUserRoles", "Discriminator");
        }
    }
}
