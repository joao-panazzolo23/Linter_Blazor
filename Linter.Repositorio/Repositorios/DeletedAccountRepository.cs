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
    public class DeletedAccountRepository
    {
        #region Propriedades
        public ApplicationDbContext context;

        #endregion

        #region Construtores
        public DeletedAccountRepository()
        {
            context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        }
        public DeletedAccountRepository(ApplicationDbContext _contexto)
        {
            context = _contexto;
        }
        #endregion

        #region manutencao 
        public void Inserir(Account contasGerenciais)
        {
            context.CNT001_ContasGerenciais.Add(contasGerenciais);
            context.SaveChanges();
        }
        public void Atualizar(Account contasGerenciais)
        {
            context.CNT001_ContasGerenciais.Update(contasGerenciais);
            context.SaveChanges();
        }
        public void Remover(Account contasGerenciais)
        {
            context.CNT001_ContasGerenciais.Remove(contasGerenciais);
            context.SaveChanges();
        }
        #endregion

        #region retornos 
        public IQueryable<Account> RetornaContasGerenciais()
        {
            if (context == null || context.CNT001_ContasGerenciais == null)
                throw new ApplicationException("Erro ao retornar as contas gerenciais.");

            return context.CNT001_ContasGerenciais.AsNoTracking().AsQueryable();
        }

        public Account RetornaConta(int id)
        {
            if (context == null || context.CNT001_ContasGerenciais == null)
                throw new ApplicationException("Erro ao retornar esta conta.");

            var conta = context.CNT001_ContasGerenciais.FirstOrDefault(m => m.idContaGerencial== id);

            return conta == null ? throw new ApplicationException($"Conta de Nº{id} não existe no banco de dados.") : conta;
        }

        #endregion
    }
}
