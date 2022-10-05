using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace Cudataware.WorkflowServer.Application.Common.Workflow.BackgroundTasks;

public interface IBackgroundQueue 
{
    void Push(Func<CancellationToken, Task> task);
    Task<Func<CancellationToken,Task>> Pop(CancellationToken cancellationToken);
}

public class BackgroundQueue : ITasksQueue
{
    private ConcurrentQueue<Func<CancellationToken, Task>> tasksQueue = new ConcurrentQueue<Func<CancellationToken, Task>>();
    private SemaphoreSlim  signal = new SemaphoreSlim(0);

    public async Task<Func<CancellationToken, Task>> Dequeue(CancellationToken cancellationToken)
    {
        await signal.WaitAsync(cancellationToken);
        tasksQueue.TryDequeue(out var task);
        return task;
    }

    public async Task Enqueue(Func<CancellationToken, Task> task)
    {
        await Task.Run(() => {
            tasksQueue.Enqueue(task);
            signal.Release();
        });
    }
}