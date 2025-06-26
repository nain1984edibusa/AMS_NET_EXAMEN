using Microservices.Demo.Policies.Service.Domain.Policies.Entities;
using Microservices.Demo.Policies.Service.Infrastructure.Persistence.EF.MySQL.Policies.Contexts.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Microservices.Demo.Policies.Service.Infrastructure.Persistence.EF.MySQL.Policies.Contexts
{
    public partial class PoliciesDbContext : DbContext
    {
        public PoliciesDbContext(DbContextOptions<PoliciesDbContext> options) : base(options) { }

        public DbSet<Policy> Policies { get; set; }
        public DbSet<PolicyVersion> PolicyVersions { get; set; }
        public DbSet<Offer> Offers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PolicyConfiguration());
            modelBuilder.ApplyConfiguration(new PolicyVersionConfiguration());
            modelBuilder.ApplyConfiguration(new OfferConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
