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

            cfg.Property(map => map.AccessFailedCount)
                .IsRequired()
                .HasColumnName("AccessFailedCount");

            cfg.Property(map => map.ConcurrencyStamp)
                .HasColumnName("ConcurrencyStamp");

            cfg.Property(map => map.Disabled)
                .IsRequired()
                .HasColumnName("Disabled");

            cfg.Property(map => map.Email)
                .IsRequired()
                .HasMaxLength(256)
                .HasColumnName("Email");

            cfg.Property(map => map.EmailConfirmed)
                .IsRequired()
                .HasColumnName("EmailConfirmed");

            cfg.Property(map => map.FirstName)
                .HasMaxLength(256)
                .HasColumnName("FirstName");

            cfg.Property(map => map.LastName)
                .HasMaxLength(256)
                .HasColumnName("LastName");

            cfg.Property(map => map.LockoutEnabled)
                .IsRequired()
                .HasColumnName("LockoutEnabled");

            cfg.Property(map => map.LockoutEnd)
                .HasColumnName("LockoutEnd");

            cfg.Property(map => map.NormalizedEmail)
                .HasMaxLength(256)
                .HasColumnName("NormalizedEmail");

            cfg.Property(map => map.NormalizedUserName)
                .HasMaxLength(256)
                .HasColumnName("NormalizedUserName");

            cfg.Property(map => map.Password)
                .HasColumnName("Password");

            cfg.Property(map => map.PhoneNumber)
                .HasColumnName("PhoneNumber");

            cfg.Property(map => map.PhoneNumberConfirmed)
                .IsRequired()
                .HasColumnName("PhoneNumberConfirmed");
            
            cfg.Property(map => map.TwoFactorEnabled)
                .IsRequired()
                .HasColumnName("TwoFactorEnabled");

            cfg.Property(map => map.UserName)
                .IsRequired()
                .HasMaxLength(256)
                .HasColumnName("UserName");

            cfg.Property(map => map.Created)
                .IsRequired()
                .HasColumnName("Created");

            return cfg;
        }
    }
}
