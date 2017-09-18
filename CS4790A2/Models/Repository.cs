using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS4790A2.Models
{
    public class Repository
    {
        public static CourseAndSections getCourseAndSections(int? id)
        {
            CourseAndSections courseSection = BasicSchoolA1.getCourseAndSections(id);
            return courseSection;
        }

        public static Course getCourse(int? id)
        {
            Course course = BasicSchoolA1.getCourse(id);
            return course;
        }

        public static void deleteCourse(Course course)
        {
           BasicSchoolA1.deleteCourse(course);
        }

        public static void deleteSection(Section section)
        {
            BasicSchoolA1.deleteSection(section);
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

        public static void editCourse(Course course)
        {
            BasicSchoolA1.editCourse(course);
        }

        public static void editSection(Section section)
        {
            BasicSchoolA1.editSection(section);
        }

        public static void createSection(Section section)
        {
            BasicSchoolA1.createSection(section);
        }

        public static void createCourse(Course course)
        {
            BasicSchoolA1.createCourse(course);
        }
    }

    public class CourseAndSections
    {
        public CourseAndSections()
        {

        }
        public Course course { get; set; }
        public List<Section> sections { get; set; }
 
    }
}