using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class MemberLoginAudit
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int LoginTime { get; set; }
        public DateTime? LogoutTime { get; set; }
    }

    public partial class MemberLoginAuditConfiguration : IEntityTypeConfiguration<MemberLoginAudit>
    {
        public void Configure(EntityTypeBuilder<MemberLoginAudit> builder)
        {
builder.Property(e => e.LogoutTime).HasColumnType("datetime");
        }

    }
    public static partial class Seeder
    {
        public static void SeedMemberLoginAudit(this ModelBuilder modelBuilder)
        {

        }
    }
}
