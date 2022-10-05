using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cudataware.WorkflowServer.Application.Common.Workflow.BackgroundTasks;

public interface ITasksQueue
{
    Task Enqueue(Func<CancellationToken, Task> task);
    Task<Func<CancellationToken, Task>> Dequeue(CancellationToken cancellationToken);
}
