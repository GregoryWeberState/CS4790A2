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