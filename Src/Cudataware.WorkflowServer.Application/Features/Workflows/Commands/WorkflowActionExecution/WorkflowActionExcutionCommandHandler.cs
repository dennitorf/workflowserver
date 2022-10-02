using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Cudataware.WorkflowServer.Application.Common.Exceptions;
using Cudataware.WorkflowServer.Domain.Entities.Workflow;
using Cudataware.WorkflowServer.Persistence.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Cudataware.WorkflowServer.Application.Features.Workflows.Commands.WorkflowActionExecution;

public class WorkflowActionExcutionCommandHandler : IRequestHandler<WorkflowActionExecutionCommand>
{
    private IMediator mediator;
    private AppDbContext db;    
    private IMapper mapper;
    private ILogger logger;
    
    public async Task<Unit> Handle(WorkflowActionExecutionCommand request, CancellationToken cancellationToken)
    {
        var workflowActionExecution = await db
            .WorkflowExecutionDetails            
            .Include(c => c.WorkflowExecution)
            .Include(c => c.WorkflowAction)
            .ThenInclude(c => c.Action)                        
            .Where(c => c.Id == request.WorkflowExecutionDetailId)
            .FirstOrDefaultAsync();
        
        if (workflowActionExecution == null)
            throw new NotFoundException(nameof(WorkflowExecutionDetail), request.WorkflowExecutionDetailId);

        var commandType = Assembly.GetExecutingAssembly().GetType(workflowActionExecution.WorkflowAction.Action.WorkflowActionHandler);

        var command = JsonConvert.DeserializeObject(workflowActionExecution.InputEntity, commandType);
        try 
        {
            var result = await mediator.Send(command);
            var resultSerialized = JsonConvert.SerializeObject(result);

            if (!workflowActionExecution.WorkflowAction.LastAction) 
            {
                var nextWorkflowActionExecution = mapper.Map<WorkflowExecutionDetail>(workflowActionExecution);
                nextWorkflowActionExecution.WorkflowActionId  = workflowActionExecution.WorkflowAction.NextAction;
                nextWorkflowActionExecution.InputEntity = resultSerialized;
                workflowActionExecution.ReadyToExecute = true;
                workflowActionExecution.Executed = false;

                await db.WorkflowExecutionDetails.AddAsync(nextWorkflowActionExecution);
            }

            workflowActionExecution.OuputEntity = resultSerialized;
            workflowActionExecution.Executed = true;

            db.WorkflowExecutionDetails.Update(workflowActionExecution);

            await db.SaveChangesAsync(cancellationToken);

        }
        catch (Exception e)
        {
            throw e;
        }

        return Unit.Task.Result;        
        
    }
}