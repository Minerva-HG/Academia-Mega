using TaskManager.Models;

namespace TaskManager.Repositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskItem>> GetAllAsync();
        Task AddAsync(TaskItem taskItem);

        Task AddAsync(TaskItem task);

        Task UpdateAsync(TaskItem taskItem);

        Task DeleteAsync(Guid id);
    }
}