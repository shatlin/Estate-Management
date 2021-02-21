using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MDM.Models
{
    public partial class Board
    {
        public Board()
        {
        }

        public int Id { get; set; }
        public int Year { get; set; }
        public bool isCurrent { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        [Display(Name = "Portfolio")]
        [Required(ErrorMessage = "Portfolio is required")]
        public int? PortfolioId { get; set; }

        [Display(Name = "User")]
        [Required(ErrorMessage = "User is required")]
        public int? SystemUserId { get; set; }


        public virtual Portfolio Portfolio { get; set; }
        public virtual SystemUser SystemUser { get; set; }
    }

    public partial class BoardConfiguration : IEntityTypeConfiguration<Board>
    {
        public void Configure(EntityTypeBuilder<Board> builder)
        {

            builder.Property(e => e.CreatedOn).HasColumnType("datetime");
            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");
            builder.Property(e => e.From).HasColumnType("datetime");
            builder.Property(e => e.To).HasColumnType("datetime");

            builder.Property(e => e.PortfolioId)
            .IsRequired(false);

            builder.Property(e => e.SystemUserId)
              .IsRequired(false);

            builder.HasOne(d => d.Portfolio)
                .WithMany(p => p.Board)
                .HasForeignKey(d => d.PortfolioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Board_Portfolio");

            builder.HasOne(d => d.SystemUser)
                .WithMany(p => p.Board)
                .HasForeignKey(d => d.SystemUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Board_SystemUser");

        }


    }

    public static partial class Seeder
    {
        public static void SeedBoard(this ModelBuilder modelBuilder)
        {
            
        }
    }
}
