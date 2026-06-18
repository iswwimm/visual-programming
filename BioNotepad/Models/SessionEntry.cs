using System;
using System.Collections.Generic;

namespace BioNotepad.Models;

public class SessionEntry
{
    public int Id { get; set; }
    public int AnalysisSessionId { get; set; } // Klucz obcy
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    
    public List<Attachment> Attachments { get; set; } = new();
    
    public AnalysisSession? AnalysisSession { get; set; }
}