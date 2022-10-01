using Cudataware.WorkflowServer.Application.Common.Interfaces.Email;
using Cudataware.WorkflowServer.Infrastructure.Email;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cudataware.WorkflowServer.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IEmailService, EmailService>();   

            return services;
        }
    }
}
