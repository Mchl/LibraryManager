namespace LibraryManager.Core
{
  public class CatalogueItem
  {
    public int Id { get; set; }

    public BibliographicRecord BibliographicRecord { get; set; } = new BibliographicRecord();
    public CatalogueItemStatus Status { get; set; }
  }
}