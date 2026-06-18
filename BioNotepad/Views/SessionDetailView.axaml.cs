using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using BioNotepad.Models;
using BioNotepad.ViewModels;
using System.Linq;

namespace BioNotepad.Views;

public partial class SessionDetailView : UserControl
{
    public SessionDetailView()
    {
        InitializeComponent();
    }
    
    private async void OnAddAttachmentClick(object? sender, RoutedEventArgs e)
    {
        if (sender is Button button && button.Tag is SessionEntry entry)
        {
            var topLevel = TopLevel.GetTopLevel(this);
            if (topLevel == null) return;

            var files = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
            {
                Title = "Wybierz plik analityczny",
                AllowMultiple = false
            });

            if (files.Count >= 1)
            {
                var filePath = files[0].Path.LocalPath;
                var viewModel = (SessionDetailViewModel)DataContext!;
                
                viewModel.AddAttachmentToEntry(entry, filePath);
            }
        }
    }
    
    private async void OnExportPdfClick(object? sender, RoutedEventArgs e)
    {
        var topLevel = TopLevel.GetTopLevel(this);
        if (topLevel == null) return;

        var viewModel = (SessionDetailViewModel)DataContext!;
        
        var file = await topLevel.StorageProvider.SaveFilePickerAsync(new FilePickerSaveOptions
        {
            Title = "Zapisz raport jako PDF",
            SuggestedFileName = $"Raport_{viewModel.Session.Title}.pdf",
            DefaultExtension = ".pdf",
            FileTypeChoices = new[]
            {
                new FilePickerFileType("Dokument PDF") { Patterns = new[] { "*.pdf" } }
            }
        });

        if (file != null)
        {
            viewModel.Session.Entries = viewModel.Entries.ToList();
            Services.PdfExportService.ExportSessionToPdf(viewModel.Session, file.Path.LocalPath);
        }
    }
}