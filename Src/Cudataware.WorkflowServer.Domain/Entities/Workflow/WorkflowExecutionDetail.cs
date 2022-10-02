using Cudataware.WorkflowServer.Domain.Common;

namespace Cudataware.WorkflowServer.Domain.Entities.Workflow;

public class WorkflowExecutionDetail : BaseEntity
{
    public int CorrelationId {set; get;}
    public string InputEntity {set; get;}
    public string OuputEntity {set; get;}
    public bool ReadyToExecute {set; get; }
    public bool Executed {set; get; } 
    public WorkflowExecution WorkflowExecution {set; get;}
    public int WorkflowExecutionId {set; get;}
}