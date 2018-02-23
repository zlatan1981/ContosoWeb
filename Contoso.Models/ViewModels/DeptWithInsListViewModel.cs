using Contoso.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Contoso.Models.ViewModels {
    public class DeptWithInsListViewModel {
        public Department Department { get; set; }
        // this will include a drop down list on the department create page to allow the user to select a instructor
        public InstructorSelectList InsList { get; set; }

    }

    public class InstructorSelectList {

        public List<Instructor> _instructors { get; set; }


        [Display(Name = "Instructor")]
        public int SelectedInstructorId { get; set; }

        public IEnumerable<SelectListItem> InstructorItems {
            get {
                var ins = _instructors.Select(i => new {
                    Id = i.Id,
                    FullName = i.Person.FirstName + " " + i.Person.LastName
                });


                return new SelectList(ins, "Id", "FullName");
            }
        }
    }
}
