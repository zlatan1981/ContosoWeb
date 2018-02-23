using Contoso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Models.ViewModels {
    public class StuCoursEnrollViewModel {

        public Student Student { get; set; }
        public List<Course> Courses { get; set; }
    }
}
