using Cudataware.WorkflowServer.Domain.Entities.Workflow;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cudataware.WorkflowServer.Persistence.Configurations.Workflow;

public class WorkflowConfiguration : IEntityTypeConfiguration<Cudataware.WorkflowServer.Domain.Entities.Workflow.Workflow>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Workflow.Workflow> builder)
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

        builder.HasMany<WorkflowAction>(c => c.Actions)
            .WithOne(c => c.Workflow)
            .HasForeignKey(c => c.WorkflowId);

        builder.ToTable("Workflow");
    }
}