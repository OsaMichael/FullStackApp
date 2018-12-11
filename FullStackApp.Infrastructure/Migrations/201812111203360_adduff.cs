namespace FullStackApp.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adduff : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Employees", "RoleId");
            AddForeignKey("dbo.Employees", "RoleId", "dbo.Roles", "RoleId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "RoleId", "dbo.Roles");
            DropIndex("dbo.Employees", new[] { "RoleId" });
        }
    }
}
