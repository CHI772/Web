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
    public class PromptsController : Controller
    {
        private MoodleModel db = new MoodleModel();

        // GET: Prompts
        public ActionResult Index()
        {
            return View(db.Prompts.ToList());
        }

        // GET: Prompts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prompt prompt = db.Prompts.Find(id);
            if (prompt == null)
            {
                return HttpNotFound();
            }
            return View(prompt);
        }

        // GET: Prompts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prompts/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PID,MID,PContent")] Prompt prompt)
        {
            if (ModelState.IsValid)
            {
                db.Prompts.Add(prompt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prompt);
        }

        // GET: Prompts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prompt prompt = db.Prompts.Find(id);
            if (prompt == null)
            {
                return HttpNotFound();
            }
            return View(prompt);
        }

        // POST: Prompts/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PID,MID,PContent")] Prompt prompt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prompt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prompt);
        }

        // GET: Prompts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prompt prompt = db.Prompts.Find(id);
            if (prompt == null)
            {
                return HttpNotFound();
            }
            return View(prompt);
        }

        // POST: Prompts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prompt prompt = db.Prompts.Find(id);
            db.Prompts.Remove(prompt);
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
