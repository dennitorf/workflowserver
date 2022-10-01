using MediatR;

namespace Cudataware.WorkflowServer.Application.Features.TodoItems.Commands.DeleteTodoItem
{
    public class DeleteTodoItemCommand : IRequest
    {
        public int Id { set; get; }
    }
}
