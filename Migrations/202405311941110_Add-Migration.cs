namespace iCantine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Menus", "idPlates", "dbo.Plates");
            DropIndex("dbo.Menus", new[] { "idPlates" });
            CreateTable(
                "dbo.MenuPlates",
                c => new
                    {
                        idMenuPlates = c.Int(nullable: false, identity: true),
                        idPlates = c.Int(nullable: false),
                        idExtras = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idMenuPlates)
                .ForeignKey("dbo.Plates", t => t.idPlates, cascadeDelete: true)
                .Index(t => t.idPlates);
            
            AddColumn("dbo.Menus", "Plate_idPlate", c => c.Int());
            CreateIndex("dbo.Menus", "Plate_idPlate");
            AddForeignKey("dbo.Menus", "Plate_idPlate", "dbo.Plates", "idPlate");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Menus", "Plate_idPlate", "dbo.Plates");
            DropForeignKey("dbo.MenuPlates", "idPlates", "dbo.Plates");
            DropIndex("dbo.MenuPlates", new[] { "idPlates" });
            DropIndex("dbo.Menus", new[] { "Plate_idPlate" });
            DropColumn("dbo.Menus", "Plate_idPlate");
            DropTable("dbo.MenuPlates");
            CreateIndex("dbo.Menus", "idPlates");
            AddForeignKey("dbo.Menus", "idPlates", "dbo.Plates", "idPlate", cascadeDelete: true);
        }
    }
}
