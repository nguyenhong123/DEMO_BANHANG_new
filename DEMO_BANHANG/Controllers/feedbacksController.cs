using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DEMO_BANHANG.Models;

namespace DEMO_BANHANG.Controllers
{
    public class feedbacksController : Controller
    {
        private Model1 db = new Model1();

        // GET: feedbacks
        public ActionResult Index()

        {
            if (Session["IdAccount"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            var feedbacks = db.feedbacks.Include(f => f.account).Include(f => f.PRODUCT);
            return View(feedbacks.ToList());
        }

        // GET: feedbacks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            feedback feedback = db.feedbacks.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return View(feedback);
        }

        // GET: feedbacks/Create
        public ActionResult Create()
        {
            ViewBag.accountid = new SelectList(db.accounts, "id", "name");
            ViewBag.productid = new SelectList(db.PRODUCTs, "id", "name");
            return View();
        }

        // POST: feedbacks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,productid,accountid,comment,created_at,update_at")] feedback feedback)
        {
            if (ModelState.IsValid)
            {
                db.feedbacks.Add(feedback);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.accountid = new SelectList(db.accounts, "id", "name", feedback.accountid);
            ViewBag.productid = new SelectList(db.PRODUCTs, "id", "name", feedback.productid);
            return View(feedback);
        }

        // GET: feedbacks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            feedback feedback = db.feedbacks.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            ViewBag.accountid = new SelectList(db.accounts, "id", "name", feedback.accountid);
            ViewBag.productid = new SelectList(db.PRODUCTs, "id", "name", feedback.productid);
            return View(feedback);
        }

        // POST: feedbacks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,productid,accountid,comment,created_at,update_at")] feedback feedback)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feedback).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.accountid = new SelectList(db.accounts, "id", "name", feedback.accountid);
            ViewBag.productid = new SelectList(db.PRODUCTs, "id", "name", feedback.productid);
            return View(feedback);
        }

        // GET: feedbacks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            feedback feedback = db.feedbacks.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return View(feedback);
        }

        // POST: feedbacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            feedback feedback = db.feedbacks.Find(id);
            db.feedbacks.Remove(feedback);
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
