using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linter.Modelos.Modelos
{
    public class TAB002_ContasGerenciais
    {
        [Key]
        public int idConta { get; set; }
        [Required(ErrorMessage ="Informe a descrição da conta")]
        [MaxLength(300)]
        [MinLength(5)]
        public string Descricao { get; set; } = string.Empty;
    }
}
