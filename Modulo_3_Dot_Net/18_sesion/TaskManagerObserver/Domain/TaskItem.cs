//Este nos va a servir para el DTO del vbackend
namespace Domain;

public class TaskItem
{
    public Guid id { get; } = Guid.NewGuid();
    public string Title { get; init; } = string.Empty;

    public string? Description { get; init; }
    public bool IsDone { get; private set; }

    public void Complete() => IsDone = true;
}

