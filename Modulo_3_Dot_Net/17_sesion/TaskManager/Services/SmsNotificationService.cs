using System.Diagnostics;
using TaskManager.Models;

namespace TaskManager.Services
{
    public class SmsNotificationService : NotificationService
    {
        public SmsNotificationService() : base("Gestor de tareas") { }

        public override Task NotifyTaskCreatedAsync(TaskItem task)
        {
            //Aquí se debe mandar el mensaje.
            Console.WriteLine($"[SMS] {SenderName}: Nueva tarea '{task.Title}'");
            return Task.CompletedTask;
        }
    }
}