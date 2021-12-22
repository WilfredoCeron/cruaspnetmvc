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
    public class AlumnoController : Controller
    {
        private RegistroEntities db = new RegistroEntities();

        // GET: Alumno
        public ActionResult Index()
        {
            var alm_alumno = db.alm_alumno.Include(a => a.grd_grado);
            return View(alm_alumno.ToList());
        }

        // GET: Alumno/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            alm_alumno alm_alumno = db.alm_alumno.Find(id);
            if (alm_alumno == null)
            {
                return HttpNotFound();
            }
            return View(alm_alumno);
        }

        // GET: Alumno/Create
        public ActionResult Create()
        {
            ViewBag.alm_id_grd = new SelectList(db.grd_grado, "grd_id", "grd_nombre");
            return View();
        }

        // POST: Alumno/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "alm_id,alm_codigo,alm_nombre,alm_edad,alm_sexo,alm_id_grd,alm_descripcion")] alm_alumno alm_alumno)
        {
            if (ModelState.IsValid)
            {
                db.alm_alumno.Add(alm_alumno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.alm_id_grd = new SelectList(db.grd_grado, "grd_id", "grd_nombre", alm_alumno.alm_id_grd);
            return View(alm_alumno);
        }

        // GET: Alumno/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            alm_alumno alm_alumno = db.alm_alumno.Find(id);
            if (alm_alumno == null)
            {
                return HttpNotFound();
            }
            ViewBag.alm_id_grd = new SelectList(db.grd_grado, "grd_id", "grd_nombre", alm_alumno.alm_id_grd);
            return View(alm_alumno);
        }

        // POST: Alumno/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "alm_id,alm_codigo,alm_nombre,alm_edad,alm_sexo,alm_id_grd,alm_descripcion")] alm_alumno alm_alumno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alm_alumno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.alm_id_grd = new SelectList(db.grd_grado, "grd_id", "grd_nombre", alm_alumno.alm_id_grd);
            return View(alm_alumno);
        }

        // GET: Alumno/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            alm_alumno alm_alumno = db.alm_alumno.Find(id);
            if (alm_alumno == null)
            {
                return HttpNotFound();
            }
            return View(alm_alumno);
        }

        // POST: Alumno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            alm_alumno alm_alumno = db.alm_alumno.Find(id);
            db.alm_alumno.Remove(alm_alumno);
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
