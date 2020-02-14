using Financeiro.DAO;
using Financeiro.Entidades;
using Financeiro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Financeiro.Controllers
{
    [Authorize]
    public class MovimentacaoController : Controller
    {

        private MovimentacaoDAO movimentacaoDAO;
        private UsuarioDAO usuarioDAO;
        public MovimentacaoController(MovimentacaoDAO movimentacaoDAO, UsuarioDAO usuarioDAO)
        {
            this.movimentacaoDAO = movimentacaoDAO;
            this.usuarioDAO = usuarioDAO;
        }
        public ActionResult Index()
        {
            return View(movimentacaoDAO.listar());
        }
 
        public ActionResult Form()
        {
            ViewBag.Usuarios = usuarioDAO.listar(); 
            return View();
        }

        public ActionResult Adiciona(Movimentacao movimentacao)
        {
            if (ModelState.IsValid)
            {
                movimentacaoDAO.adiciona(movimentacao);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Usuarios = movimentacaoDAO.listar();
                return View("Form");
            }
        }

        public ActionResult MovimentacoesPorUsuario(MovimentacoesPorUsuarioModel model)
        {
            model.Usuarios = usuarioDAO.listar();
            model.Movimentacoes = movimentacaoDAO.BuscaPorUsuario(model.UsuarioId);
            return View(model);
        }

        public ActionResult Busca(BuscaMovimentacoes model)
        {
            model.Usuarios = usuarioDAO.listar();
            model.Movimentacoes = movimentacaoDAO.Busca(model.ValorMinimo, model.ValorMaximo,
                                    model.DataMinima, model.DataMaxima,
                                    model.Tipo, model.UsuarioId);
            return View(model);
        }
    }
}