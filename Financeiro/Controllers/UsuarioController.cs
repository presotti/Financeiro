using Financeiro.DAO;
using Financeiro.Entidades;
using Financeiro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace Financeiro.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioDAO usuarioDAO;

        public UsuarioController(UsuarioDAO usuarioDAO)
        {
            this.usuarioDAO = usuarioDAO;
        }
        public ActionResult Form()
        {
            return View();
        }
        public ActionResult adiciona(UsuarioModel usuarioModel)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    WebSecurity.CreateUserAndAccount(usuarioModel.nome, usuarioModel.senha, new { email = usuarioModel.email });
                    return RedirectToAction("Index");
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("usuario.invalido", e.Message);
                    return View("Form", usuarioModel);
                }
            }
            else
            {
                return View("Form", usuarioModel);
            }
        }
        public ActionResult Index()
        {
            IList<Usuario> usuarios = usuarioDAO.listar();
            return View(usuarios);
        }
    }
}