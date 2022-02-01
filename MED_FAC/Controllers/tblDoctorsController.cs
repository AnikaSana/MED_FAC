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
    public class tblDoctorsController : Controller
    {
        private Model1 db = new Model1();

        // GET: tblDoctors
        public ActionResult Index()
        {
            var tblDoctors = db.tblDoctors.Include(t => t.tblDept);
            return View(tblDoctors.ToList());
        }

        // GET: tblDoctors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDoctor tblDoctor = db.tblDoctors.Find(id);
            if (tblDoctor == null)
            {
                return HttpNotFound();
            }
            return View(tblDoctor);
        }

        // GET: tblDoctors/Create
        public ActionResult Create()
        {
            ViewBag.DEPARTMENT_FID = new SelectList(db.tblDepts, "DEPARTMENT_ID", "DEPARTMENT_NAME");
            return View();
        }

        // POST: tblDoctors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(tblDoctor tblDoctor,HttpPostedFileBase pic)
        {
            string fullpath = Server.MapPath("~/Content/pics/" + pic.FileName);
            pic.SaveAs(fullpath);
            tblDoctor.DOCTOR_IMAGE = "~/Content/pics/" + pic.FileName;

            if (ModelState.IsValid)
            {
                db.tblDoctors.Add(tblDoctor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DEPARTMENT_FID = new SelectList(db.tblDepts, "DEPARTMENT_ID", "DEPARTMENT_NAME", tblDoctor.DEPARTMENT_FID);
            return View(tblDoctor);
        }

        // GET: tblDoctors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDoctor tblDoctor = db.tblDoctors.Find(id);
            if (tblDoctor == null)
            {
                return HttpNotFound();
            }
            ViewBag.DEPARTMENT_FID = new SelectList(db.tblDepts, "DEPARTMENT_ID", "DEPARTMENT_NAME", tblDoctor.DEPARTMENT_FID);
            return View(tblDoctor);
        }

        // POST: tblDoctors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DOCTOR_ID,DOCTOR_NAME,DOCTOR_IMAGE,DOCTOR_FEE,DOCTOR_CONTACT,DEPARTMENT_FID")] tblDoctor tblDoctor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblDoctor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DEPARTMENT_FID = new SelectList(db.tblDepts, "DEPARTMENT_ID", "DEPARTMENT_NAME", tblDoctor.DEPARTMENT_FID);
            return View(tblDoctor);
        }

        // GET: tblDoctors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDoctor tblDoctor = db.tblDoctors.Find(id);
            if (tblDoctor == null)
            {
                return HttpNotFound();
            }
            return View(tblDoctor);
        }

        // POST: tblDoctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblDoctor tblDoctor = db.tblDoctors.Find(id);
            db.tblDoctors.Remove(tblDoctor);
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
        