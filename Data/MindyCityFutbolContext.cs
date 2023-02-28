using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MindyCityFutbol.Data;

public partial class MindyCityFutbolContext : DbContext
{
    public MindyCityFutbolContext(DbContextOptions<MindyCityFutbolContext> options)
        : base(options)
    {
    }
    public DbSet<Team> Team { get; set; }
}
