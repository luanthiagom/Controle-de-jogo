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
    public class AmigoJogoController : Controller
    {
        private ControleJogosEntities db = new ControleJogosEntities();

        // GET: AmigoJogo
        public ActionResult Index()
        {
            var amigoJogo = db.AmigoJogo.Include(a => a.Amigo).Include(a => a.Jogo);
            return View(amigoJogo.ToList());
        }

        // GET: AmigoJogo/Details/5
        public ActionResult Details(decimal id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                AmigoJogo amigoJogo = db.AmigoJogo.Find(id);
                if (amigoJogo == null)
                {
                    return HttpNotFound();
                }
                return View(amigoJogo);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.InnerException.Message;
            }
            return View();
        }

        // GET: AmigoJogo/Create
        public ActionResult Create()
        {
            ViewBag.AMIGOID = new SelectList(db.Amigo, "AMIGOID", "NOME");
            ViewBag.JOGOID = new SelectList(db.Jogo, "JOGOID", "NOME");
            return View();
        }

        // POST: AmigoJogo/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AMIGOJOGOID,JOGOID,AMIGOID,DATAEMPRESTIMO")] AmigoJogo amigoJogo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.AmigoJogo.Add(amigoJogo);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.AMIGOID = new SelectList(db.Amigo, "AMIGOID", "NOME", amigoJogo.AMIGOID);
                ViewBag.JOGOID = new SelectList(db.Jogo, "JOGOID", "NOME", amigoJogo.JOGOID);
                return View(amigoJogo);
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.InnerException.Message;
            }
            return View(amigoJogo);
}

        // GET: AmigoJogo/Edit/5
        public ActionResult Edit(decimal id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                AmigoJogo amigoJogo = db.AmigoJogo.Find(id);
                if (amigoJogo == null)
                {
                    return HttpNotFound();
                }
                ViewBag.AMIGOID = new SelectList(db.Amigo, "AMIGOID", "NOME", amigoJogo.AMIGOID);
                ViewBag.JOGOID = new SelectList(db.Jogo, "JOGOID", "NOME", amigoJogo.JOGOID);
                return View(amigoJogo);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.InnerException.Message;
            }
            return View();
        }

        // POST: AmigoJogo/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AMIGOJOGOID,JOGOID,AMIGOID,DATAEMPRESTIMO")] AmigoJogo amigoJogo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(amigoJogo).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.AMIGOID = new SelectList(db.Amigo, "AMIGOID", "NOME", amigoJogo.AMIGOID);
                ViewBag.JOGOID = new SelectList(db.Jogo, "JOGOID", "NOME", amigoJogo.JOGOID);
                return View(amigoJogo);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.InnerException.Message;
            }
            return View(amigoJogo);
        }

        // GET: AmigoJogo/Delete/5
        public ActionResult Delete(decimal id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                AmigoJogo amigoJogo = db.AmigoJogo.Find(id);
                if (amigoJogo == null)
                {
                    return HttpNotFound();
                }
                return View(amigoJogo);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.InnerException.Message;
            }
            return View();
        }

        // POST: AmigoJogo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            try
            {
                AmigoJogo amigoJogo = db.AmigoJogo.Find(id);
                db.AmigoJogo.Remove(amigoJogo);
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
