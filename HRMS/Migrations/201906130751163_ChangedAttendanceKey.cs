namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedAttendanceKey : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Attendances");
            AddColumn("dbo.Attendances", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Attendances", "ID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Attendances");
            DropColumn("dbo.Attendances", "ID");
            AddPrimaryKey("dbo.Attendances", "Date");
        }
    }
}
