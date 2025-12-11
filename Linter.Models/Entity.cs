namespace Linter.Modelos;

public abstract class Entity
{
    public Guid Id { get; set; } = new();
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}