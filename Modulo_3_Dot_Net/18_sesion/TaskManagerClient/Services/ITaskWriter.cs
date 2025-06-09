using TaskManagerClient.Models;
namespace TaskManagerClient.Services;

public interface ITaskWriter
{
    Task<TaskItem> AddAsync(TaskItem task);
    Task UpdateAsync(TaskItem taskItem);
    Task DeleteAsync(Guid id);
    
}
