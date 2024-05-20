namespace iCantine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePlateType1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Plates", "Type", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Plates", "Type");
        }
    }
}
