using TaskManager.Models;

namespace TaskManager.Services
{
    public class SmsNotificationService : NotificationService
    {
        public SmsNotificationService() : base("Gestor de tareas") { }

        public override Task NotifyTaskCreatedAsync(TaskItem task)
        {
            //Imaginate que aquí se manda el SMS
            Console.WriteLine($"[SMS] {senderName} : Nueva tarea '{task.Title}'");

            return Task.CompletedTask;
        }
    }
}