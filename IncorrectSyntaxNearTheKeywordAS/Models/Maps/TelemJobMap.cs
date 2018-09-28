using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace IncorrectSyntaxNearTheKeywordAS.Models.Maps
{
    public static class TelemJobMap
    {
        public static EntityTypeBuilder<TelemJob> Map(
            this EntityTypeBuilder<TelemJob> cfg)
        {
            cfg.ToTable("telem_Jobs");

            // Primary Key
            cfg.HasKey(job => job.Id);

            cfg.Property(job => job.Id)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasColumnName("Id");
            
            // Field Mappings
            
            return cfg;
        }
    }
}
