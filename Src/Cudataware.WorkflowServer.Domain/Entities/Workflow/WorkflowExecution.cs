using System.Collections.Generic;
using Cudataware.WorkflowServer.Domain.Common;

namespace Cudataware.WorkflowServer.Domain.Entities.Workflow;

public class WorkflowExecution : BaseEntity
{ 
    public int EntityId {set; get;}
    public int CorrelationId {set; get;}
    public string Entity {set; get;} 
    public Workflow Workflow {set; get;}
    public int WorkflowId {set; get;}
    public virtual ICollection<WorkflowExecutionDetail> WorkflowExecutionDetails {set; get;}
}