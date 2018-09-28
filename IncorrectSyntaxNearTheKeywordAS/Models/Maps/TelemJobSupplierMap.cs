using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IncorrectSyntaxNearTheKeywordAS.Models.Maps
{
    public static class TelemJobSupplierMap
    {
        public static EntityTypeBuilder<TelemJobSupplier> Map(
            this EntityTypeBuilder<TelemJobSupplier> cfg)
        {
            cfg.ToTable("telem_JobSuppliers");

            // Primary Key
            cfg.HasKey(supplier => supplier.Id);

            cfg.Property(supplier => supplier.Id)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasColumnName("Id");


            // Field Mappings
            cfg.Property(supplier => supplier.JobId)
                .IsRequired()
                .HasColumnName("JobId");

            cfg.Property(supplier => supplier.RecordsRequired)
                .IsRequired()
                .HasColumnName("RecordsRequired");

            cfg.Property(supplier => supplier.JobFrozen)
                .IsRequired()
                .HasColumnName("JobFrozen");

            cfg.Property(supplier => supplier.Notes)
                .HasColumnName("Notes");

            cfg.Property(supplier => supplier.Created)
                .IsRequired()
                .HasColumnName("Created");

            cfg.Property(supplier => supplier.Timestamp)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .IsRowVersion()
                .HasColumnName("Timestamp");

            return cfg;
        }
    }
}
