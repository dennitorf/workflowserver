using MediatR;

namespace Cudataware.WorkflowServer.Application.Features.Todos.Commands.DeleteTodo
{
    public class DeleteTodoCommand : IRequest
    {
        public int Id { set; get; }
    }
}
