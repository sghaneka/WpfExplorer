using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.DomainClasses.AngularJsForNetCourse.Models
{
    [Table("c0_Instructor")]
    public class Instructor
    {
        public int InstructorId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Email { get; set; }
        public int RoomNumber { get; set; }
    }
}
