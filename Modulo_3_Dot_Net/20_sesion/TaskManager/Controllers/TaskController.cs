using Microsoft.AspNetCore.Mvc;
using TaskManager.Shared.Domain;
using TaskManager.Repositories;
using TaskManager.Services;

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _repo;
        private readonly IEnumerable<INotificationService> _notifiers;

        public TasksController(ITaskRepository repo, IEnumerable<INotificationService> notifiers)
        {
            _repo = repo;
            _notifiers = notifiers;
        }

        [HttpGet] // GET /api/tasks
        public async Task<IEnumerable<TaskItem>> GetAll() =>
            await _repo.GetAllAsync();

        [HttpPost]
        public async Task<ActionResult<TaskItem>> Create(TaskItem taskItem)
        {
            await _repo.AddAsync(taskItem);

            // Notificar por SMS
            foreach (var notifier in _notifiers)
                await notifier.NotifyTaskCreatedAsync(taskItem);

            return CreatedAtAction(nameof(GetAll), new { id = taskItem.id }, taskItem);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, TaskItem updatedTask)
        {
            var existingTask = await _repo.GetAsync(id);
            if (existingTask is null)
                return NotFound();

            existingTask.Title = updatedTask.Title;
            existingTask.Description = updatedTask.Description;

            // Opcional: Si quieres poder modificar IsDone también
            if (updatedTask.IsDone)
                existingTask.Complete();

            await _repo.UpdateAsync(existingTask);
            return NoContent(); // 204
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var existingTask = await _repo.GetAsync(id);
            if (existingTask is null)
                return NotFound();

            await _repo.DeleteAsync(id);
            return NoContent(); // 204
        }


    }
}