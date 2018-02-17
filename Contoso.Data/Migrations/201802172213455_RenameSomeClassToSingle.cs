namespace Contoso.Data.Migrations {
    using System;
    using System.Data.Entity.Migrations;

    public partial class RenameSomeClassToSingle : DbMigration {
        public override void Up() {
            RenameTable(name: "dbo.RolesPersons", newName: "PersonRoles");
            RenameColumn(table: "dbo.PersonRoles", name: "Roles_Id", newName: "Role_Id");
            RenameIndex(table: "dbo.PersonRoles", name: "IX_Roles_Id", newName: "IX_Role_Id");
        }

        public override void Down() {
            RenameIndex(table: "dbo.PersonRoles", name: "IX_Role_Id", newName: "IX_Roles_Id");
            RenameColumn(table: "dbo.PersonRoles", name: "Role_Id", newName: "Roles_Id");
            RenameTable(name: "dbo.PersonRoles", newName: "RolesPersons");
        }
    }
}
