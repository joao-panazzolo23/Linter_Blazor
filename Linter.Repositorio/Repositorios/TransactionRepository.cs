using Linter.Dados.Contexto;
using Linter.Modelos.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Linter.Dados.Repositorios
{
    public class TransactionRepository
    {
        #region Construtores 
        private readonly ApplicationDbContext contexto;
        public TransactionRepository()
        {
            contexto = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        }
        public TransactionRepository(ApplicationDbContext _context)
        {
            contexto = _context;
        }
        #endregion

        #region Manutencao
        public async void Insert(CAX001_Movimentacoes caixa)
        {
            if (contexto != null || caixa != null || contexto.CAX001_MovimentacoesCaixa != null)
            {
                contexto.CAX001_MovimentacoesCaixa.Add(caixa);
                await contexto.SaveChangesAsync();
            }
        }
        public async void Delete(int id)
        {
            if (contexto != null || id != 0 || contexto.CAX001_MovimentacoesCaixa != null)
            {
                var movimentacao = contexto.CAX001_MovimentacoesCaixa.FirstOrDefault(m => m.Id == id);
                contexto.CAX001_MovimentacoesCaixa.Remove(movimentacao);
                await contexto.SaveChangesAsync();
            }
        }
        public async Task<CAX001_Movimentacoes> Update(CAX001_Movimentacoes caixa)
        {
            if (contexto != null || caixa != null)
            {
                contexto.CAX001_MovimentacoesCaixa.Update(caixa);
                await contexto.SaveChangesAsync();
            }
            return caixa;
        }
        #endregion

        #region Retornos 

        public async Task<IList<CAX001_Movimentacoes>> RetornaMovimentacoesParaRPT()
        {
            if (contexto == null || contexto.CAX001_MovimentacoesCaixa == null)
                throw new ApplicationException("Erro ao retornar todas as movimentações.");

            return await contexto.CAX001_MovimentacoesCaixa.ToListAsync();
        }

        public IQueryable<CAX001_Movimentacoes> RetornaMovimentacoes()
        {
            if (contexto == null || contexto.CAX001_MovimentacoesCaixa == null)
                throw new ApplicationException("Erro ao retornar todas as movimentações.");

            return contexto.CAX001_MovimentacoesCaixa.AsQueryable();
        }

        public CAX001_Movimentacoes RetornaMovimentacao(int id)
        {
            if (contexto == null || contexto.CAX001_MovimentacoesCaixa == null)
                throw new ApplicationException("Erro ao retornar esta movimentação.");

            var movimentacao = contexto.CAX001_MovimentacoesCaixa.FirstOrDefault(m => m.Id == id);

            return movimentacao == null ? throw new ApplicationException($"Movimentação de Nº{id} não existe no banco de dados.") : movimentacao;
        }

        #endregion
    }
}
