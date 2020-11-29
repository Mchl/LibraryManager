namespace LibraryManager.Core
{
  public class CatalogueItem
  {
    public int Id { get; set; }

    public BibliographicRecord BibliographicRecord { get; set; } = null!;
    public CatalogueItemStatus Status { get; set; }
  }
}