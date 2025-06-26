using Microservices.Demo.Policies.Service.Domain.Policies.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Microservices.Demo.Policies.Service.Infrastructure.Persistence.EF.MySQL.Policies.Contexts.Configurations
{
    public class PolicyVersionConfiguration : IEntityTypeConfiguration<PolicyVersion>
    {
        public void Configure(EntityTypeBuilder<PolicyVersion> builder)
        {
            builder.ToTable("PolicyVersions");

            builder.HasKey(v => v.Id);
            builder.Property(v => v.Id).HasColumnName("PolicyVersionId");

            builder.Property(v => v.VersionNumber);
            builder.Property(v => v.TotalPremiumAmount).HasColumnType("decimal(18,2)");

            // ValidityPeriod (Value Object)
            builder.OwnsOne(v => v.CoverPeriod, vp =>
            {
                vp.Property(x => x.ValidFrom).HasColumnName("CoverFrom");
                vp.Property(x => x.ValidTo).HasColumnName("CoverTo");
            });
            builder.OwnsOne(v => v.VersionValidityPeriod, vp =>
            {
                vp.Property(x => x.ValidFrom).HasColumnName("VersionFrom");
                vp.Property(x => x.ValidTo).HasColumnName("VersionTo");
            });


            builder.OwnsOne(pv => pv.PolicyHolder, ph =>
            {
                ph.Property(x => x.FirstName).HasColumnName("HolderFirstName").IsRequired(false);
                ph.Property(x => x.LastName).HasColumnName("HolderLastName").IsRequired(false);
                ph.Property(x => x.Pesel).HasColumnName("HolderTaxId").IsRequired(false);
                ph.OwnsOne(x => x.Address, addr =>
                {
                    addr.Property(a => a.Country).HasColumnName("HolderCountry").IsRequired(false);
                    addr.Property(a => a.ZipCode).HasColumnName("HolderZipCode").IsRequired(false);
                    addr.Property(a => a.City).HasColumnName("HolderCity").IsRequired(false);
                    addr.Property(a => a.Street).HasColumnName("HolderStreet").IsRequired(false);
                });
            });


            // Covers (PolicyCover is Value Object)
            builder.OwnsMany(pv => pv.Covers, c =>
            {
                c.ToTable("PolicyCovers");
                c.WithOwner().HasForeignKey("PolicyVersionId");                
                c.Property(x => x.Code).HasColumnName("CoverCode").IsRequired(false);
                c.Property(x => x.Premium).HasColumnType("decimal(18,2)");
                c.OwnsOne(x => x.CoverPeriod, cp =>
                {
                    cp.Property(v => v.ValidFrom).HasColumnName("ValidFrom");
                    cp.Property(v => v.ValidTo).HasColumnName("ValidTo");
                });                
                c.HasKey("PolicyVersionId", "Code");
            });
        }
    }
}
