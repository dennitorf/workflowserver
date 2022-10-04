using Cudataware.WorkflowServer.Application.Common.Workflow.Attributes;

namespace Cudataware.WorkflowServer.Application.Common.Workflow.Expressions.Operators.Aritmetical;

public enum AritmeticalOperator 
{
    [WfExpressionOperatorAttribute(Description = "Sum")]
    Plus, 
    [WfExpressionOperatorAttribute(Description = "Subtract")]
    Minus,
    [WfExpressionOperatorAttribute(Description = "Multiply")]
    Mul,
    [WfExpressionOperatorAttribute(Description = "Divide")]
    Div
}