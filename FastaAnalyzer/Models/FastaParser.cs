using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FastaAnalyzer.Models;

public static class FastaParser
{
    public static List<FastaRecord> ParseFile(string filePath)
    {
        var records = new List<FastaRecord>();
        
        if (!File.Exists(filePath))
            throw new FileNotFoundException($"Nie znaleziono pliku: {filePath}");

        using var reader = new StreamReader(filePath);
        string? line;
        string? currentHeader = null;
        var currentSequence = new StringBuilder();

        while ((line = reader.ReadLine()) != null)
        {
            line = line.Trim();
            if (string.IsNullOrWhiteSpace(line)) continue;

            if (line.StartsWith('>'))
            {
                if (currentHeader != null)
                {
                    records.Add(new FastaRecord(currentHeader, currentSequence.ToString()));
                    currentSequence.Clear();
                }
                currentHeader = line.Substring(1).Trim();
            }
            else
            {
                if (currentHeader == null)
                    throw new FormatException("Błąd formatu FASTA. Plik musi zaczynać się od znaku '>'");

                currentSequence.Append(line);
            }
        }

        if (currentHeader != null)
        {
            records.Add(new FastaRecord(currentHeader, currentSequence.ToString()));
        }

        return records;
    }
}