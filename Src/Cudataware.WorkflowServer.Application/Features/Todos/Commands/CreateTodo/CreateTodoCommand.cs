using Cudataware.WorkflowServer.Application.Features.Todos.Queries.GetAllTodos;
using MediatR;

namespace Cudataware.WorkflowServer.Application.Features.Todos.Commands.CreateTodo
{
    public class CreateTodoCommand : IRequest<TodoDto>
    {
        public string Name { set; get; }
    }
}
