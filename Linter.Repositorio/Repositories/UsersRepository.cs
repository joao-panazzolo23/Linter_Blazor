using Linter.Infraestructure.Contexto;
using Linter.Models.Modelos;
using Microsoft.AspNetCore.Identity;


namespace Linter.Infraestructure.Repositories;

/// <summary>
/// cara mas qq eu fiz aq jesus senhor amado
/// </summary>
public class UsersRepository
{
    private readonly ApplicationDbContext contexto;

    private readonly UserManager<Users> userManager;
    //sla pq eu n tenho essa bigorna
    //private readonly SignInManager<TAB001_Usuar;ios> signInManager;

    // #region Construtores
    //
    // public UsersRepository()
    // {
    //     contexto = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
    //     //eu n sei como fazer isso aq po 
    //     //userManager = new UserManager<TAB001_Usuarios<StoreOptions>()>;
    // }
    //
    // public UsersRepository(ApplicationDbContext _contexto, UserManager<Users> _manager)
    // {
    //     contexto = _contexto;
    //     userManager = _manager;
    // }
    // #endregion
    //
    // #region Retornos
    //
    // public IQueryable<Users> RetornaTodos()
    // {
    //     if (contexto == null || contexto.Users == null)
    //         throw new ApplicationException("Erro ao retornar todas as movimentações.");
    //
    //     return contexto.Users.AsQueryable();
    // }
    // public async Task<IList<Users>> RetornaTodosRelatorio()
    // {
    //     if (contexto == null || contexto.Users == null)
    //         throw new ApplicationException("Erro ao retornar todas as movimentações.");
    //
    //     return await contexto.Users.ToListAsync();
    // }
    // public Users RetornaUm(int id)
    // {
    //     if (contexto == null || contexto.Users == null)
    //         throw new ApplicationException("Erro ao retornar todas as movimentações.");
    //
    //     return contexto.Users.Where(X => X.Id == id).FirstOrDefault() ?? new Users();
    // }
    //
    // #endregion
    //
    // #region Manutencao
    //
    // public async Task InserirUsuario(Users usuario, List<string> Role, List<Claim> CLAIMS)
    // {
    //     usuario.ConcurrencyStamp = Guid.NewGuid().ToString();
    //     usuario.SecurityStamp = Guid.NewGuid().ToString();
    //     contexto.Users.Update(usuario);
    //     usuario.Id = RetornaUltimoId();
    //
    //     if (Role != null | Role?.Count == 0)
    //     {
    //         await userManager.AddToRolesAsync(usuario, Role);
    //     }
    //     if (CLAIMS != null || CLAIMS.Count > 0)
    //     {
    //         await userManager.AddClaimsAsync(usuario, CLAIMS);
    //     }
    //
    //     //eu n faço a mínima ideia do q uma claim faça.
    //     // await userManager.AddClaimAsync(usuario, new Claim() { });
    //     await contexto.SaveChangesAsync();
    //
    // }
    // public async Task RemoverUsuario(Users usuario, List<string> Role, List<Claim> claims)
    // {
    //     await userManager.RemoveFromRolesAsync(usuario, Role);
    //
    //     await userManager.RemoveClaimsAsync(usuario, claims);
    //
    //     contexto.Users.Remove(usuario);
    //     await contexto.SaveChangesAsync();
    // }
    //
    // public async Task AtualizarUsuario(Users usuario,
    //                                    List<string>? rolesPart = null,
    //                                    List<Claim>? lstClaims = null) //Claim claim
    // {
    //     if (contexto == null || contexto.Users == null)
    //         throw new ApplicationException("Erro ao Atualizar Usuário.");
    //
    //     usuario.ConcurrencyStamp = Guid.NewGuid().ToString();
    //     //await userManager.RemoveFromRolesAsync()
    //     var roles = await userManager.GetRolesAsync(usuario);
    //     var claims = await userManager.GetClaimsAsync(usuario);
    //     //preciso de um ienumerable de roles pra remover 
    //     //o get roles retorna uma IList
    //     //essa conversao deve dar um erro grotesco
    //
    //     if (rolesPart != null)
    //     {
    //         await userManager.RemoveFromRolesAsync(usuario, roles);
    //         await userManager.AddToRolesAsync(usuario, rolesPart);
    //     }
    //     if (lstClaims != null)
    //     {
    //         await userManager.RemoveClaimsAsync(usuario, claims);
    //         await userManager.AddClaimsAsync(usuario, lstClaims);
    //     }
    //
    //     //await userManager.RemoveClaimsAsync(usuario);
    //     //eu n faço a mínima ideia do q uma claim faça.
    //     //await userManager.AddClaimAsync(usuario, claim);
    //
    //     contexto.Users.Update(usuario);
    //     await contexto.SaveChangesAsync();
    // }
    //
    // public int RetornaUltimoId()
    // {
    //     if (contexto == null || contexto.Users == null)
    //         throw new ApplicationException("Erro ao retornar todas as movimentações.");
    //     int retorno;
    //     try
    //     {
    //         retorno = contexto.Users.OrderBy(x => x.Id).FirstOrDefault().Id + 1;
    //     }
    //     catch
    //     {
    //         retorno = 0;
    //     }
    //     return retorno + 1;
    // }
    //
    //
    // #endregion
}