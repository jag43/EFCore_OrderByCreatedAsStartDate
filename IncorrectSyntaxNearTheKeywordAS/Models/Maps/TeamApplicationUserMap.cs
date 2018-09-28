using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IncorrectSyntaxNearTheKeywordAS.Models.Maps
{
    public static class TeamApplicationUserMap
    {
        public static EntityTypeBuilder<TeamApplicationUser> Map(
           this EntityTypeBuilder<TeamApplicationUser> cfg)
        {
            cfg.ToTable("inboxid_TeamApplicationUsers");

            // Primary Key
            cfg.HasKey(team => new { team.TeamId, team.UserId });

            cfg.Property(team => team.TeamId)
                .IsRequired()
                .HasColumnName("Team_Id");

            cfg.Property(team => team.UserId)
                .IsRequired()
                .HasColumnName("User_Id");

            return cfg;
        }
    }
}
