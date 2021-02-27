using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MDM.Models
{
    public partial class ServiceProvider : BaseModel
    {
        public ServiceProvider()
        {
            ServiceProviderTrusteeApproval = new HashSet<ServiceProviderTrusteeApproval>();
        }
        public virtual ICollection<ServiceProviderTrusteeApproval> ServiceProviderTrusteeApproval { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool plumbing { get; set; }
        public bool electrician { get; set; }
        public bool dstv { get; set; }
        public bool horticulturist { get; set; }
        public bool buildingrenovation { get; set; }
        public bool painting { get; set; }
        public bool waterproofing { get; set; }
        public bool csddocuments { get; set; }
        public bool taxcertificate { get; set; }
        public bool beecertificate { get; set; }
        public bool accreditation { get; set; }
        public bool coideclaration { get; set; }
        public bool signedselfassesmentform { get; set; }
       
    }

    public partial class ServiceProviderConfiguration : IEntityTypeConfiguration<ServiceProvider>
    {
        public void Configure(EntityTypeBuilder<ServiceProvider> builder)
        {
            builder.Property(e => e.CreatedOn).HasColumnType("datetime");
            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
        }

    }
    public static partial class Seeder
    {
        public static void SeedServiceProvider(this ModelBuilder modelBuilder)
        {
        }
    }
}
