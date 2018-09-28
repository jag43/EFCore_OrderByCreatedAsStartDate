using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IncorrectSyntaxNearTheKeywordAS.Models.Maps
{
    public static class ApplicationUserMap
    {
        public static EntityTypeBuilder<ApplicationUser> Map(
            this EntityTypeBuilder<ApplicationUser> cfg)
        {
            cfg.ToTable("inboxid_Users");

            // Primary Key
            cfg.HasKey(map => map.Id);

            cfg.Property(map => map.Id)
                .IsRequired()
                .HasColumnName("Id");

            // Field Mappings
            cfg.Property(map => map.OrganisationId)
                .HasMaxLength(10)
                .HasColumnName("OrganisationId");

            cfg.Property(map => map.UserName)
                .IsRequired()
                .HasMaxLength(256)
                .HasColumnName("UserName");

            return cfg;
        }
    }
}
