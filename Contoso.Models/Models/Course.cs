using Contoso.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Model {

    [Table("Courses")]
    public class Course : AudibleEntity {

        [MaxLength(70)]
        [Required]
        public string Name { get; set; }
        [Range(1, 4)]
        [Required]
        public int Credits { get; set; }
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }

        public Course() {
            CreatedAt = DateTime.Now;
        }
        [JsonIgnore]
        public virtual ICollection<Instructor> Instructors { get; set; }
        [JsonIgnore]
        public virtual ICollection<Enrollment> Enrollments { get; set; }


    }
}
