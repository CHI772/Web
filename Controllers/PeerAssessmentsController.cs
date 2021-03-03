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
    public class PeerAssessmentsController : Controller
    {
        private MoodleModel db = new MoodleModel();

        // GET: PeerAssessments
        public ActionResult Index()
        {
            return View(db.PeerA.ToList());
        }

        // GET: PeerAssessments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PeerAssessment peerAssessment = db.PeerA.Find(id);
            if (peerAssessment == null)
            {
                return HttpNotFound();
            }
            return View(peerAssessment);
        }

        // GET: PeerAssessments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PeerAssessments/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PEID,MID,SID,GID,PeerA,AssessedSID")] PeerAssessment peerAssessment)
        {
            if (ModelState.IsValid)
            {
                db.PeerA.Add(peerAssessment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(peerAssessment);
        }

        // GET: PeerAssessments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PeerAssessment peerAssessment = db.PeerA.Find(id);
            if (peerAssessment == null)
            {
                return HttpNotFound();
            }
            return View(peerAssessment);
        }

        // POST: PeerAssessments/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PEID,MID,SID,GID,PeerA,AssessedSID")] PeerAssessment peerAssessment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(peerAssessment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(peerAssessment);
        }

        // GET: PeerAssessments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PeerAssessment peerAssessment = db.PeerA.Find(id);
            if (peerAssessment == null)
            {
                return HttpNotFound();
            }
            return View(peerAssessment);
        }

        // POST: PeerAssessments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PeerAssessment peerAssessment = db.PeerA.Find(id);
            db.PeerA.Remove(peerAssessment);
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
