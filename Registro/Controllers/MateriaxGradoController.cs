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
    public class MateriaxGradoController : Controller
    {
        private RegistroEntities db = new RegistroEntities();

        // GET: MateriaxGrado
        public ActionResult Index()
        {
            var mxg_materiaxgrado = db.mxg_materiaxgrado.Include(m => m.grd_grado).Include(m => m.mat_materia);
            return View(mxg_materiaxgrado.ToList());
        }

        // GET: MateriaxGrado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mxg_materiaxgrado mxg_materiaxgrado = db.mxg_materiaxgrado.Find(id);
            if (mxg_materiaxgrado == null)
            {
                return HttpNotFound();
            }
            return View(mxg_materiaxgrado);
        }

        // GET: MateriaxGrado/Create
        public ActionResult Create()
        {
            ViewBag.mxg_id_grd = new SelectList(db.grd_grado, "grd_id", "grd_nombre");
            ViewBag.mxg_id_mat = new SelectList(db.mat_materia, "mat_id", "mat_nombre");
            return View();
        }

        // POST: MateriaxGrado/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "mxg_id,mxg_id_grd,mxg_id_mat")] mxg_materiaxgrado mxg_materiaxgrado)
        {
            if (ModelState.IsValid)
            {
                db.mxg_materiaxgrado.Add(mxg_materiaxgrado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.mxg_id_grd = new SelectList(db.grd_grado, "grd_id", "grd_nombre", mxg_materiaxgrado.mxg_id_grd);
            ViewBag.mxg_id_mat = new SelectList(db.mat_materia, "mat_id", "mat_nombre", mxg_materiaxgrado.mxg_id_mat);
            return View(mxg_materiaxgrado);
        }

        // GET: MateriaxGrado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mxg_materiaxgrado mxg_materiaxgrado = db.mxg_materiaxgrado.Find(id);
            if (mxg_materiaxgrado == null)
            {
                return HttpNotFound();
            }
            ViewBag.mxg_id_grd = new SelectList(db.grd_grado, "grd_id", "grd_nombre", mxg_materiaxgrado.mxg_id_grd);
            ViewBag.mxg_id_mat = new SelectList(db.mat_materia, "mat_id", "mat_nombre", mxg_materiaxgrado.mxg_id_mat);
            return View(mxg_materiaxgrado);
        }

        // POST: MateriaxGrado/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "mxg_id,mxg_id_grd,mxg_id_mat")] mxg_materiaxgrado mxg_materiaxgrado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mxg_materiaxgrado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.mxg_id_grd = new SelectList(db.grd_grado, "grd_id", "grd_nombre", mxg_materiaxgrado.mxg_id_grd);
            ViewBag.mxg_id_mat = new SelectList(db.mat_materia, "mat_id", "mat_nombre", mxg_materiaxgrado.mxg_id_mat);
            return View(mxg_materiaxgrado);
        }

        // GET: MateriaxGrado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mxg_materiaxgrado mxg_materiaxgrado = db.mxg_materiaxgrado.Find(id);
            if (mxg_materiaxgrado == null)
            {
                return HttpNotFound();
            }
            return View(mxg_materiaxgrado);
        }

        // POST: MateriaxGrado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            mxg_materiaxgrado mxg_materiaxgrado = db.mxg_materiaxgrado.Find(id);
            db.mxg_materiaxgrado.Remove(mxg_materiaxgrado);
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
