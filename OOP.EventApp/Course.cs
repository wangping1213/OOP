using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP.EventApp
{
    class Course
    {
        public Course(string courseName, int courseId, string teacher, int courseHour)
        {
            CourseHour = courseHour;
            CourseId = courseId;
            Teacher = teacher;
            CourseName = courseName;
        }
        public string CourseName { get; set; }
        public int CourseId { get; set; }
        public string Teacher { get; set; }
        public int CourseHour { get; set; }
    }
}
