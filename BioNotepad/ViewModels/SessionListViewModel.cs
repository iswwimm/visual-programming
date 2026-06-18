using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using BioNotepad.Data;
using BioNotepad.Models;

namespace BioNotepad.ViewModels;

public partial class SessionListViewModel : ViewModelBase
{
    private readonly MainWindowViewModel _mainViewModel;

    [ObservableProperty]
    private ObservableCollection<AnalysisSession> _sessions = new();

    [ObservableProperty]
    private string _newSessionTitle = string.Empty;

    public SessionListViewModel(MainWindowViewModel mainViewModel)
    {
        _mainViewModel = mainViewModel;
        LoadSessions();
    }

    private void LoadSessions()
    {
        using var dbContext = new AppDbContext();
        var loadedSessions = dbContext.Sessions.OrderByDescending(s => s.CreatedAt).ToList();
        Sessions = new ObservableCollection<AnalysisSession>(loadedSessions);
    }
    
    [RelayCommand]
    private void CreateSession()
    {
        if (string.IsNullOrWhiteSpace(NewSessionTitle)) return;

        var newSession = new AnalysisSession { Title = NewSessionTitle };
        
        using var dbContext = new AppDbContext();
        dbContext.Sessions.Add(newSession);
        dbContext.SaveChanges(); 

        Sessions.Insert(0, newSession); 
        NewSessionTitle = string.Empty;
    }

    [RelayCommand]
    private void OpenSession(AnalysisSession selectedSession)
    {
        if (selectedSession != null)
        {
            _mainViewModel.NavigateTo(new SessionDetailViewModel(selectedSession, _mainViewModel));
        }
    }
}