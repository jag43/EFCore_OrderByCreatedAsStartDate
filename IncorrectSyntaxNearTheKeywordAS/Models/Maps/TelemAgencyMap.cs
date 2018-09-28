using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IncorrectSyntaxNearTheKeywordAS.Models.Maps
{
    public static class TelemAgencyMap
    {
        public static EntityTypeBuilder<TelemAgency> Map(
            this EntityTypeBuilder<TelemAgency> cfg)
        {
            cfg.ToTable("inbox_TeleMarketingSuppliers");

            // Primary Key
            cfg.HasKey(tms => tms.Id);

            cfg.Property(tms => tms.Id)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasColumnName("TeleMarketingSupplierId");


            // Field Mappings
            cfg.Property(tms => tms.OrganisationId)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("OrganisationId");

            cfg.Property(tms => tms.Archived)
                .IsRequired()
                .HasColumnName("Archived");

            cfg.Property(tms => tms.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Name");

            cfg.Property(tms => tms.Timestamp)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .IsRowVersion()
                .HasColumnName("Timestamp");

            return cfg;
        }
    }
}
