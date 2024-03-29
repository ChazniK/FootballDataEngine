using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FootballDataEngine.Api.Data;

public partial class FootballdataengineContext : DbContext
{
    public FootballdataengineContext()
    {
    }

    public FootballdataengineContext(DbContextOptions<FootballdataengineContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Match> Matches { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL("Name=ConnectionStrings:FootballDataEngineDbConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Match>(entity =>
        {
            entity.HasKey(e => e.MatchId).HasName("PRIMARY");

            entity.ToTable("Match", "FootballDataEngine");

            entity.HasIndex(e => e.MatchId, "MatchId_UNIQUE").IsUnique();

            entity.Property(e => e.AverageCorners).HasPrecision(5);
            entity.Property(e => e.AverageGoals).HasPrecision(5);
            entity.Property(e => e.AwayTeam).HasMaxLength(100);
            entity.Property(e => e.Country).HasMaxLength(100);
            entity.Property(e => e.DateTimeCreated)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.HomeTeam).HasMaxLength(100);
            entity.Property(e => e.League).HasMaxLength(100);
            entity.Property(e => e.MatchDateTime).HasColumnType("datetime");
            entity.Property(e => e.MatchType).HasMaxLength(100);
            entity.Property(e => e.MatchTypeSuccessRate).HasPrecision(5);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
