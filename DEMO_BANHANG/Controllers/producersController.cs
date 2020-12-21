﻿using System;
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
    public class producersController : Controller
    {
        private Model1 db = new Model1();

        // GET: producers
        public ActionResult Index()
        {
            if (Session["IdAccount"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            return View(db.producers.ToList());
        }

        // GET: producers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            producer producer = db.producers.Find(id);
            if (producer == null)
            {
                return HttpNotFound();
            }
            return View(producer);
        }

        // GET: producers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: producers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name")] producer producer)
        {
            if (ModelState.IsValid)
            {
                db.producers.Add(producer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(producer);
        }

        // GET: producers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            producer producer = db.producers.Find(id);
            if (producer == null)
            {
                return HttpNotFound();
            }
            return View(producer);
        }

        // POST: producers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name")] producer producer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(producer);
        }

        // GET: producers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            producer producer = db.producers.Find(id);
            if (producer == null)
            {
                return HttpNotFound();
            }
            return View(producer);
        }

        // POST: producers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            producer producer = db.producers.Find(id);
            db.producers.Remove(producer);
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