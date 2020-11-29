using System;
using LibraryManager.Core;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Infrastructure.Data
{
  public class LibraryManagerDbContext : DbContext
  {
    public LibraryManagerDbContext(DbContextOptions<LibraryManagerDbContext> options) : base(options)
    {
      
    }

    public DbSet<BibliographicRecord> BibliographicRecords => Set<BibliographicRecord>();
    public DbSet<CatalogueItem> CatalogueItems => Set<CatalogueItem>();
    public DbSet<Catalogue> Catalogues => Set<Catalogue>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
      optionsBuilder
        .UseSqlite("Data Source=./LibraryManager.sqlite;")
        .LogTo(Console.WriteLine);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
  }
}