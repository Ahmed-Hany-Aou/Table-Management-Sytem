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
    public class reservationsController : Controller
    {
        private table_management_systemEntities db = new table_management_systemEntities();

        // GET: reservations
        public ActionResult Index()
        {
            var reservations = db.reservations.Include(r => r.table).Include(r => r.time_slots).Include(r => r.user);
            return View(reservations.ToList());
        }

        // GET: reservations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reservation reservation = db.reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // GET: reservations/Create
        public ActionResult Create()
        {
            ViewBag.table_id = new SelectList(db.tables, "table_id", "table_id");
            ViewBag.time_slot_id = new SelectList(db.time_slots, "time_slot_id", "time_slot_id");
            ViewBag.user_id = new SelectList(db.users, "user_id", "user_name");
            return View();
        }

        // POST: reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "reservation_id,date,time_slot_id,table_id,user_id")] reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.reservations.Add(reservation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.table_id = new SelectList(db.tables, "table_id", "table_id", reservation.table_id);
            ViewBag.time_slot_id = new SelectList(db.time_slots, "time_slot_id", "time_slot_id", reservation.time_slot_id);
            ViewBag.user_id = new SelectList(db.users, "user_id", "user_name", reservation.user_id);
            return View(reservation);
        }

        // GET: reservations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reservation reservation = db.reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            ViewBag.table_id = new SelectList(db.tables, "table_id", "table_id", reservation.table_id);
            ViewBag.time_slot_id = new SelectList(db.time_slots, "time_slot_id", "time_slot_id", reservation.time_slot_id);
            ViewBag.user_id = new SelectList(db.users, "user_id", "user_name", reservation.user_id);
            return View(reservation);
        }

        // POST: reservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "reservation_id,date,time_slot_id,table_id,user_id")] reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.table_id = new SelectList(db.tables, "table_id", "table_id", reservation.table_id);
            ViewBag.time_slot_id = new SelectList(db.time_slots, "time_slot_id", "time_slot_id", reservation.time_slot_id);
            ViewBag.user_id = new SelectList(db.users, "user_id", "user_name", reservation.user_id);
            return View(reservation);
        }

        // GET: reservations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reservation reservation = db.reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // POST: reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            reservation reservation = db.reservations.Find(id);
            db.reservations.Remove(reservation);
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
