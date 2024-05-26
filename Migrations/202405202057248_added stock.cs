namespace iCantine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedstock : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Extras", "Stock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Extras", "Stock");
        }
    }
}
