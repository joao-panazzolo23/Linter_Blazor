using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Linter.Models.Modelos
{
    // Add profile data for application users by adding properties to the ApplicationUser class

    public class Users : IdentityUser<int>
    {
        public byte TipoUsuario { get; set; }//talvez isso esteja mais relacionado a tabelas de roles doq a de usuarios, pensar sobre
        public string? Rua { get; set; }
        public string? Cidade { get; set; }
        public string? Bairro { get; set; }
        public string? CEP { get; set; }
        [NotMapped]
        public IdentityRole? Role { get; set; } //NRT
    }

}
