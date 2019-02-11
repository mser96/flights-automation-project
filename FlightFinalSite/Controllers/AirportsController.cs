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
    public class AirportsController : Controller
    {
        private FlightFinalEntities db = new FlightFinalEntities();

        // GET: Airports
        public ActionResult Index()
        {
            return View(db.Airport.ToList());
        }

        // GET: Airports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Airport airport = db.Airport.Find(id);
            if (airport == null)
            {
                return HttpNotFound();
            }
            return View(airport);
        }

        // GET: Airports/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Airports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AirportID,AirportName,AirportCountry,AirportCity,AirportAbbre")] Airport airport)
        {
            if (ModelState.IsValid)
            {
                db.Airport.Add(airport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(airport);
        }

        // GET: Airports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Airport airport = db.Airport.Find(id);
            if (airport == null)
            {
                return HttpNotFound();
            }
            return View(airport);
        }

        // POST: Airports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AirportID,AirportName,AirportCountry,AirportCity,AirportAbbre")] Airport airport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(airport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(airport);
        }

        // GET: Airports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Airport airport = db.Airport.Find(id);
            if (airport == null)
            {
                return HttpNotFound();
            }
            return View(airport);
        }

        // POST: Airports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Airport airport = db.Airport.Find(id);
            db.Airport.Remove(airport);
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
