namespace iCantine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatePriceType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Menus", "PriceStudent", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Menus", "PriceProf", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Menus", "PriceProf", c => c.Double(nullable: false));
            AlterColumn("dbo.Menus", "PriceStudent", c => c.Double(nullable: false));
        }
    }
}
