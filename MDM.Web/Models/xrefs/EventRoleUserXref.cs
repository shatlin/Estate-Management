using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class EventRoleUserXref
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int EventRoleId { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual EventRole EventRole { get; set; }
        public virtual ClientUser User { get; set; }
    }
    public partial class EventRoleUserXrefConfiguration : IEntityTypeConfiguration<EventRoleUserXref>
    {
        public void Configure(EntityTypeBuilder<EventRoleUserXref> builder)
        {
builder.ToTable("EventRoleUserXRef");

                builder.Property(e => e.CreatedOn).HasColumnType("datetime");

                builder.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(1000);

                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

                builder.HasOne(d => d.EventRole)
                    .WithMany(p => p.EventRoleUserXref)
                    .HasForeignKey(d => d.EventRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventRoleUserXRef_EventRole");

                builder.HasOne(d => d.User)
                    .WithMany(p => p.EventRoleUserXref)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventRoleUserXRef_User");
        }

    }
    public static partial class Seeder
    {
        public static void SeedEventRoleUserXref(this ModelBuilder modelBuilder)
        {

        }
    }
}

