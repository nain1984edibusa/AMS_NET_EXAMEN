using Microservices.Demo.Policies.Service.Domain.Policies.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Microservices.Demo.Policies.Service.Infrastructure.Persistence.EF.MySQL.Policies.Contexts.Configurations
{
    public class PolicyConfiguration : IEntityTypeConfiguration<Policy>
    {
        public void Configure(EntityTypeBuilder<Policy> builder)
        {
            builder.ToTable("Policies");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("PolicyId");

            builder.Property(p => p.Number).IsRequired(false);
            builder.Property(p => p.ProductCode).IsRequired(false);
            builder.Property(p => p.Status).HasConversion<string>();
            builder.Property(p => p.CreationDate);
            builder.Property(p => p.AgentLogin).IsRequired(false);

            builder.HasMany(p => p.Versions)
                .WithOne(v => v.Policy)
                .HasForeignKey("PolicyId")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
