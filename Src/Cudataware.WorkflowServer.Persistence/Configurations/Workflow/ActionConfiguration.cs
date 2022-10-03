using Cudataware.WorkflowServer.Domain.Entities.Workflow;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cudataware.WorkflowServer.Persistence.Configurations.Workflow;

public class ActionsConfiguration : IEntityTypeConfiguration<Action>
{
    public void Configure(EntityTypeBuilder<Action> builder)
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

        builder.ToTable("Action");
    }
}