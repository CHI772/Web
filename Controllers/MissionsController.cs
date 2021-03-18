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
    public class MissionsController : Controller
    {
        private MoodleModel db = new MoodleModel();

        // GET: Missions
        public ActionResult Index_Mission()
        {
            return View(db.Missions.ToList());
        }

        // GET: Missions/Details/5
        public ActionResult Details_Mission(string mid, string cid)
        {
            if (mid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mission mission = db.Missions.Find(mid, cid);
            if (mission == null)
            {
                return HttpNotFound();
            }
            return View(mission);
        }

        // GET: Missions/Create
        public ActionResult Create_Mission()
        {
            return View();
        }

        // POST: Missions/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create_Mission([Bind(Include = "MID,CID,MName,MDetail")] Mission mission)
        {
            if (ModelState.IsValid)
            {
                db.Missions.Add(mission);
                db.SaveChanges();
                return RedirectToAction("Create_KP");
            }

            return View(mission);
        }

        // GET: Missions/Edit/5
        public ActionResult Edit_Mission(string mid, string cid)
        {
            if (mid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mission mission = db.Missions.Find(mid, cid);
            if (mission == null)
            {
                return HttpNotFound();
            }
            return View(mission);
        }

        // POST: Missions/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit_Mission([Bind(Include = "MID,CID,MName,MDetail")] Mission mission)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mission).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index_Mission");
            }
            return View(mission);
        }

        // GET: Missions/Delete/5
        public ActionResult Delete_Mission(string mid, string cid)
        {
            if (mid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mission mission = db.Missions.Find(mid, cid);
            if (mission == null)
            {
                return HttpNotFound();
            }
            return View(mission);
        }

        // POST: Missions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string mid, string cid)
        {
            Mission mission = db.Missions.Find(mid);
            db.Missions.Remove(mission);
            db.SaveChanges();
            return RedirectToAction("Index_Mission");
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
