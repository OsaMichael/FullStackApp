namespace FullStackApp.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addup1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "RoleId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "RoleId", c => c.Int(nullable: false));
        }
    }
}
