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
    public class TeacherAssessmentsController : Controller
    {
        private MoodleModel db = new MoodleModel();

        // GET: TeacherAssessments
        public ActionResult Index()
        {
            return View(db.TeacherA.ToList());
        }

        // GET: TeacherAssessments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherAssessment teacherAssessment = db.TeacherA.Find(id);
            if (teacherAssessment == null)
            {
                return HttpNotFound();
            }
            return View(teacherAssessment);
        }

        // GET: TeacherAssessments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeacherAssessments/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TEID,MID,GID,TeacherA,GroupAchievementLevel")] TeacherAssessment teacherAssessment)
        {
            if (ModelState.IsValid)
            {
                db.TeacherA.Add(teacherAssessment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(teacherAssessment);
        }

        // GET: TeacherAssessments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherAssessment teacherAssessment = db.TeacherA.Find(id);
            if (teacherAssessment == null)
            {
                return HttpNotFound();
            }
            return View(teacherAssessment);
        }

        // POST: TeacherAssessments/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TEID,MID,GID,TeacherA,GroupAchievementLevel")] TeacherAssessment teacherAssessment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacherAssessment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teacherAssessment);
        }

        // GET: TeacherAssessments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherAssessment teacherAssessment = db.TeacherA.Find(id);
            if (teacherAssessment == null)
            {
                return HttpNotFound();
            }
            return View(teacherAssessment);
        }

        // POST: TeacherAssessments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeacherAssessment teacherAssessment = db.TeacherA.Find(id);
            db.TeacherA.Remove(teacherAssessment);
            db.SaveChanges();
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
