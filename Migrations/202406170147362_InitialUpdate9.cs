namespace iCantine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialUpdate9 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tickets", "Value", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tickets", "Value", c => c.Double(nullable: false));
        }
    }
}
