using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace IncorrectSyntaxNearTheKeywordAS.Models.Maps
{
    public static class TelemCallStackMap
    {
        public static EntityTypeBuilder<TelemCallStack> Map(
            this EntityTypeBuilder<TelemCallStack> cfg)
        {
            cfg.ToTable("telem_CallStacks");

            // Primary Key
            cfg.HasKey(stack => stack.Id);

            cfg.Property(stack => stack.Id)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasColumnName("Id");


            // Field Mappings
            cfg.Property(stack => stack.JobSupplierId)
                .IsRequired()
                .HasColumnName("JobSupplierId");

            cfg.Property(stack => stack.Timestamp)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .IsRowVersion()
                .HasColumnName("Timestamp");

            return cfg;
        }
    }
}
