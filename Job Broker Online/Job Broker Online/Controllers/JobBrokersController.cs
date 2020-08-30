using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Job_Broker_Online.Models;

namespace Job_Broker_Online.Controllers
{
    public class JobBrokersController : Controller
    {
        private Database1Entities db = new Database1Entities();

        // GET: JobBrokers
        public ActionResult Index()
        {
            return View(db.JobBrokers.ToList());
        }

        // GET: JobBrokers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobBroker jobBroker = db.JobBrokers.Find(id);
            if (jobBroker == null)
            {
                return HttpNotFound();
            }
            return View(jobBroker);
        }

        // GET: JobBrokers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JobBrokers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Account_Name,Password,Contact_Number,Email")] JobBroker jobBroker)
        {
            if (ModelState.IsValid)
            {
                db.JobBrokers.Add(jobBroker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jobBroker);
        }

        // GET: JobBrokers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobBroker jobBroker = db.JobBrokers.Find(id);
            if (jobBroker == null)
            {
                return HttpNotFound();
            }
            return View(jobBroker);
        }

        // POST: JobBrokers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Account_Name,Password,Contact_Number,Email")] JobBroker jobBroker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobBroker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jobBroker);
        }

        // GET: JobBrokers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobBroker jobBroker = db.JobBrokers.Find(id);
            if (jobBroker == null)
            {
                return HttpNotFound();
            }
            return View(jobBroker);
        }

        // POST: JobBrokers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            JobBroker jobBroker = db.JobBrokers.Find(id);
            db.JobBrokers.Remove(jobBroker);
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
