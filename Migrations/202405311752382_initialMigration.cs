namespace iCantine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Extras", "Menu_idMenu", "dbo.Menus");
            DropForeignKey("dbo.Plates", "Menu_idMenu", "dbo.Menus");
            DropIndex("dbo.Extras", new[] { "Menu_idMenu" });
            DropIndex("dbo.Plates", new[] { "Menu_idMenu" });
            AddColumn("dbo.Menus", "idPlates", c => c.Int(nullable: false));
            AddColumn("dbo.Menus", "Plate_idPlate", c => c.Int());
            AlterColumn("dbo.Menus", "PriceStudent", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Menus", "PriceProf", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            CreateIndex("dbo.Menus", "Plate_idPlate");
            AddForeignKey("dbo.Menus", "Plate_idPlate", "dbo.Plates", "idPlate");
            DropColumn("dbo.Extras", "Menu_idMenu");
            DropColumn("dbo.Menus", "Hour");
            DropColumn("dbo.Plates", "Menu_idMenu");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Plates", "Menu_idMenu", c => c.Int());
            AddColumn("dbo.Menus", "Hour", c => c.DateTime(nullable: false));
            AddColumn("dbo.Extras", "Menu_idMenu", c => c.Int());
            DropForeignKey("dbo.Menus", "Plate_idPlate", "dbo.Plates");
            DropIndex("dbo.Menus", new[] { "Plate_idPlate" });
            AlterColumn("dbo.Menus", "PriceProf", c => c.Double(nullable: false));
            AlterColumn("dbo.Menus", "PriceStudent", c => c.Double(nullable: false));
            DropColumn("dbo.Menus", "Plate_idPlate");
            DropColumn("dbo.Menus", "idPlates");
            CreateIndex("dbo.Plates", "Menu_idMenu");
            CreateIndex("dbo.Extras", "Menu_idMenu");
            AddForeignKey("dbo.Plates", "Menu_idMenu", "dbo.Menus", "idMenu");
            AddForeignKey("dbo.Extras", "Menu_idMenu", "dbo.Menus", "idMenu");
        }
    }
}
