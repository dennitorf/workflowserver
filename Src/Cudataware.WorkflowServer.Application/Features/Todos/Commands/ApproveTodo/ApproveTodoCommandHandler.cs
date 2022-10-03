using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cudataware.WorkflowServer.Application.Features.Todos.Commands.ApproveTodo;

public class ApproveTodoCommandHandler : IRequestHandler<ApproveTodoCommand, ApproveTodoDto>
{
    private IMapper mapper;    
    private ILogger logger;

    public ApproveTodoCommandHandler(IMapper mapper, ILogger<ApproveTodoCommandHandler> logger)
    {
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<ApproveTodoDto> Handle(ApproveTodoCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Approving Todo {id}", request.Id);

        return new ApproveTodoDto() { };
    }
}