namespace Intellimedia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "TimeId", c => c.Int(nullable: false));
            AddColumn("dbo.PersonnelTimes", "TimeOfBeginning", c => c.Int(nullable: false));
            AddColumn("dbo.PersonnelTimes", "TimeOfEnding", c => c.Int(nullable: false));
            DropColumn("dbo.PersonnelTimes", "EmployeeId");
            DropColumn("dbo.PersonnelTimes", "DateOfBeginning");
            DropColumn("dbo.PersonnelTimes", "DateOfEnding");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PersonnelTimes", "DateOfEnding", c => c.DateTime(nullable: false));
            AddColumn("dbo.PersonnelTimes", "DateOfBeginning", c => c.DateTime(nullable: false));
            AddColumn("dbo.PersonnelTimes", "EmployeeId", c => c.Int(nullable: false));
            DropColumn("dbo.PersonnelTimes", "TimeOfEnding");
            DropColumn("dbo.PersonnelTimes", "TimeOfBeginning");
            DropColumn("dbo.Employees", "TimeId");
        }
    }
}
