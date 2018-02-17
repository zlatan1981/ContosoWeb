using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Contoso.Model {

    [Table("Departments")]
    public class Department {

        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdateBy { get; set; }
        [ForeignKey("Instructor")]
        public int? InstrutorId { get; set; }
        public Instructor Instructor { get; set; }
        public ICollection<Course> Courses { get; set; }

    }
}
