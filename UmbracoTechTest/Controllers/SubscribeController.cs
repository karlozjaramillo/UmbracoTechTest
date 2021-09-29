using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using UmbracoTechTest.Models;

namespace UmbracoTechTest.Controllers
{
    public class SubscribeController : SurfaceController
    {
        private Umbraco_Tech_TestEntities db = new Umbraco_Tech_TestEntities();

        // GET: Subscribe
        public ActionResult Index()
        {
            return View(db.Subscribe.ToList());
        }

        // GET: Subscribe/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscribe subscribe = db.Subscribe.Find(id);
            if (subscribe == null)
            {
                return HttpNotFound();
            }
            return View(subscribe);
        }

        // GET: Subscribe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Subscribe/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "email,date,status")] Subscribe subscribe)
        {
            if (ModelState.IsValid)
            {
                db.Subscribe.Add(subscribe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subscribe);
        }

        // GET: Subscribe/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscribe subscribe = db.Subscribe.Find(id);
            if (subscribe == null)
            {
                return HttpNotFound();
            }
            return View(subscribe);
        }

        // POST: Subscribe/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "email,date,status")] Subscribe subscribe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subscribe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subscribe);
        }

        // GET: Subscribe/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscribe subscribe = db.Subscribe.Find(id);
            if (subscribe == null)
            {
                return HttpNotFound();
            }
            return View(subscribe);
        }

        // POST: Subscribe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Subscribe subscribe = db.Subscribe.Find(id);
            db.Subscribe.Remove(subscribe);
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

        [HttpPost]
        public ActionResult SubmitForm([Bind(Include = "email,date,status")] Subscribe subscribe)
        {
            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }

            var vDate = DateTime.Now;
            var vStatus = "active";
            subscribe.date = vDate;
            subscribe.status = vStatus;
            db.Subscribe.Add(subscribe);
            db.SaveChanges();

            return RedirectToCurrentUmbracoPage();
        }
    }
}
