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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("host=localhost;port=5432;database=MindyCityFutbol;username=postgres;password=password;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
