using Microservices.Demo.Products.Service.Domain.Products.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Microservices.Demo.Products.Service.Infrastructure.Persistence.EF.SqlServer.Contexts.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("Questions");

            builder.HasKey(q => q.Id);
            builder.Property(q => q.Id).HasColumnName("QuestionId");

            builder.Property(q => q.Code).IsRequired().HasMaxLength(50);
            builder.Property(q => q.Index).IsRequired();
            builder.Property(q => q.Text).IsRequired().HasMaxLength(300);
                        
            builder.HasDiscriminator<int>("QuestionType")
                   .HasValue<Question>(0)
                   .HasValue<NumericQuestion>(1)
                   .HasValue<DateQuestion>(2)
                   .HasValue<ChoiceQuestion>(3);

            builder.HasOne(q => q.Product)
                   .WithMany(p => p.Questions)
                   .HasForeignKey("ProductId");
        }
    }
}
