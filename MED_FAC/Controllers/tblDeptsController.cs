using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MED_FAC.Models;

namespace MED_FAC.Controllers
{
    public class tblDeptsController : Controller
    {
        private Model1 db = new Model1();

        // GET: tblDepts
        public ActionResult Index()
        {
            return View(db.tblDepts.ToList());
        }

        // GET: tblDepts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDept tblDept = db.tblDepts.Find(id);
            if (tblDept == null)
            {
                return HttpNotFound();
            }
            return View(tblDept);
        }

        // GET: tblDepts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblDepts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DEPARTMENT_ID,DEPARTMENT_NAME")] tblDept tblDept)
        {
            if (ModelState.IsValid)
            {
                db.tblDepts.Add(tblDept);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblDept);
        }

        // GET: tblDepts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDept tblDept = db.tblDepts.Find(id);
            if (tblDept == null)
            {
                return HttpNotFound();
            }
            return View(tblDept);
        }

        // POST: tblDepts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DEPARTMENT_ID,DEPARTMENT_NAME")] tblDept tblDept)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblDept).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblDept);
        }

        // GET: tblDepts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDept tblDept = db.tblDepts.Find(id);
            if (tblDept == null)
            {
                return HttpNotFound();
            }
            return View(tblDept);
        }

        // POST: tblDepts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblDept tblDept = db.tblDepts.Find(id);
            db.tblDepts.Remove(tblDept);
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
