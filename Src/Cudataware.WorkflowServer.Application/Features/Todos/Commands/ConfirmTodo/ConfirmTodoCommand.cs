using Cudataware.WorkflowServer.Application.Common.Workflow.Attributes;
using Cudataware.WorkflowServer.Application.Features.Todos.Queries.GetAllTodos;
using MediatR;

namespace Cudataware.WorkflowServer.Application.Features.Todos.Commands.ConfirmTodo;

[WfAction(Automatic = false)]
public class ConfirmTodoCommand : IRequest<TodoDto>
{
    public int Id {set; get;}
}