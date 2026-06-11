using System;

namespace BioSampleManager.Models;

public class BiologicalSample
{
    public int Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public SampleType Type { get; set; }
    
    public DateTime CollectionDate { get; set; } = DateTime.Now;
    
    public string? Notes { get; set; }
}