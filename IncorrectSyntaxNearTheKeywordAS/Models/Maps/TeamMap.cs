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

            cfg.Property(team => team.OrganisationId)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("OrganisationId");

            return cfg;
        }
    }
}
