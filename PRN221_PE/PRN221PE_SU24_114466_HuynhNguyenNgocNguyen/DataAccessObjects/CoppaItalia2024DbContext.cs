using System;
using System.Collections.Generic;
using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccessObjects;

public partial class CoppaItalia2024DbContext : DbContext
{
    public CoppaItalia2024DbContext()
    {
    }

    public CoppaItalia2024DbContext(DbContextOptions<CoppaItalia2024DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CoppaItaliaAccount> CoppaItaliaAccounts { get; set; }

    public virtual DbSet<CoppaItaliaClub> CoppaItaliaClubs { get; set; }

    public virtual DbSet<CoppaItaliaPlayer> CoppaItaliaPlayers { get; set; }

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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CoppaItaliaAccount>(entity =>
        {
            entity.HasKey(e => e.AccId).HasName("PK__CoppaIta__91CBC398B7102EBC");

            entity.ToTable("CoppaItaliaAccount");

            entity.HasIndex(e => e.EmailAddress, "UQ__CoppaIta__49A1474052219AAF").IsUnique();

            entity.Property(e => e.AccId)
                .ValueGeneratedNever()
                .HasColumnName("AccID");
            entity.Property(e => e.AccDescription).HasMaxLength(140);
            entity.Property(e => e.AccPassword).HasMaxLength(90);
            entity.Property(e => e.EmailAddress).HasMaxLength(90);
        });

        modelBuilder.Entity<CoppaItaliaClub>(entity =>
        {
            entity.HasKey(e => e.CoppaItaliaClubId).HasName("PK__CoppaIta__1FBF3FA696C3890C");

            entity.ToTable("CoppaItaliaClub");

            entity.Property(e => e.CoppaItaliaClubId)
                .HasMaxLength(20)
                .HasColumnName("CoppaItaliaClubID");
            entity.Property(e => e.ClubName).HasMaxLength(100);
            entity.Property(e => e.CurrentPresident).HasMaxLength(100);
            entity.Property(e => e.FoundedDate).HasColumnType("datetime");
            entity.Property(e => e.Ground).HasMaxLength(120);
            entity.Property(e => e.ShortDescription).HasMaxLength(250);
            entity.Property(e => e.Website).HasMaxLength(250);
        });

        modelBuilder.Entity<CoppaItaliaPlayer>(entity =>
        {
            entity.HasKey(e => e.CoppaItaliaPlayerId).HasName("PK__CoppaIta__4E2E3FF3EF4CCAA3");

            entity.ToTable("CoppaItaliaPlayer");

            entity.Property(e => e.CoppaItaliaPlayerId)
                .HasMaxLength(30)
                .HasColumnName("CoppaItaliaPlayerID");
            entity.Property(e => e.Birthday).HasColumnType("datetime");
            entity.Property(e => e.CoppaItaliaClubId)
                .HasMaxLength(20)
                .HasColumnName("CoppaItaliaClubID");
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.InternationalCareer).HasMaxLength(400);
            entity.Property(e => e.Position).HasMaxLength(100);
            entity.Property(e => e.StyleOfPlay).HasMaxLength(400);

            entity.HasOne(d => d.CoppaItaliaClub).WithMany(p => p.CoppaItaliaPlayers)
                .HasForeignKey(d => d.CoppaItaliaClubId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__CoppaItal__Coppa__3C69FB99");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
