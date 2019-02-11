using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FlightFinalSite.Models;

namespace FlightFinalSite.Controllers
{
    public class RoutesController : Controller
    {
        private FlightFinalEntities db = new FlightFinalEntities();

        // GET: Routes
        public ActionResult Index()
        {
            var route = db.Route.Include(r => r.Plane);
            return View(route.ToList());
        }

        // GET: Routes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Route route = db.Route.Find(id);
            if (route == null)
            {
                return HttpNotFound();
            }
            return View(route);
        }

        // GET: Routes/Create
        public ActionResult Create()
        {
            ViewBag.RoutePlaneID = new SelectList(db.Plane, "PlaneID", "PlaneName");
            return View();
        }

        // POST: Routes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RouteID,RouteFlightNumber,RoutePlaneID,RouteDepAirport,RouteArrAirport,RouteDepDate,RouteArrTDate")] Route route)
        {
            if (ModelState.IsValid)
            {
                db.Route.Add(route);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoutePlaneID = new SelectList(db.Plane, "PlaneID", "PlaneName", route.RoutePlaneID);
            return View(route);
        }

        // GET: Routes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Route route = db.Route.Find(id);
            if (route == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoutePlaneID = new SelectList(db.Plane, "PlaneID", "PlaneName", route.RoutePlaneID);
            return View(route);
        }

        // POST: Routes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RouteID,RouteFlightNumber,RoutePlaneID,RouteDepAirport,RouteArrAirport,RouteDepDate,RouteArrTDate")] Route route)
        {
            if (ModelState.IsValid)
            {
                db.Entry(route).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoutePlaneID = new SelectList(db.Plane, "PlaneID", "PlaneName", route.RoutePlaneID);
            return View(route);
        }

        // GET: Routes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Route route = db.Route.Find(id);
            if (route == null)
            {
                return HttpNotFound();
            }
            return View(route);
        }

        // POST: Routes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Route route = db.Route.Find(id);
            db.Route.Remove(route);
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
