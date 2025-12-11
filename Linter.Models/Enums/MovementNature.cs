using System.ComponentModel.DataAnnotations;

namespace Linter.Models.Enums;

public enum MovementNature
{
    [Display(Name = "Entrada")]
    Plus = 0,
    [Display(Name = "Saida")]
    Minus = 1
    //transferencia, troco, etc?
}