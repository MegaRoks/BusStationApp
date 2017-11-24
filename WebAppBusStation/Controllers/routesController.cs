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
    public class routesController : Controller
    {
        private bus_stationEntities db = new bus_stationEntities();

        // GET: routes
        public ActionResult Index()
        {
            var route = db.route.Include(r => r.stopping);
            return View(route.ToList());
        }

        // GET: routes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            route route = db.route.Find(id);
            if (route == null)
            {
                return HttpNotFound();
            }
            return View(route);
        }

        // GET: routes/Create
        public ActionResult Create()
        {
            ViewBag.ID_stopping = new SelectList(db.stopping, "ID_stopping", "stop_name");
            return View();
        }

        // POST: routes/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_route,destination,departure_time,route_number,days_of_movement,distance,ticket_price,ID_stopping")] route route)
        {
            if (ModelState.IsValid)
            {
                db.route.Add(route);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_stopping = new SelectList(db.stopping, "ID_stopping", "stop_name", route.ID_stopping);
            return View(route);
        }

        // GET: routes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            route route = db.route.Find(id);
            if (route == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_stopping = new SelectList(db.stopping, "ID_stopping", "stop_name", route.ID_stopping);
            return View(route);
        }

        // POST: routes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_route,destination,departure_time,route_number,days_of_movement,distance,ticket_price,ID_stopping")] route route)
        {
            if (ModelState.IsValid)
            {
                db.Entry(route).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_stopping = new SelectList(db.stopping, "ID_stopping", "stop_name", route.ID_stopping);
            return View(route);
        }

        // GET: routes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            route route = db.route.Find(id);
            if (route == null)
            {
                return HttpNotFound();
            }
            return View(route);
        }

        // POST: routes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            route route = db.route.Find(id);
            db.route.Remove(route);
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
