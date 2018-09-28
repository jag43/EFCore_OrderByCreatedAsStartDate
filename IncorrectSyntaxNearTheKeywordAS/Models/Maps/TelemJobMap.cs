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
            cfg.Property(job => job.ClosedById)
                .HasColumnName("ClosedById");

            cfg.Property(job => job.CreatedById)
                .IsRequired()
                .HasColumnName("CreatedById");

            cfg.Property(job => job.Reference)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Reference");

            cfg.Property(job => job.Closed)
                .HasColumnName("Closed");

            cfg.Property(job => job.PrivateNotes)
                .HasColumnName("PrivateNotes");

            cfg.Property(job => job.PublicNotes)
                .HasColumnName("PublicNotes");

            cfg.Property(job => job.RecordsRequired)
                .IsRequired()
                .HasColumnName("RecordsRequired");

            cfg.Property(job => job.Status)
                .IsRequired()
                .HasColumnName("Status");

            cfg.Property(job => job.Created)
                .IsRequired()
                .HasColumnName("Created");

            cfg.Property(job => job.ScheduledEndDate)
                .HasColumnName("ScheduledEndDate");

            cfg.Property(job => job.Timestamp)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .IsRowVersion()
                .HasColumnName("Timestamp");

            return cfg;
        }
    }
}
