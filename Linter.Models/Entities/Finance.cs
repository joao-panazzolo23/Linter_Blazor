using System.ComponentModel.DataAnnotations;

namespace Linter.Modelos.Entities;

/// <summary>
/// mas ta uma completa bosta essa entidade, ta validando, ta salvando no banco, ta retornando do banco, saporra faz tudo
/// </summary>
public class FinanceMovement : Entity
{
    [Key] public int Id { get; set; }

    [Required(ErrorMessage = "Informe a data da movimentação")]
    public DateTime? DataMovimentacao { get; set; }

    [MaxLength(300, ErrorMessage = "Digite no máximo 300 caracteres para a descrição.")]
    [MinLength(5, ErrorMessage = "Digite pelo menos cinco caracteres para a descrição.")]
    public string Descritivo { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe a conta utilizada para esta movimentação.")]
    public int idContaGerencial { get; set; }

    [Required(ErrorMessage = "Informe o valor da movimentação")]
    [CustomValidation(typeof(FinanceMovement), nameof(ValidarValor))]
    public decimal Valor { get; set; }

    //[Required(ErrorMessage = "Informe a razão da movimentação")]
    //[EnumDataType(typeof(Enumeradores.TipoMovimentacao))]
    //[NotMapped]
    //public Enumeradores.TipoMovimentacao Tipo_nrt { get; set; }
    public byte Tipo { get; set; }


    public static ValidationResult ValidarValor(int Valor, ValidationContext contexto)
    {
        if (Valor <= 0) return new ValidationResult("Valor não pode ser igual ou menor do que zero.");

        return ValidationResult.Success;
    }
}