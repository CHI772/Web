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
    public class LearningBehaviorsController : Controller
    {
        private MoodleModel db = new MoodleModel();

        // GET: LearningBehaviors
        public ActionResult Index_LB()
        {
            return View(db.LearnB.ToList());
        }
        

        // GET: LearningBehaviors/Details/5
        public ActionResult Details_LB(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LearningBehavior learningBehavior = db.LearnB.Find(id);
            if (learningBehavior == null)
            {
                return HttpNotFound();
            }
            return View(learningBehavior);
        }

        // GET: LearningBehaviors/Create
        public ActionResult Create_LB()
        {
            return View();
        }

        // POST: LearningBehaviors/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create_LB([Bind(Include = "ID,MID,SID,GID,ActionType,subAction,Detail,Time")] LearningBehavior learningBehavior)
        {
            if (ModelState.IsValid)
            {
                db.LearnB.Add(learningBehavior);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(learningBehavior);
        }

        // GET: LearningBehaviors/Edit/5
        public ActionResult Edit_LB(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LearningBehavior learningBehavior = db.LearnB.Find(id);
            if (learningBehavior == null)
            {
                return HttpNotFound();
            }
            return View(learningBehavior);
        }

        // POST: LearningBehaviors/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit_LB([Bind(Include = "ID,MID,SID,GID,ActionType,subAction,Detail,Time")] LearningBehavior learningBehavior)
        {
            if (ModelState.IsValid)
            {
                db.Entry(learningBehavior).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(learningBehavior);
        }

        // GET: LearningBehaviors/Delete/5
        public ActionResult Delete_LB(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LearningBehavior learningBehavior = db.LearnB.Find(id);
            if (learningBehavior == null)
            {
                return HttpNotFound();
            }
            return View(learningBehavior);
        }

        // POST: LearningBehaviors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LearningBehavior learningBehavior = db.LearnB.Find(id);
            db.LearnB.Remove(learningBehavior);
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
