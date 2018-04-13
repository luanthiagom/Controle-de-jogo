using Controle_de_jogo.Models;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace Controle_de_jogo.Controllers
{
    public class AccountController : Controller
    {
        /// <param name="returnURL"></param>
        /// <returns></returns>
        public ActionResult Login(string returnURL)
        {
            /*Recebe a url que o usuário tentou acessar*/
            ViewBag.ReturnUrl = returnURL;
            return View(new Acesso());
        }

        /// <param name="login"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Acesso login, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                using (ControleJogosEntities db = new ControleJogosEntities())
                {
                    var vLogin = db.Acesso.Where(p => p.EMAIL.Equals(login.EMAIL)).FirstOrDefault();
                    /*Verificar se a variavel vLogin está vazia. Isso pode ocorrer caso o usuário não existe. 
              Caso não exista ele vai cair na condição else.*/
                    if (vLogin != null)
                    {
                        /*Código abaixo verifica se o usuário que retornou na variavel tem está 
                          ativo. Caso não esteja cai direto no else*/

                        /*Código abaixo verifica se a senha digitada no site é igual a senha que está sendo retornada 
                         do banco. Caso não cai direto no else*/
                        if (Equals(vLogin.SENHA, login.SENHA))
                        {
                            FormsAuthentication.SetAuthCookie(vLogin.EMAIL, false);
                            if (Url.IsLocalUrl(returnUrl)
                            && returnUrl.Length > 1
                            && returnUrl.StartsWith("/")
                            && !returnUrl.StartsWith("//")
                            && returnUrl.StartsWith("/\\"))
                            {
                                return Redirect(returnUrl);
                            }
                            /*código abaixo cria uma session para armazenar o nome do usuário*/
                            Session["Nome"] = vLogin.NOME;
                            /*retorna para a tela inicial do Home*/
                            return RedirectToAction("Index", "Home");
                        }
                        /*Else responsável da validação da senha*/
                        else
                        {
                            /*Escreve na tela a mensagem de erro informada*/
                            ModelState.AddModelError("", "Senha informada Inválida!!!");
                            /*Retorna a tela de login*/
                            return View(new Acesso());
                        }
                    }
                    /*Else responsável por verificar se o usuário existe*/
                    else
                    {
                        /*Escreve na tela a mensagem de erro informada*/
                        ModelState.AddModelError("", "Login informado inválido!!!");
                        /*Retorna a tela de login*/
                        return View(new Acesso());
                    }
                }
            }
            /*Caso os campos não esteja de acordo com a solicitação retorna a tela de login com as mensagem dos campos*/
            return View(login);
        }
    }
}
