using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class TeachersController : Controller
    {
        private MoodleModel db = new MoodleModel();

        // GET: Teachers
        public ActionResult Home_T()
        {
            return View(db.Courses.ToList());
        }
        public ActionResult Index_Teacher()
        {
            return View(db.Teachers.ToList());
        }

        // GET: Teachers/Details/5
        public ActionResult Details_Teacher(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // GET: Teachers/Create
        public ActionResult Create_Teacher()
        {
            return View();
        }

        // POST: Teachers/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create_Teacher([Bind(Include = "TID,TName,TPassword,Email")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                db.Teachers.Add(teacher);
                db.SaveChanges();
                return RedirectToAction("Index_Teacher");
            }

            return View(teacher);
        }

        // GET: Teachers/Edit/5
        public ActionResult Edit_Teacher(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // POST: Teachers/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit_Teacher([Bind(Include = "TID,TName,TPassword,Email")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index_Teacher");
            }
            return View(teacher);
        }

        // GET: Teachers/Delete/5
        public ActionResult Delete_Teacher(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete_Teacher")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Teacher teacher = db.Teachers.Find(id);
            db.Teachers.Remove(teacher);
            db.SaveChanges();
            return RedirectToAction("Index_Teacher");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult Details_Course(string cid, string tid)
        {
            if (cid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(cid, tid);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }
        public ActionResult Index_Course()
        {
            var courses = db.Courses.Include(c => c.Teacher);
            return View(courses.ToList());
        }


        // GET: Courses/Create
        public ActionResult Create_Course()
        {
            ViewBag.TID = new SelectList(db.Teachers, "TID", "TName");
            return View();
        }

        // POST: Courses/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create_Course([Bind(Include = "CID,TID,CName")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Home_T");
            }

            ViewBag.TID = new SelectList(db.Teachers, "TID", "TName", course.TID);
            return View(course);
        }

        // GET: Courses/Edit/5
        public ActionResult Edit_Course(string cid, string tid)
        {
            if (cid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(cid, tid);
            if (course == null)
            {
                return HttpNotFound();
            }
            ViewBag.TID = new SelectList(db.Teachers, "TID", "TName", course.TID);
            return View(course);
        }

        // POST: Courses/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit_Course([Bind(Include = "CID,TID,CName")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index_Course");
            }
            ViewBag.TID = new SelectList(db.Teachers, "TID", "TName", course.TID);
            return View(course);
        }

        // GET: Courses/Delete/5
        public ActionResult Delete_Course(string cid, string tid)
        {
            if (cid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(cid, tid);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete_Course")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string cid, string tid)
        {
            Course course = db.Courses.Find(cid);
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("Home_T");
        }

    }
}
