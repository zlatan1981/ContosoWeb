using Contoso.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Models.ViewModels {
    public class StudentPerson {
        [Required]
        public Person Person { get; set; }
        [Required]
        public Student Student { get; set; }
    }
}
