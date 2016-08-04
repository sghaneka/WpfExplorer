using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.DomainClasses.AngularJsForNetCourse.Models;

namespace Explorer.DataLayer.AngularJsForNetCourse
{
    public interface ICourseModelContext
    {
        IDbSet<Course> Courses { get; set; }

        IDbSet<Instructor> Instructors { get; set; } 
    }
}
