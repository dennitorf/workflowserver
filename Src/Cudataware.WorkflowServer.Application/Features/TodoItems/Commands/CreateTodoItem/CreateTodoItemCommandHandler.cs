using AutoMapper;
using Cudataware.WorkflowServer.Application.Features.TodoItems.Queries.GetAllTodoItems;
using Cudataware.WorkflowServer.Domain.Entities.Sample;
using Cudataware.WorkflowServer.Persistence.Contexts;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cudataware.WorkflowServer.Application.Features.TodoItems.Commands.CreateTodoItem
{
    public class CreateTodoItemCommandHandler : IRequestHandler<CreateTodoItemCommand, TodoItemDto>
    {
        private IMapper mapper;
        private AppDbContext db;
        private ILogger logger;

        public CreateTodoItemCommandHandler(IMapper mapper, AppDbContext db, ILogger<CreateTodoItemCommandHandler> logger)
        {
            this.mapper = mapper;
            this.db = db;
            this.logger = logger;
        }

        public async Task<TodoItemDto> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var ent = new TodoItem()
            {
                Name = request.Name,
                CreatedBy = "system",
                CreatedDate = DateTime.UtcNow,
                LastModifiedBy = "system",
                ModifiedDate = DateTime.UtcNow,
                IsActive = true,
                TodoId = request.TodoId
            };

            await db.TodoItems.AddAsync(ent);
            await db.SaveChangesAsync(cancellationToken);

            return mapper.Map<TodoItemDto>(ent);
        }
    }
}
