using MediatR;
namespace Cudataware.WorkflowServer.Application.Features.Todos.Commands.RequestTodoApproval;

public class RequestTodoApprovalCommand : IRequest
{
    public int Id {set; get;}
}