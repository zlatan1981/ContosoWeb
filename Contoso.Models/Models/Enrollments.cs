using Contoso.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Model {

    [Table("Enrollments")]
    public class Enrollment : AudibleEntity {
        public int Id { get; set; }
        [ForeignKey("Course")]
        public int? CourseId { get; set; }
        public Course Course { get; set; }
        [ForeignKey("Student")]
        public int? StudentId { get; set; }
        public Student Student { get; set; }
        public double? Grade { get; set; }

        public Enrollment() {
            CreatedAt = DateTime.Now;
        }

    }
}
