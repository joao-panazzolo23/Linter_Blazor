using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linter.Modelos.Modelos
{
    public class TAB999_UsuariosBloqueados : TAB001_Usuarios
    {
        public int idBloqueio { get; set; }
        public string? MotivoBloqueio { get; set; }
        public DateTime DataBloqueio { get; set; }


    }
}
