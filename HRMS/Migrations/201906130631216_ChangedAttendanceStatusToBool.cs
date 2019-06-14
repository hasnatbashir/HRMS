namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedAttendanceStatusToBool : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Attendances", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Attendances", "Status", c => c.String());
        }
    }
}
