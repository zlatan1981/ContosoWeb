using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Model {
    [Table("Students")]
    public class Student {
        [Key, ForeignKey("Person")]
        public int Id { get; set; }
        public virtual Person Person { get; set; }
        public DateTime? EnrollmentDate { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }


    }
}
