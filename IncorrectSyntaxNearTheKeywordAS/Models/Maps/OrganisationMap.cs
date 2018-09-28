using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace IncorrectSyntaxNearTheKeywordAS.Models.Maps
{
    public static class OrganisationMap
    {
        public static EntityTypeBuilder<Organisation> Map(
           this EntityTypeBuilder<Organisation> cfg)
        {
            cfg.ToTable("inboxid_Organisations");

            // Primary Key
            cfg.HasKey(org => org.Id);

            cfg.Property(org => org.Id)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("Id");

            // Field Mappings
            cfg.Property(org => org.Description)
                .HasColumnName("Description");

            cfg.Property(org => org.Name)
                .IsRequired()
                .HasMaxLength(128)
                .HasColumnName("Name");

            cfg.Property(org => org.WebsiteUrl)
                .HasMaxLength(1024)
                .HasColumnName("WebsiteUrl");

            cfg.Property(org => org.RowVersion)
                .IsRequired()
                .IsRowVersion()
                .HasColumnName("RowVersion");

            return cfg;
        }
    }
}
