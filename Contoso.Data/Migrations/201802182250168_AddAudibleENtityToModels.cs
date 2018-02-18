namespace Contoso.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAudibleENtityToModels : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.OfficeAssignments", name: "InstructorId", newName: "Id");
            RenameIndex(table: "dbo.OfficeAssignments", name: "IX_InstructorId", newName: "IX_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.OfficeAssignments", name: "IX_Id", newName: "IX_InstructorId");
            RenameColumn(table: "dbo.OfficeAssignments", name: "Id", newName: "InstructorId");
        }
    }
}
