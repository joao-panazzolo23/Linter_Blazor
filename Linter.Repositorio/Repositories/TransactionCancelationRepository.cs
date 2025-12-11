using Linter.Infraestructure.Contexto;

namespace Linter.Infraestructure.Repositories;

public class TransactionCancelationRepository
{
    private readonly ApplicationDbContext context;

    public TransactionCancelationRepository(ApplicationDbContext _context)
    {
        context = _context;
    }
}