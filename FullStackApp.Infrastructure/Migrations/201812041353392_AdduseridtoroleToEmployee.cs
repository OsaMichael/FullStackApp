namespace FullStackApp.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdduseridtoroleToEmployee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "RoleId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "RoleId");
        }
    }
}
