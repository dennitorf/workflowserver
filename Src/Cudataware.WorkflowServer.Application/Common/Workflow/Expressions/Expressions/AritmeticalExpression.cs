using System;

namespace Cudataware.WorkflowServer.Application.Common.Workflow.Expressions.Expressions.Expressions;

public abstract class AritmeticalExpression
{
    public Guid Id {set; get;}

    protected AritmeticalExpression()
    {
        Id = Guid.NewGuid();
    }

    
}