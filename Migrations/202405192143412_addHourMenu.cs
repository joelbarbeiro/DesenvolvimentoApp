namespace iCantine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addHourMenu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menus", "Hour", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Menus", "Hour");
        }
    }
}
