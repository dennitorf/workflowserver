using Cudataware.WorkflowServer.Domain.Entities.Workflow;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cudataware.WorkflowServer.Persistence.Configurations.Workflow;

public class WorkflowExecutionDetailConfiguration : IEntityTypeConfiguration<WorkflowExecutionDetail>
{
    public void Configure(EntityTypeBuilder<WorkflowExecutionDetail> builder)
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

        builder.ToTable("WorkflowExecutionDetail");

        builder.HasOne<WorkflowExecution>(c => c.WorkflowExecution)
            .WithMany(c => c.WorkflowExecutionDetails)
            .HasForeignKey(c => c.WorkflowExecutionId)
            .OnDelete(DeleteBehavior.Restrict);        

        builder.HasOne<WorkflowAction>(c => c.WorkflowAction)
            .WithMany(c => c.WorkflowExecutionDetails)
            .HasForeignKey(c => c.WorkflowExecutionId)
            .OnDelete(DeleteBehavior.Restrict);        
    }
}