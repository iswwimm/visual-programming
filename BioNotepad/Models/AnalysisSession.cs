using System;
using System.Collections.Generic;

namespace BioNotepad.Models;

public class AnalysisSession
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public List<SessionEntry> Entries { get; set; } = new();
}