namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedValidationEmployee : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "ImageUrl", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "FatherName", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "AccountHolderName", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "AccountNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "BankName", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Branch", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Password", c => c.String());
            AlterColumn("dbo.Employees", "Email", c => c.String());
            AlterColumn("dbo.Employees", "Branch", c => c.String());
            AlterColumn("dbo.Employees", "BankName", c => c.String());
            AlterColumn("dbo.Employees", "AccountNumber", c => c.String());
            AlterColumn("dbo.Employees", "AccountHolderName", c => c.String());
            AlterColumn("dbo.Employees", "Address", c => c.String());
            AlterColumn("dbo.Employees", "Phone", c => c.String());
            AlterColumn("dbo.Employees", "FatherName", c => c.String());
            AlterColumn("dbo.Employees", "Name", c => c.String());
            AlterColumn("dbo.Employees", "ImageUrl", c => c.String());
        }
    }
}
