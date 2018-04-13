using Controle_de_jogo.Models;
using System.Web.Mvc;
using System.Web.Security;

namespace Controle_de_jogo.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Sair()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}