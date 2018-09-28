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

            cfg.Property(supplier => supplier.Created)
                .IsRequired()
                .HasColumnName("Created");

            return cfg;
        }
    }
}
