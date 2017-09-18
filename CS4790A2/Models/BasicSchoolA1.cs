using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace CS4790A2.Models
{
    public class BasicSchoolA1
    {

        public static Course getCourse(int? id)
        {
            BasicSchoolA1DbContext db = new BasicSchoolA1DbContext();
            Course course = db.courses.Find(id);

            return course;
        }

        public static List<Course> getAllCourses()
        {
             // added static above, and the code below for class demo
            BasicSchoolA1DbContext db = new BasicSchoolA1DbContext();
            return db.courses.ToList();
        }

        public static Section getSection(int? id)
        {
            BasicSchoolA1DbContext db = new BasicSchoolA1DbContext();
            Section section = db.sections.Find(id);

            return section;
        }

        public static List<Section> getAllSections()
        {
            // added static above, and the code below for class demo
            BasicSchoolA1DbContext db = new BasicSchoolA1DbContext();
            return db.sections.ToList();
        }

        public static void deleteCourse(Course course)
        {
           BasicSchoolA1DbContext db = new BasicSchoolA1DbContext();
           db.Entry(course).State = EntityState.Deleted;
           db.courses.Remove(course);
           db.SaveChanges();

        }

        public static void deleteSection(Section section)
        {
            BasicSchoolA1DbContext db = new BasicSchoolA1DbContext();
            db.Entry(section).State = EntityState.Deleted;
            db.sections.Remove(section);
            db.SaveChanges();

        }

        public static void editCourse(Course course)
        {
            BasicSchoolA1DbContext db = new BasicSchoolA1DbContext();
            db.Entry(course).State = EntityState.Modified;
            db.SaveChanges();
        }

        public static void editSection(Section section)
        {
            BasicSchoolA1DbContext db = new BasicSchoolA1DbContext();
            db.Entry(section).State = EntityState.Modified;
            db.SaveChanges();
        }

        public static void createSection(Section section)
        {
            BasicSchoolA1DbContext db = new BasicSchoolA1DbContext();
            db.Entry(section).State = EntityState.Added;
            db.sections.Add(section);
            db.SaveChanges();
        }

        public static void createCourse(Course course)
        {
            BasicSchoolA1DbContext db = new BasicSchoolA1DbContext();
            db.Entry(course).State = EntityState.Added;
            db.courses.Add(course);
            db.SaveChanges();
        }

        public static CourseAndSections getCourseAndSections(int? id)
        {
            BasicSchoolA1DbContext db = new BasicSchoolA1DbContext();
            CourseAndSections courseSection = new CourseAndSections();
            courseSection.course = db.courses.Find(id);
            var sections = db.sections.Where(s => s.courseNumber == courseSection.course.courseNumber);
            courseSection.sections = sections.ToList();

            return courseSection;
        }

    }

    [Table("Course")]
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Course Number")]
        public string courseNumber { get; set; }
        [DisplayName("Course Name")]
        public string courseName { get; set; }
        [DisplayName("Credit Hours")]
        [Range(0,4, ErrorMessage = "Between 0 to 4 credit hours")]
        public int creditHours { get; set; }
        [DisplayName("Maximum Enrollment")]
        public int? maxEnrollment { get; set; }
    }

    [Table("Section")]
    public class Section
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Section ID")]
        public int sectionID { get; set; }
        [DisplayName("Section Number")]
        public int sectionNumber { get; set; }
        [DisplayName("Course Number")]
        public string courseNumber { get; set; }
        [DisplayName("Section Days")]
        public string sectionDays { get; set; }
        [DisplayName("Section Time")]
        public DateTime sectionTime { get; set; }
    }

    public class BasicSchoolA1DbContext : DbContext
    {
        public DbSet<Course> courses { get; set; }
        public DbSet<Section> sections { get; set; }
    }
}