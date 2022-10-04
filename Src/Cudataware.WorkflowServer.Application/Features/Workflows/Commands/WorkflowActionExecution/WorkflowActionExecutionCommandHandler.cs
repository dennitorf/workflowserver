using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Cudataware.WorkflowServer.Application.Common.Exceptions;
using Cudataware.WorkflowServer.Application.Features.Workflows.Commands.IfAction;
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

    public WorkflowActionExcutionCommandHandler(IMediator mediator, AppDbContext db, IMapper mapper, ILogger<WorkflowActionExcutionCommandHandler> logger)
    {
        this.mediator = mediator;
        this.db = db;
        this.mapper = mapper;
        this.logger = logger;
    }

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

        var commandType = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(c => c.Name == workflowActionExecution.WorkflowAction.Action.WorkflowActionName)
            .FirstOrDefault();
        
        try 
        {
            var command = JsonConvert.DeserializeObject(workflowActionExecution.InputEntity, commandType);
            
            string resultSerialized = request.ResultFromManualAction;

            if (workflowActionExecution.WorkflowAction.Action.Automatic) 
            {
                if (commandType == typeof(IfActionCommand))
                {
                    PropertyInfo propInput = commandType.GetProperty("Input");
                    propInput.SetValue(command, workflowActionExecution.InputEntity);

                    PropertyInfo propEntityType = commandType.GetProperty("EntityType");
                    propEntityType.SetValue(command, workflowActionExecution.WorkflowAction.Action.EntityOutputType);

                    PropertyInfo propExpression = commandType.GetProperty("Expression");
                    propExpression.SetValue(command, workflowActionExecution.WorkflowAction.ActionMetadata);

                }

                var result = await mediator.Send(command);
                resultSerialized = JsonConvert.SerializeObject(result);
            }

            workflowActionExecution.OuputEntity = resultSerialized;
            workflowActionExecution.Executed = true;
            db.WorkflowExecutionDetails.Update(workflowActionExecution);
            await db.SaveChangesAsync(cancellationToken);

            if (!workflowActionExecution.WorkflowAction.LastAction) 
            {                
                int nextActionToExecute = workflowActionExecution.WorkflowAction.NextAction;

                if (commandType == typeof(IfActionCommand))
                {
                    bool result = JsonConvert.DeserializeObject<bool>(resultSerialized);
                    resultSerialized  = workflowActionExecution.InputEntity;
                    
                    if (!result)
                    {
                        nextActionToExecute = workflowActionExecution.WorkflowAction.NextSecondAction;                            
                    }
                }   

                var nextWorkflowActionExecution = new WorkflowExecutionDetail() 
                {
                    WorkflowActionId = nextActionToExecute,   
                    WorkflowExecutionId = workflowActionExecution.WorkflowExecutionId,         
                    CorrelationId = 1,
                    InputEntity = resultSerialized,
                    ReadyToExecute = true,
                    Executed = false,
                    IsActive = true                    
                };
                
                await db.WorkflowExecutionDetails.AddAsync(nextWorkflowActionExecution);
                await db.SaveChangesAsync(cancellationToken);
            }                        
        }
        catch (Exception e)
        {
            logger.LogError("Error while executing workflow action: {message} {stackTrace}", e.Message, e.StackTrace);
            throw e;
        }

        return Unit.Task.Result;        
        
    }
}