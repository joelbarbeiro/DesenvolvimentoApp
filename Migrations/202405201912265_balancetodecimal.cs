namespace iCantine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class balancetodecimal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Balance", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Balance", c => c.Double());
        }
    }
}
