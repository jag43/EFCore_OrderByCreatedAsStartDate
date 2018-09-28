using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IncorrectSyntaxNearTheKeywordAS.Models.Maps
{
    public static class TeamMap
    {
        public static EntityTypeBuilder<Team> Map(
            this EntityTypeBuilder<Team> cfg)
        {
            cfg.ToTable("inboxid_Teams");

            // Primary Key
            cfg.HasKey(team => team.Id);

            cfg.Property(team => team.Id)
                .IsRequired()
                .HasColumnName("Id");

            // Field Mappings
            cfg.Property(team => team.ManagerId)
                .HasColumnName("ManagerId");

            cfg.Property(team => team.OrganisationId)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("OrganisationId");

            cfg.Property(team => team.Reference)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Reference");

            cfg.Property(team => team.Notes)
                .HasColumnName("Notes");

            cfg.Property(team => team.Timestamp)
                .IsRequired()
                .IsRowVersion()
                .HasColumnName("Timestamp");

            return cfg;
        }
    }
}
