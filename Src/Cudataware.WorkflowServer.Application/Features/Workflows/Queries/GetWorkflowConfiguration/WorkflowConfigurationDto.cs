using AutoMapper;
using Cudataware.WorkflowServer.Application.Common.Interfaces.Mappings;
using Cudataware.WorkflowServer.Domain.Entities.Workflow;
using MediatR;
namespace Cudataware.WorkflowServer.Application.Features.Workflows.Queries.GetWorkflowConfiguration;

public class WorkflowConfigurationDto : IHaveCustomMapping
{
    public bool WorkflowBackgroungJobEnable {set; get;}
    public int ConcurrentMaxExecutions {set; get;}
    public int IntervalMiliseconds {set; get;}
    public void CreateMappings(Profile configuration)
    {
        configuration.CreateMap<WorkflowConfiguration, WorkflowConfigurationDto>();
    }
}