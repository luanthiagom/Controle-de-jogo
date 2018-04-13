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
    public class JogoController : Controller
    {
        private ControleJogosEntities db = new ControleJogosEntities();

        // GET: Jogo
        public ActionResult Index()
        {
            return View(db.Jogo.ToList());
        }

        // GET: Jogo/Details/5
        public ActionResult Details(decimal id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Jogo jogo = db.Jogo.Find(id);
                if (jogo == null)
                {
                    return HttpNotFound();
                }
                return View(jogo);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.InnerException.Message;
            }
            return View();
        }

        // GET: Jogo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jogo/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JOGOID,NOME")] Jogo jogo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Jogo.Add(jogo);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(jogo);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.InnerException.Message;
            }
            return View(jogo);
        }

        // GET: Jogo/Edit/5
        public ActionResult Edit(decimal id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Jogo jogo = db.Jogo.Find(id);
                if (jogo == null)
                {
                    return HttpNotFound();
                }
                return View(jogo);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.InnerException.Message;
            }
            return View();
        }

        // POST: Jogo/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JOGOID,NOME")] Jogo jogo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(jogo).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(jogo);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.InnerException.Message;
            }
            return View(jogo);
        }

        // GET: Jogo/Delete/5
        public ActionResult Delete(decimal id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Jogo jogo = db.Jogo.Find(id);
                if (jogo == null)
                {
                    return HttpNotFound();
                }
                return View(jogo);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.InnerException.Message;
            }
            return View();
        }

        // POST: Jogo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            try
            {
                Jogo jogo = db.Jogo.Find(id);
                db.Jogo.Remove(jogo);
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
