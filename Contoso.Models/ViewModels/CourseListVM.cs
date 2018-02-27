using Contoso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Models.ViewModels {
    public class CourseListVM {
        public List<CheckedCourse> Courses { get; set; }
    }
    // a view model used for a checked course for checkbox list display
    public class CheckedCourse {
        public Course Course { get; set; }
        public bool IsChecked { get; set; }

        public CheckedCourse(Course c) {
            Course = c;
            IsChecked = false;
        }
    }


}
