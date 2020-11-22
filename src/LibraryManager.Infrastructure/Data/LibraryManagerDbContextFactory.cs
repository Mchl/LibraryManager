using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LibraryManager.Infrastructure.Data
{
  public class LibraryManagerDbContextFactory : IDesignTimeDbContextFactory<LibraryManagerDbContext>
  {
    public LibraryManagerDbContext CreateDbContext(string[] args)
    {
      return new LibraryManagerDbContext(new DbContextOptions<LibraryManagerDbContext>());
    }
  }
}