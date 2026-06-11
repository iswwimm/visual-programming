using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia.Media.Imaging;
using BioSampleManager.Models;
using BioSampleManager.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BioSampleManager.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly SampleService _sampleService;
    private readonly QrCodeService _qrCodeService;

    public MainWindowViewModel()
    {
        _sampleService = new SampleService();
        _qrCodeService = new QrCodeService();

        AvailableFilters = new List<SampleType?>();
        AvailableFilters.Add(null); 
        AvailableFilters.AddRange(Enum.GetValues<SampleType>().Cast<SampleType?>());

        LoadSamples();
    }
    
    
    [ObservableProperty]
    private ObservableCollection<BiologicalSample> _samples = new();
    
    [ObservableProperty]
    private BiologicalSample? _selectedSample;
    
    [ObservableProperty]
    private Bitmap? _qrCodeImage;
    
    [ObservableProperty]
    private string _searchText = string.Empty;
    
    [ObservableProperty]
    private SampleType? _selectedFilterType;
    
    public List<SampleType?> AvailableFilters { get; }
    
    private void LoadSamples()
    {
        var data = _sampleService.GetSamples(SearchText, SelectedFilterType);
        Samples = new ObservableCollection<BiologicalSample>(data);
    }
    
    partial void OnSearchTextChanged(string value)
    {
        LoadSamples();
    }

    partial void OnSelectedFilterTypeChanged(SampleType? value)
    {
        LoadSamples();
    }
    
    partial void OnSelectedSampleChanged(BiologicalSample? value)
    {
        if (value != null)
        {
            QrCodeImage = _qrCodeService.GenerateQrCodeBitmap(value);
        }
        else
        {
            QrCodeImage = null;
        }
    }
    

    [RelayCommand]
    private void ExportQrCode()
    {
        if (SelectedSample == null) return;
        
        string path = $"QR_{SelectedSample.Id}_{SelectedSample.Name}.png";
        _qrCodeService.ExportQrCodeToFile(SelectedSample, path);
        
    }
    public void SaveNewSampleToDatabase(BiologicalSample newSample)
    {
        _sampleService.AddSample(newSample);
        LoadSamples();
    }
}