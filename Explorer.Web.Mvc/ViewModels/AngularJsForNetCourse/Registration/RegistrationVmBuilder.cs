using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Explorer.Web.Mvc.ViewModels.AngularJsForNetCourse.Courses;
using Explorer.Web.Mvc.ViewModels.AngularJsForNetCourse.Instructors;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Explorer.Web.Mvc.ViewModels.AngularJsForNetCourse.Registration
{
    public class RegistrationVmBuilder
    {
        public RegistrationVm BuildRegistrationVm()
        {
            var registrationVm = new RegistrationVm
            {
                Courses = GetSerializedCourseVms(),
                Instructors = GetSerializedInstructors()
            };
            return registrationVm;
        }

        public string GetSerializedCourseVms()
        {
            var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            return JsonConvert.SerializeObject(GetCourseVms(), Formatting.None, settings);
        }

        public string GetSerializedInstructors()
        {
            var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            return JsonConvert.SerializeObject(GetInstructorVms(), Formatting.None, settings);
        }

        public CourseVm[] GetCourseVms()
        {
            var courses = new[]
            {
                new CourseVm {Number = "CREA101", Name = "Care of Magical Creatures", Instructor = "Rubeus Hagrid"},
                new CourseVm {Number = "DARK502", Name = "Defence Against the Dark Arts", Instructor = "Severus Snape"},
                new CourseVm {Number = "TRAN201", Name = "Transfiguration", Instructor = "Minerva McGonagall"}
            };

            return courses;
        }

        public InstructorVm[] GetInstructorVms()
        {
            var service = InstructorService.GetInstance();
            return service.Instructors;
        }
    }
}