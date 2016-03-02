namespace Turtle.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyNewMigrationName2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "First", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "First");
        }
    }
}
