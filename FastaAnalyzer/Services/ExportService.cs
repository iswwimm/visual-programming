using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using CsvHelper;
using Newtonsoft.Json;
using FastaAnalyzer.Models;

namespace FastaAnalyzer.Services;

public class ExportRow
{
    public string Header { get; set; } = "";
    public int Length { get; set; }
    public int Codons { get; set; }
    public double GCContentPercent { get; set; }
}

public static class ExportService
{
    private static List<ExportRow> MapRecords(IEnumerable<FastaRecord> records)
    {
        var list = new List<ExportRow>();
        foreach (var r in records)
        {
            list.Add(new ExportRow
            {
                Header = r.Header,
                Length = r.Length,
                Codons = r.CodonsCount,
                GCContentPercent = r.GcContent
            });
        }
        return list;
    }

    public static void ExportToCsv(string filePath, IEnumerable<FastaRecord> records)
    {
        var data = MapRecords(records);
        using var writer = new StreamWriter(filePath);
        using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
        csv.WriteRecords(data);
    }

    public static void ExportToJson(string filePath, IEnumerable<FastaRecord> records)
    {
        var data = MapRecords(records);
        string json = JsonConvert.SerializeObject(data, Formatting.Indented);
        File.WriteAllText(filePath, json);
    }
}