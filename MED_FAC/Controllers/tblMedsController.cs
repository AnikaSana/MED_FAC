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
    public class tblMedsController : Controller
    {
        private Model1 db = new Model1();

        // GET: tblMeds
        public ActionResult Index()
        {
            return View(db.tblMeds.ToList());
        }

        // GET: tblMeds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMed tblMed = db.tblMeds.Find(id);
            if (tblMed == null)
            {
                return HttpNotFound();
            }
            return View(tblMed);
        }

        // GET: tblMeds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblMeds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "MEDICINE_ID,MEDICINE_NAME,MEDICINE_BRAND,MEDICINE_IMAGE,MADICINE_WEIGHT,MEDICINE_PRICE,MEDICINE_DETAILS,OrderMed_FID")] tblMed tblMed)
        public ActionResult Create( tblMed tblMed ,HttpPostedFileBase pic)
        {
            string fullpath = Server.MapPath("~/Content/pics/" + pic.FileName);
            pic.SaveAs(fullpath);
            //pic.SaveAs(Server.MapPath("~/Content/pics/" + pic.FileName));
            tblMed.MEDICINE_IMAGE="~/Content/pics/" + pic.FileName;


            if (ModelState.IsValid)
            {
                db.tblMeds.Add(tblMed);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblMed);
        }

        // GET: tblMeds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMed tblMed = db.tblMeds.Find(id);
            if (tblMed == null)
            {
                return HttpNotFound();
            }
            return View(tblMed);
        }

        // POST: tblMeds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MEDICINE_ID,MEDICINE_NAME,MEDICINE_BRAND,MEDICINE_IMAGE,MADICINE_WEIGHT,MEDICINE_PRICE,MEDICINE_DETAILS,OrderMed_FID")] tblMed tblMed)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblMed).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblMed);
        }

        // GET: tblMeds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMed tblMed = db.tblMeds.Find(id);
            if (tblMed == null)
            {
                return HttpNotFound();
            }
            return View(tblMed);
        }

        // POST: tblMeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblMed tblMed = db.tblMeds.Find(id);
            db.tblMeds.Remove(tblMed);
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
