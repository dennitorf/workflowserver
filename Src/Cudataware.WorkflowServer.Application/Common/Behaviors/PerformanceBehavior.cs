using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Cudataware.WorkflowServer.Application.Common.Behaviors
{
    public class PerformanceBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : MediatR.IRequest<TResponse>
    {
        private readonly Stopwatch timer;
        private readonly ILogger logger;

        public PerformanceBehavior(ILogger<PerformanceBehavior<TRequest, TResponse>> logger)
        {
            this.timer = new Stopwatch();
            this.logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            timer.Start();

            var response = await next();

            timer.Stop();

            var requestName = typeof(TRequest);

            logger.LogInformation("Cudataware.WorkflowServer {Name} Execution Time {time}", requestName, timer.ElapsedMilliseconds);

            return response;
        }
    }
}
