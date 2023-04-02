namespace Sisreq.Core.Objects;

#nullable disable

public class Entity<T>
{
    public T Id { get; set; }
    public ValidationResult ValidationResult { get; set; }
}