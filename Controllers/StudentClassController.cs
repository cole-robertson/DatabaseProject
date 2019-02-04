using StudentApp.Models;
using System;
using System.Web.Mvc;

namespace StudentApp.Controllers
{
    public class StudentClassController : Controller
    {
        // GET: StudentClass
        public ActionResult Index()
        {
            StudentClassDBHandle dbhandle = new StudentClassDBHandle();
            ModelState.Clear();
            return View(dbhandle.GetStudents());
        }

        // GET: StudentClass/Create
        public ActionResult Create(EnrollViewModel enrollViewModel)
        {
            if(enrollViewModel == null)
            {
                enrollViewModel = new EnrollViewModel();
            }
            if (enrollViewModel.Days == null)
            {
                enrollViewModel.Days = "";
            }
            TempData["firstName"] = enrollViewModel.FirstName;
            TempData["lastName"] = enrollViewModel.LastName;
            TempData["department"] = enrollViewModel.Department;
            TempData["days"] = enrollViewModel.Days;

            ClassDBHandle classDBHandle = new ClassDBHandle();
            ModelState.Clear();
            enrollViewModel.ClassList = classDBHandle.GetFilteredClasses(enrollViewModel.FirstName, enrollViewModel.LastName, enrollViewModel.Department, enrollViewModel.Days, enrollViewModel.StartTime, enrollViewModel.EndTime, enrollViewModel.TermName, enrollViewModel.TermYear, enrollViewModel.Type);
            
            return View(enrollViewModel);
        }

        // POST: StudentClass/Create
        [HttpPost]
        public ActionResult Create(EnrollViewModel enrollViewModel, string studentId, string classId)
        {
            
            //ClassDBHandle classDBHandle = new ClassDBHandle();
            //List<ClassDetails> classList = classDBHandle.GetClasses();
            try
            {
                ClassDBHandle classDBHandle = new ClassDBHandle();
                if ((classId == null || studentId == null) && enrollViewModel.Department != "")
                {
                    enrollViewModel.Days = "";
                    enrollViewModel.ClassList = classDBHandle.GetFilteredClasses(enrollViewModel.FirstName, enrollViewModel.LastName, enrollViewModel.Department, enrollViewModel.Days, enrollViewModel.StartTime, enrollViewModel.EndTime, enrollViewModel.TermName, enrollViewModel.TermYear, enrollViewModel.Type);
                    
                    return View(enrollViewModel);
                }
                if (ModelState.IsValid)
                {
                    StudentClassDBHandle dbhandle = new StudentClassDBHandle();

                    StudentClass studentClass = new StudentClass();
                    studentClass.ClassId = Convert.ToInt32(classId);
                    studentClass.StudentId = Convert.ToInt32(studentId);

                    if (dbhandle.AddStudentClass(studentClass))
                    {
                        ViewBag.Message = "Student Enrolled in Class Successfully";
                        ModelState.Clear();
                    }
                }
                enrollViewModel.ClassList   = classDBHandle.GetClasses();
                return View(enrollViewModel);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.ToString();
                return View(enrollViewModel);
            }
        }
    }
}
