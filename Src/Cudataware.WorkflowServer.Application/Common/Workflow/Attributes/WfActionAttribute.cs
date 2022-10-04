using System;

namespace Cudataware.WorkflowServer.Application.Common.Workflow.Attributes;

public class WfActionAttribute : Attribute
{
    public string Code {set; get;}
    public string Description {set; get;}
    public bool Automatic {set; get;}
    public string EntityInputType {set; get;} 
    public string EntityOutputType { set; get; }
    public string WorkflowActionHandler {set; get;}
    public bool FlowControlAction {set; get;}
}