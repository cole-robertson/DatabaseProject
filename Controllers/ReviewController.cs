using StudentApp.Models;
using System;
using System.Web.Mvc;

namespace StudentApp.Controllers
{
    public class ReviewController : Controller
    {
        // GET: Review
        public ActionResult Index()
        {
            ReviewDBHandle dbhandle = new ReviewDBHandle();
            ModelState.Clear();
            return View(dbhandle.GetReviews());
        }

        // GET: Review/Details/5
        public ActionResult Details(int id)
        {
            ReviewDBHandle dbhandle = new ReviewDBHandle();
            ModelState.Clear();
            return View(dbhandle.GetReviewDetails(id));
        }

        // GET: Review/Create

        public ActionResult Create()
        {
            return View();
        }

        // POST: Review/Create
        [HttpPost]
        public ActionResult Create(Review review)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ReviewDBHandle dbhandle = new ReviewDBHandle();
                    if (dbhandle.AddReview(review))
                    {
                        ViewBag.Message = "Review Added Successfully";
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

        // GET: Review/Edit/5
        public ActionResult Edit(int id)
        {
            ReviewDBHandle dbhandle = new ReviewDBHandle();
            return View(dbhandle.GetReviewDetails(id));
        }

        // POST: Review/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Review review)
        {
            try
            {
                ReviewDBHandle dbhandle = new ReviewDBHandle();
                dbhandle.UpdateDetails(review);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Review/Delete/5
        public ActionResult Delete(int id)
        {
            ReviewDBHandle dbhandle = new ReviewDBHandle();
            return View(dbhandle.GetReviewDetails(id));
        }

        // POST: Review/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Review review)
        {
            try
            {
                ReviewDBHandle dbhandle = new ReviewDBHandle();
                if (dbhandle.DeleteReview(id))
                {
                    ViewBag.AlertMsg = "Review Deleted Successfully";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
        
    }
}
