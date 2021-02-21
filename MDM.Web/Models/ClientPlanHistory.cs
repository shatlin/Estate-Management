using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class ClientPlanHistory
    {
        public int Id { get; set; }
        public int BillingUserId { get; set; }
        public int PlanDetailId { get; set; }
        public bool IsCurrentPlan { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Notes { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ClientUser BillingUser { get; set; }
    }
    public partial class ClientPlanHistoryConfiguration : IEntityTypeConfiguration<ClientPlanHistory>
    {
        public void Configure(EntityTypeBuilder<ClientPlanHistory> builder)
        {
            builder.Property(e => e.CreatedOn).HasColumnType("datetime");

            builder.Property(e => e.EndDate).HasColumnType("datetime");

            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

            builder.Property(e => e.Notes).HasMaxLength(1000);

            builder.Property(e => e.StartDate).HasColumnType("datetime");

            builder.HasOne(d => d.BillingUser)
                .WithMany(p => p.ClientPlanHistory)
                .HasForeignKey(d => d.BillingUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClientPlanHistory_User");
        }

    }
    public static partial class Seeder
    {
        public static void SeedClientPlanHistory(this ModelBuilder modelBuilder)
        {

        }
    }
}
