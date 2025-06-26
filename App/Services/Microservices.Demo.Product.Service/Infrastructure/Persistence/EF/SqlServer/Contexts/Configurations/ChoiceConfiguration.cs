using Microservices.Demo.Products.Service.Domain.Products.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Microservices.Demo.Products.Service.Infrastructure.Persistence.EF.SqlServer.Contexts.Configurations
{
    public class ChoiceConfiguration : IEntityTypeConfiguration<Choice>
    {
        public void Configure(EntityTypeBuilder<Choice> builder)
        {
            builder.ToTable("Choice");
            builder.HasKey(x => x.Code);
            builder.Property(x => x.Label).IsRequired().HasMaxLength(100);
            builder.HasOne(q => q.Question)
                .WithMany(c => c.Choices)
                .HasForeignKey("ChoiceQuestionId");
        }
    }
}
