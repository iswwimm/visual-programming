using System;
using System.Collections.Generic;
using System.Linq;
using BioSampleManager.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BioSampleManager.ViewModels;

public partial class AddSampleViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _name = string.Empty;

    [ObservableProperty]
    private SampleType _selectedType = SampleType.DNA;

    [ObservableProperty]
    private string? _notes;
    
    public List<SampleType> AvailableTypes { get; } = Enum.GetValues<SampleType>().ToList();
    
    public Action<BiologicalSample?>? OnRequestClose;

    [RelayCommand]
    private void Save()
    {
        if (string.IsNullOrWhiteSpace(Name)) return;

        var newSample = new BiologicalSample
        {
            Name = Name,
            Type = SelectedType,
            Notes = Notes,
            CollectionDate = DateTime.Now 
        };

        OnRequestClose?.Invoke(newSample);
    }

    [RelayCommand]
    private void Cancel()
    {
        OnRequestClose?.Invoke(null);
    }
}