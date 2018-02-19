namespace Contoso.Data.Migrations {
    using System;
    using System.Data.Entity.Migrations;

    public partial class RenameRolePersonTbl : DbMigration {
        public override void Up() {
            RenameTable("dbo.RolePersons", "PersonRoles");
        }

        public override void Down() {
            RenameTable("dbo.PersonRoles", "RolePersons");
        }
    }
}
