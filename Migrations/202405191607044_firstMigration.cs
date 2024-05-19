namespace iCantine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstMigration : DbMigration
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
                        Balance = c.Double(),
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
                        Menu_idMenu = c.Int(),
                    })
                .PrimaryKey(t => t.idExtra)
                .ForeignKey("dbo.Menus", t => t.Menu_idMenu)
                .Index(t => t.Menu_idMenu);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        idMenu = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        QuantAvailable = c.Int(nullable: false),
                        PriceStudent = c.Double(nullable: false),
                        PriceProf = c.Double(nullable: false),
                        Receipt_idReceipt = c.Int(),
                    })
                .PrimaryKey(t => t.idMenu)
                .ForeignKey("dbo.Receipts", t => t.Receipt_idReceipt)
                .Index(t => t.Receipt_idReceipt);
            
            CreateTable(
                "dbo.Plates",
                c => new
                    {
                        idPlate = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Active = c.Boolean(nullable: false),
                        Menu_idMenu = c.Int(),
                    })
                .PrimaryKey(t => t.idPlate)
                .ForeignKey("dbo.Menus", t => t.Menu_idMenu)
                .Index(t => t.Menu_idMenu);
            
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
            DropForeignKey("dbo.Plates", "Menu_idMenu", "dbo.Menus");
            DropForeignKey("dbo.Extras", "Menu_idMenu", "dbo.Menus");
            DropIndex("dbo.ItemReceipts", new[] { "Receipt_idReceipt" });
            DropIndex("dbo.Plates", new[] { "Menu_idMenu" });
            DropIndex("dbo.Menus", new[] { "Receipt_idReceipt" });
            DropIndex("dbo.Extras", new[] { "Menu_idMenu" });
            DropTable("dbo.Tickets");
            DropTable("dbo.Reservations");
            DropTable("dbo.ItemReceipts");
            DropTable("dbo.Receipts");
            DropTable("dbo.Plates");
            DropTable("dbo.Menus");
            DropTable("dbo.Extras");
            DropTable("dbo.Users");
        }
    }
}
