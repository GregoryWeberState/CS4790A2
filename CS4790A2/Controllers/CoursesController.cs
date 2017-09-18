using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CS4790A2.Models;

namespace CS4790A2.Controllers
{
    public class CoursesController : Controller
    {
        private BasicSchoolA1DbContext db = new BasicSchoolA1DbContext();

        // GET: Courses
        public ActionResult Index()
        {
            //return View(db.courses.ToList());
            return View(BasicSchoolA1.getAllCourses());
        }

        // GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Changed to Reporsitory.getcourse
            // old way not repository is             Course course = db.courses.Find(id);
            Course course = Repository.getCourse(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        
        // added in class GET : 
        public ActionResult DetailsAndSections(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseAndSections courseSection = Repository.getCourseAndSections(id);
            if (courseSection == null)
            {
                return HttpNotFound();
            }
            return View(courseSection);
        }
        

        // GET: Courses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,courseNumber,courseName,creditHours,maxEnrollment")] Course course)
        {
            if (ModelState.IsValid)
            {
                //db.courses.Add(course);
                //db.SaveChanges();
                Repository.createCourse(course);
                return RedirectToAction("Index");
            }

            return View(course);
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Changed to Reporsitory.getcourse
            // old way not repository is             Course course = db.courses.Find(id);
            Course course = Repository.getCourse(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,courseNumber,courseName,creditHours,maxEnrollment")] Course course)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(course).State = EntityState.Modified;
                //db.SaveChanges();
                Repository.editCourse(course);
                return RedirectToAction("Index");
            }
            return View(course);
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Changed to Reporsitory.getcourse
            // old way not repository is             Course course = db.courses.Find(id);
            Course course = Repository.getCourse(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = Repository.getCourse(id);
            //Course course = db.courses.Find(id);
            Repository.deleteCourse(course);
            //db.courses.Remove(course);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
