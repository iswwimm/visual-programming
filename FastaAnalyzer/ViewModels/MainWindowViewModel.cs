using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using FastaAnalyzer.Models;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;

namespace FastaAnalyzer.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public ObservableCollection<FastaRecord> Records { get; } = new();
    
    [ObservableProperty]
    private FastaRecord? _selectedRecord;
    
    [ObservableProperty] private string _countA = "-";
    [ObservableProperty] private string _countT = "-";
    [ObservableProperty] private string _countG = "-";
    [ObservableProperty] private string _countC = "-";
    [ObservableProperty] private string _countN = "-";
    
    public ObservableCollection<ISeries> ChartSeries { get; set; } = new();
    public ObservableCollection<Axis> ChartXAxes { get; set; } = new();

    public MainViewModel()
    {
        ChartSeries.Add(new ColumnSeries<int> { Values = new List<int> { 0, 0, 0, 0 } });
        ChartXAxes.Add(new Axis { Labels = new[] { "A", "T", "G", "C" } });
    }
    
    partial void OnSelectedRecordChanged(FastaRecord? value)
    {
        if (value == null)
        {
            CountA = CountT = CountG = CountC = CountN = "-";
            ChartSeries[0].Values = new List<int> { 0, 0, 0, 0 };
            return;
        }

        var counts = value.GetNucleotideCounts();
        CountA = counts.GetValueOrDefault('A', 0).ToString();
        CountT = counts.GetValueOrDefault('T', 0).ToString();
        CountG = counts.GetValueOrDefault('G', 0).ToString();
        CountC = counts.GetValueOrDefault('C', 0).ToString();
        CountN = counts.GetValueOrDefault('N', 0).ToString();
        
        ChartSeries[0].Values = new List<int>
        {
            counts.GetValueOrDefault('A', 0),
            counts.GetValueOrDefault('T', 0),
            counts.GetValueOrDefault('G', 0),
            counts.GetValueOrDefault('C', 0)
        };
    }

    public void LoadFastaFiles(IEnumerable<string> filePaths)
    {
        Records.Clear();
        foreach (var path in filePaths)
        {
            try
            {
                var parsed = FastaParser.ParseFile(path);
                foreach (var record in parsed)
                {
                    Records.Add(record);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Błąd wczytywania: {ex.Message}");
            }
        }
    }
}