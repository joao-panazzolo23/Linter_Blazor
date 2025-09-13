using Linter.Dados.Contexto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Linter.Dados.Repositorios
{
    public class RoleRepository
    {
        #region Construtores
        private readonly ApplicationDbContext context;
        public RoleRepository()
        {

        }
        public RoleRepository(ApplicationDbContext _context)
        {
            context = _context;
        }
        #endregion

        #region Manutencao

        public async Task Save(IdentityRole<int> permissao)
        {
            await context.Roles.AddAsync(permissao);
            await context.SaveChangesAsync();
        }
        public void Update(IdentityRole<int> permissao)
        {
            context.Roles.Update(permissao);
            context.SaveChangesAsync();
        }
        #endregion

        #region Retornos

        public IQueryable<IdentityRole<int>> RetornaTodosOsCargos()
        {
            return context.Roles.AsQueryable();
        }
        public async Task<IdentityRole<int>> RetornaUm(int id)
        {
            return await context.Roles.Where(X => X.Id == id).FirstOrDefaultAsync() ?? new IdentityRole<int>();
        }

        #endregion
    }
}
