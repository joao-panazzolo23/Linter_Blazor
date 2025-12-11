using Linter.Infraestructure.Contexto;
using Linter.Modelos.Entities;

namespace Linter.Infraestructure.Repositories;

public class DeletedAccountRepository
{
    private readonly ApplicationDbContext _context;
    public DeletedAccountRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Insert(Account account)
    {
        _context.Accounts.Add(account);
    }

    public void Update(Account contasGerenciais)
    {
        _context.Accounts.Update(contasGerenciais);
    }

    public void Remove(Account contasGerenciais)
    {
        _context.Accounts.Remove(contasGerenciais);
    }
}