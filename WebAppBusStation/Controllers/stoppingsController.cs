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
    public class stoppingsController : Controller
    {
        private bus_stationEntities db = new bus_stationEntities();

        // GET: stoppings
        public ActionResult Index()
        {
            return View(db.stopping.ToList());
        }

        // GET: stoppings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stopping stopping = db.stopping.Find(id);
            if (stopping == null)
            {
                return HttpNotFound();
            }
            return View(stopping);
        }

        // GET: stoppings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: stoppings/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_stopping,stop_name,arrival_time")] stopping stopping)
        {
            if (ModelState.IsValid)
            {
                db.stopping.Add(stopping);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stopping);
        }

        // GET: stoppings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stopping stopping = db.stopping.Find(id);
            if (stopping == null)
            {
                return HttpNotFound();
            }
            return View(stopping);
        }

        // POST: stoppings/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_stopping,stop_name,arrival_time")] stopping stopping)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stopping).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stopping);
        }

        // GET: stoppings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stopping stopping = db.stopping.Find(id);
            if (stopping == null)
            {
                return HttpNotFound();
            }
            return View(stopping);
        }

        // POST: stoppings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            stopping stopping = db.stopping.Find(id);
            db.stopping.Remove(stopping);
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
