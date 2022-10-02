using System.Collections.Generic;
using Cudataware.WorkflowServer.Domain.Common;

namespace Cudataware.WorkflowServer.Domain.Entities.Workflow; 

public class WorkflowAction : BaseEntity
{
    public bool FirstAction {set ; get; }
    public bool LastAction { set; get; }
    public int NextAction {set; get; }
    public Workflow Workflow {set; get;}
    public int WorkflowId {set; get;}
    public Action Action {set; get; }
    public int ActionId {set; get;}
    public virtual ICollection<WorkflowExecutionDetail> WorkflowExecutionDetails {set; get;}
}    