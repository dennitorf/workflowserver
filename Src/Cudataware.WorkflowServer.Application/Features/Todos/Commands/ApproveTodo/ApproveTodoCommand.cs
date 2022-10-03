using MediatR;

namespace Cudataware.WorkflowServer.Application.Features.Todos.Commands.ApproveTodo;

public class ApproveTodoCommand : IRequest<ApproveTodoDto>
{
    public int Id { set; get; }
}