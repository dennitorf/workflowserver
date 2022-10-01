using Cudataware.WorkflowServer.Application.Features.TodoItems.Queries.GetAllTodoItems;
using MediatR;

namespace Cudataware.WorkflowServer.Application.Features.TodoItems.Queries.GetTodoItem
{
    public class GetTodoItemQuery : IRequest<TodoItemDto>
    {
        public int Id { set; get; }
    }
}
