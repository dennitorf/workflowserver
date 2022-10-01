﻿using Cudataware.WorkflowServer.Application.Features.TodoItems.Queries.GetAllTodoItems;
using MediatR;

namespace Cudataware.WorkflowServer.Application.Features.TodoItems.Commands.UpdateTodoItem
{
    public class UpdateTodoItemCommand : IRequest<TodoItemDto>
    {
        public int Id { get; set; }
        public string Name { set; get; }
    }
}
