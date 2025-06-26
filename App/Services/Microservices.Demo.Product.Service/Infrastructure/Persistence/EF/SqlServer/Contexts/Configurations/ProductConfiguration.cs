using Microservices.Demo.Products.Service.Domain.Products.Entities;
using Microservices.SharedKernel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities=Microservices.Demo.Products.Service.Domain.Products.Entities;

namespace Microservices.Demo.Products.Service.Infrastructure.Persistence.EF.SqlServer.Contexts.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("ProductId");

            builder.Property(p => p.Code).IsRequired().HasMaxLength(50);
            builder.HasIndex(p => p.Code).IsUnique();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(200);
            builder.Property(q => q.Status).HasConversion<string>().IsRequired();
            builder.Property(p => p.Image).HasMaxLength(300);
            builder.Property(p => p.Description).HasMaxLength(500);
            builder.Property(p => p.MaxNumberOfInsured).IsRequired();
            builder.Property(p => p.ProductIcon).HasMaxLength(100);
                        
            builder.HasMany(p => p.Covers)
                   .WithOne()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.Questions)
                   .WithOne(q => q.Product)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
