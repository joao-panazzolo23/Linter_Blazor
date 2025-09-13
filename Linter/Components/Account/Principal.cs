using Linter.Modelos.Modelos;
using Microsoft.AspNetCore.Identity;

namespace Linter.Components.Account
{
    public static class Principal
    {
        public static Users UsuarioAtual { get; set; }
        public static bool PrecisaRegistrar { get; set; } = false;
    }
}
