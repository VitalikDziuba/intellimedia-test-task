namespace Intellimedia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DepartmentStructures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Gender = c.Int(nullable: false),
                        ContactInformation = c.String(),
                        DateOfAdding = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PersonnelTimes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateOfBeginning = c.DateTime(nullable: false),
                        DateOfEnding = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Cars");
            DropTable("dbo.Orders");
            DropTable("dbo.Services");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                        AeroportOrRailwayStation = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OneHour = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OneKilometer = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OneDay = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaxPeriod = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OneLiter = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartAddressCar = c.String(nullable: false, maxLength: 100),
                        DateOfStart = c.DateTime(nullable: false),
                        DateOfEnd = c.DateTime(nullable: false),
                        CarModel = c.String(nullable: false, maxLength: 40),
                        CarId = c.Int(nullable: false),
                        CustomerFullName = c.String(nullable: false, maxLength: 50),
                        CustomerEmail = c.String(nullable: false),
                        CustomerPhoneNumber = c.String(nullable: false, maxLength: 10),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Transfer = c.Boolean(nullable: false),
                        BabySeat = c.Boolean(nullable: false),
                        GPS = c.Boolean(nullable: false),
                        AdditionalDriver = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Model = c.String(nullable: false, maxLength: 40),
                        PhotoUrl = c.String(nullable: false),
                        PriceMaxTwoDays = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceMaxSevenDays = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceMoreThenEightDays = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceMoreThenMonth = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateOfAddCar = c.DateTime(nullable: false),
                        Description = c.String(nullable: false, maxLength: 500),
                        EngineType = c.String(maxLength: 50),
                        EngineCapacity = c.String(maxLength: 50),
                        FuelSupplySystem = c.String(maxLength: 50),
                        MaxPower = c.String(maxLength: 50),
                        Torque = c.String(maxLength: 50),
                        Transmission = c.String(maxLength: 30),
                        WheelDrive = c.String(maxLength: 30),
                        CurbWeight = c.String(maxLength: 30),
                        FullWeight = c.String(maxLength: 30),
                        MaxSpeed = c.String(maxLength: 10),
                        AccelerationToEighty = c.String(maxLength: 10),
                        AccelerationToHundred = c.String(maxLength: 10),
                        Fuel = c.String(maxLength: 20),
                        InTheCity = c.String(maxLength: 10),
                        OnTheHighway = c.String(maxLength: 10),
                        Combined = c.String(maxLength: 10),
                        ExtentFuelTank = c.String(maxLength: 10),
                        Length = c.String(maxLength: 10),
                        Width = c.String(maxLength: 10),
                        Height = c.String(maxLength: 10),
                        WheelBase = c.String(maxLength: 10),
                        TrackFront = c.String(maxLength: 10),
                        Clearance = c.String(maxLength: 10),
                        TheLuggageDefaultsFive = c.String(maxLength: 10),
                        TheLuggageWithFoldedSeatsFive = c.String(maxLength: 10),
                        TheLuggageDefaultsSeven = c.String(maxLength: 10),
                        TheLuggageWithFoldedSeatsSeven = c.String(maxLength: 10),
                        TheLuggageWithFoldedCombinedSeatsSeven = c.String(maxLength: 10),
                        Turning = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.PersonnelTimes");
            DropTable("dbo.Employees");
            DropTable("dbo.DepartmentStructures");
        }
    }
}
