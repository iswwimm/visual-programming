using System.Collections.Generic;
using System.Linq;
using BioSampleManager.Data;
using BioSampleManager.Models;
using Microsoft.EntityFrameworkCore;

namespace BioSampleManager.Services;

public class SampleService
{
    public List<BiologicalSample> GetSamples(string? searchTerm = null, SampleType? filterType = null)
    {
        using var context = new AppDbContext();
        IQueryable<BiologicalSample> query = context.Samples;
        
        if (filterType.HasValue)
        {
            query = query.Where(s => s.Type == filterType.Value);
        }
        
        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            var lowerSearch = searchTerm.ToLower();
            query = query.Where(s => s.Name.ToLower().Contains(lowerSearch) || 
                                     (s.Notes != null && s.Notes.ToLower().Contains(lowerSearch)));
        }
        
        return query.OrderByDescending(s => s.CollectionDate).ToList();
    }
    
    public void AddSample(BiologicalSample sample)
    {
        using var context = new AppDbContext();
        context.Samples.Add(sample);
        context.SaveChanges();
    }
    
    public void UpdateSample(BiologicalSample sample)
    {
        using var context = new AppDbContext();
        context.Samples.Update(sample);
        context.SaveChanges();
    }
    
    public void DeleteSample(int id)
    {
        using var context = new AppDbContext();
        var sample = context.Samples.Find(id);
        if (sample != null)
        {
            context.Samples.Remove(sample);
            context.SaveChanges();
        }
    }
}