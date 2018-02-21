using Contoso.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace Contoso.Models.ViewModels {
    public class InstructorSelectList {

        public List<Instructor> _instructors { get; set; }


        [Display(Name = "Instructor")]
        public int SelectedInstructorId { get; set; }

        public IEnumerable<SelectListItem> InstructorItems {
            get { return new SelectList(_instructors, "Id", "Id"); }
        }
    }
}
