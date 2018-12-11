namespace FullStackApp.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddnAMEtOeMPL : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Name", c => c.String());
            DropColumn("dbo.Employees", "FirstName");
            DropColumn("dbo.Employees", "LastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "LastName", c => c.String());
            AddColumn("dbo.Employees", "FirstName", c => c.String());
            DropColumn("dbo.Employees", "Name");
        }
    }
}
