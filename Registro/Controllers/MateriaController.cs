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
    public class MateriaController : Controller
    {
        private RegistroEntities db = new RegistroEntities();

        // GET: Materia
        public ActionResult Index()
        {
            return View(db.mat_materia.ToList());
        }

        // GET: Materia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mat_materia mat_materia = db.mat_materia.Find(id);
            if (mat_materia == null)
            {
                return HttpNotFound();
            }
            return View(mat_materia);
        }

        // GET: Materia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Materia/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "mat_id,mat_nombre")] mat_materia mat_materia)
        {
            if (ModelState.IsValid)
            {
                db.mat_materia.Add(mat_materia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mat_materia);
        }

        // GET: Materia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mat_materia mat_materia = db.mat_materia.Find(id);
            if (mat_materia == null)
            {
                return HttpNotFound();
            }
            return View(mat_materia);
        }

        // POST: Materia/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "mat_id,mat_nombre")] mat_materia mat_materia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mat_materia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mat_materia);
        }

        // GET: Materia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mat_materia mat_materia = db.mat_materia.Find(id);
            if (mat_materia == null)
            {
                return HttpNotFound();
            }
            return View(mat_materia);
        }

        // POST: Materia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            mat_materia mat_materia = db.mat_materia.Find(id);
            db.mat_materia.Remove(mat_materia);
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
