using Contoso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoWeb.ViewModels {
    public class InstructorPerson {
        public Person Person { get; set; }
        public Instructor Instructor { get; set; }
    }
}