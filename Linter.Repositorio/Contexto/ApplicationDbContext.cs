using Linter.Modelos.Modelos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace Linter.Dados.Contexto
{
    public class ApplicationDbContext : IdentityDbContext<Users, IdentityRole<int>, int>
    {
        #region Construtor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
        #endregion

        #region Propriedades
        public DbSet<Users> TAB001_Usuarios { get; set; }
        public DbSet<CAX001_Movimentacoes> CAX001_MovimentacoesCaixa { get; set; }
        public DbSet<FinanceCancel> Cancelations { get; set; }
        public DbSet<Account> CNT001_ContasGerenciais { get; set; }
        public DbSet<DeletedAccount> CNT002_ContasExcluidas { get; set; }
        #endregion

        #region OnModelCreating
        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region Criação dos Usuários/Roles/Claims

            base.OnModelCreating(builder);
            #endregion

            #region Remover aspas do Postgre

            base.OnModelCreating(builder);

            foreach (var entity in builder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.GetTableName()?.ToLower());

                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(property.Name.ToLower());
                }

                foreach (var key in entity.GetKeys())
                {
                    key.SetName(key.GetName()?.ToLower());
                }

                foreach (var foreignKey in entity.GetForeignKeys())
                {
                    foreignKey.SetConstraintName(foreignKey.GetConstraintName()?.ToLower());
                }

                foreach (var index in entity.GetIndexes())
                {
                    index.SetDatabaseName(index.GetDatabaseName()?.ToLower());
                }
            }


            #endregion

            #region Renomeando tabelas do identity

            //conforme o uso pretendo mudar o nome dessas classes pra palavras chave mais especificas 

            //builder.Entity<TAB001_Usuarios>()
            //            .ToTable("tab001_usuarios");

            //tab002 proprietária

            //builder.Entity<IdentityRole<int>>()
            //            .ToTable("tab002_cargos");

            //builder.Entity<IdentityUserRole<int>>()
            //            .ToTable("tab003_usuarioscargos");

            //builder.Entity<IdentityUserLogin<int>>()
            //            .ToTable("tab004_usuarioslogin");

            //builder.Entity<IdentityUserToken<int>>()
            //            .ToTable("tab005_usuariostokens");

            //builder.Entity<IdentityRoleClaim<int>>()
            //            .ToTable("tab006_cargosdeidentidade");

            //builder.Entity<IdentityUserClaim<int>>()
            //            .ToTable("tab007_solicitacoescargo"); //esse nome n faz sentido
            #endregion

            #region Renomear colunas das tabelas + Propriedades de colunas

            //#region TAB001 + IdentityUser
            //builder.Entity<TAB001_Usuarios>()
            //            .Property(u => u.UserName)
            //            .HasColumnName("nomeusuario");

            //builder.Entity<TAB001_Usuarios>()
            //            .Property(u => u.PasswordHash)
            //            .HasColumnName("senhahash");

            //builder.Entity<TAB001_Usuarios>()
            //            .Property(u => u.AccessFailedCount)
            //            .HasColumnName("numeroacessosfalhos");

            //builder.Entity<TAB001_Usuarios>()
            //           .Property(u => u.PhoneNumber)
            //           .HasColumnName("numerotelefone");

            //builder.Entity<TAB001_Usuarios>()
            //            .Property(u => u.EmailConfirmed)
            //            .HasColumnName("confirmacaoemail");

            //builder.Entity<TAB001_Usuarios>()
            //            .Property(u => u.TwoFactorEnabled)
            //            .HasColumnName("autentificacao2fa");

            //builder.Entity<TAB001_Usuarios>()
            //            .Property(u => u.NormalizedUserName)
            //            .HasColumnName("nomenormalizado");

            //builder.Entity<TAB001_Usuarios>()
            //            .Property(u => u.LockoutEnabled)
            //            .HasColumnName("bloqueiohabilitado");

            //builder.Entity<TAB001_Usuarios>() //essa propriedade serve pra bloquear/desbloquear uma conta
            //            .Property(u => u.LockoutEnabled)
            //            .HasColumnName("statusdesbloqueio");

            //builder.Entity<TAB001_Usuarios>() //isso serve em complemento para a anterior, se estiver bloqueado, aqui é passado a data que vai ser desbloqueado
            //            .Property(u => u.LockoutEnd)
            //            .HasColumnName("datadesbloqueio");

            //builder.Entity<TAB001_Usuarios>()
            //           .Property(u => u.LockoutEnd)
            //           .HasColumnName("datadesbloqueio");

            //builder.Entity<TAB001_Usuarios>()
            //            .Property(u => u.NormalizedEmail)
            //            .HasColumnName("emailnormalizado");

            //builder.Entity<TAB001_Usuarios>()
            //           .Property(u => u.PhoneNumberConfirmed)
            //           .HasColumnName("confirmacaotelefone");

            //builder.Entity<TAB001_Usuarios>()
            //          .Property(u => u.SecurityStamp)
            //          .HasColumnName("marcadeseguranca");

            //builder.Entity<TAB001_Usuarios>() //isso aq serve pra marcar o atual estado de um dado
            //          .Property(u => u.ConcurrencyStamp) //ex: se um admin alterar um valor e outro admin estiver alterando ele ao mesmo tempo, algum dos dois deverá 
            //          .HasColumnName("marcadeconcorrencia"); //receber um codigo de erro dizendo q a marca de concorrencia do servidor e local sao incompativeis

            //builder.Entity<TAB001_Usuarios>()
            //          .Property(u => u.CEP)
            //          .IsRequired(false);

            //builder.Entity<TAB001_Usuarios>()
            //         .Property(u => u.Rua)
            //         .IsRequired(false);

            //builder.Entity<TAB001_Usuarios>()
            //         .Property(u => u.Bairro)
            //         .IsRequired(false);

            //builder.Entity<TAB001_Usuarios>()
            //         .Property(u => u.Cidade)
            //         .IsRequired(false);
            #endregion

            #region TAB003 // IdentityRole

            //builder.Entity<IdentityRole<int>>()
            //           .Property(u => u.Name)
            //           .HasColumnName("nome");

            //builder.Entity<IdentityRole<int>>()
            //            .Property(u => u.NormalizedName)
            //            .HasColumnName("nomenormalizado");

            //builder.Entity<IdentityRole<int>>()
            //            .Property(u => u.ConcurrencyStamp)
            //            .HasColumnName("marcadeconcorrencia");

            #endregion

            #region TAB003A // IdentityUserRole

            //builder.Entity<IdentityUserRole<int>>()
            //           .Property(u => u.UserId)
            //           .HasColumnName("idusuario");

            //builder.Entity<IdentityUserRole<int>>()
            //            .Property(u => u.RoleId)
            //            .HasColumnName("idcargo");

            #endregion

            #region TAB004 // IdentityUserLogin

            //builder.Entity<IdentityUserLogin<int>>()
            //          .Property(u => u.UserId)
            //          .HasColumnName("idusuario");

            //builder.Entity<IdentityUserLogin<int>>()
            //            .Property(u => u.ProviderKey)
            //            .HasColumnName("provedordachave");

            //builder.Entity<IdentityUserLogin<int>>()
            //            .Property(u => u.LoginProvider)
            //            .HasColumnName("provedordelogin");

            //builder.Entity<IdentityUserLogin<int>>()
            //            .Property(u => u.ProviderDisplayName)
            //            .HasColumnName("nomedeexibicao");

            #endregion

            #region TAB005 // IdentityUserToken

            //builder.Entity<IdentityUserToken<int>>()
            //          .Property(u => u.UserId)
            //          .HasColumnName("idusuario");

            //builder.Entity<IdentityUserToken<int>>()
            //            .Property(u => u.LoginProvider)
            //            .HasColumnName("provedordologin");

            //builder.Entity<IdentityUserToken<int>>()
            //            .Property(u => u.Value)
            //            .HasColumnName("valor"); //valor de q?

            //builder.Entity<IdentityUserToken<int>>()
            //            .Property(u => u.Name)
            //            .HasColumnName("nome");
            #endregion

            #region TAB006 // IdentityRoleClaim

            //builder.Entity<IdentityRoleClaim<int>>()
            //            .Property(u => u.RoleId)
            //            .HasColumnName("idcargo");

            //builder.Entity<IdentityRoleClaim<int>>()
            //            .Property(u => u.ClaimType)
            //            .HasColumnName("tiposolicitacao");

            //builder.Entity<IdentityRoleClaim<int>>()
            //            .Property(u => u.ClaimValue)
            //            .HasColumnName("valorsolicitacao");
            #endregion

            #region TAB007 // IdentityUserClaim

            //builder.Entity<IdentityUserClaim<int>>()
            //           .Property(u => u.ClaimType)
            //           .HasColumnName("tiposolicitacao");

            //builder.Entity<IdentityUserClaim<int>>()
            //            .Property(u => u.ClaimValue)
            //            .HasColumnName("valorsolicitacao");

            //builder.Entity<IdentityUserClaim<int>>()
            //            .Property(u => u.UserId)
            //            .HasColumnName("idusuario");
            #endregion

            #region CAX002_MovimentacoesCanceladas
            builder.Entity<FinanceCancel>().HasNoKey();
            #endregion


            builder.Entity<IdentityRole<int>>().HasData(new IdentityRole<int>
            {
                Id = 1,
                Name = "Administrador",
                NormalizedName = "ADMINISTRADOR",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            });

            builder.Entity<IdentityRole<int>>().HasData(new IdentityRole<int>
            {
                Id = 2,
                Name = "usuario",
                NormalizedName = "USUARIO",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            });
            builder.Entity<IdentityRole<int>>().HasData(new IdentityRole<int>
            {
                Id = 3,
                Name = "suporte",
                NormalizedName = "SUPORTE",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            });

            #endregion



        }
    }

}

