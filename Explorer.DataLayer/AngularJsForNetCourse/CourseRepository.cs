using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.DomainClasses.AngularJsForNetCourse.Models;

namespace Explorer.DataLayer.AngularJsForNetCourse
{
    public class CourseRepository : ICourseRepository
    {
        private ICourseModelContext _context;

        public CourseRepository(ICourseModelContext context)
        {
            _context = context;
        }

        public void Add(Course newCourse)
        {
            _context.Courses.Add(newCourse);
        }

        public void Remove(Course course)
        {
            
        }

        public IQueryable<Course> Find(System.Linq.Expressions.Expression<Func<Course, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
