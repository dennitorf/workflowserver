using Cudataware.WorkflowServer.Domain.Entities.Workflow;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cudataware.WorkflowServer.Persistence.Configurations.Workflow;

public class WorkflowConfigurationConfiguration : IEntityTypeConfiguration<Cudataware.WorkflowServer.Domain.Entities.Workflow.WorkflowConfiguration>
{
    public void Configure(EntityTypeBuilder<Cudataware.WorkflowServer.Domain.Entities.Workflow.WorkflowConfiguration> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .UseIdentityColumn();

        builder.Property(c => c.CreatedDate)
            .IsRequired(true)
            .HasDefaultValueSql("GETDATE()");

        builder.Property(c => c.ModifiedDate)
            .IsRequired(true)
            .HasDefaultValueSql("GETDATE()");                    

        builder.ToTable("WorkflowConfiguration");
    }
}