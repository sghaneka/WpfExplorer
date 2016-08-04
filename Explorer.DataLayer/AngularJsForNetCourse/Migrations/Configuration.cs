using System.Data.Entity.Migrations;
using Explorer.DomainClasses.AngularJsForNetCourse.Models;

namespace Explorer.DataLayer.AngularJsForNetCourse.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<CourseModelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(CourseModelContext context)
        {
            var instructor0 = new Instructor
            {
                Name = "Rubeus Hagrid",
                Email = "hagrid@hogwarts.com",
                RoomNumber = 1001
            };

            var instructor1 = new Instructor
            {
                Name = "Severus Snape",
                Email = "snape@hogwarts.com",
                RoomNumber = 105 
            };

            var instructor2 = new Instructor
            {
                Name = "Minerva McGonagall",
                Email = "mcgonagall@hogwarts.com",
                RoomNumber = 102
            };

            var course0 = new Course
            {
                Number = "CREA101",
                Name = "Care of Magical Creatures",
                Instructor = instructor0
            };

            var course1 = new Course
            {
                Number = "DARK502",
                Name = "Defence Against the Dark Arts",
                Instructor = instructor1
            };

            var course2 = new Course
            {
                Number = "TRAN201",
                Name = "Transfiguration",
                Instructor = instructor2
            };

            context.Instructors.AddOrUpdate(x => x.Name, new []{ instructor0, instructor1, instructor2});
            context.Courses.AddOrUpdate(x => x.Number, new[] { course0, course1, course2 });

            context.SaveChanges();
        }
    }
}
