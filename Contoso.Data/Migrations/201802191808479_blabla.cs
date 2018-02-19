namespace Contoso.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class blabla : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.RolePersons", newName: "PersonRoles");
            RenameColumn(table: "dbo.PersonRoles", name: "Role_Id", newName: "RoleId");
            RenameColumn(table: "dbo.PersonRoles", name: "Person_Id", newName: "PersonId");
            RenameIndex(table: "dbo.PersonRoles", name: "IX_Person_Id", newName: "IX_PersonId");
            RenameIndex(table: "dbo.PersonRoles", name: "IX_Role_Id", newName: "IX_RoleId");
            DropPrimaryKey("dbo.PersonRoles");
            AddPrimaryKey("dbo.PersonRoles", new[] { "PersonId", "RoleId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.PersonRoles");
            AddPrimaryKey("dbo.PersonRoles", new[] { "Role_Id", "Person_Id" });
            RenameIndex(table: "dbo.PersonRoles", name: "IX_RoleId", newName: "IX_Role_Id");
            RenameIndex(table: "dbo.PersonRoles", name: "IX_PersonId", newName: "IX_Person_Id");
            RenameColumn(table: "dbo.PersonRoles", name: "PersonId", newName: "Person_Id");
            RenameColumn(table: "dbo.PersonRoles", name: "RoleId", newName: "Role_Id");
            RenameTable(name: "dbo.PersonRoles", newName: "RolePersons");
        }
    }
}
