using System;
using LibraryManager.Core;
using LibraryManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.CLI
{
  class Program
  {
    static void Main(string[] args)
    {
      var catalogue = new Catalogue("Local catalogue");

      // var book1 = new BookRecord
      // {
      //   Isbn = "9781491929124",
      //   Title = "Site Reliability Engineering"
      // };

      // var catalogueItem1 = new CatalogueItem(
      //   book1,
      //   CatalogueItemStatus.Available
      // );
      //
      // var catalogueItem2 = new CatalogueItem
      // (
      //
      //   book1,
      //   CatalogueItemStatus.CheckedOut
      // );
      //
      // catalogue.Items.Add(catalogueItem1);
      // catalogue.Items.Add(catalogueItem2);

      var dbContext = new LibraryManagerDbContext(new DbContextOptions<LibraryManagerDbContext>());
    }
  }
}