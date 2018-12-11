namespace FullStackApp.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdduseridToEmployee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "UserId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "UserId");
        }
    }
}
