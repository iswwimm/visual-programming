using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections.Generic;
using System.Linq;

namespace DnaSequencer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        public void ButtonClicked(object source, RoutedEventArgs args)
        {
            string dnaSequence = DnaInputTextBox.Text?.ToUpper().Trim() ?? "";
            
            if (dnaSequence.Length < 4)
            {
                ResultsTextBlock.Text = "Sekwencja jest zbyt krótka. Musi mieć co najmniej 4 nukleotydy.";
                return;
            }

            Dictionary<string, int> sequenceCounts = new Dictionary<string, int>();
            
            for (int i = 0; i <= dnaSequence.Length - 4; i++)
            {
                string subSequence = dnaSequence.Substring(i, 4);

                if (sequenceCounts.ContainsKey(subSequence))
                {
                    sequenceCounts[subSequence]++;
                }
                else
                {
                    sequenceCounts[subSequence] = 1;
                }
            }
            
            var resultsString = string.Join("\n", sequenceCounts
                .OrderByDescending(kvp => kvp.Value)
                .Select(kvp => $"{kvp.Key}: {kvp.Value}x"));

            ResultsTextBlock.Text = resultsString;
        }
    }
}