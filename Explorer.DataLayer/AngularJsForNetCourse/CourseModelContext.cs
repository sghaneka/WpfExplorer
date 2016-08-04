using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.DomainClasses.AngularJsForNetCourse.Models;

namespace Explorer.DataLayer.AngularJsForNetCourse
{
    public class CourseModelContext : DbContext, ICourseModelContext
    {
        public IDbSet<Course> Courses { get; set; }

        public IDbSet<Instructor> Instructors { get; set; }
    }
}
