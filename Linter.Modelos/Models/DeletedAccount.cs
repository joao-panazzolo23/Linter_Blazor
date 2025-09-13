using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linter.Modelos.Modelos
{
    public class DeletedAccount
    {
        [Key]
        public int idContaGerencial { get; set; }
        public string Descricao { get; set; } = "";
        public DateTime? DataCadastro { get; set; }
        public int idUsuarioCriador { get; set; }
        public DateTime DataExclusao { get; set; }
        public string MotivoCancelamento { get; set; } = "";
        public string? UsuarioExclusao { get; set; }
    }
}
