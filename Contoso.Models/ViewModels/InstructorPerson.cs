using Contoso.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Contoso.Models.ViewModels {
    public class InstructorPerson {
        [Required]
        public Person Person { get; set; }
        [Required]
        public Instructor Instructor { get; set; }
    }
}