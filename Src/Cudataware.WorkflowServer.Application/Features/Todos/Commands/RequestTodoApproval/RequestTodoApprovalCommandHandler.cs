using System.Threading;
using System.Threading.Tasks;
using Cudataware.WorkflowServer.Application.Features.Todos.Queries.GetTodo;
using Cudataware.WorkflowServer.Application.Features.Workflows.Commands.StartWorkflowExecution;
using Cudataware.WorkflowServer.Persistence.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Cudataware.WorkflowServer.Application.Features.Todos.Commands.RequestTodoApproval;

public class RequestTodoApprovalCommandHandler : IRequestHandler<RequestTodoApprovalCommand>
{
    private IMediator mediator;
    private ILogger logger;
    private AppDbContext db;

    public RequestTodoApprovalCommandHandler(IMediator mediator, ILogger<RequestTodoApprovalCommandHandler> logger, AppDbContext db)
    {
        this.mediator = mediator;
        this.logger = logger;
        this.db = db;
    }

    public async Task<Unit> Handle(RequestTodoApprovalCommand request, CancellationToken cancellationToken)
    {
        var ent = await mediator.Send(new GetTodoQuery() { Id = request.Id });

        var workflow  = await db.Workflows.FirstOrDefaultAsync(); 
        
        await mediator.Send(new StartWorkflowExecutionCommand() { EntityId = ent.Id, WorkflowId = workflow.Id } );

        return Unit.Task.Result;

    }
}