using Contoso.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Model {

    [Table("OfficeAssignments")]
    public class OfficeAssignments : AudibleEntity {
        [Key, ForeignKey("Instructor")]
        public override int Id { get; set; }
        public Instructor Instructor { get; set; }
        [MaxLength(50)]
        public string Location { get; set; }

        public OfficeAssignments() {
            CreatedAt = DateTime.Now;
        }

    }
}
