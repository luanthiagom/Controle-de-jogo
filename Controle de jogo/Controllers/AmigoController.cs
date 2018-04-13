using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Controle_de_jogo.Models;

namespace Controle_de_jogo.Controllers
{
    [Authorize]
    public class AmigoController : Controller
    {
        private ControleJogosEntities db = new ControleJogosEntities();

        // GET: Amigo
        public ActionResult Index()
        {
            return View(db.Amigo.ToList());
        }

        // GET: Amigo/Details/5
        public ActionResult Details(decimal id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Amigo amigo = db.Amigo.Find(id);
                if (amigo == null)
                {
                    return HttpNotFound();
                }
                return View(amigo);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.InnerException.Message;
            }
            return View();
        }

        // GET: Amigo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Amigo/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AMIGOID,NOME")] Amigo amigo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Amigo.Add(amigo);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(amigo);
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.InnerException.Message;
            }
            return View(amigo);
        }

        // GET: Amigo/Edit/5
        public ActionResult Edit(decimal id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Amigo amigo = db.Amigo.Find(id);
                if (amigo == null)
                {
                    return HttpNotFound();
                }
                return View(amigo);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.InnerException.Message;
            }
            return View();
        }

        // POST: Amigo/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AMIGOID,NOME")] Amigo amigo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(amigo).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(amigo);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.InnerException.Message;
            }
            return View(amigo);
        }

        // GET: Amigo/Delete/5
        public ActionResult Delete(decimal id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Amigo amigo = db.Amigo.Find(id);
                if (amigo == null)
                {
                    return HttpNotFound();
                }
                return View(amigo);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.InnerException.Message;
            }
            return View();
        }

        // POST: Amigo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            try
            {
                Amigo amigo = db.Amigo.Find(id);
                db.Amigo.Remove(amigo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.InnerException.Message;
            }
            return View();
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
