﻿using System;
using System.Collections.Generic;
using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccessObjects;

public partial class OilPaintingArt2024DbContext : DbContext
{
    public OilPaintingArt2024DbContext()
    {
    }

    public OilPaintingArt2024DbContext(DbContextOptions<OilPaintingArt2024DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<OilPaintingArt> OilPaintingArts { get; set; }

    public virtual DbSet<SupplierCompany> SupplierCompanies { get; set; }

    public virtual DbSet<SystemAccount> SystemAccounts { get; set; }
    public static string GetConnectionString(string connectionStringName)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        string connectionString = config.GetConnectionString(connectionStringName);
        return connectionString;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(GetConnectionString("DefaultConnectionStringDB")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer("Server=LAPTOP-AGJF065R\\NGUYEN; Database=OilPaintingArt2024DB; Uid=sa; Pwd=123456");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OilPaintingArt>(entity =>
        {
            entity.HasKey(e => e.OilPaintingArtId).HasName("PK__OilPaint__708184D894233536");

            entity.ToTable("OilPaintingArt");

            entity.Property(e => e.OilPaintingArtId).ValueGeneratedNever();
            entity.Property(e => e.ArtTitle).HasMaxLength(100);
            entity.Property(e => e.Artist).HasMaxLength(80);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.NotablFeatures).HasMaxLength(250);
            entity.Property(e => e.OilPaintingArtLocation).HasMaxLength(240);
            entity.Property(e => e.OilPaintingArtStyle).HasMaxLength(50);
            entity.Property(e => e.PriceOfOilPaintingArt).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.SupplierId).HasMaxLength(30);

            entity.HasOne(d => d.Supplier).WithMany(p => p.OilPaintingArts)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__OilPainti__Suppl__3C69FB99");
        });

        modelBuilder.Entity<SupplierCompany>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("PK__Supplier__4BE666B4595F37D1");

            entity.ToTable("SupplierCompany");

            entity.Property(e => e.SupplierId).HasMaxLength(30);
            entity.Property(e => e.CompanyName).HasMaxLength(100);
            entity.Property(e => e.CompanyTypeDescription).HasMaxLength(250);
        });

        modelBuilder.Entity<SystemAccount>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__SystemAc__349DA586D6FB14DB");

            entity.ToTable("SystemAccount");

            entity.HasIndex(e => e.AccountEmail, "UQ__SystemAc__FC770D33971B6FE0").IsUnique();

            entity.Property(e => e.AccountId)
                .ValueGeneratedNever()
                .HasColumnName("AccountID");
            entity.Property(e => e.AccountEmail).HasMaxLength(80);
            entity.Property(e => e.AccountFullName).HasMaxLength(80);
            entity.Property(e => e.AccountPassword).HasMaxLength(40);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}