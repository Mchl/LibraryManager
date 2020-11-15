using System.Collections.Generic;

namespace LibraryManager.Core
{
  public class Catalogue
  {
    public Catalogue(string name)
    {
      Name = name;
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public List<CatalogueItem> Items { get; } = new ();
  }
}