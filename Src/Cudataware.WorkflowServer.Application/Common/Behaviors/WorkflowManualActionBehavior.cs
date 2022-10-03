using Cudataware.WorkflowServer.Application.Common.Workflow.Attributes;
using Cudataware.WorkflowServer.Application.Features.Workflows.Commands.WorkflowActionExecution;
using Cudataware.WorkflowServer.Persistence.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Cudataware.WorkflowServer.Application.Common.Behaviors
{
    public class WorkflowManualActionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : MediatR.IRequest<TResponse>
    {
        private ILogger logger;
        private AppDbContext db;
        private IMediator mediator;

        public WorkflowManualActionBehavior(ILogger<WorkflowManualActionBehavior<TRequest, TResponse>> logger, AppDbContext db, IMediator mediator)
        {
            this.logger = logger;
            this.db = db;
            this.mediator = mediator;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var response = await next();

            var requestType = typeof(TRequest);

            WfActionAttribute customWfActionAttribute = (WfActionAttribute)Attribute.GetCustomAttribute(requestType, typeof(WfActionAttribute));

            if (customWfActionAttribute != null)
            {
                if (!customWfActionAttribute.Automatic)
                {                      
                    int entityId = (int)requestType.GetProperty("Id").GetValue(request);
                    // it is a manual action, then, we need to find if there is any WorkflowExecution, pointing to this action and this entity

                    var workflowExecution = await db.WorkflowExecutionDetails
                        .Include(c => c.WorkflowExecution)
                        .Include(c => c.WorkflowAction)
                        .ThenInclude(c => c.Action)
                        .Where(c => c.WorkflowAction.Action.WorkflowActionName == requestType.Name && c.ReadyToExecute && !c.Executed && c.WorkflowExecution.EntityId == entityId) 
                        .FirstOrDefaultAsync();
                    
                    if (workflowExecution != null)
                    {
                        await mediator.Send(new WorkflowActionExecutionCommand() { WorkflowExecutionDetailId = workflowExecution.Id, ResultFromManualAction = JsonConvert.SerializeObject(response) });
                    }
                }   
            }

            return response;
        }
    }
}