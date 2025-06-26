using Microservices.Demo.Products.Service.Domain.Products.Entities;
using Microservices.Demo.Products.Service.Infrastructure.Persistence.EF.SqlServer.Contexts.Configurations;
using Microsoft.EntityFrameworkCore;
using Entities=Microservices.Demo.Products.Service.Domain.Products.Entities;

namespace Microservices.Demo.Products.Service.Infrastructure.Persistence.EF.SqlServer.Contexts
{
    public partial class ProductsDbContext: DbContext
    {
        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Cover> Covers { get; set; }
        public DbSet<Choice> Choices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CoverConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionConfiguration());
            modelBuilder.ApplyConfiguration(new ChoiceQuestionConfiguration());
            modelBuilder.ApplyConfiguration(new ChoiceConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
