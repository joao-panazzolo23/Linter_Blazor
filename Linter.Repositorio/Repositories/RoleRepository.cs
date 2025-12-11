using Linter.Infraestructure.Contexto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Linter.Infraestructure.Repositories
{
    public class RoleRepository
    {
        private readonly ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task Save(IdentityRole<int> permissao)
        {
            await _context.Roles.AddAsync(permissao);
        }

        public void Update(IdentityRole<int> permissao)
        {
            _context.Roles.Update(permissao);
        }


        public IQueryable<IdentityRole<int>> RetornaTodosOsCargos()
        {
            return _context.Roles.AsQueryable();
        }

        public async Task<IdentityRole<int>> RetornaUm(int id)
        {
            return await _context.Roles.Where(X => X.Id == id).FirstOrDefaultAsync() ?? new IdentityRole<int>();
        }
    }
}