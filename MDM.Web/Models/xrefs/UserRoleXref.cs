using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class UserRoleXref
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual Role Role { get; set; }
        public virtual ClientUser User { get; set; }
    }
    public partial class UserRoleXrefConfiguration : IEntityTypeConfiguration<UserRoleXref>
    {
        public void Configure(EntityTypeBuilder<UserRoleXref> builder)
        {
 builder.ToTable("UserRoleXRef");

                builder.Property(e => e.CreatedOn).HasColumnType("datetime");

                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

                builder.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoleXref)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRole_Role");

                builder.HasOne(d => d.User)
                    .WithMany(p => p.UserRoleXref)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRole_User");
        }

    }
    public static partial class Seeder
    {
        public static void SeedUserRoleXref(this ModelBuilder modelBuilder)
        {

        }
    }
}
