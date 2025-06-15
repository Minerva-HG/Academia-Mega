namespace Domain;

public class TaskItem
{
    public Guid id { get; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsDone { get; private set; }

    public void Complete() => IsDone = true;
}