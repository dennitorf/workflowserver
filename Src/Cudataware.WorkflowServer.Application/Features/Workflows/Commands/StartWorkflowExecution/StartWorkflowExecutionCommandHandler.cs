using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Cudataware.WorkflowServer.Domain.Entities.Workflow;
using Cudataware.WorkflowServer.Persistence.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Cudataware.WorkflowServer.Application.Features.Workflows.Commands.StartWorkflowExecution; 

public class StartWorkflowExecutionCommandHandler : IRequestHandler<StartWorkflowExecutionCommand>
{
    private IMapper mapper;
    private AppDbContext db;
    private IMediator mediator;
    private ILogger logger;

    public StartWorkflowExecutionCommandHandler(IMapper mapper, AppDbContext db, IMediator mediator, ILogger<StartWorkflowExecutionCommandHandler> logger)
    {
        this.mapper = mapper;
        this.db = db;
        this.mediator = mediator;
        this.logger = logger;
    }

    public async Task<Unit> Handle(StartWorkflowExecutionCommand request, CancellationToken cancellationToken)
    {
        var workflow = await db
            .Workflows            
            .Include(c => c.Actions)
            .Where(c => c.Id == request.WorkflowId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        var firstAction = workflow
            .Actions
            .Where(c => c.FirstAction)
            .FirstOrDefault();
        
        string correlationId = Guid.NewGuid().ToString();

        var workflowExecution = new Cudataware.WorkflowServer.Domain.Entities.Workflow.WorkflowExecution() 
        {
            WorkflowId = request.WorkflowId,
            CorrelationId = 1,
            EntityId = request.EntityId,
            IsActive = true,
            WorkflowExecutionDetails = new List<WorkflowExecutionDetail> () 
            {
                new WorkflowExecutionDetail() 
                {
                    WorkflowActionId = firstAction.Id,
                    CorrelationId = 1,
                    InputEntity = JsonConvert.SerializeObject(new  { Id = request.EntityId }),
                    ReadyToExecute = true,
                    Executed = false,
                    IsActive = true                    
                }
            }
        };

        await db.WorkflowExecutions.AddAsync(workflowExecution);
        await db.SaveChangesAsync(cancellationToken);

        return Unit.Task.Result;
    }
}