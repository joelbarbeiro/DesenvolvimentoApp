namespace iCantine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menus", "Hour", c => c.DateTime(nullable: false));
            AddColumn("dbo.Plates", "Type", c => c.String());
            AlterColumn("dbo.Users", "Balance", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Balance", c => c.Double());
            DropColumn("dbo.Plates", "Type");
            DropColumn("dbo.Menus", "Hour");
        }
    }
}
