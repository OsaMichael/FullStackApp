namespace FullStackApp.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adduseridtorole : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Roles", "UserId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Roles", "UserId");
        }
    }
}
