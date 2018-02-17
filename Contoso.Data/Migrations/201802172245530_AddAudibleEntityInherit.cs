namespace Contoso.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAudibleEntityInherit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "UpdatedBy", c => c.String());
            AddColumn("dbo.Departments", "UpdatedBy", c => c.String());
            AddColumn("dbo.Instructors", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Instructors", "CreatedBy", c => c.String());
            AddColumn("dbo.Instructors", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.Instructors", "UpdatedBy", c => c.String());
            AddColumn("dbo.OfficeAssignments", "UpdatedBy", c => c.String());
            AddColumn("dbo.Person", "UpdatedBy", c => c.String());
            AddColumn("dbo.Roles", "UpdatedBy", c => c.String());
            AddColumn("dbo.Students", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Students", "CreatedBy", c => c.String());
            AddColumn("dbo.Students", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.Students", "UpdatedBy", c => c.String());
            AddColumn("dbo.Enrollments", "UpdatedBy", c => c.String());
            AlterColumn("dbo.Courses", "CreatedBy", c => c.String());
            AlterColumn("dbo.OfficeAssignments", "Location", c => c.String(maxLength: 50));
            AlterColumn("dbo.OfficeAssignments", "CreatedBy", c => c.String());
            AlterColumn("dbo.Person", "CreatedBy", c => c.String());
            AlterColumn("dbo.Roles", "CreatedBy", c => c.String());
            AlterColumn("dbo.Enrollments", "CreatedBy", c => c.String());
            DropColumn("dbo.Courses", "UpdateBy");
            DropColumn("dbo.Departments", "UpdateBy");
            DropColumn("dbo.OfficeAssignments", "UpdateBy");
            DropColumn("dbo.Person", "UpdateBy");
            DropColumn("dbo.Roles", "UpdateBy");
            DropColumn("dbo.Enrollments", "UpdateBy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Enrollments", "UpdateBy", c => c.String());
            AddColumn("dbo.Roles", "UpdateBy", c => c.String());
            AddColumn("dbo.Person", "UpdateBy", c => c.String());
            AddColumn("dbo.OfficeAssignments", "UpdateBy", c => c.String());
            AddColumn("dbo.Departments", "UpdateBy", c => c.String());
            AddColumn("dbo.Courses", "UpdateBy", c => c.String());
            AlterColumn("dbo.Enrollments", "CreatedBy", c => c.String(nullable: false));
            AlterColumn("dbo.Roles", "CreatedBy", c => c.String(nullable: false));
            AlterColumn("dbo.Person", "CreatedBy", c => c.String(nullable: false));
            AlterColumn("dbo.OfficeAssignments", "CreatedBy", c => c.String(nullable: false));
            AlterColumn("dbo.OfficeAssignments", "Location", c => c.String(maxLength: 30));
            AlterColumn("dbo.Courses", "CreatedBy", c => c.String(nullable: false));
            DropColumn("dbo.Enrollments", "UpdatedBy");
            DropColumn("dbo.Students", "UpdatedBy");
            DropColumn("dbo.Students", "UpdatedAt");
            DropColumn("dbo.Students", "CreatedBy");
            DropColumn("dbo.Students", "CreatedAt");
            DropColumn("dbo.Roles", "UpdatedBy");
            DropColumn("dbo.Person", "UpdatedBy");
            DropColumn("dbo.OfficeAssignments", "UpdatedBy");
            DropColumn("dbo.Instructors", "UpdatedBy");
            DropColumn("dbo.Instructors", "UpdatedAt");
            DropColumn("dbo.Instructors", "CreatedBy");
            DropColumn("dbo.Instructors", "CreatedAt");
            DropColumn("dbo.Departments", "UpdatedBy");
            DropColumn("dbo.Courses", "UpdatedBy");
        }
    }
}
