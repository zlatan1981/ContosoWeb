namespace Contoso.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addsomeRequiredAnnotationtoSomeModels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "Name", c => c.String(nullable: false, maxLength: 70));
            AlterColumn("dbo.Departments", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Departments", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.Courses", "Name", c => c.String(maxLength: 70));
        }
    }
}
