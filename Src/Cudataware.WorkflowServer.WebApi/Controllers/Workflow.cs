using Cudataware.WorkflowServer.Application.Features.Workflows.Commands.WorkflowExecution;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cudataware.WorkflowServer.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Workflow : BaseController
    {        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Post(WorkflowExecutionCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        
    }
}
