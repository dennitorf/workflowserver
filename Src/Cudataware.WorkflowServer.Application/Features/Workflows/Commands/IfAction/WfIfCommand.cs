using MediatR;
namespace Cudataware.WorkflowServer.Application.Features.Workflows.Commands.IfAction;

public class IfActionCommand : IRequest<bool>
{    
    public string Input { set ; get; }
    public string EntityType {set ; get; }
    public string Expression {set; get; }
}