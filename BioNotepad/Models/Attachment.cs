using System;

namespace BioNotepad.Models;

public class Attachment
{
    public int Id { get; set; }
    public int SessionEntryId { get; set; } 
    public string FileName { get; set; } = string.Empty; 
    public string FilePath { get; set; } = string.Empty;
    
    public SessionEntry? SessionEntry { get; set; }
}