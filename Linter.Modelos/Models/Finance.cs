using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linter.Modelos.Modelos
{
    public class CAX001_Movimentacoes
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Informe a data da movimentação")]
        public DateTime? DataMovimentacao { get; set; }
        [MaxLength(300, ErrorMessage = "Digite no máximo 300 caracteres para a descrição.")]
        [MinLength(5, ErrorMessage = "Digite pelo menos cinco caracteres para a descrição.")]
        public string Descritivo { get; set; } = string.Empty;
        [Required(ErrorMessage = "Informe a conta utilizada para esta movimentação.")]
        public int idContaGerencial { get; set; }
        [Required(ErrorMessage = "Informe o valor da movimentação")]
        [CustomValidation(typeof(CAX001_Movimentacoes), nameof(ValidarValor))]
        public decimal Valor { get; set; }
        //[Required(ErrorMessage = "Informe a razão da movimentação")]
        //[EnumDataType(typeof(Enumeradores.TipoMovimentacao))]
        //[NotMapped]
        //public Enumeradores.TipoMovimentacao Tipo_nrt { get; set; }
        public byte Tipo { get; set; } 


        #region CustomValidations
        public static ValidationResult ValidarValor(int Valor, ValidationContext contexto)
        {
            if (Valor <= 0) return new ValidationResult("Valor não pode ser igual ou menor do que zero.");

            return ValidationResult.Success;
        }


        #endregion
    }
}
