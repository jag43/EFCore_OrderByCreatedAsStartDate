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

            cfg.Property(call => call.OperatorId)
                .IsRequired()
                .HasColumnName("OperatorId");
            
            cfg.Property(call => call.AcceptDisclaimer)
                .IsRequired()
                .HasColumnName("AcceptDisclaimer");

            cfg.Property(call => call.CallAttempts)
                .IsRequired()
                .HasColumnName("CallAttempts");

            cfg.Property(call => call.CallbackTime)
                .HasColumnName("CallbackTime");

            cfg.Property(call => call.CallEnd)
                .HasColumnName("CallEnd");

            cfg.Property(call => call.CallStart)
                .IsRequired()
                .HasColumnName("CallStart");

            cfg.Property(call => call.CallDurationSeconds)
                .HasComputedColumnSql("datediff(second,[CallStart],[CallEnd])")
                .HasColumnName("CallDurationSeconds");

            cfg.Property(call => call.Notes)
                .HasColumnName("Notes");

            cfg.Property(call => call.ScriptDelivered)
                .IsRequired()
                .HasColumnName("ScriptDelivered");

            cfg.Property(call => call.Status)
                .IsRequired()
                .HasColumnName("Status");

            cfg.Property(call => call.SubscriberComments)
                .HasColumnName("SubscriberComments");

            cfg.Property(call => call.Timestamp)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .IsRowVersion()
                .HasColumnName("Timestamp");

            return cfg;
        }
    }
}
