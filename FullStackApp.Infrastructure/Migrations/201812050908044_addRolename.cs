namespace FullStackApp.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRolename : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Roles", "RoleName", c => c.String());
            DropColumn("dbo.Roles", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Roles", "Name", c => c.String());
            DropColumn("dbo.Roles", "RoleName");
        }
    }
}
