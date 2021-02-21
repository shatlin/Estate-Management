using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class RolePermissionXref
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int Permissionid { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual Permission Permission { get; set; }
        public virtual Role Role { get; set; }
    }

    public partial class RolePermissionXrefConfiguration : IEntityTypeConfiguration<RolePermissionXref>
    {
        public void Configure(EntityTypeBuilder<RolePermissionXref> builder)
        {
  builder.ToTable("RolePermissionXRef");

                builder.Property(e => e.CreatedOn).HasColumnType("datetime");

                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

                builder.HasOne(d => d.Permission)
                    .WithMany(p => p.RolePermissionXref)
                    .HasForeignKey(d => d.Permissionid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RolePermissionXRef_Permission");

                builder.HasOne(d => d.Role)
                    .WithMany(p => p.RolePermissionXref)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RolePermissionXRef_Role");
        }

    }
    public static partial class Seeder
    {
        public static void SeedRolePermissionXref(this ModelBuilder modelBuilder)
        {

        }
    }
}
