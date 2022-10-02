using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cudataware.WorkflowServer.Application.Features.Todos.Commands.EvaluateTodo;

public class EvaluateTodoCommandHandler : IRequestHandler<EvaluateTodoCommand, EvaluateTodoDto>
{
    private IMapper mapper;    
    private ILogger logger;

    public EvaluateTodoCommandHandler(IMapper mapper, ILogger<EvaluateTodoCommandHandler> logger)
    {
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<EvaluateTodoDto> Handle(EvaluateTodoCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Evaluating Todo {id}", request.Id);
        
        return new EvaluateTodoDto() {IsGood = true };
    }
}