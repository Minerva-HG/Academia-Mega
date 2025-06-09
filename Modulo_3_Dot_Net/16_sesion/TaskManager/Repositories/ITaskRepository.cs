using TaskManager.Models;

namespace TaskManager.Repositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskItem>> GetAllAsync();
        Task AddAsync(TaskItem taskItem);
        Task UpdateAsync(TaskItem taskItem);
        Task<TaskItem?> GetAsync(Guid id);
        Task DeleteAsync(Guid id);
    }
}