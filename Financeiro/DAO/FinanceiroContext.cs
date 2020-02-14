using Financeiro.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Financeiro.DAO
{
    public class FinanceiroContext : DbContext
    {
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Movimentacao> movimentacoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movimentacao>().HasRequired(m => m.Usuario);
        }
    }
}