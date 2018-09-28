using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace IncorrectSyntaxNearTheKeywordAS.Models.Maps
{
    public static class TelemCallMap
    {
        public static EntityTypeBuilder<TelemCall> Map(
            this EntityTypeBuilder<TelemCall> cfg)
        {
            cfg.ToTable("telem_Calls");

            // Primary Key
            cfg.HasKey(call => call.Id);

            cfg.Property(call => call.Id)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasColumnName("Id");

            // Field Mappings
            cfg.Property(call => call.CallStackId)
                .IsRequired()
                .HasColumnName("CallStackId");

            return cfg;
        }
    }
}
