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
    public class StudentCasesController : Controller
    {
        private Database1Entities db = new Database1Entities();

        // GET: StudentCases
        public ActionResult Index()
        {
            var studentCases = db.StudentCases.Include(s => s.Student);
            return View(studentCases.ToList());
        }

        // GET: StudentCases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentCase studentCase = db.StudentCases.Find(id);
            if (studentCase == null)
            {
                return HttpNotFound();
            }
            return View(studentCase);
        }

        // GET: StudentCases/Create
        public ActionResult Create()
        {
            ViewBag.Student_Id = new SelectList(db.Students, "Student_Id", "Password");
            return View();
        }

        // POST: StudentCases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Student_Id,Full_Name,Contact_Number,Student_Email_Link,Qualification_Title,Recommanded_Job,Progress,Profile_Link,Explanatory_Comment")] StudentCase studentCase)
        {
            if (ModelState.IsValid)
            {
                db.StudentCases.Add(studentCase);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Student_Id = new SelectList(db.Students, "Student_Id", "Password", studentCase.Student_Id);
            return View(studentCase);
        }

        // GET: StudentCases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentCase studentCase = db.StudentCases.Find(id);
            if (studentCase == null)
            {
                return HttpNotFound();
            }
            ViewBag.Student_Id = new SelectList(db.Students, "Student_Id", "Password", studentCase.Student_Id);
            return View(studentCase);
        }

        // POST: StudentCases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Student_Id,Full_Name,Contact_Number,Student_Email_Link,Qualification_Title,Recommanded_Job,Progress,Profile_Link,Explanatory_Comment")] StudentCase studentCase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentCase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Student_Id = new SelectList(db.Students, "Student_Id", "Password", studentCase.Student_Id);
            return View(studentCase);
        }

        // GET: StudentCases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentCase studentCase = db.StudentCases.Find(id);
            if (studentCase == null)
            {
                return HttpNotFound();
            }
            return View(studentCase);
        }

        // POST: StudentCases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentCase studentCase = db.StudentCases.Find(id);
            db.StudentCases.Remove(studentCase);
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
