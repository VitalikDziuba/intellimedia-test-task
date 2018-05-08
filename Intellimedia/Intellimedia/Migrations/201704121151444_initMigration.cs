namespace Intellimedia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Model = c.String(),
                        PhotoUrl = c.String(),
                        PriceMaxTwoDays = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceMaxSevenDays = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceMoreThenEightDays = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceMoreThenMonth = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartAddressCar = c.String(),
                        DateOfStart = c.DateTime(nullable: false),
                        DateOfEnd = c.DateTime(nullable: false),
                        CarModel = c.String(),
                        CustomerFullName = c.String(),
                        CustomerEmail = c.String(),
                        CustomerPhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Transfers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                        AeroportOrRailwayStation = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OneHour = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OneKilometer = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Transfers");
            DropTable("dbo.Orders");
            DropTable("dbo.Cars");
        }
    }
}
