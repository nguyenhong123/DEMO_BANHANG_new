using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DEMO_BANHANG.Models;

namespace DEMO_BANHANG.Controllers
{
    public class PRODUCTsController : Controller
    {
        private Model1 db = new Model1();

        // GET: PRODUCTs
        public ActionResult Index()
        {
            if (Session["IdAccount"] == null)
            {
                return RedirectToAction("Login", "Home");
            }    
            var pRODUCTs = db.PRODUCTs.Include(p => p.producer);
            return View(pRODUCTs.ToList());
        }

        // GET: PRODUCTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT pRODUCT = db.PRODUCTs.Find(id);
            if (pRODUCT == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCT);
        }

        // GET: PRODUCTs/Create
        public ActionResult Create()
        {
            ViewBag.producerid = new SelectList(db.producers, "id", "name");
            return View();
        }

        // POST: PRODUCTs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,author,price,discount,images,producerid,catID,description,status,created_at")] PRODUCT pRODUCT, HttpPostedFileBase images)
        {
            if (ModelState.IsValid)
            {
                var path = Path.Combine(Server.MapPath("~/Images/"), Path.GetFileName(images.FileName));
                images.SaveAs(path);

                db.PRODUCTs.Add(new PRODUCT 
                {
                    id = pRODUCT.id,
                    name = pRODUCT.name,
                    author = pRODUCT.author,
                    price = pRODUCT.price,
                    discount = pRODUCT.discount,
                    producerid = pRODUCT.producerid,
                    catID = pRODUCT.catID,
                    description = pRODUCT.description,
                    status = pRODUCT.status,
                    created_at = pRODUCT.created_at,
                    images = "/Images/" + images.FileName
                });
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.producerid = new SelectList(db.producers, "id", "name", pRODUCT.producerid);
            return View(pRODUCT);
        }

        // GET: PRODUCTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT pRODUCT = db.PRODUCTs.Find(id);
            if (pRODUCT == null)
            {
                return HttpNotFound();
            }
            ViewBag.producerid = new SelectList(db.producers, "id", "name", pRODUCT.producerid);
            return View(pRODUCT);
        }

        // POST: PRODUCTs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,author,price,discount,images,producerid,catID,description,status,created_at")] PRODUCT pRODUCT, HttpPostedFileBase images)
        {
            if (ModelState.IsValid)
            {
                var path = Path.Combine(Server.MapPath("~/Images/"), Path.GetFileName(images.FileName));
                images.SaveAs(path);
                db.Entry(new PRODUCT
                {
                    id = pRODUCT.id,
                    name = pRODUCT.name,
                    author = pRODUCT.author,
                    price = pRODUCT.price,
                    discount = pRODUCT.discount,
                    producerid = pRODUCT.producerid,
                    catID = pRODUCT.catID,
                    description = pRODUCT.description,
                    status = pRODUCT.status,
                    created_at = pRODUCT.created_at,
                    images = "/Images/" + images.FileName
                }).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.producerid = new SelectList(db.producers, "id", "name", pRODUCT.producerid);
            return View(pRODUCT);
        }

        // GET: PRODUCTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT pRODUCT = db.PRODUCTs.Find(id);
            if (pRODUCT == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCT);
        }

        // POST: PRODUCTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRODUCT pRODUCT = db.PRODUCTs.Find(id);
            db.PRODUCTs.Remove(pRODUCT);
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
