using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Table_Management_System;

namespace Table_Management_System.Controllers
{
    public class TimeSlotsController : Controller
    {
        private table_management_systemEntities db = new table_management_systemEntities();

        // GET: TimeSlots
        public ActionResult Index()
        {
            return View(db.time_slots.ToList());
        }

        // GET: TimeSlots/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            time_slots time_slots = db.time_slots.Find(id);
            if (time_slots == null)
            {
                return HttpNotFound();
            }
            return View(time_slots);
        }

        // GET: TimeSlots/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TimeSlots/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "time_slot_id,start_time,end_time")] time_slots time_slots)
        {
            if (ModelState.IsValid)
            {
                db.time_slots.Add(time_slots);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(time_slots);
        }

        // GET: TimeSlots/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            time_slots time_slots = db.time_slots.Find(id);
            if (time_slots == null)
            {
                return HttpNotFound();
            }
            return View(time_slots);
        }

        // POST: TimeSlots/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "time_slot_id,start_time,end_time")] time_slots time_slots)
        {
            if (ModelState.IsValid)
            {
                db.Entry(time_slots).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(time_slots);
        }

        // GET: TimeSlots/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            time_slots time_slots = db.time_slots.Find(id);
            if (time_slots == null)
            {
                return HttpNotFound();
            }
            return View(time_slots);
        }

        // POST: TimeSlots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            time_slots time_slots = db.time_slots.Find(id);
            db.time_slots.Remove(time_slots);
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
