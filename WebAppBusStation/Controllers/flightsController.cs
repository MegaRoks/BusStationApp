using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppBusStation.Models;

namespace WebAppBusStation.Controllers
{
    public class flightsController : Controller
    {
        private bus_stationEntities db = new bus_stationEntities();

        // GET: flights
        public ActionResult Index()
        {
            var flight = db.flight.Include(f => f.bus).Include(f => f.route);
            return View(flight.ToList());
        }

        // GET: flights/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            flight flight = db.flight.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            return View(flight);
        }

        // GET: flights/Create
        public ActionResult Create()
        {
            ViewBag.ID_bus = new SelectList(db.bus, "ID_bus", "regist_number");
            ViewBag.ID_route = new SelectList(db.route, "ID_route", "destination");
            return View();
        }

        // POST: flights/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_flight,driver,ID_bus,ID_route")] flight flight)
        {
            if (ModelState.IsValid)
            {
                db.flight.Add(flight);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_bus = new SelectList(db.bus, "ID_bus", "regist_number", flight.ID_bus);
            ViewBag.ID_route = new SelectList(db.route, "ID_route", "destination", flight.ID_route);
            return View(flight);
        }

        // GET: flights/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            flight flight = db.flight.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_bus = new SelectList(db.bus, "ID_bus", "regist_number", flight.ID_bus);
            ViewBag.ID_route = new SelectList(db.route, "ID_route", "destination", flight.ID_route);
            return View(flight);
        }

        // POST: flights/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_flight,driver,ID_bus,ID_route")] flight flight)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flight).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_bus = new SelectList(db.bus, "ID_bus", "regist_number", flight.ID_bus);
            ViewBag.ID_route = new SelectList(db.route, "ID_route", "destination", flight.ID_route);
            return View(flight);
        }

        // GET: flights/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            flight flight = db.flight.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            return View(flight);
        }

        // POST: flights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            flight flight = db.flight.Find(id);
            db.flight.Remove(flight);
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
