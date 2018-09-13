namespace Auction.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bids", "Id", "dbo.Lots");
            DropIndex("dbo.Bids", new[] { "Id" });
            AddColumn("dbo.Bids", "Lot_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Bids", "Lot_Id");
            AddForeignKey("dbo.Bids", "Lot_Id", "dbo.Lots", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bids", "Lot_Id", "dbo.Lots");
            DropIndex("dbo.Bids", new[] { "Lot_Id" });
            DropColumn("dbo.Bids", "Lot_Id");
            CreateIndex("dbo.Bids", "Id");
            AddForeignKey("dbo.Bids", "Id", "dbo.Lots", "Id");
        }
    }
}
