using Linter.Infraestructure.Contexto;
using Linter.Models.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Linter.Infraestructure.Repositories;

public class DeletedAccountsRepository
{
    public ApplicationDbContext context;

    public DeletedAccountsRepository(ApplicationDbContext _context)
    {
        context = _context;
    }
}