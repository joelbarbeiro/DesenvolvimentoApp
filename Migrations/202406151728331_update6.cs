
namespace iCantine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update6 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Plates", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Plates", "Price", c => c.Double(nullable: false));
        }
    }
}
