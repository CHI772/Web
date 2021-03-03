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
    public class MissionKnowledgePointsController : Controller
    {
        private MoodleModel db = new MoodleModel();

        // GET: MissionKnowledgePoints
        public ActionResult Index()
        {
            return View(db.MKPs.ToList());
        }

        // GET: MissionKnowledgePoints/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MissionKnowledgePoints missionKnowledgePoints = db.MKPs.Find(id);
            if (missionKnowledgePoints == null)
            {
                return HttpNotFound();
            }
            return View(missionKnowledgePoints);
        }

        // GET: MissionKnowledgePoints/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MissionKnowledgePoints/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KID,MID")] MissionKnowledgePoints missionKnowledgePoints)
        {
            if (ModelState.IsValid)
            {
                db.MKPs.Add(missionKnowledgePoints);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(missionKnowledgePoints);
        }

        // GET: MissionKnowledgePoints/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MissionKnowledgePoints missionKnowledgePoints = db.MKPs.Find(id);
            if (missionKnowledgePoints == null)
            {
                return HttpNotFound();
            }
            return View(missionKnowledgePoints);
        }

        // POST: MissionKnowledgePoints/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KID,MID")] MissionKnowledgePoints missionKnowledgePoints)
        {
            if (ModelState.IsValid)
            {
                db.Entry(missionKnowledgePoints).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(missionKnowledgePoints);
        }

        // GET: MissionKnowledgePoints/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MissionKnowledgePoints missionKnowledgePoints = db.MKPs.Find(id);
            if (missionKnowledgePoints == null)
            {
                return HttpNotFound();
            }
            return View(missionKnowledgePoints);
        }

        // POST: MissionKnowledgePoints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            MissionKnowledgePoints missionKnowledgePoints = db.MKPs.Find(id);
            db.MKPs.Remove(missionKnowledgePoints);
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
