using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Cudataware.WorkflowServer.Application.Common.Exceptions;
using Cudataware.WorkflowServer.Domain.Entities.Workflow;
using Cudataware.WorkflowServer.Persistence.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Cudataware.WorkflowServer.Application.Features.Workflows.Queries.GetWorkflowConfiguration;

public class GetWorkflowConfigurationQueryHandler : IRequestHandler<GetWorkflowConfigurationQuery, WorkflowConfigurationDto>
{
    private IMapper mapper;
    private AppDbContext db;
    private ILogger logger;

    public GetWorkflowConfigurationQueryHandler(IMapper mapper, AppDbContext db, ILogger<GetWorkflowConfigurationQueryHandler> logger)
    {
        this.mapper = mapper;
        this.db = db;
        this.logger = logger;
    }

    public async Task<WorkflowConfigurationDto> Handle(GetWorkflowConfigurationQuery request, CancellationToken cancellationToken)
    {
        var ent = await db.WorkflowConfiguration.FirstOrDefaultAsync();

        if (ent == null)
            throw new NotFoundException(nameof(WorkflowConfiguration), $"{1}");

        return mapper.Map<WorkflowConfigurationDto>(ent);
    }
}