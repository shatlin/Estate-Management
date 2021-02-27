﻿using System;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace MDM.Models
{
    public partial class DB : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public DB()
        {
        }

        public DB(DbContextOptions<DB> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<AddressType> AddressType { get; set; }
        public virtual DbSet<UserType> UserType { get; set; }
        public virtual DbSet<ContactUsRelatedTo> ContactUsRelatedTo { get; set; }
        public virtual DbSet<ContactUs> ContactUs { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Currency> Currency { get; set; }
        public virtual DbSet<FileType> FileType { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<RelatedTo> RelatedTo { get; set; }
        public virtual DbSet<Province> Province { get; set; }
        public virtual DbSet<Title> Title { get; set; }
        public virtual DbSet<UserActivity> UserActivity { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<Ethnicity> Ethnicity { get; set; }
        public virtual DbSet<Occupation> Occupation { get; set; }
        public virtual DbSet<SystemUser> SystemUser { get; set; }

        public virtual DbSet<Portfolio> Portfolio { get; set; }
        public virtual DbSet<Block> Block { get; set; }
        public virtual DbSet<Board> Board { get; set; }
        public virtual DbSet<Floor> Floor { get; set; }
        public virtual DbSet<Floor> Group { get; set; }
        public virtual DbSet<Priority> Priority { get; set; }
        public virtual DbSet<ServiceProvider> ServiceProvider { get; set; }
        public virtual DbSet<ServiceProviderTrusteeApproval> ServiceProviderTrusteeApproval { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<TaskItem> TaskItem { get; set; }
        public virtual DbSet<TaskItemAssignee> TaskItemAssignee { get; set; }
        public virtual DbSet<TaskItemFile> TaskItemFile { get; set; }
        public virtual DbSet<Unit> Unit{ get; set; }
        public virtual DbSet<TaskItemType> TaskItemType { get; set; }
        public virtual DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<ApplicationUser>(entity => entity.Property(m => m.Id).HasMaxLength(50));
            modelBuilder.Entity<ApplicationUser>(entity => entity.Property(m => m.NormalizedEmail).HasMaxLength(50));
            modelBuilder.Entity<ApplicationUser>(entity => entity.Property(m => m.NormalizedUserName).HasMaxLength(50));
            modelBuilder.Entity<ApplicationRole>(entity => entity.Property(m => m.Id).HasMaxLength(50));
            modelBuilder.Entity<ApplicationRole>(entity => entity.Property(m => m.NormalizedName).HasMaxLength(50));
            modelBuilder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(50));
            modelBuilder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.ProviderKey).HasMaxLength(50));
            modelBuilder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(50));
            modelBuilder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(50));
            modelBuilder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.RoleId).HasMaxLength(50));
            modelBuilder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(50));
            modelBuilder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(50));
            modelBuilder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.Name).HasMaxLength(50));
            modelBuilder.Entity<IdentityUserClaim<string>>(entity => entity.Property(m => m.Id).HasMaxLength(50));
            modelBuilder.Entity<IdentityUserClaim<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(50));
            modelBuilder.Entity<IdentityRoleClaim<string>>(entity => entity.Property(m => m.Id).HasMaxLength(50));
            modelBuilder.Entity<IdentityRoleClaim<string>>(entity => entity.Property(m => m.RoleId).HasMaxLength(50));

            modelBuilder.ApplyConfiguration(new AddressConfiguration()).SeedAddress();
            modelBuilder.ApplyConfiguration(new AddressTypeConfiguration()).SeedAddressType();
            modelBuilder.ApplyConfiguration(new UserTypeConfiguration()).SeedUserType();
            modelBuilder.ApplyConfiguration(new ContactUsConfiguration()).SeedContactUs();
            modelBuilder.ApplyConfiguration(new ContactUsRelatedToConfiguration()).SeedContactUsRelatedTo();
            modelBuilder.ApplyConfiguration(new CountryConfiguration()).SeedCountry();
            modelBuilder.ApplyConfiguration(new CurrencyConfiguration()).SeedCurrency();
            modelBuilder.ApplyConfiguration(new FileTypeConfiguration()).SeedFileType();
            modelBuilder.ApplyConfiguration(new GenderConfiguration()).SeedGender();
            modelBuilder.ApplyConfiguration(new RelatedToConfiguration()).SeedRelatedTo();
            modelBuilder.ApplyConfiguration(new ProvinceConfiguration()).SeedProvince();
            modelBuilder.ApplyConfiguration(new TitleConfiguration()).SeedTitle();
            modelBuilder.ApplyConfiguration(new UserActivityConfiguration()).SeedUserActivity();
            modelBuilder.ApplyConfiguration(new LanguageConfiguration()).SeedLanguage();
            modelBuilder.ApplyConfiguration(new EthnicityConfiguration()).SeedEthnicity();
            modelBuilder.ApplyConfiguration(new OccupationConfiguration()).SeedOccupation();
            modelBuilder.ApplyConfiguration(new SystemUserConfiguration());

            modelBuilder.ApplyConfiguration(new PortfolioConfiguration()).SeedPortfolio();
            modelBuilder.ApplyConfiguration(new BlockConfiguration()).SeedBlock();
            modelBuilder.ApplyConfiguration(new FloorConfiguration()).SeedFloor();
            modelBuilder.ApplyConfiguration(new GroupConfiguration()).SeedGroup();
            modelBuilder.ApplyConfiguration(new StatusConfiguration()).SeedStatus();
            modelBuilder.ApplyConfiguration(new UnitConfiguration()).SeedUnit();
            modelBuilder.ApplyConfiguration(new BoardConfiguration()).SeedBoard();
            modelBuilder.ApplyConfiguration(new ServiceProviderConfiguration()).SeedServiceProvider();
            modelBuilder.ApplyConfiguration(new ServiceProviderTrusteeApprovalConfiguration()).SeedServiceProviderTrusteeApproval();

            modelBuilder.ApplyConfiguration(new TaskItemConfiguration()).SeedTaskItem();
            modelBuilder.ApplyConfiguration(new TaskItemAssigneeConfiguration());
            modelBuilder.ApplyConfiguration(new TaskItemFileConfiguration());
            modelBuilder.ApplyConfiguration(new TaskItemCommentConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration()).SeedCategory();
            modelBuilder.ApplyConfiguration(new TaskItemTypeConfiguration()).SeedTaskItemType();
            modelBuilder.ApplyConfiguration(new PriorityConfiguration()).SeedPriority();
            
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL(new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["MDMDBContext"]);
                base.OnConfiguring(optionsBuilder);
            }
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override async Task<int> SaveChangesAsync(
           bool acceptAllChangesOnSuccess,
           CancellationToken cancellationToken = default(CancellationToken)
        )
        {
            OnBeforeSaving();
            return (await base.SaveChangesAsync(acceptAllChangesOnSuccess,
                          cancellationToken));
        }

        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            var utcNow = DateTime.UtcNow;

            foreach (var entry in entries)
            {
                // for entities that inherit from BaseEntity,
                // set UpdatedOn / CreatedOn appropriately
                if (entry.Entity is BaseModel trackable)
                {
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            // set the updated date to "now"
                            trackable.ModifiedOn = utcNow;

                            // mark property as "don't touch"
                            // we don't want to update on a Modify operation
                            entry.Property("CreatedOn").IsModified = false;
                            break;

                        case EntityState.Added:
                            // set both updated and created date to "now"
                            trackable.CreatedOn = utcNow;
                            trackable.ModifiedOn = utcNow;
                            break;
                    }
                }
            }
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }


}


