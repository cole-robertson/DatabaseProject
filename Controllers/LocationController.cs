using StudentApp.Models;
using System;
using System.Web.Mvc;

namespace StudentApp.Controllers
{
    public class LocationController : Controller
    {
        // GET: Location
        public ActionResult Index()
        {
            LocationDBHandle dbhandle = new LocationDBHandle();
            ModelState.Clear();
            return View(dbhandle.GetLocations());
        }

        // GET: Location/Details/5
        public ActionResult Details(int id)
        {
            LocationDBHandle dbhandle = new LocationDBHandle();
            ModelState.Clear();
            return View(dbhandle.GetLocationDetails(id));
        }

        // GET: Location/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Location/Create
        [HttpPost]
        public ActionResult Create(Location location)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    LocationDBHandle dbhandle = new LocationDBHandle();
                    if (dbhandle.AddLocation(location))
                    {
                        ViewBag.Message = "Location Added Successfully";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch (Exception e)
            {
                ViewBag.Message = e.ToString();
                return View();
            }
        }

        // GET: Location/Edit/5
        public ActionResult Edit(int id)
        {
            LocationDBHandle dbhandle = new LocationDBHandle();
            return View(dbhandle.GetLocations().Find(location => location.LocationId == id));
        }

        // POST: Location/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Location location)
        {
            try
            {
                LocationDBHandle dbhandle = new LocationDBHandle();
                dbhandle.UpdateDetails(location);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Location/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Location/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
