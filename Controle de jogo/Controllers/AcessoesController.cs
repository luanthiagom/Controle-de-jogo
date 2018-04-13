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
    public class AcessoesController : Controller
    {
        private ControleJogosEntities db = new ControleJogosEntities();

        // GET: Acessoes
        public ActionResult Index()
        {
            return View(db.Acesso.ToList());
        }

        // GET: Acessoes/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acesso acesso = db.Acesso.Find(id);
            if (acesso == null)
            {
                return HttpNotFound();
            }
            return View(acesso);
        }

        // GET: Acessoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Acessoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_LOGIN,EMAIL,SENHA,NOME")] Acesso acesso)
        {
            if (ModelState.IsValid)
            {
                db.Acesso.Add(acesso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(acesso);
        }

        // GET: Acessoes/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acesso acesso = db.Acesso.Find(id);
            if (acesso == null)
            {
                return HttpNotFound();
            }
            return View(acesso);
        }

        // POST: Acessoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_LOGIN,EMAIL,SENHA,NOME")] Acesso acesso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(acesso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(acesso);
        }

        // GET: Acessoes/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acesso acesso = db.Acesso.Find(id);
            if (acesso == null)
            {
                return HttpNotFound();
            }
            return View(acesso);
        }

        // POST: Acessoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Acesso acesso = db.Acesso.Find(id);
            db.Acesso.Remove(acesso);
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
