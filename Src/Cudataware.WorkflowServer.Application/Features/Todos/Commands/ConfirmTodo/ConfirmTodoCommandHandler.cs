using System.Threading;
using System.Threading.Tasks;
using Cudataware.WorkflowServer.Application.Common.Workflow.Attributes;
using Cudataware.WorkflowServer.Application.Features.Todos.Queries.GetAllTodos;
using Cudataware.WorkflowServer.Application.Features.Todos.Queries.GetTodo;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cudataware.WorkflowServer.Application.Features.Todos.Commands.ConfirmTodo;

public class ConfirmTodoCommandHandler : IRequestHandler<ConfirmTodoCommand, TodoDto>
{
    private ILogger logger;
    private IMediator mediator;

    public ConfirmTodoCommandHandler(ILogger<ConfirmTodoCommandHandler> logger, IMediator mediator)
    {
        this.logger = logger;
        this.mediator = mediator;
    }

    public async Task<TodoDto> Handle(ConfirmTodoCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Confirming TODO");        
        return await mediator.Send(new GetTodoQuery() { Id = request.Id });
    }
}