using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RexsReptileReviews.Models;

namespace RexsReptileReviews.Controllers
{
    public class ReviewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Reviews
        public ActionResult Index()
        {
            return View(db.reviews.ToList());
        }

        [HttpGet]
        public ActionResult Index(string sortOrder)
        {
            ViewBag.ExperienceLevels = ListOfExperienceLevels();

            IEnumerable<Review> reviewsList = db.reviews.ToList();
            switch (sortOrder)
            {
                case "Author":
                    reviewsList = reviewsList.OrderBy(review => review.Author);
                    break;
                case "Title":
                    reviewsList = reviewsList.OrderBy(review => review.Title);
                    break;
                case "Reptile":
                    reviewsList = reviewsList.OrderBy(review => review.Reptile);
                    break;
                case "Rating":
                    reviewsList = reviewsList.OrderBy(review => review.Rating);
                    break;
                case "ExperienceLevel":
                    reviewsList = reviewsList.OrderBy(review => review.ExperienceLevel);
                    break;
                default:
                    reviewsList = reviewsList.OrderBy(review => review.Author);
                    break;
            }
            return View(reviewsList);
        }

        [HttpPost]
        public ActionResult Index(string searchCriteria, string ExperienceFilter)
        {
            IEnumerable<Review> reviewsList = db.reviews.ToList();

            if (searchCriteria != null)
            {
                reviewsList = reviewsList.Where(review => review.Title.ToUpper().Contains(searchCriteria.ToUpper()));
            }

            //if (ExperienceFilter != "" || ExperienceFilter != null)
            //{
            //    reviewsList = reviewsList.Where(review => review.ExperienceLevel.ToString() == ExperienceFilter);
            //}

            return View(reviewsList);
        }

        [NonAction]
        private IEnumerable<string> ListOfExperienceLevels()
        {
            IEnumerable<string> levels = Enum.GetNames(typeof(ExperienceLevelType));

            //IEnumerable<Review> reviewsList = db.reviews.ToList();

            //var experienceLevels = reviewsList.Select(review => review.ExperienceLevel.ToString().Distinct().OrderBy(x => x)) as IEnumerable<string>;

            return levels;
        }

        // GET: Reviews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // GET: Reviews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Author,DateTime,Title,Reptile,Rating,ExperienceLevel,Body")] Review review)
        {
            if (ModelState.IsValid)
            {
                db.reviews.Add(review);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(review);
        }

        // GET: Reviews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Author,DateTime,Title,Reptile,Rating,ExperienceLevel,Body")] Review review)
        {
            if (ModelState.IsValid)
            {
                db.Entry(review).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(review);
        }

        // GET: Reviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Review review = db.reviews.Find(id);
            db.reviews.Remove(review);
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
