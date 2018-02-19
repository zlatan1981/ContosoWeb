namespace Contoso.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addGradeEnumToEnrollmentTbl : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Enrollments", "Grade", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Enrollments", "Grade", c => c.Double());
        }
    }
}
