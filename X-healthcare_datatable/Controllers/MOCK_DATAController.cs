﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using X_healthcare_datatable.Models;

namespace X_healthcare_datatable.Controllers
{
    public class MOCK_DATAController : Controller
    {
        private X_healthcare_datatable_Models db = new X_healthcare_datatable_Models();

        // GET: MOCK_DATA
        public ActionResult Index()
        {
            return View(db.MOCK_DATA.ToList());
        }

        // GET: MOCK_DATA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MOCK_DATA mOCK_DATA = db.MOCK_DATA.Find(id);
            if (mOCK_DATA == null)
            {
                return HttpNotFound();
            }
            return View(mOCK_DATA);
        }

        // GET: MOCK_DATA/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MOCK_DATA/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,first_name,last_name,email,gender,ip_address")] MOCK_DATA mOCK_DATA)
        {
            if (ModelState.IsValid)
            {
                db.MOCK_DATA.Add(mOCK_DATA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mOCK_DATA);
        }

        // GET: MOCK_DATA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MOCK_DATA mOCK_DATA = db.MOCK_DATA.Find(id);
            if (mOCK_DATA == null)
            {
                return HttpNotFound();
            }
            return View(mOCK_DATA);
        }

        // POST: MOCK_DATA/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,first_name,last_name,email,gender,ip_address")] MOCK_DATA mOCK_DATA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mOCK_DATA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mOCK_DATA);
        }

        // GET: MOCK_DATA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MOCK_DATA mOCK_DATA = db.MOCK_DATA.Find(id);
            if (mOCK_DATA == null)
            {
                return HttpNotFound();
            }
            return View(mOCK_DATA);
        }

        // POST: MOCK_DATA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MOCK_DATA mOCK_DATA = db.MOCK_DATA.Find(id);
            db.MOCK_DATA.Remove(mOCK_DATA);
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
