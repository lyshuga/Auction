namespace Auction.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Lots", "BidderId", "dbo.ApplicationProfiles");
            DropForeignKey("dbo.Lots", "SellerId", "dbo.ApplicationProfiles");
            DropIndex("dbo.Lots", new[] { "BidderId" });
            RenameColumn(table: "dbo.Lots", name: "SellerId", newName: "Seller_Id");
            RenameIndex(table: "dbo.Lots", name: "IX_SellerId", newName: "IX_Seller_Id");
            CreateTable(
                "dbo.Bids",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Time = c.DateTime(nullable: false),
                        Bidder_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationProfiles", t => t.Bidder_Id, cascadeDelete: true)
                .ForeignKey("dbo.Lots", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.Bidder_Id);
            
            AddColumn("dbo.Lots", "StartPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddForeignKey("dbo.Lots", "Seller_Id", "dbo.ApplicationProfiles", "Id", cascadeDelete: true);
            DropColumn("dbo.Lots", "BidderId");
            DropColumn("dbo.Lots", "Price");
            DropColumn("dbo.Lots", "LastBid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lots", "LastBid", c => c.DateTime(nullable: false));
            AddColumn("dbo.Lots", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Lots", "BidderId", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.Lots", "Seller_Id", "dbo.ApplicationProfiles");
            DropForeignKey("dbo.Bids", "Id", "dbo.Lots");
            DropForeignKey("dbo.Bids", "Bidder_Id", "dbo.ApplicationProfiles");
            DropIndex("dbo.Bids", new[] { "Bidder_Id" });
            DropIndex("dbo.Bids", new[] { "Id" });
            DropColumn("dbo.Lots", "StartPrice");
            DropTable("dbo.Bids");
            RenameIndex(table: "dbo.Lots", name: "IX_Seller_Id", newName: "IX_SellerId");
            RenameColumn(table: "dbo.Lots", name: "Seller_Id", newName: "SellerId");
            CreateIndex("dbo.Lots", "BidderId");
            AddForeignKey("dbo.Lots", "SellerId", "dbo.ApplicationProfiles", "Id");
            AddForeignKey("dbo.Lots", "BidderId", "dbo.ApplicationProfiles", "Id");
        }
    }
}
