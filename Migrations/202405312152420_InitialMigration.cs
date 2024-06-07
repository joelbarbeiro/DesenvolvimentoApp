namespace iCantine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
<<<<<<<< Updated upstream:Migrations/202405312009227_update.cs
    public partial class update : DbMigration
========
    public partial class InitialMigration : DbMigration
>>>>>>>> Stashed changes:Migrations/202405312152420_InitialMigration.cs
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        idUser = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        nif = c.Int(nullable: false),
                        username = c.String(),
                        Balance = c.Decimal(precision: 18, scale: 2),
                        email = c.String(),
                        studentNumber = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.idUser);
            
            CreateTable(
                "dbo.Extras",
                c => new
                    {
                        idExtra = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Price = c.Double(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Stock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idExtra);
            
            CreateTable(
                "dbo.MenuExtras",
                c => new
                    {
                        idMenuExtras = c.Int(nullable: false, identity: true),
                        idMenu = c.Int(nullable: false),
                        idExtras = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idMenuExtras)
                .ForeignKey("dbo.Extras", t => t.idExtras, cascadeDelete: true)
                .Index(t => t.idExtras);
            
            CreateTable(
                "dbo.MenuPlates",
                c => new
                    {
                        idMenuPlates = c.Int(nullable: false, identity: true),
                        idPlates = c.Int(nullable: false),
<<<<<<<< Updated upstream:Migrations/202405312009227_update.cs
                        Plate_idPlate = c.Int(),
                        Receipt_idReceipt = c.Int(),
                    })
                .PrimaryKey(t => t.idMenu)
                .ForeignKey("dbo.Plates", t => t.Plate_idPlate)
                .ForeignKey("dbo.Receipts", t => t.Receipt_idReceipt)
                .Index(t => t.Plate_idPlate)
                .Index(t => t.Receipt_idReceipt);
========
                        idExtras = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idMenuPlates)
                .ForeignKey("dbo.Plates", t => t.idPlates, cascadeDelete: true)
                .Index(t => t.idPlates);
>>>>>>>> Stashed changes:Migrations/202405312152420_InitialMigration.cs
            
            CreateTable(
                "dbo.Plates",
                c => new
                    {
                        idPlate = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Type = c.String(),
                        Stock = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.idPlate);
            
            CreateTable(
<<<<<<<< Updated upstream:Migrations/202405312009227_update.cs
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
========
                "dbo.Menus",
                c => new
                    {
                        idMenu = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        QuantAvailable = c.Int(nullable: false),
                        PriceStudent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceProf = c.Decimal(nullable: false, precision: 18, scale: 2),
                        idPlates = c.Int(nullable: false),
                        Plate_idPlate = c.Int(),
                        Receipt_idReceipt = c.Int(),
                    })
                .PrimaryKey(t => t.idMenu)
                .ForeignKey("dbo.Plates", t => t.Plate_idPlate)
                .ForeignKey("dbo.Receipts", t => t.Receipt_idReceipt)
                .Index(t => t.Plate_idPlate)
                .Index(t => t.Receipt_idReceipt);
>>>>>>>> Stashed changes:Migrations/202405312152420_InitialMigration.cs
            
            CreateTable(
                "dbo.Receipts",
                c => new
                    {
                        idReceipt = c.Int(nullable: false, identity: true),
                        Total = c.Double(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.idReceipt);
            
            CreateTable(
                "dbo.ItemReceipts",
                c => new
                    {
                        idItemReceipt = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Price = c.Double(nullable: false),
                        Receipt_idReceipt = c.Int(),
                    })
                .PrimaryKey(t => t.idItemReceipt)
                .ForeignKey("dbo.Receipts", t => t.Receipt_idReceipt)
                .Index(t => t.Receipt_idReceipt);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        idReservation = c.Int(nullable: false, identity: true),
                        Date = c.String(),
                        Plate = c.String(),
                        Extra = c.String(),
                        Client = c.String(),
                        Hour = c.String(),
                    })
                .PrimaryKey(t => t.idReservation);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        idTicket = c.Int(nullable: false, identity: true),
                        Value = c.Double(nullable: false),
                        NumHours = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idTicket);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Menus", "Receipt_idReceipt", "dbo.Receipts");
            DropForeignKey("dbo.ItemReceipts", "Receipt_idReceipt", "dbo.Receipts");
            DropForeignKey("dbo.Menus", "Plate_idPlate", "dbo.Plates");
            DropForeignKey("dbo.MenuPlates", "idPlates", "dbo.Plates");
            DropForeignKey("dbo.MenuExtras", "idExtras", "dbo.Extras");
            DropIndex("dbo.ItemReceipts", new[] { "Receipt_idReceipt" });
            DropIndex("dbo.MenuPlates", new[] { "idPlates" });
            DropIndex("dbo.Menus", new[] { "Receipt_idReceipt" });
            DropIndex("dbo.Menus", new[] { "Plate_idPlate" });
<<<<<<<< Updated upstream:Migrations/202405312009227_update.cs
========
            DropIndex("dbo.MenuPlates", new[] { "idPlates" });
>>>>>>>> Stashed changes:Migrations/202405312152420_InitialMigration.cs
            DropIndex("dbo.MenuExtras", new[] { "idExtras" });
            DropTable("dbo.Tickets");
            DropTable("dbo.Reservations");
            DropTable("dbo.ItemReceipts");
            DropTable("dbo.Receipts");
<<<<<<<< Updated upstream:Migrations/202405312009227_update.cs
            DropTable("dbo.MenuPlates");
            DropTable("dbo.Plates");
========
>>>>>>>> Stashed changes:Migrations/202405312152420_InitialMigration.cs
            DropTable("dbo.Menus");
            DropTable("dbo.Plates");
            DropTable("dbo.MenuPlates");
            DropTable("dbo.MenuExtras");
            DropTable("dbo.Extras");
            DropTable("dbo.Users");
        }
    }
}
