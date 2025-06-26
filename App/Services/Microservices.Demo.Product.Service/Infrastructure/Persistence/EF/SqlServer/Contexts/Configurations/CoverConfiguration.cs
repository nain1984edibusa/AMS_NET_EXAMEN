using Microservices.Demo.Products.Service.Domain.Products.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Microservices.Demo.Products.Service.Infrastructure.Persistence.EF.SqlServer.Contexts.Configurations
{
    public class CoverConfiguration : IEntityTypeConfiguration<Cover>
    {
        public void Configure(EntityTypeBuilder<Cover> builder)
        {
            builder.ToTable("Covers");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("CoverId");
            builder.Property(c => c.Code).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(200);
            builder.Property(c => c.Description).HasMaxLength(500);
            builder.Property(c => c.Optional).IsRequired();
            builder.Property(c => c.SumInsured);
        }
    }
}
