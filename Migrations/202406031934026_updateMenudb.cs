namespace iCantine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateMenudb : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Menus", "Plate_idPlate", "dbo.Plates");
            DropIndex("dbo.Menus", new[] { "Plate_idPlate" });
            AddColumn("dbo.MenuPlates", "idMenu", c => c.Int(nullable: false));
            AddColumn("dbo.Menus", "idMenuPlates", c => c.Int(nullable: false));
            AddColumn("dbo.Menus", "idMenuExtra", c => c.Int(nullable: false));
            AddColumn("dbo.Menus", "MenuExtras_idMenuExtras", c => c.Int());
            CreateIndex("dbo.Menus", "idMenuPlates");
            CreateIndex("dbo.Menus", "MenuExtras_idMenuExtras");
            AddForeignKey("dbo.Menus", "MenuExtras_idMenuExtras", "dbo.MenuExtras", "idMenuExtras");
            AddForeignKey("dbo.Menus", "idMenuPlates", "dbo.MenuPlates", "idMenuPlates", cascadeDelete: true);
            DropColumn("dbo.MenuPlates", "idExtras");
            DropColumn("dbo.Menus", "idPlates");
            DropColumn("dbo.Menus", "Plate_idPlate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Menus", "Plate_idPlate", c => c.Int());
            AddColumn("dbo.Menus", "idPlates", c => c.Int(nullable: false));
            AddColumn("dbo.MenuPlates", "idExtras", c => c.Int(nullable: false));
            DropForeignKey("dbo.Menus", "idMenuPlates", "dbo.MenuPlates");
            DropForeignKey("dbo.Menus", "MenuExtras_idMenuExtras", "dbo.MenuExtras");
            DropIndex("dbo.Menus", new[] { "MenuExtras_idMenuExtras" });
            DropIndex("dbo.Menus", new[] { "idMenuPlates" });
            DropColumn("dbo.Menus", "MenuExtras_idMenuExtras");
            DropColumn("dbo.Menus", "idMenuExtra");
            DropColumn("dbo.Menus", "idMenuPlates");
            DropColumn("dbo.MenuPlates", "idMenu");
            CreateIndex("dbo.Menus", "Plate_idPlate");
            AddForeignKey("dbo.Menus", "Plate_idPlate", "dbo.Plates", "idPlate");
        }
    }
}
