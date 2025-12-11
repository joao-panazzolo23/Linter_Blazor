namespace Linter.Modelos.Entities;

public class Account : Entity
{
    public string Description { get; set; } = "";
    public int CreationUserId { get; set; }
}