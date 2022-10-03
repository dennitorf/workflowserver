using Cudataware.WorkflowServer.Domain.Common;

namespace Cudataware.WorkflowServer.Domain.Entities.Workflow;

public class WorkflowConfiguration : BaseEntity
{
    public bool WorkflowBackgroungJobEnable {set; get;}
    public int ConcurrentMaxExecutions {set; get;}
    public int IntervalMiliseconds {set; get;}
} 