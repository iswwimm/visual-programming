using Avalonia.Controls;
using Avalonia.Interactivity;
using BioSampleManager.Models;
using BioSampleManager.ViewModels;

namespace BioSampleManager.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    
    private async void OnAddSampleClick(object? sender, RoutedEventArgs e)
    {
        var dialog = new AddSampleWindow();
        
        var result = await dialog.ShowDialog<BiologicalSample?>(this);

        if (result != null && DataContext is MainWindowViewModel vm)
        {
            vm.SaveNewSampleToDatabase(result);
        }
    }
}