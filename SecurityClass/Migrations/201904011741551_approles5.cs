namespace SecurityClass.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class approles5 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("Security.AppSystems", "Name", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("Security.AppSystems", new[] { "Name" });
        }
    }
}
