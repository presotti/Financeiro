using Financeiro.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Financeiro.DAO
{
    public class UsuarioDAO
    {
        private FinanceiroContext context;

        public UsuarioDAO(FinanceiroContext context)
        {
            this.context = context;
        }
        public void adiciona(Usuario usuario)
        {
            context.usuarios.Add(usuario);
            context.SaveChanges();
        }

        public IList<Usuario> listar()
        {
            return context.usuarios.ToList();
        }
    }
}