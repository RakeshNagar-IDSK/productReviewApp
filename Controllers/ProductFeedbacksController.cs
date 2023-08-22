using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SampleAppDemo.Models;

namespace SampleAppDemo.Controllers
{
    public class ProductFeedbacksController : Controller
    {
        private northwindEntities db = new northwindEntities();

        // GET: ProductFeedbacks
        public async Task<ActionResult> Index()
        {
            var productFeedbacks = db.ProductFeedbacks;
            return View(await productFeedbacks.ToListAsync());
        }

        // GET: ProductFeedbacks/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductFeedback productFeedback = await db.ProductFeedbacks.FindAsync(id);
            if (productFeedback == null)
            {
                return HttpNotFound();
            }
            return View(productFeedback);
        }

        // GET: ProductFeedbacks/Create
        public ActionResult Create()
        {
            ViewBag.RatingID = new SelectList(db.ProductFeedbacks, "RatingID", "RatingType");
            ViewBag.RatingID = new SelectList(db.ProductFeedbacks, "RatingID", "RatingType");
            return View();
        }

        // POST: ProductFeedbacks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "RatingID,RatingType,ProductReview,ProductId")] ProductFeedback productFeedback)
        {
            if (ModelState.IsValid)
            {
                db.ProductFeedbacks.Add(productFeedback);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.RatingID = new SelectList(db.ProductFeedbacks, "RatingID", "RatingType", productFeedback.RatingID);
            ViewBag.RatingID = new SelectList(db.ProductFeedbacks, "RatingID", "RatingType", productFeedback.RatingID);
            return View(productFeedback);
        }

        // GET: ProductFeedbacks/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductFeedback productFeedback = await db.ProductFeedbacks.FindAsync(id);
            if (productFeedback == null)
            {
                return HttpNotFound();
            }
            ViewBag.RatingID = new SelectList(db.ProductFeedbacks, "RatingID", "RatingType", productFeedback.RatingID);
            ViewBag.RatingID = new SelectList(db.ProductFeedbacks, "RatingID", "RatingType", productFeedback.RatingID);
            return View(productFeedback);
        }

        // POST: ProductFeedbacks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "RatingID,RatingType,ProductReview,ProductId")] ProductFeedback productFeedback)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productFeedback).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.RatingID = new SelectList(db.ProductFeedbacks, "RatingID", "RatingType", productFeedback.RatingID);
            ViewBag.RatingID = new SelectList(db.ProductFeedbacks, "RatingID", "RatingType", productFeedback.RatingID);
            return View(productFeedback);
        }

        // GET: ProductFeedbacks/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductFeedback productFeedback = await db.ProductFeedbacks.FindAsync(id);
            if (productFeedback == null)
            {
                return HttpNotFound();
            }
            return View(productFeedback);
        }

        // POST: ProductFeedbacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ProductFeedback productFeedback = await db.ProductFeedbacks.FindAsync(id);
            db.ProductFeedbacks.Remove(productFeedback);
            await db.SaveChangesAsync();
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
