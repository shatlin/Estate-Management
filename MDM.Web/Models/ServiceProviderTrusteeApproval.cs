using System;
using System.Collections.Generic;
using MDM.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MDM.Models
{
    public partial class ServiceProviderTrusteeApproval : BaseModel
    {
        public int Id { get; set; }
        public int? ServiceProviderId { get; set; }
        public int? SystemUserId { get; set; }
        public bool isApproved { get; set; }
        public DateTime? DecisionDate { get; set; }
      

        public virtual ServiceProvider ServiceProvider { get; set; }
        public virtual SystemUser SystemUser { get; set; }
    }

public partial class ServiceProviderTrusteeApprovalConfiguration : IEntityTypeConfiguration<ServiceProviderTrusteeApproval>
{
    public void Configure(EntityTypeBuilder<ServiceProviderTrusteeApproval> builder)
    {
         builder.ToTable("ServiceProviderTrusteeApproval");

                builder.Property(e => e.CreatedOn).HasColumnType("datetime");
                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");
             builder.Property(e => e.DecisionDate).HasColumnType("datetime");
           
            builder.HasOne(d => d.ServiceProvider)
                    .WithMany(p => p.ServiceProviderTrusteeApproval)
                    .HasForeignKey(d => d.ServiceProviderId)
                    .HasConstraintName("FK_ServiceProviderTrusteeApproval_ServiceProvider");

                builder.HasOne(d => d.SystemUser)
                    .WithMany(p => p.ServiceProviderTrusteeApproval)
                    .HasForeignKey(d => d.SystemUserId)
                    .HasConstraintName("FK_ServiceProviderTrusteeApproval_SystemUser");

    }

}
public static partial class Seeder
{
        public static void SeedServiceProviderTrusteeApproval(this ModelBuilder modelBuilder)
        {

        }
    }
}
