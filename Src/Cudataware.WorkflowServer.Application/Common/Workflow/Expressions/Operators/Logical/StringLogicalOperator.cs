using Cudataware.WorkflowServer.Application.Common.Workflow.Attributes;

namespace Cudataware.WorkflowServer.Application.Common.Workflow.Expressions.Operators.Logical;
public enum StringLogicalOperator 
{
    [WfExpressionOperatorAttribute(Description = "Equal")]
    Equal, 
    [WfExpressionOperatorAttribute(Description = "Different")]
    Different,
    [WfExpressionOperatorAttribute(Description = "Contains")]
    Contains,
    [WfExpressionOperatorAttribute(Description = "Not Contains")]
    NotContains,
    [WfExpressionOperatorAttribute(Description = "Starts With")]
    StartWith,
    [WfExpressionOperatorAttribute(Description = "Not Starts With")]
    NotStartWith,
    [WfExpressionOperatorAttribute(Description = "Ends With")]
    EndsWith,
    [WfExpressionOperatorAttribute(Description = "Not SEnds With")]
    NotEndsWith
}