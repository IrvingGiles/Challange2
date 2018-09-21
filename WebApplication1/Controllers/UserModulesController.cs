using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UserModulesController : Controller
    {
        private Entities db = new Entities();

        // GET: UserModules
        public ActionResult Index()
        {
            return View(db.UserModules.ToList());
        }

        // GET: UserModules/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserModule userModule = db.UserModules.Find(id);
            if (userModule == null)
            {
                return HttpNotFound();
            }
            return View(userModule);
        }

        // GET: UserModules/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserModules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MacAddress,DateIssued")] UserModule userModule)
        {
            if (ModelState.IsValid)
            {
                db.UserModules.Add(userModule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userModule);
        }

        // GET: UserModules/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserModule userModule = db.UserModules.Find(id);
            if (userModule == null)
            {
                return HttpNotFound();
            }
            return View(userModule);
        }

        // POST: UserModules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MacAddress,DateIssued")] UserModule userModule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userModule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userModule);
        }

        // GET: UserModules/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserModule userModule = db.UserModules.Find(id);
            if (userModule == null)
            {
                return HttpNotFound();
            }
            return View(userModule);
        }

        // POST: UserModules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            UserModule userModule = db.UserModules.Find(id);
            db.UserModules.Remove(userModule);
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
