using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineArtGalleryProject.Models;

namespace OnlineArtGalleryProject.Controllers
{
    public class ArtGalleriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ArtGalleries
        public ActionResult Index()
        {
            return View(db.ArtGalleries.ToList());
        }

        // GET: ArtGalleries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtGallery artGallery = db.ArtGalleries.Find(id);
            if (artGallery == null)
            {
                return HttpNotFound();
            }
            return View(artGallery);
        }

        // GET: ArtGalleries/Create
        [Authorize(Roles = "Administrator,Editor")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArtGalleries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator,Editor")]
        public ActionResult Create([Bind(Include = "Id,Name,Address,ImageURL,Description")] ArtGallery artGallery)
        {
            if (ModelState.IsValid)
            {
                db.ArtGalleries.Add(artGallery);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(artGallery);
        }

        // GET: ArtGalleries/Edit/5
        [Authorize(Roles = "Administrator,Editor")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtGallery artGallery = db.ArtGalleries.Find(id);
            if (artGallery == null)
            {
                return HttpNotFound();
            }
            return View(artGallery);
        }

        // POST: ArtGalleries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator,Editor")]
        public ActionResult Edit([Bind(Include = "Id,Name,Address,ImageURL,Description")] ArtGallery artGallery)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artGallery).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(artGallery);
        }

        // GET: ArtGalleries/Delete/5
        [Authorize(Roles = "Administrator,Editor")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtGallery artGallery = db.ArtGalleries.Find(id);
            if (artGallery == null)
            {
                return HttpNotFound();
            }
            return View(artGallery);
        }

        // POST: ArtGalleries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator,Editor")]
        public ActionResult DeleteConfirmed(int id)
        {
            ArtGallery artGallery = db.ArtGalleries.Find(id);
            db.ArtGalleries.Remove(artGallery);
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
