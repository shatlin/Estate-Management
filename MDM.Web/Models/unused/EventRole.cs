using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class EventRole
    {
        public EventRole()
        {
            EventRoleUserXref = new HashSet<EventRoleUserXref>();
        }

        public int Id { get; set; }
        public int EventId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual Event Event { get; set; }
        public virtual ICollection<EventRoleUserXref> EventRoleUserXref { get; set; }
    }
public partial class EventRoleConfiguration : IEntityTypeConfiguration<EventRole>
    {
        public void Configure(EntityTypeBuilder<EventRole> builder)
        {
 builder.Property(e => e.CreatedOn).HasColumnType("datetime");

                builder.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

                builder.Property(e => e.Name).HasMaxLength(100);

                builder.HasOne(d => d.Event)
                    .WithMany(p => p.EventRole)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventRole_Event");
        }

    }
    public static partial class Seeder
    {
        public static void SeedEventRole(this ModelBuilder modelBuilder)
        {
           
        }
    }
}
