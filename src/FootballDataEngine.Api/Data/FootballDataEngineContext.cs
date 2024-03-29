﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FootballDataEngine.Api.Data;

public partial class FootballDataEngineContext : DbContext
{
    public FootballDataEngineContext()
    {
    }

    public FootballDataEngineContext(DbContextOptions<FootballDataEngineContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Match> Matches { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Match>(entity =>
        {
            entity.HasKey(e => e.MatchId).HasName("PK__Match__4218C817FFC92591");

            entity.ToTable("Match");

            entity.Property(e => e.AverageGoals).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.AwayTeam)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DateTimeCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.HomeTeam)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.League)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MatchDateTime).HasColumnType("datetime");
            entity.Property(e => e.MatchType)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MatchTypeSuccessRate).HasColumnType("decimal(18, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
