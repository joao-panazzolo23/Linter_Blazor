using Linter.Modelos.Entities;
using Linter.Models.Modelos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Linter.Infraestructure.Contexto
{
    public class ApplicationDbContext : IdentityDbContext<Users, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
        
        public DbSet<Users> Users { get; set; }
        public DbSet<FinanceMovement> FinanceMovement { get; set; }
        public DbSet<FinanceCancellations> Cancelations { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<DeletedAccount> DeletedAccounts { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
        }
    }

}

