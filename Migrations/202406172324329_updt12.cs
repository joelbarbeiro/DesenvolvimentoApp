namespace iCantine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updt12 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Extras",
                c => new
                    {
                        idExtra = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Active = c.Boolean(nullable: false),
                        Stock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idExtra);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        idMenu = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        QuantAvailable = c.Int(nullable: false),
                        PriceStudent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceProf = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.idMenu);
            
            CreateTable(
                "dbo.Plates",
                c => new
                    {
                        idPlate = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Type = c.String(),
                        Stock = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.idPlate);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        idReservation = c.Int(nullable: false, identity: true),
                        Active = c.Boolean(nullable: false),
                        Clients_idUser = c.Int(),
                        Menus_idMenu = c.Int(),
                        Plates_idPlate = c.Int(),
                        Tickets_idTicket = c.Int(),
                    })
                .PrimaryKey(t => t.idReservation)
                .ForeignKey("dbo.Users", t => t.Clients_idUser)
                .ForeignKey("dbo.Menus", t => t.Menus_idMenu)
                .ForeignKey("dbo.Plates", t => t.Plates_idPlate)
                .ForeignKey("dbo.Tickets", t => t.Tickets_idTicket)
                .Index(t => t.Clients_idUser)
                .Index(t => t.Menus_idMenu)
                .Index(t => t.Plates_idPlate)
                .Index(t => t.Tickets_idTicket);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        idUser = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        nif = c.Int(nullable: false),
                        Balance = c.Decimal(precision: 18, scale: 2),
                        email = c.String(),
                        studentNumber = c.Int(),
                        username = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Receipt_idReceipt = c.Int(),
                    })
                .PrimaryKey(t => t.idUser)
                .ForeignKey("dbo.Receipts", t => t.Receipt_idReceipt)
                .Index(t => t.Receipt_idReceipt);
            
            CreateTable(
                "dbo.Receipts",
                c => new
                    {
                        idReceipt = c.Int(nullable: false, identity: true),
                        Total = c.Double(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Menus_idMenu = c.Int(),
                    })
                .PrimaryKey(t => t.idReceipt)
                .ForeignKey("dbo.Menus", t => t.Menus_idMenu)
                .Index(t => t.Menus_idMenu);
            
            CreateTable(
                "dbo.ItemReceipts",
                c => new
                    {
                        idItemReceipt = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Price = c.Double(nullable: false),
                        Receipts_idReceipt = c.Int(),
                    })
                .PrimaryKey(t => t.idItemReceipt)
                .ForeignKey("dbo.Receipts", t => t.Receipts_idReceipt)
                .Index(t => t.Receipts_idReceipt);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        idTicket = c.Int(nullable: false, identity: true),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NumHours = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idTicket);
            
            CreateTable(
                "dbo.MenuExtras",
                c => new
                    {
                        Menu_idMenu = c.Int(nullable: false),
                        Extra_idExtra = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Menu_idMenu, t.Extra_idExtra })
                .ForeignKey("dbo.Menus", t => t.Menu_idMenu, cascadeDelete: true)
                .ForeignKey("dbo.Extras", t => t.Extra_idExtra, cascadeDelete: true)
                .Index(t => t.Menu_idMenu)
                .Index(t => t.Extra_idExtra);
            
            CreateTable(
                "dbo.PlateMenus",
                c => new
                    {
                        Plate_idPlate = c.Int(nullable: false),
                        Menu_idMenu = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Plate_idPlate, t.Menu_idMenu })
                .ForeignKey("dbo.Plates", t => t.Plate_idPlate, cascadeDelete: true)
                .ForeignKey("dbo.Menus", t => t.Menu_idMenu, cascadeDelete: true)
                .Index(t => t.Plate_idPlate)
                .Index(t => t.Menu_idMenu);
            
            CreateTable(
                "dbo.ReservationExtras",
                c => new
                    {
                        Reservation_idReservation = c.Int(nullable: false),
                        Extra_idExtra = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Reservation_idReservation, t.Extra_idExtra })
                .ForeignKey("dbo.Reservations", t => t.Reservation_idReservation, cascadeDelete: true)
                .ForeignKey("dbo.Extras", t => t.Extra_idExtra, cascadeDelete: true)
                .Index(t => t.Reservation_idReservation)
                .Index(t => t.Extra_idExtra);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "Tickets_idTicket", "dbo.Tickets");
            DropForeignKey("dbo.Reservations", "Plates_idPlate", "dbo.Plates");
            DropForeignKey("dbo.Reservations", "Menus_idMenu", "dbo.Menus");
            DropForeignKey("dbo.ReservationExtras", "Extra_idExtra", "dbo.Extras");
            DropForeignKey("dbo.ReservationExtras", "Reservation_idReservation", "dbo.Reservations");
            DropForeignKey("dbo.Reservations", "Clients_idUser", "dbo.Users");
            DropForeignKey("dbo.Receipts", "Menus_idMenu", "dbo.Menus");
            DropForeignKey("dbo.ItemReceipts", "Receipts_idReceipt", "dbo.Receipts");
            DropForeignKey("dbo.Users", "Receipt_idReceipt", "dbo.Receipts");
            DropForeignKey("dbo.PlateMenus", "Menu_idMenu", "dbo.Menus");
            DropForeignKey("dbo.PlateMenus", "Plate_idPlate", "dbo.Plates");
            DropForeignKey("dbo.MenuExtras", "Extra_idExtra", "dbo.Extras");
            DropForeignKey("dbo.MenuExtras", "Menu_idMenu", "dbo.Menus");
            DropIndex("dbo.ReservationExtras", new[] { "Extra_idExtra" });
            DropIndex("dbo.ReservationExtras", new[] { "Reservation_idReservation" });
            DropIndex("dbo.PlateMenus", new[] { "Menu_idMenu" });
            DropIndex("dbo.PlateMenus", new[] { "Plate_idPlate" });
            DropIndex("dbo.MenuExtras", new[] { "Extra_idExtra" });
            DropIndex("dbo.MenuExtras", new[] { "Menu_idMenu" });
            DropIndex("dbo.ItemReceipts", new[] { "Receipts_idReceipt" });
            DropIndex("dbo.Receipts", new[] { "Menus_idMenu" });
            DropIndex("dbo.Users", new[] { "Receipt_idReceipt" });
            DropIndex("dbo.Reservations", new[] { "Tickets_idTicket" });
            DropIndex("dbo.Reservations", new[] { "Plates_idPlate" });
            DropIndex("dbo.Reservations", new[] { "Menus_idMenu" });
            DropIndex("dbo.Reservations", new[] { "Clients_idUser" });
            DropTable("dbo.ReservationExtras");
            DropTable("dbo.PlateMenus");
            DropTable("dbo.MenuExtras");
            DropTable("dbo.Tickets");
            DropTable("dbo.ItemReceipts");
            DropTable("dbo.Receipts");
            DropTable("dbo.Users");
            DropTable("dbo.Reservations");
            DropTable("dbo.Plates");
            DropTable("dbo.Menus");
            DropTable("dbo.Extras");
        }
    }
}
