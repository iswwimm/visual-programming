using System;
using System.Collections.Generic;
using System.Linq;

namespace FastaAnalyzer.Models;

public class FastaRecord
{
    public string Header { get; }
    public string Sequence { get; }

    public FastaRecord(string header, string sequence)
    {
        Header = header ?? throw new ArgumentNullException(nameof(header));
        Sequence = sequence?.ToUpperInvariant() ?? throw new ArgumentNullException(nameof(sequence));
    }

    public int Length => Sequence.Length;
    
    public int CodonsCount => Length / 3;

    public double GcContent
    {
        get
        {
            if (Length == 0) return 0;
            int gcCount = Sequence.Count(c => c == 'G' || c == 'C');
            return Math.Round((double)gcCount / Length * 100, 2);
        }
    }
    
    public Dictionary<char, int> GetNucleotideCounts()
    {
        var counts = new Dictionary<char, int> { { 'A', 0 }, { 'T', 0 }, { 'G', 0 }, { 'C', 0 }, { 'N', 0 } };
        
        foreach (char c in Sequence)
        {
            if (counts.ContainsKey(c))
                counts[c]++;
            else
                counts[c] = 1;
        }
        return counts;
    }
}