using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Explorer.Web.Mvc.ViewModels.AngularJsForNetCourse.Instructors;

namespace Explorer.Web.Mvc.ViewModels.AngularJsForNetCourse.Registration
{
    public class InstructorService
    {
        private readonly List<InstructorVm> _instructors; 
        public InstructorVm[] Instructors
        {
            get { return _instructors.ToArray(); }
        }

        private static InstructorService _service;

        public static InstructorService GetInstance()
        {
            return _service ?? (_service = new InstructorService());
        }

        private InstructorService()
        {
            _instructors = new List<InstructorVm>
            {
                new InstructorVm {Name = "Rubeus Hagrid", Email = "hagrid@hogwarts.com", RoomNumber = 1001},
                new InstructorVm {Name = "Severus Snape", Email = "snape@hogwarts.com", RoomNumber = 105},
                new InstructorVm {Name = "Minerva McGonagall", Email = "mcgonagall@hogwarts.com", RoomNumber = 102}
            };

        }

        public void AddInstructor(InstructorVm instructor)
        {
            _instructors.Add(instructor);
        }
    }
}