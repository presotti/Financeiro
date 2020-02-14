using Financeiro.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Financeiro.DAO
{
    public class MovimentacaoDAO
    {
        private FinanceiroContext context;

        public MovimentacaoDAO(FinanceiroContext context)
        {
            this.context = context;
        }

        public void adiciona(Movimentacao movimentacao)
        {
            context.movimentacoes.Add(movimentacao);
            context.SaveChanges();
        }

        public IList<Movimentacao> listar()
        {
            return context.movimentacoes.ToList();
        }

        public IList<Movimentacao> BuscaPorUsuario(int? usuarioID)
        {
            return context.movimentacoes.Where(m => m.UsuarioId == usuarioID).ToList();
        }

        public IList<Movimentacao> Busca(decimal? valorMinimo, decimal? valorMaximo,
                                        DateTime? dataMinima, DateTime? dataMaxima,
                                        Tipo? tipo, int? usuario)
        {
            IQueryable<Movimentacao> resultado = context.movimentacoes;
            if (valorMinimo.HasValue)
            {
                resultado = resultado.Where(m => m.Valor >= valorMinimo);
            }
            if (valorMaximo.HasValue)
            {
                resultado = resultado.Where(m => m.Valor <= valorMaximo);
            }
            if (dataMinima.HasValue)
            {
                resultado = resultado.Where(m => m.Data >= dataMinima);
            }
            if (dataMaxima.HasValue)
            {
                resultado = resultado.Where(m => m.Data <= dataMaxima);
            }
            if (tipo.HasValue)
            {
                resultado = resultado.Where(m => m.Tipo == tipo);
            }
            if (usuario.HasValue)
            {
                resultado = resultado.Where(m => m.UsuarioId == usuario);
            }
            return resultado.ToList();
        }
    }
}