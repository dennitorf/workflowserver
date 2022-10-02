using Cudataware.WorkflowServer.Domain.Entities.Sample;
using Cudataware.WorkflowServer.Domain.Entities.Workflow;
using Microsoft.EntityFrameworkCore;

namespace Cudataware.WorkflowServer.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }        
        public DbSet<Todo> Todos { set; get; }
        public DbSet<TodoItem> TodoItems { set; get; }

        // Workflow

        public DbSet<Action> Actions {set; get;}
        public DbSet<Workflow> Workflows {set; get;}
        public DbSet<WorkflowAction> WorkflowActions {set; get;}
        public DbSet<WorkflowConfiguration> WorkflowConfiguration {set; get;}
        public DbSet<WorkflowExecution> WorkflowExecutions {set; get;}
        public DbSet<WorkflowExecutionDetail> WorkflowExecutionDetails {set; get;}
    }
}
