using Contoso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Models.ViewModels {
    public class StudentPerson {
        public Person Person { get; set; }
        public Student Student { get; set; }
    }
}
