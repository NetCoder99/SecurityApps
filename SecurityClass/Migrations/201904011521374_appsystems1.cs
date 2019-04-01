namespace SecurityClass.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appsystems1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Security.AppSystems",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 50),
                        Desc = c.String(nullable: false, maxLength: 250),
                        CreateDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("Security.AppSystems");
        }
    }
}
