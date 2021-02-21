using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class EmailTemplateName
    {
        public EmailTemplateName()
        {
            EmailTemplateContent = new HashSet<EmailTemplateContent>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<EmailTemplateContent> EmailTemplateContent { get; set; }
    }

    public partial class EmailTemplateNameConfiguration : IEntityTypeConfiguration<EmailTemplateName>
    {
        public void Configure(EntityTypeBuilder<EmailTemplateName> builder)
        {
 builder.Property(e => e.Id).HasColumnName("id");

                builder.Property(e => e.CreatedOn).HasColumnType("datetime");

                builder.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50);

                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

                builder.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
        }

    }
    public static partial class Seeder
    {
        public static void SeedEmailTemplateName(this ModelBuilder modelBuilder)
        {

        }
    }
}
