using MediatR;
namespace Cudataware.WorkflowServer.Application.Features.Workflows.Commands.WorkflowActionExecution; 

public class WorkflowActionExecutionCommand : IRequest
{
    public int WorkflowExecutionDetailId {set; get;}
}