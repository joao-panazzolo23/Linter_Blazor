using Linter.Infraestructure.Contexto;

namespace Linter.Infraestructure.Repositories;

public class TransactionRepository
{
    private readonly ApplicationDbContext contexto;

    public TransactionRepository(ApplicationDbContext _context)
    {
        contexto = _context;
    }
}