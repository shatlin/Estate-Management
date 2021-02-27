﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace MDM.Models
{
    public partial class ContactUs : BaseModel
    {
        public ContactUs()
        {
        }

        public int Id { get; set; }
        public int? ContactUsRelatedToId { get; set; }
        public int? ActionedByUserId { get; set; }
        public string ClientEmail { get; set; }
        public string ClientName { get; set; }
        public string PhoneNumber { get; set; }
        public string ClientQuery { get; set; }
        public string Response { get; set; }
        public bool isResolved { get; set; }
       

        public virtual ContactUsRelatedTo ContactUsRelatedTo { get; set; }
       
    }

    public partial class ContactUsConfiguration : IEntityTypeConfiguration<ContactUs>
    {
        public void Configure(EntityTypeBuilder<ContactUs> builder)
        {
            builder.Property(e => e.CreatedOn).HasColumnType("datetime");
            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");
            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

            builder.Property(e => e.ContactUsRelatedToId)
                    .IsRequired(false);
            builder.Property(e => e.ActionedByUserId)
               .IsRequired(false);

            builder.Property(e => e.ClientEmail)
                    .IsRequired()
                    .HasMaxLength(50);
            builder.Property(e => e.ClientName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(e => e.ClientQuery)
                  .IsRequired()
                  .HasMaxLength(1500);
            builder.Property(e => e.Response)
            .IsRequired(false)
            .HasMaxLength(1500);

            builder.HasOne(d => d.ContactUsRelatedTo)
             .WithMany(p => p.ContactUs)
             .HasForeignKey(d => d.ContactUsRelatedToId)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("FK_ContactUs_ContactUsRelatedTo");

         
        }
    }

    public static partial class Seeder
    {
        public static void SeedContactUs(this ModelBuilder modelBuilder)
        {

        }
    }
}