using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Cudataware.WorkflowServer.Application.Common.Exceptions;
using Cudataware.WorkflowServer.Application.Features.Workflows.Commands.WorkflowActionExecution;
using Cudataware.WorkflowServer.Application.Features.Workflows.Queries.GetWorkflowConfiguration;
using Cudataware.WorkflowServer.Persistence.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Cudataware.WorkflowServer.Application.Features.Workflows.Commands.WorkflowExecution;

public class WorkflowExecutionCommandHandler : IRequestHandler<WorkflowExecutionCommand>
{
    private IMediator mediator;
    private AppDbContext db;    
    private IMapper mapper;
    private ILogger logger;

    public WorkflowExecutionCommandHandler(IMediator mediator, AppDbContext db, IMapper mapper, ILogger<WorkflowExecutionCommandHandler> logger)
    {
        this.mediator = mediator;
        this.db = db;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<Unit> Handle(WorkflowExecutionCommand request, CancellationToken cancellationToken)
    {                
        logger.LogInformation("Starting Workflow Engine");

        try
        {
            var configuration = await mediator.Send(new GetWorkflowConfigurationQuery() {});

            while (true)
            {
                if (configuration.WorkflowBackgroungJobEnable)
                {
                    var workflowActionInstancesReadyToExecute = db
                        .WorkflowExecutionDetails                        
                        .Where(c => c.ReadyToExecute && !c.Executed)
                        .AsNoTracking();
                        
                    foreach (var workflowAction in workflowActionInstancesReadyToExecute)
                    {
                        await mediator.Send(new WorkflowActionExecutionCommand() { WorkflowExecutionDetailId = workflowAction.Id });
                    }
                    
                }

                Thread.Sleep(configuration.IntervalMiliseconds);
            }

        }
        catch (NotFoundException e)
        {
            logger.LogError("Workflow Engine Configuration Not Found");
        }
        catch (Exception e)
        {
            logger.LogError("Is not possible to start the workflow engine due some exception. Exception: {message} {stackTrace}", e.Message, e.StackTrace);
        }

        return Unit.Task.Result;
    }
}