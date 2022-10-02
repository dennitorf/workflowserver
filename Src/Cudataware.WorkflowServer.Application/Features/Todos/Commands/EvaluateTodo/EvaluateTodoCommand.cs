using MediatR;

namespace Cudataware.WorkflowServer.Application.Features.Todos.Commands.EvaluateTodo;

public class EvaluateTodoCommand : IRequest<EvaluateTodoDto>
{
    public int Id {set; get;}
}