using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS4790A2.Models
{
    public class Repository
    {
        public static Course getCourse(int? id)
        {
            Course course = BasicSchoolA1.getCourse(id);
            return course;
        }

        public static Section getSection(int? id)
        {
            Section section = BasicSchoolA1.getSection(id);
            return section;
        }

        public static List<Section> getAllSections()
        {
            return BasicSchoolA1.getAllSections();
        }

        public static List<Course> getAllCourses()
        {
            return BasicSchoolA1.getAllCourses();
        }
    }

    public class CourseAndSections
    {
        public Course course { get; set; }
        public List<Section> sections { get; set; }
    }
}