using Linter.Modelos;

namespace Linter.Models.Modelos;

public class DeletedAccount : Entity
{
    public Guid AccountId { get; set; }
    public string? Reason { get; set; } = "";
    public string? UserId { get; set; }
}