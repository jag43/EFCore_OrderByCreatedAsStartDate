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

            return cfg;
        }
    }
}
