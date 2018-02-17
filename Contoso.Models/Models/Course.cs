using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Model {

    [Table("Courses")]
    public class Course {

        public int Id { get; set; }
        public string Name { get; set; }

        public int Credits { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public DateTime CreatedAt { get; set; }
        [Required]
        public string CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }
        public string UpdateBy { get; set; }



        public virtual ICollection<Instructor> Instructors { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }


    }
}
