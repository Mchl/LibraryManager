using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryManager.Core
{
  public class BibliographicRecord
  {
    public int Id { get; set; }
    public string? ProductCode { get; set; }
    public string? Name { get; set; }
  }
}