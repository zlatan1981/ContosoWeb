﻿using Contoso.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Model {

    [Table("Instructors")]
    public class Instructor : AudibleEntity {

        [Key, ForeignKey("Person")]
        public override int Id { get; set; }
        public virtual Person Person { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? HireDate { get; set; }
        [JsonIgnore]
        public ICollection<Course> Courses { get; set; }
        [JsonIgnore]
        public OfficeAssignments OfficeAssignments { get; set; }

        public Instructor() {
            CreatedAt = DateTime.Now;
        }

    }
}
