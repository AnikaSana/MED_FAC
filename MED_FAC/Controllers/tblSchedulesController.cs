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
    public class tblSchedulesController : Controller
    {
        private Model1 db = new Model1();

        // GET: tblSchedules
        public ActionResult Index()
        {
            var tblSchedules = db.tblSchedules.Include(t => t.tblDoctor);
            return View(tblSchedules.ToList());
        }

        // GET: tblSchedules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSchedule tblSchedule = db.tblSchedules.Find(id);
            if (tblSchedule == null)
            {
                return HttpNotFound();
            }
            return View(tblSchedule);
        }

        // GET: tblSchedules/Create
        public ActionResult Create()
        {
            ViewBag.DOCTOR_FID = new SelectList(db.tblDoctors, "DOCTOR_ID", "DOCTOR_NAME");
            return View();
        }

        // POST: tblSchedules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SCHEDULE_ID,SCHEDULE_TIME,SCHEDULE_DATE,SCHEDULE_DAY,SCHEDULE_LOC,DOCTOR_FID")] tblSchedule tblSchedule)
        {
            if (ModelState.IsValid)
            {
                db.tblSchedules.Add(tblSchedule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DOCTOR_FID = new SelectList(db.tblDoctors, "DOCTOR_ID", "DOCTOR_NAME", tblSchedule.DOCTOR_FID);
            return View(tblSchedule);
        }

        // GET: tblSchedules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSchedule tblSchedule = db.tblSchedules.Find(id);
            if (tblSchedule == null)
            {
                return HttpNotFound();
            }
            ViewBag.DOCTOR_FID = new SelectList(db.tblDoctors, "DOCTOR_ID", "DOCTOR_NAME", tblSchedule.DOCTOR_FID);
            return View(tblSchedule);
        }

        // POST: tblSchedules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SCHEDULE_ID,SCHEDULE_TIME,SCHEDULE_DATE,SCHEDULE_DAY,SCHEDULE_LOC,DOCTOR_FID")] tblSchedule tblSchedule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblSchedule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DOCTOR_FID = new SelectList(db.tblDoctors, "DOCTOR_ID", "DOCTOR_NAME", tblSchedule.DOCTOR_FID);
            return View(tblSchedule);
        }

        // GET: tblSchedules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSchedule tblSchedule = db.tblSchedules.Find(id);
            if (tblSchedule == null)
            {
                return HttpNotFound();
            }
            return View(tblSchedule);
        }

        // POST: tblSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblSchedule tblSchedule = db.tblSchedules.Find(id);
            db.tblSchedules.Remove(tblSchedule);
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
