using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using BioNotepad.Data;
using BioNotepad.Models;
using BioNotepad.Services;

namespace BioNotepad.ViewModels;

public partial class SessionDetailViewModel : ViewModelBase
{
    private readonly MainWindowViewModel _mainViewModel;
    public AnalysisSession Session { get; }

    [ObservableProperty]
    private ObservableCollection<SessionEntry> _entries = new();

    [ObservableProperty]
    private string _newEntryDescription = string.Empty;

    public SessionDetailViewModel(AnalysisSession session, MainWindowViewModel mainViewModel)
    {
        Session = session;
        _mainViewModel = mainViewModel;
        LoadEntries();
    }

    private void LoadEntries()
    {
        using var dbContext = new AppDbContext();
        var loadedEntries = dbContext.Entries
            .Include(e => e.Attachments)
            .Where(e => e.AnalysisSessionId == Session.Id)
            .OrderBy(e => e.CreatedAt)
            .ToList();
            
        Entries = new ObservableCollection<SessionEntry>(loadedEntries);
    }

    [RelayCommand]
    private void AddEntry()
    {
        if (string.IsNullOrWhiteSpace(NewEntryDescription)) return;

        var entry = new SessionEntry 
        { 
            AnalysisSessionId = Session.Id,
            Description = NewEntryDescription 
        };

        using var dbContext = new AppDbContext();
        dbContext.Entries.Add(entry);
        dbContext.SaveChanges();

        Entries.Add(entry);
        NewEntryDescription = string.Empty;
    }

    [RelayCommand]
    private void GoBack()
    {
        _mainViewModel.NavigateTo(new SessionListViewModel(_mainViewModel));
    }
    
    public void AddAttachmentToEntry(SessionEntry entry, string filePath)
    {
        var savedPath = FileStorageService.SaveAttachmentLocally(filePath);
        
        var attachment = new Attachment 
        { 
            SessionEntryId = entry.Id, 
            FileName = System.IO.Path.GetFileName(filePath),
            FilePath = savedPath 
        };

        using var dbContext = new AppDbContext();
        dbContext.Attachments.Add(attachment);
        dbContext.SaveChanges();

        LoadEntries();
    }
}