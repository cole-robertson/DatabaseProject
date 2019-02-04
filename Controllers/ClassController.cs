using StudentApp.Models;
using System;
using System.Web.Mvc;

namespace StudentApp.Controllers
{
    public class ClassController : Controller
    {
        // GET: Class
        public ActionResult Index()
        {
            ClassDBHandle dbhandle = new ClassDBHandle();
            ModelState.Clear();
            return View(dbhandle.GetClasses());
        }

        [HttpPost]
        public ActionResult Index(string firstName, string lastName, string department, string days, string startTime, string endTime, string termName, string termYear, string type)
        {
            TempData["firstName"] = firstName;
            TempData["lastName"] = lastName;
            TempData["department"] = department;
            TempData["days"] = days;
            TempData["startTime"] = startTime;
            TempData["endTime"] = endTime;
            TempData["termName"] = termName;
            TempData["termYear"] = termYear;
            TempData["type"] = type;
            
            ClassDBHandle dbhandle = new ClassDBHandle();
            ModelState.Clear();
            return View(dbhandle.GetFilteredClasses(firstName, lastName, department, days, startTime, endTime, termName, termYear, type));
        }

        // GET: Class/Details/5
        public ActionResult Details(int classId)
        {
            ClassDBHandle classdb = new ClassDBHandle();
            ReviewDBHandle reviewdb = new ReviewDBHandle();
            ModelState.Clear();
            return View(new ClassReviewViewModel(classdb.GetFullClassDetails(classId), reviewdb.GetReviewsByClassId(classId)));
        }

        // GET: Class/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Class/Create
        [HttpPost]
        public ActionResult Create(Class classModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ClassDBHandle dbhandle = new ClassDBHandle();
                    if (dbhandle.AddClass(classModel))
                    {
                        ViewBag.Message = "Class Added Successfully";
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

        // GET: Class/Edit/5
        public ActionResult Edit(int id)
        {
            ClassDBHandle dbhandle = new ClassDBHandle();
            return View(dbhandle.GetClassDetails(id));
        }

        // POST: Class/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Class classModel)
        {
            try
            {
                ClassDBHandle dbhandle = new ClassDBHandle();
                dbhandle.UpdateDetails(classModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult AddReview(int id)
        {
            TempData["ClassId"] = id;
            return RedirectToAction("Create", "Review");
        }

        public ActionResult ClassCount()
        {
            ClassDBHandle classDBHandle = new ClassDBHandle();
            return View(classDBHandle.GetStudentCount());
        }

        public ActionResult ReviewParticipation()
        {
            ClassDBHandle classDBHandle = new ClassDBHandle();
            return View(classDBHandle.ReviewParticipation());
        }
    }
}
