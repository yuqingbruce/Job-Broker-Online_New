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
    public class JobInformationsController : Controller
    {
        private Database1Entities db = new Database1Entities();

        // GET: JobInformations
        public ActionResult Index()
        {
            var jobInformations = db.JobInformations.Include(j => j.Employee);
            return View(jobInformations.ToList());
        }

        // GET: JobInformations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobInformation jobInformation = db.JobInformations.Find(id);
            if (jobInformation == null)
            {
                return HttpNotFound();
            }
            return View(jobInformation);
        }

        // GET: JobInformations/Create
        public ActionResult Create()
        {
            ViewBag.Person_to_Contact = new SelectList(db.Employees, "Account_Name", "Password");
            return View();
        }

        // POST: JobInformations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Job_Position,Company_Name,Work_Address,Job_Description,Job_Requirement,Person_to_Contact,Contact_Number,Contact_Email,Other_Notes")] JobInformation jobInformation)
        {
            if (ModelState.IsValid)
            {
                db.JobInformations.Add(jobInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Person_to_Contact = new SelectList(db.Employees, "Account_Name", "Password", jobInformation.Person_to_Contact);
            return View(jobInformation);
        }

        // GET: JobInformations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobInformation jobInformation = db.JobInformations.Find(id);
            if (jobInformation == null)
            {
                return HttpNotFound();
            }
            ViewBag.Person_to_Contact = new SelectList(db.Employees, "Account_Name", "Password", jobInformation.Person_to_Contact);
            return View(jobInformation);
        }

        // POST: JobInformations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Job_Position,Company_Name,Work_Address,Job_Description,Job_Requirement,Person_to_Contact,Contact_Number,Contact_Email,Other_Notes")] JobInformation jobInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Person_to_Contact = new SelectList(db.Employees, "Account_Name", "Password", jobInformation.Person_to_Contact);
            return View(jobInformation);
        }

        // GET: JobInformations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobInformation jobInformation = db.JobInformations.Find(id);
            if (jobInformation == null)
            {
                return HttpNotFound();
            }
            return View(jobInformation);
        }

        // POST: JobInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobInformation jobInformation = db.JobInformations.Find(id);
            db.JobInformations.Remove(jobInformation);
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
