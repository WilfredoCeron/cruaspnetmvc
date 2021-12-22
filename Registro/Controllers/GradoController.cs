using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Registro.Controllers
{
    public class GradoController : Controller
    {
        private RegistroEntities db = new RegistroEntities();

        // GET: Grado
        public ActionResult Index()
        {
            return View(db.grd_grado.ToList());
        }

        // GET: Grado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            grd_grado grd_grado = db.grd_grado.Find(id);
            if (grd_grado == null)
            {
                return HttpNotFound();
            }
            return View(grd_grado);
        }

        // GET: Grado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Grado/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "grd_id,grd_nombre")] grd_grado grd_grado)
        {
            if (ModelState.IsValid)
            {
                db.grd_grado.Add(grd_grado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(grd_grado);
        }

        // GET: Grado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            grd_grado grd_grado = db.grd_grado.Find(id);
            if (grd_grado == null)
            {
                return HttpNotFound();
            }
            return View(grd_grado);
        }

        // POST: Grado/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "grd_id,grd_nombre")] grd_grado grd_grado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grd_grado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(grd_grado);
        }

        // GET: Grado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            grd_grado grd_grado = db.grd_grado.Find(id);
            if (grd_grado == null)
            {
                return HttpNotFound();
            }
            return View(grd_grado);
        }

        // POST: Grado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            grd_grado grd_grado = db.grd_grado.Find(id);
            db.grd_grado.Remove(grd_grado);
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
