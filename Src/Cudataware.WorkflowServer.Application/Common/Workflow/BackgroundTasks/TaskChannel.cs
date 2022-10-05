using System;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Channels;

namespace Cudataware.WorkflowServer.Application.Common.Workflow.BackgroundTasks;

public class TaskChannel : ITasksQueue
{
    private Channel<Func<CancellationToken, Task>> channel = Channel.CreateUnbounded<Func<CancellationToken, Task>>();
    public async Task<Func<CancellationToken, Task>> Dequeue(CancellationToken cancellationToken)
    {
        bool thereAreData = await channel.Reader.WaitToReadAsync(cancellationToken);
        var t = await channel.Reader.ReadAsync(cancellationToken);
        return t;
    }

    public async Task Enqueue(Func<CancellationToken, Task> task)
    {
        await channel.Writer.WriteAsync(task);
    }
}