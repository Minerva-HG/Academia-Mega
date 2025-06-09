using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;
using TaskManager.Repositories;
using TaskManager.Services;

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _repo;

        private readonly IEnumerable<INotificationService> _notifiers;

        public TaskController(TaskRepository repo, IEnumerable<INotificationService> notifiers)
        {
            _repo = repo;
            _notifiers = notifiers;
        }

        [Http] // GET /api/tasks
        public async Task<IEnumerable<TaskItem>> GetAll() =>
            await _repo.GetAllAsync();
    }
}
