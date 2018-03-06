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
    [Table("Person")]
    public class Person : AudibleEntity {

        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        [Required, MaxLength(50)]
        public string LastName { get; set; }
        [NotMapped]
        [Display(Name = "Name")]
        [JsonIgnore]
        public string FullName { get { return FirstName + " " + LastName; } set { FullName = value; } }
        [MaxLength(50)]
        public string MiddleName { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(20)]
        public string Phone { get; set; }
        [MaxLength(20)]
        public string AddLine1 { get; set; }
        [MaxLength(20)]
        public string AddLine2 { get; set; }
        [MaxLength(30)]
        public string City { get; set; }
        [MaxLength(2)]
        public string State { get; set; }
        [MaxLength(10)]
        public string ZipCode { get; set; }

        [MaxLength(50)]
        public string Password { get; set; }
        public string Salt { get; set; }
        public bool? IsLocked { get; set; }
        public DateTime? LastLockedDateTime { get; set; }
        public int? FailedAttempts { get; set; }
        public DateTime? DateofBirth { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
        [JsonIgnore]
        public virtual Student Student { get; set; }
        [JsonIgnore]
        public virtual Instructor Instructor { get; set; }

        public Person() {
            CreatedAt = DateTime.Now;
        }


    }
}
