using Cudataware.WorkflowServer.Persistence.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Cudataware.WorkflowServer.Persistence.Contexts
{
    public class AppDbContextFactory : DesignTimeDbContextFactoryBase<AppDbContext>
    {
        protected override AppDbContext CreateNewInstance(DbContextOptions<AppDbContext> options)
        {
            return new AppDbContext(options);
        }
    }
}
