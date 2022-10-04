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
            .HasForeignKey(c => c.WorkflowId)
            .OnDelete(DeleteBehavior.Restrict);                             

        builder.HasOne<Action>(c => c.Action)
            .WithMany(c => c.WorkflowActions)
            .HasForeignKey(c => c.ActionId)
            .OnDelete(DeleteBehavior.Restrict);    

        builder.Property(c => c.ActionMetadata)
            .IsRequired(false);                        

        builder.ToTable("WorkflowAction");
    }
}