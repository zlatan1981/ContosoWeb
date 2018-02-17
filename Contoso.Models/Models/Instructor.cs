using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Model {

    [Table("Instructors")]
    public class Instructor {

        [Key, ForeignKey("Person")]
        public int Id { get; set; }
        public virtual Person Person { get; set; }
        public DateTime? HireDate { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual OfficeAssignments OfficeAssignments { get; set; }

    }
}
