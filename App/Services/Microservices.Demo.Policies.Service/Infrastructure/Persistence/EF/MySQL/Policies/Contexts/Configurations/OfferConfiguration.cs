using Microservices.Demo.Policies.Service.Domain.Policies.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Microservices.Demo.Policies.Service.Infrastructure.Persistence.EF.MySQL.Policies.Contexts.Configurations
{
    public class OfferConfiguration : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.ToTable("Offers");

            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).HasColumnName("OfferId");

            builder.Property(o => o.Number).IsRequired();
            builder.Property(o => o.ProductCode).IsRequired();
            builder.Property(o => o.TotalPrice).IsRequired().HasColumnType("decimal(18,2)"); ;
            builder.Property(o => o.Status).HasConversion<string>().IsRequired();
            builder.Property(o => o.CreationDate).IsRequired();
            builder.Property(o => o.AgentLogin);

            builder.OwnsOne(o => o.PolicyValidityPeriod, vvp =>
            {
                vvp.Property(x => x.ValidFrom).HasColumnName("PolicyFrom");
                vvp.Property(x => x.ValidTo).HasColumnName("PolicyTo"); ;
            });

            // PolicyHolder (Value Object)
            builder.OwnsOne(o => o.OfferHolder, ph =>
            {
                ph.Property(x => x.FirstName).HasColumnName("HolderFirstName");
                ph.Property(x => x.LastName).HasColumnName("HolderLastName");
                ph.Property(x => x.Pesel).HasColumnName("HolderPesel");
            });

            // Covers
            builder.OwnsMany(o => o.Covers, c =>
            {
                c.ToTable("OfferCovers");
                c.WithOwner().HasForeignKey("OfferId");
                c.Property(x => x.Code).HasColumnName("CoverCode").IsRequired();
                c.Property(x => x.Price).HasColumnType("decimal(18,2)");
                c.HasKey("OfferId", "Code");
            });
        }
    }
}
