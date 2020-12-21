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
    public class billdetailsController : Controller
    {
        private Model1 db = new Model1();

        // GET: billdetails
        public ActionResult Index()
        {
            if (Session["IdAccount"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            var billdetails = db.billdetails.Include(b => b.bill).Include(b => b.PRODUCT);
            return View(billdetails.ToList());
        }

        // GET: billdetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            billdetail billdetail = db.billdetails.Find(id);
            if (billdetail == null)
            {
                return HttpNotFound();
            }
            return View(billdetail);
        }

        // GET: billdetails/Create
        public ActionResult Create()
        {
            ViewBag.billID = new SelectList(db.bills, "id", "id");
            ViewBag.productId = new SelectList(db.PRODUCTs, "id", "name");
            return View();
        }

        // POST: billdetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,billID,productId,quantity,price,discount,sum_price,created_at,update_at")] billdetail billdetail)
        {
            if (ModelState.IsValid)
            {
                db.billdetails.Add(billdetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.billID = new SelectList(db.bills, "id", "id", billdetail.billID);
            ViewBag.productId = new SelectList(db.PRODUCTs, "id", "name", billdetail.productId);
            return View(billdetail);
        }

        // GET: billdetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            billdetail billdetail = db.billdetails.Find(id);
            if (billdetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.billID = new SelectList(db.bills, "id", "id", billdetail.billID);
            ViewBag.productId = new SelectList(db.PRODUCTs, "id", "name", billdetail.productId);
            return View(billdetail);
        }

        // POST: billdetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,billID,productId,quantity,price,discount,sum_price,created_at,update_at")] billdetail billdetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(billdetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.billID = new SelectList(db.bills, "id", "id", billdetail.billID);
            ViewBag.productId = new SelectList(db.PRODUCTs, "id", "name", billdetail.productId);
            return View(billdetail);
        }

        // GET: billdetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            billdetail billdetail = db.billdetails.Find(id);
            if (billdetail == null)
            {
                return HttpNotFound();
            }
            return View(billdetail);
        }

        // POST: billdetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            billdetail billdetail = db.billdetails.Find(id);
            db.billdetails.Remove(billdetail);
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
