using Linter.Dados.Contexto;
using Linter.Modelos.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linter.Dados.Repositorios
{
    public class TransactionCancelationRepository
    {
        #region Construtores 
        private readonly ApplicationDbContext context;
        public TransactionCancelationRepository()
        { 
            context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        }
        public TransactionCancelationRepository(ApplicationDbContext _context)
        {
            context = _context;
        }
        #endregion

        #region Manutencao
        public async void InserirMovimentacao(FinanceCancel caixa)
        {
            if (context != null || caixa != null || context.Cancelations != null)
            {
                context.Cancelations.Add(caixa);
                await context.SaveChangesAsync();
            }
        }
        public async void Delete(int id)
        {
            if (context != null || id != 0 || context.Cancelations != null)
            {
                var movimentacao = context.Cancelations.FirstOrDefault(m => m.idMovimentacao == id);
                context.Cancelations.Remove(movimentacao);
                await context.SaveChangesAsync();
            }
        }
        public async Task<FinanceCancel> EditarMovimentacao(FinanceCancel cancelada)
        {
            if (context != null || cancelada != null)
            {
                context.Cancelations.Update(cancelada);
                await context.SaveChangesAsync();
            }
            return cancelada;
        }
        #endregion

        #region Retornos 

        public IQueryable<FinanceCancel> RetornaMovimentacoesCanceladas()
        {
            if (context == null || context.Cancelations == null)
                throw new ApplicationException("Erro ao retornar todas as movimentações.");

             return context.Cancelations.AsNoTracking().AsQueryable();
        }

        public FinanceCancel RetornaMovimentacao(int id)
        {
            if (context == null || context.Cancelations == null)
                throw new ApplicationException("Erro ao retornar esta movimentação.");

            var movimentacao = context.Cancelations.FirstOrDefault(m => m.idMovimentacao == id);

            return movimentacao == null ? throw new ApplicationException($"Movimentação de Nº{id} não existe no banco de dados.") : movimentacao;
        }

        #endregion
    }
}
