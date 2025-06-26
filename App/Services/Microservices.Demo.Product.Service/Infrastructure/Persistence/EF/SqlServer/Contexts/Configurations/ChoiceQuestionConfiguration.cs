using Microservices.Demo.Products.Service.Domain.Products.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Microservices.Demo.Products.Service.Infrastructure.Persistence.EF.SqlServer.Contexts.Configurations
{
    public class ChoiceQuestionConfiguration : IEntityTypeConfiguration<ChoiceQuestion>
    {
        public void Configure(EntityTypeBuilder<ChoiceQuestion> builder)
        {
            builder.HasBaseType<Question>();
            builder.HasMany(q => q.Choices)
                   .WithOne(c => c.Question)
                   .HasForeignKey("ChoiceQuestionId")
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
