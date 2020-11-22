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
      optionsBuilder.UseSqlite("Data Source=./LibraryManager.sqlite;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder
        .Entity<BookRecord>(e =>
        {
          e.HasBaseType<BibliographicRecord>();
          e.Property(b => b.Isbn).HasColumnName("ProductCode");
          e.Property(b => b.Title).HasColumnName("Name");
        })
        .Entity<SerialRecord>(e =>
        {
          e.HasBaseType<BibliographicRecord>();
          e.Property(s => s.Issn).HasColumnName("ProductCode");
          e.Property(s => s.Title).HasColumnName("Name");
        })
;
        
    }
  }
}