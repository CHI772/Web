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
    public class KnowledgePointsController : Controller
    {
        private MoodleModel db = new MoodleModel();

        // GET: KnowledgePoints
        public ActionResult Index_KP()
        {
            return View(db.KPs.ToList());
        }

        // GET: KnowledgePoints/Details/5
        public ActionResult Details_KP(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KnowledgePoints knowledgePoints = db.KPs.Find(id);
            if (knowledgePoints == null)
            {
                return HttpNotFound();
            }
            return View(knowledgePoints);
        }

        // GET: KnowledgePoints/Create
        public ActionResult Create_KP()
        {
            return View();
        }

        // POST: KnowledgePoints/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create_KP([Bind(Include = "KID, MID,KContent")] KnowledgePoints knowledgePoints)
        {
            if (ModelState.IsValid)
            {
                db.KPs.Add(knowledgePoints);
                db.SaveChanges();
                return RedirectToAction("Index_KP");
            }

            return View(knowledgePoints);
        }

        // GET: KnowledgePoints/Edit/5
        public ActionResult Edit_KP(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KnowledgePoints knowledgePoints = db.KPs.Find(id);
            if (knowledgePoints == null)
            {
                return HttpNotFound();
            }
            return View(knowledgePoints);
        }

        // POST: KnowledgePoints/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit_KP([Bind(Include = "KID,MID,KContent")] KnowledgePoints knowledgePoints)
        {
            if (ModelState.IsValid)
            {
                db.Entry(knowledgePoints).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(knowledgePoints);
        }

        // GET: KnowledgePoints/Delete/5
        public ActionResult Delete_KP(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KnowledgePoints knowledgePoints = db.KPs.Find(id);
            if (knowledgePoints == null)
            {
                return HttpNotFound();
            }
            return View(knowledgePoints);
        }

        // POST: KnowledgePoints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KnowledgePoints knowledgePoints = db.KPs.Find(id);
            db.KPs.Remove(knowledgePoints);
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
