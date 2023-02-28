using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MindyCityFutbol;

public partial class MindyCityFutbolContext : DbContext
{
    public MindyCityFutbolContext()
    {
    }

    public MindyCityFutbolContext(DbContextOptions<MindyCityFutbolContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("name=MindyCityFutbolContext;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
