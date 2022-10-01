using MediatR;
using System.Collections.Generic;

namespace Cudataware.WorkflowServer.Application.Features.TodoItems.Queries.GetAllTodoItems
{
    public class GetAllTodoItemsQuery : IRequest<IEnumerable<TodoItemDto>>
    {
        public int Id { set; get; }
    }
}
