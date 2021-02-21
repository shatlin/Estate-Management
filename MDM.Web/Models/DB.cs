﻿using System;
using System.Configuration;
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



        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL(new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["MDMDBContext"]);
                base.OnConfiguring(optionsBuilder);
            }
        }


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }


}


