namespace SkillageApp.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inital : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DailyPrices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExchangeId = c.Int(nullable: false),
                        StockSymbolId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        StockPriceOpen = c.Double(nullable: false),
                        StockPriceHigh = c.Double(nullable: false),
                        StockPriceLow = c.Double(nullable: false),
                        StockPriceClose = c.Double(nullable: false),
                        StockVolume = c.Long(nullable: false),
                        StockPriceAdjClose = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exchanges", t => t.ExchangeId, cascadeDelete: true)
                .ForeignKey("dbo.StockSymbols", t => t.StockSymbolId, cascadeDelete: true)
                .Index(t => t.ExchangeId)
                .Index(t => t.StockSymbolId);
            
            CreateTable(
                "dbo.Exchanges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 50),
                        Name = c.String(maxLength: 255),
                        Description = c.String(maxLength: 1000),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StockSymbols",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 255),
                        Name = c.String(maxLength: 255),
                        Description = c.String(maxLength: 1000),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DailyPrices", "StockSymbolId", "dbo.StockSymbols");
            DropForeignKey("dbo.DailyPrices", "ExchangeId", "dbo.Exchanges");
            DropIndex("dbo.DailyPrices", new[] { "StockSymbolId" });
            DropIndex("dbo.DailyPrices", new[] { "ExchangeId" });
            DropTable("dbo.StockSymbols");
            DropTable("dbo.Exchanges");
            DropTable("dbo.DailyPrices");
        }
    }
}
