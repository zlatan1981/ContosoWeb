using Contoso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Models.ViewModels {
    public class DeptWithInsListViewModel {
        public Department Department { get; set; }
        // this will include a drop down list on the department create page to allow the user to select a instructor
        public InstructorSelectList InsList { get; set; }

    }
}
