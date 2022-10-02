using Cudataware.WorkflowServer.Domain.Entities.Workflow;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cudataware.WorkflowServer.Persistence.Configurations.Workflow;

public class WorkflowActionConfiguration : IEntityTypeConfiguration<WorkflowAction>
{
    public void Configure(EntityTypeBuilder<WorkflowAction> builder)
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

        builder.HasOne<Cudataware.WorkflowServer.Domain.Entities.Workflow.Workflow>(c => c.Workflow)
            .WithMany(c => c.Actions)
            .HasForeignKey(c => c.WorkflowId);                             

        builder.ToTable("WorkflowAction");
    }
}