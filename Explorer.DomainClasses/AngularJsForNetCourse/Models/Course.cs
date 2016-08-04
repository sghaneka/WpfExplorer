using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.DomainClasses.AngularJsForNetCourse.Models
{
     [Table("c0_Course")]
    public class Course
    {
        public int CourseId { get; set; }
        [MaxLength(50)]
        public string Number { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public virtual Instructor Instructor { get; set; }

    }
}
