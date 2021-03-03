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
    public class SelfAssessmentsController : Controller
    {
        private MoodleModel db = new MoodleModel();

        // GET: SelfAssessments
        public ActionResult Index()
        {
            return View(db.SelfA.ToList());
        }

        // GET: SelfAssessments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SelfAssessment selfAssessment = db.SelfA.Find(id);
            if (selfAssessment == null)
            {
                return HttpNotFound();
            }
            return View(selfAssessment);
        }

        // GET: SelfAssessments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SelfAssessments/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SEID,MID,SID,GID,CooperationLevel,PersonalContributionLevel,SelfA")] SelfAssessment selfAssessment)
        {
            if (ModelState.IsValid)
            {
                db.SelfA.Add(selfAssessment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(selfAssessment);
        }

        // GET: SelfAssessments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SelfAssessment selfAssessment = db.SelfA.Find(id);
            if (selfAssessment == null)
            {
                return HttpNotFound();
            }
            return View(selfAssessment);
        }

        // POST: SelfAssessments/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SEID,MID,SID,GID,CooperationLevel,PersonalContributionLevel,SelfA")] SelfAssessment selfAssessment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(selfAssessment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(selfAssessment);
        }

        // GET: SelfAssessments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SelfAssessment selfAssessment = db.SelfA.Find(id);
            if (selfAssessment == null)
            {
                return HttpNotFound();
            }
            return View(selfAssessment);
        }

        // POST: SelfAssessments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SelfAssessment selfAssessment = db.SelfA.Find(id);
            db.SelfA.Remove(selfAssessment);
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
