using System;
using System.Collections.Generic;
using MDM.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MDM.Models
{
    public partial class TrustAccountInvoiceFiles : BaseModel
    {
        public int Id { get; set; }
       public int TrustAccountId { get; set; }
        public int? FileTypeId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string Notes { get; set; }
        public virtual FileType FileType { get; set; }
        public virtual TrustAccount TrustAccount { get; set; }
    }

public partial class TrustAccountInvoiceFilesConfiguration : IEntityTypeConfiguration<TrustAccountInvoiceFiles>
{
    public void Configure(EntityTypeBuilder<TrustAccountInvoiceFiles> builder)
    {
         builder.ToTable("TrustAccountInvoiceFiles");

                builder.Property(e => e.CreatedOn).HasColumnType("datetime");
                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");
            
                builder.HasOne(d => d.TrustAccount)
                    .WithMany(p => p.TrustAccountInvoiceFiles)
                    .HasForeignKey(d => d.TrustAccountId)
                    .HasConstraintName("FK_TrustAccountInvoiceFiles_TrustAccount");

            builder.HasOne(d => d.FileType)
                  .WithMany(p => p.TrustAccountInvoiceFiles)
                  .HasForeignKey(d => d.FileTypeId)
                  .HasConstraintName("FK_TrustAccountInvoiceFiles_FileType");

        }

}

}
