using Cudataware.WorkflowServer.Application.Common.Workflow.Attributes;

namespace Cudataware.WorkflowServer.Application.Common.Workflow.Expressions.Operators.Logical;

public enum BooleanLogicOperator 
{
    [WfExpressionOperatorAttribute(Description = "Equal")]
    Equal, 
    [WfExpressionOperatorAttribute(Description = "Different")]
    Different
}