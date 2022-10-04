using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Cudataware.WorkflowServer.Persistence.Contexts;
using MediatR;
using Newtonsoft.Json;

namespace Cudataware.WorkflowServer.Application.Features.Workflows.Commands.IfAction;

public class IfActionCommandHandler : IRequestHandler<IfActionCommand, bool>
{    
    private IMapper mapper;
    private AppDbContext db;

    public IfActionCommandHandler(IMapper mapper, AppDbContext db)
    {
        this.mapper = mapper;
        this.db = db;
    }

    public async Task<bool> Handle(IfActionCommand request, CancellationToken cancellationToken)
    {
        var entityType = Assembly.GetExecutingAssembly().GetType(request.EntityType);        
        var entity = JsonConvert.DeserializeObject(request.Input, entityType);

        // implement evaluation process , for now, just check a simple condition 

        if ((bool)entityType.GetProperty(request.Expression).GetValue(entity) == true)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}