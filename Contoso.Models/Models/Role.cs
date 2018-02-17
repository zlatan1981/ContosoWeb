using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Model {

    [Table("Roles")]
    public class Role {
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string RoleName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        [Required]
        public string CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }
        public string UpdateBy { get; set; }
        public virtual ICollection<Person> Persons { get; set; }


    }
}
