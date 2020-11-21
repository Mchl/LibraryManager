using System.ComponentModel.DataAnnotations;

namespace LibraryManager.Core
{
  public class BookRecord : BibliographicRecord
  {
    public string? Isbn { get; set; }
    public string? Title { get; set; }
  }
}