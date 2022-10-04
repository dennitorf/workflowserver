using Cudataware.WorkflowServer.Application.Common.Workflow.Attributes;

namespace Cudataware.WorkflowServer.Application.Common.Workflow.Expressions.Operators.Logical;

public enum NumericalLogicOperator 
{
    [WfExpressionOperatorAttribute(Description = "Equal")]
    Equal, 
    [WfExpressionOperatorAttribute(Description = "Different")]
    Different,
    [WfExpressionOperatorAttribute(Description = "Greather than")]
    GreatherThan,
    [WfExpressionOperatorAttribute(Description = "Greather than or equal")]
    GreatherThanOrEqual,
    [WfExpressionOperatorAttribute(Description = "Less than")]
    LessThan,
    [WfExpressionOperatorAttribute(Description = "Less than or equal")]
    LessThanOrEqual
}