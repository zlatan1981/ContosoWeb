using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contoso.Model;

namespace Contoso.Data {

    public class ContosoContext : DbContext {

        public ContosoContext() : base("name=ContosoWebString") {

        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<OfficeAssignments> OfficeAssignments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<Person>().HasMany(p => p.Roles)
                .WithMany(r => r.Persons).Map(
                m => {
                    m.MapLeftKey("PersonId");
                    m.MapRightKey("RoleId");
                    m.ToTable("PersonRoles");
                });
        }



    }
}
