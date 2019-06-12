namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedValidationInEmployee : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Password", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Password", c => c.String(nullable: false));
        }
    }
}
