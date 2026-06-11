using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Platform.Storage;
using FastaAnalyzer.Services;
using FastaAnalyzer.ViewModels;

namespace FastaAnalyzer.Views;

public partial class MainWindow : Window
{
    private MainViewModel VM => (MainViewModel)DataContext!;

    public MainWindow()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private async void OnLoadFileClick(object? sender, RoutedEventArgs e)
    {
        var topLevel = GetTopLevel(this);
        if (topLevel == null) return;

        var files = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = "Wybierz plik FASTA",
            AllowMultiple = true,
            FileTypeFilter = new[] { new FilePickerFileType("Pliki FASTA") { Patterns = new[] { "*.fasta", "*.fa", "*.txt" } } }
        });

        if (files.Any())
        {
            var paths = files.Select(f => f.Path.LocalPath);
            VM.LoadFastaFiles(paths);
        }
    }

    private async void OnExportCsvClick(object? sender, RoutedEventArgs e)
    {
        var topLevel = GetTopLevel(this);
        if (topLevel == null) return;

        var file = await topLevel.StorageProvider.SaveFilePickerAsync(new FilePickerSaveOptions
        {
            Title = "Zapisz jako CSV",
            DefaultExtension = "csv",
            SuggestedFileName = "analiza_fasta.csv"
        });

        if (file != null)
        {
            ExportService.ExportToCsv(file.Path.LocalPath, VM.Records);
        }
    }

    private async void OnExportJsonClick(object? sender, RoutedEventArgs e)
    {
        var topLevel = GetTopLevel(this);
        if (topLevel == null) return;

        var file = await topLevel.StorageProvider.SaveFilePickerAsync(new FilePickerSaveOptions
        {
            Title = "Zapisz jako JSON",
            DefaultExtension = "json",
            SuggestedFileName = "analiza_fasta.json"
        });

        if (file != null)
        {
            ExportService.ExportToJson(file.Path.LocalPath, VM.Records);
        }
    }
}