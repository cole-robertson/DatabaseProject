using StudentApp.Models;
using System;
using System.Web.Mvc;

namespace StudentApp.Controllers
{
    public class InstructorController : Controller
    {
        // GET: Instructor
        public ActionResult Index()
        {
            InstructorDBHandle dbhandle = new InstructorDBHandle();
            ModelState.Clear();
            return View(dbhandle.GetInstructors());
        }

        // GET: Instructor/Details/5
        public ActionResult Details(int id)
        {
            InstructorDBHandle instructordb = new InstructorDBHandle();
            ClassDBHandle classdb = new ClassDBHandle();
            ModelState.Clear();
            return View(new InstructorClassReviewViewModel(instructordb.GetInstructorDetails(id), instructordb.GetInstructorsAvgRating(id), classdb.GetClassDetailsByInstructor(id)));
        }

        // GET: Instructor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Instructor/Create
        [HttpPost]
        public ActionResult Create(Instructor instructor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    InstructorDBHandle dbhandle = new InstructorDBHandle();
                    if (dbhandle.AddInstructor(instructor))
                    {
                        ViewBag.Message = "Instructor Added Successfully";
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

        // GET: Instructor/Edit/5
        public ActionResult Edit(int id)
        {
            InstructorDBHandle dbhandle = new InstructorDBHandle();
            return View(dbhandle.GetInstructors().Find(instructor => instructor.InstructorId == id));
        }

        // POST: Instructor/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Instructor instructor)
        {
            try
            {
                InstructorDBHandle dbhandle = new InstructorDBHandle();
                dbhandle.UpdateDetails(instructor);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Instructor/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Instructor/Delete/5
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

        public ActionResult AverageRatings()
        {
            if(TempData["range"] == null)
            {
                TempData["range"] = 1;
            }
            InstructorDBHandle instructorDBHandle = new InstructorDBHandle();
            return View(instructorDBHandle.AverageRatings((int)TempData.Peek("range")));
        }

        [HttpPost]
        public ActionResult AverageRatings(int range)
        {
            TempData["range"] = range;
            InstructorDBHandle instructorDBHandle = new InstructorDBHandle();
            return View(instructorDBHandle.AverageRatings(range));
        }


    }
}
