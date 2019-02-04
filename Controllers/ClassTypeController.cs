using StudentApp.Models;
using System.Web.Mvc;

namespace StudentApp.Controllers
{
    public class ClassTypeController : Controller
    {
        // GET: ClassType
        public ActionResult Index()
        {
            ClassTypeDBHandle dbhandle = new ClassTypeDBHandle();
            ModelState.Clear();
            return View(dbhandle.GetClassTypes());
        }

        public ActionResult ClassTypeCount()
        {
            ClassTypeDBHandle classTypeDBHandle = new ClassTypeDBHandle();
            return View(classTypeDBHandle.ClassTypeCount());
        }
        
    }
}
