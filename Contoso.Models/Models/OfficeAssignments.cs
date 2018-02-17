using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Model {

    [Table("OfficeAssignments")]
    public class OfficeAssignments {
        [Key, ForeignKey("Instructor")]
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
        [MaxLength(30)]
        public string Location { get; set; }
        public DateTime CreatedAt { get; set; }
        [Required]
        public string CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }
        public string UpdateBy { get; set; }
    }
}
