using Domain.Events;
using System.Diagnostics;

namespace Subscribers;

public class EmailNotifier : IObserver<TaskEvent>
{
    public void OnCompleted() { }

    public void OnError(Exception error) { }

    public void OnNext(TaskEvent taskEvent)
    {
        if (taskEvent.EventName == "Created")
            Console.WriteLine($"[EMAIL] Nueva tarea: {taskEvent.Payload.Title}");
    }
}