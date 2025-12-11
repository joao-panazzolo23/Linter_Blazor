using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linter.Models.Modelos
{
    public class FinanceCancellations
    {
        [ForeignKey("pk_cax001_movimentacoescaixa")]
        public int idMovimentacao { get; set; }
        [Required(ErrorMessage = "Informe a data da movimentação")]
        public DateTime? DataMovimentacao { get; set; }
        public string Descritivo { get; set; } = string.Empty;
        [Required(ErrorMessage = "Informe a conta utilizada para esta movimentação.")]
        public int idContaGerencial { get; set; }
        [Required(ErrorMessage = "Informe o valor da movimentação")]
        public decimal Valor { get; set; }
        //[Required(ErrorMessage = "Informe a razão da movimentação")]
        //[EnumDataType(typeof(Enumeradores.TipoMovimentacao))]
        //[NotMapped]
        //public Enumeradores.TipoMovimentacao Tipo_nrt { get; set; } //pensando em fazer isso como um enumerador
        public byte Tipo { get; set; } //pensando em fazer isso como um enumerador
        public int idUsuarioCancelamento { get; set; }
        public DateTime DataCancelamento { get; set; }
    }
}
