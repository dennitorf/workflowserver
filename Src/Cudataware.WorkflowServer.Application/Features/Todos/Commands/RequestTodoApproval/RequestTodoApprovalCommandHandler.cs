using System.Threading;
using System.Threading.Tasks;
using Cudataware.WorkflowServer.Application.Features.Todos.Queries.GetTodo;
using Cudataware.WorkflowServer.Application.Features.Workflows.Commands.StartWorkflowExecution;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cudataware.WorkflowServer.Application.Features.Todos.Commands.RequestTodoApproval;

public class RequestTodoApprovalCommandHandler : IRequestHandler<RequestTodoApprovalCommand>
{
    private IMediator mediator;
    private ILogger logger;

    public RequestTodoApprovalCommandHandler(IMediator mediator, ILogger<RequestTodoApprovalCommandHandler> logger)
    {
        this.mediator = mediator;
        this.logger = logger;
    }

    public async Task<Unit> Handle(RequestTodoApprovalCommand request, CancellationToken cancellationToken)
    {
        var ent = await mediator.Send(new GetTodoQuery() { Id = request.Id });
        
        await mediator.Send(new StartWorkflowExecutionCommand() { EntityId = ent.Id, WorkflowId = 1 } );

        return Unit.Task.Result;

    }
}