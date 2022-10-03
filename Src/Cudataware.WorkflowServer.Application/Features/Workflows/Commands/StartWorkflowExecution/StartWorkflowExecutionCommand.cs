using MediatR;
namespace Cudataware.WorkflowServer.Application.Features.Workflows.Commands.StartWorkflowExecution; 

public class StartWorkflowExecutionCommand : IRequest
{
    public int WorkflowId {set; get;}
    public int EntityId {set; get;}
}