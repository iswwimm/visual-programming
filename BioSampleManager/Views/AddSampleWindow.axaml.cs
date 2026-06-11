using Avalonia.Controls;
using BioSampleManager.Models;
using BioSampleManager.ViewModels;

namespace BioSampleManager.Views;

public partial class AddSampleWindow : Window
{
    public AddSampleWindow()
    {
        InitializeComponent();
        
        var vm = new AddSampleViewModel();
        DataContext = vm;

        vm.OnRequestClose += (sample) => Close(sample);
    }
}