namespace Contoso.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContosoWebFirst : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Credits = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdateBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Budget = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        UpdatedAt = c.DateTime(),
                        UpdateBy = c.String(),
                        InstrutorId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Instructors", t => t.InstrutorId)
                .Index(t => t.InstrutorId);
            
            CreateTable(
                "dbo.Instructors",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        HireDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Person", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.OfficeAssignments",
                c => new
                    {
                        InstructorId = c.Int(nullable: false),
                        Location = c.String(maxLength: 30),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdateBy = c.String(),
                    })
                .PrimaryKey(t => t.InstructorId)
                .ForeignKey("dbo.Instructors", t => t.InstructorId)
                .Index(t => t.InstructorId);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        MiddleName = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Phone = c.String(maxLength: 20),
                        AddLine1 = c.String(maxLength: 20),
                        AddLine2 = c.String(maxLength: 20),
                        City = c.String(maxLength: 30),
                        State = c.String(maxLength: 2),
                        ZipCode = c.String(maxLength: 10),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdateBy = c.String(),
                        Password = c.String(maxLength: 50),
                        Salt = c.String(),
                        IsLocked = c.Boolean(),
                        LastLockedDateTime = c.DateTime(),
                        FailedAttempts = c.Int(),
                        DateofBirth = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(nullable: false, maxLength: 50),
                        Description = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdateBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        EnrollmentDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Person", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Enrollments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(),
                        StudentId = c.Int(),
                        Grade = c.Double(),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        UpdatedAt = c.DateTime(),
                        UpdateBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .Index(t => t.CourseId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.InstructorCourses",
                c => new
                    {
                        Instructor_Id = c.Int(nullable: false),
                        Course_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Instructor_Id, t.Course_Id })
                .ForeignKey("dbo.Instructors", t => t.Instructor_Id, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_Id, cascadeDelete: true)
                .Index(t => t.Instructor_Id)
                .Index(t => t.Course_Id);
            
            CreateTable(
                "dbo.RolesPersons",
                c => new
                    {
                        Roles_Id = c.Int(nullable: false),
                        Person_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Roles_Id, t.Person_Id })
                .ForeignKey("dbo.Roles", t => t.Roles_Id, cascadeDelete: true)
                .ForeignKey("dbo.Person", t => t.Person_Id, cascadeDelete: true)
                .Index(t => t.Roles_Id)
                .Index(t => t.Person_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Departments", "InstrutorId", "dbo.Instructors");
            DropForeignKey("dbo.Instructors", "Id", "dbo.Person");
            DropForeignKey("dbo.Students", "Id", "dbo.Person");
            DropForeignKey("dbo.Enrollments", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Enrollments", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.RolesPersons", "Person_Id", "dbo.Person");
            DropForeignKey("dbo.RolesPersons", "Roles_Id", "dbo.Roles");
            DropForeignKey("dbo.OfficeAssignments", "InstructorId", "dbo.Instructors");
            DropForeignKey("dbo.InstructorCourses", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.InstructorCourses", "Instructor_Id", "dbo.Instructors");
            DropForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.RolesPersons", new[] { "Person_Id" });
            DropIndex("dbo.RolesPersons", new[] { "Roles_Id" });
            DropIndex("dbo.InstructorCourses", new[] { "Course_Id" });
            DropIndex("dbo.InstructorCourses", new[] { "Instructor_Id" });
            DropIndex("dbo.Enrollments", new[] { "StudentId" });
            DropIndex("dbo.Enrollments", new[] { "CourseId" });
            DropIndex("dbo.Students", new[] { "Id" });
            DropIndex("dbo.OfficeAssignments", new[] { "InstructorId" });
            DropIndex("dbo.Instructors", new[] { "Id" });
            DropIndex("dbo.Departments", new[] { "InstrutorId" });
            DropIndex("dbo.Courses", new[] { "DepartmentId" });
            DropTable("dbo.RolesPersons");
            DropTable("dbo.InstructorCourses");
            DropTable("dbo.Enrollments");
            DropTable("dbo.Students");
            DropTable("dbo.Roles");
            DropTable("dbo.Person");
            DropTable("dbo.OfficeAssignments");
            DropTable("dbo.Instructors");
            DropTable("dbo.Departments");
            DropTable("dbo.Courses");
        }
    }
}
