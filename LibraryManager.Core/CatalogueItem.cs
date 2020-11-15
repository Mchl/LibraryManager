namespace LibraryManager.Core
{
  public class CatalogueItem
  {
    public CatalogueItem(BibliographicRecord bibliographicRecord, CatalogueItemStatus status)
    {
      BibliographicRecord = bibliographicRecord;
      Status = status;
    }

    public int Id { get; set; }
    public BibliographicRecord BibliographicRecord { get; set; }
    public CatalogueItemStatus Status { get; set; }
  }
}