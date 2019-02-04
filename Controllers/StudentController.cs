using StudentApp.Models;
using System;
using System.Web.Mvc;

namespace StudentApp.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            StudentDBHandle dbhandle = new StudentDBHandle();
            ModelState.Clear();
            return View(dbhandle.GetStudents());
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            StudentDBHandle dbhandle = new StudentDBHandle();

            Student student = dbhandle.GetStudentDetails(id);
            ViewBag.Title = student.FirstName + " " + student.LastName;

            ModelState.Clear();
            return View(dbhandle.GetStudentClassDetails(id));
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    StudentDBHandle dbhandle = new StudentDBHandle();
                    if (dbhandle.AddStudent(student))
                    {
                        ViewBag.Message = "Student Added Successfully";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch(Exception e)
            {
                ViewBag.Message = e.ToString();
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            StudentDBHandle dbhandle = new StudentDBHandle();
            return View(dbhandle.GetStudentDetails(id));
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Student student)
        {
            try
            {
                StudentDBHandle dbhandle = new StudentDBHandle();
                dbhandle.UpdateDetails(student);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                StudentDBHandle dbhandle = new StudentDBHandle();
                if (dbhandle.DeleteStudent(id))
                {
                    ViewBag.AlertMsg = "Student Deleted Successfully";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
