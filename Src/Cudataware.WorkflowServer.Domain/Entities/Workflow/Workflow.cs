using System.Collections.Generic;
using Cudataware.WorkflowServer.Domain.Common;

namespace Cudataware.WorkflowServer.Domain.Entities.Workflow; 

public class Workflow : BaseEntity 
{
    public string Name {set; get;}
    public virtual ICollection<WorkflowAction> Actions {set; get;}
    public virtual ICollection<WorkflowExecution> Executions {set; get;}
}