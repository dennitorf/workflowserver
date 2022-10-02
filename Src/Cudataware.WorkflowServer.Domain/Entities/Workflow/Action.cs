using Cudataware.WorkflowServer.Domain.Common;

namespace Cudataware.WorkflowServer.Domain.Entities.Workflow;

public class Action : BaseEntity
{    
    public string Code {set; get;}
    public string Description { set; get; }
    public bool Automatic { set; get; } 
    public string EntityInputType { set; get; }
    public string EntityOutputType { set; get; }
    public string WorkflowActionHandler {set; get;}
}