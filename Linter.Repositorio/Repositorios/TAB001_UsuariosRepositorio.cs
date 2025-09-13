using Linter.Dados.Contexto;
using Linter.Modelos.Modelos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static Linter.Modelos.Modelos.FinanceCancel;

namespace Linter.Dados.Repositorios
{
    public class TAB001_UsuariosRepositorio
    {
        private readonly ApplicationDbContext contexto;
        private readonly UserManager<Users> userManager;
        //sla pq eu n tenho essa bigorna
        //private readonly SignInManager<TAB001_Usuarios> signInManager;

        #region Construtores

        public TAB001_UsuariosRepositorio()
        {
            contexto = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
            //eu n sei como fazer isso aq po 
            //userManager = new UserManager<TAB001_Usuarios<StoreOptions>()>;
        }

        public TAB001_UsuariosRepositorio(ApplicationDbContext _contexto, UserManager<Users> _manager)
        {
            contexto = _contexto;
            userManager = _manager;
        }
        #endregion

        #region Retornos

        public IQueryable<Users> RetornaTodos()
        {
            if (contexto == null || contexto.TAB001_Usuarios == null)
                throw new ApplicationException("Erro ao retornar todas as movimentações.");

            return contexto.TAB001_Usuarios.AsQueryable();
        }
        public async Task<IList<Users>> RetornaTodosRelatorio()
        {
            if (contexto == null || contexto.TAB001_Usuarios == null)
                throw new ApplicationException("Erro ao retornar todas as movimentações.");

            return await contexto.TAB001_Usuarios.ToListAsync();
        }
        public Users RetornaUm(int id)
        {
            if (contexto == null || contexto.TAB001_Usuarios == null)
                throw new ApplicationException("Erro ao retornar todas as movimentações.");

            return contexto.TAB001_Usuarios.Where(X => X.Id == id).FirstOrDefault() ?? new Users();
        }

        #endregion

        #region Manutencao

        public async Task InserirUsuario(Users usuario, List<string> Role, List<Claim> CLAIMS)
        {
            usuario.ConcurrencyStamp = Guid.NewGuid().ToString();
            usuario.SecurityStamp = Guid.NewGuid().ToString();
            contexto.TAB001_Usuarios.Update(usuario);
            usuario.Id = RetornaUltimoId();

            if (Role != null | Role?.Count == 0)
            {
                await userManager.AddToRolesAsync(usuario, Role);
            }
            if (CLAIMS != null || CLAIMS.Count > 0)
            {
                await userManager.AddClaimsAsync(usuario, CLAIMS);
            }

            //eu n faço a mínima ideia do q uma claim faça.
            // await userManager.AddClaimAsync(usuario, new Claim() { });
            await contexto.SaveChangesAsync();

        }
        public async Task RemoverUsuario(Users usuario, List<string> Role, List<Claim> claims)
        {
            await userManager.RemoveFromRolesAsync(usuario, Role);

            await userManager.RemoveClaimsAsync(usuario, claims);

            contexto.TAB001_Usuarios.Remove(usuario);
            await contexto.SaveChangesAsync();
        }

        public async Task AtualizarUsuario(Users usuario,
                                           List<string>? rolesPart = null,
                                           List<Claim>? lstClaims = null) //Claim claim
        {
            if (contexto == null || contexto.TAB001_Usuarios == null)
                throw new ApplicationException("Erro ao Atualizar Usuário.");

            usuario.ConcurrencyStamp = Guid.NewGuid().ToString();
            //await userManager.RemoveFromRolesAsync()
            var roles = await userManager.GetRolesAsync(usuario);
            var claims = await userManager.GetClaimsAsync(usuario);
            //preciso de um ienumerable de roles pra remover 
            //o get roles retorna uma IList
            //essa conversao deve dar um erro grotesco

            if (rolesPart != null)
            {
                await userManager.RemoveFromRolesAsync(usuario, roles);
                await userManager.AddToRolesAsync(usuario, rolesPart);
            }
            if (lstClaims != null)
            {
                await userManager.RemoveClaimsAsync(usuario, claims);
                await userManager.AddClaimsAsync(usuario, lstClaims);
            }

            //await userManager.RemoveClaimsAsync(usuario);
            //eu n faço a mínima ideia do q uma claim faça.
            //await userManager.AddClaimAsync(usuario, claim);

            contexto.TAB001_Usuarios.Update(usuario);
            await contexto.SaveChangesAsync();
        }

        public int RetornaUltimoId()
        {
            if (contexto == null || contexto.TAB001_Usuarios == null)
                throw new ApplicationException("Erro ao retornar todas as movimentações.");
            int retorno;
            try
            {
                retorno = contexto.TAB001_Usuarios.OrderBy(x => x.Id).FirstOrDefault().Id + 1;
            }
            catch
            {
                retorno = 0;
            }
            return retorno + 1;
        }


        #endregion

    }
}
