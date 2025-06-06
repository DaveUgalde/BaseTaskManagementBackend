namespace WorkModel.Domain.Entities;

public class EntityBase
{
  public Guid Id { get; set; } = Guid.NewGuid();
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}