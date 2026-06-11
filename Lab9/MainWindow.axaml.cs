using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Lab9
{
    public partial class MainWindow : Window
    {
        private DatabaseManager _dbManager;

        public MainWindow()
        {
            InitializeComponent();
            _dbManager = new DatabaseManager();
            RefreshComboBox(); 
        }
        
        private void RefreshComboBox()
        {
            var comboBox = this.FindControl<ComboBox>("WnioskiComboBox");
            if (comboBox != null)
            {
                comboBox.ItemsSource = _dbManager.GetWnioskiList();
            }
        }
        
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string[] daneZFormularza = new string[15];
            daneZFormularza[0] = this.FindControl<TextBox>("Field1_TextBox").Text;
            daneZFormularza[1] = this.FindControl<TextBox>("Field2_TextBox").Text;
            daneZFormularza[2] = this.FindControl<TextBox>("Field3_TextBox").Text;
            daneZFormularza[3] = this.FindControl<TextBox>("Field4_TextBox").Text;
            daneZFormularza[4] = this.FindControl<TextBox>("Field5_TextBox").Text;
            daneZFormularza[5] = this.FindControl<TextBox>("Field6_TextBox").Text;
            daneZFormularza[6] = this.FindControl<TextBox>("Field7_TextBox").Text;
            daneZFormularza[7] = this.FindControl<TextBox>("Field8_TextBox").Text;
            daneZFormularza[8] = this.FindControl<TextBox>("Field9_TextBox").Text;
            daneZFormularza[9] = this.FindControl<TextBox>("Field10_TextBox").Text;
            daneZFormularza[10] = this.FindControl<TextBox>("Field11_TextBox").Text;
            daneZFormularza[11] = this.FindControl<TextBox>("Field12_TextBox").Text;
            daneZFormularza[12] = this.FindControl<TextBox>("Field13_TextBox").Text;
            daneZFormularza[13] = this.FindControl<TextBox>("Field14_TextBox").Text;
            daneZFormularza[14] = this.FindControl<TextBox>("Field15_TextBox").Text;

            _dbManager.WriteData(daneZFormularza);

            var statusLabel = this.FindControl<TextBlock>("StatusTextBlock");
            if (statusLabel != null)
            {
                statusLabel.Text = "Pomyślnie zapisano wniosek do bazy danych!";
                statusLabel.Foreground = Avalonia.Media.Brushes.LightGreen;
            }
            
            RefreshComboBox();
        }
        
        private void LoadSelectedButton_Click(object sender, RoutedEventArgs e)
        {
            var comboBox = this.FindControl<ComboBox>("WnioskiComboBox");
            var statusLabel = this.FindControl<TextBlock>("StatusTextBlock");

            if (comboBox?.SelectedItem is WniosekItem wybranyWniosek)
            {
                string[] wczytaneDane = _dbManager.ReadDataById(wybranyWniosek.Id);

                this.FindControl<TextBox>("Field1_TextBox").Text = wczytaneDane[0] ?? "";
                this.FindControl<TextBox>("Field2_TextBox").Text = wczytaneDane[1] ?? "";
                this.FindControl<TextBox>("Field3_TextBox").Text = wczytaneDane[2] ?? "";
                this.FindControl<TextBox>("Field4_TextBox").Text = wczytaneDane[3] ?? "";
                this.FindControl<TextBox>("Field5_TextBox").Text = wczytaneDane[4] ?? "";
                this.FindControl<TextBox>("Field6_TextBox").Text = wczytaneDane[5] ?? "";
                this.FindControl<TextBox>("Field7_TextBox").Text = wczytaneDane[6] ?? "";
                this.FindControl<TextBox>("Field8_TextBox").Text = wczytaneDane[7] ?? "";
                this.FindControl<TextBox>("Field9_TextBox").Text = wczytaneDane[8] ?? "";
                this.FindControl<TextBox>("Field10_TextBox").Text = wczytaneDane[9] ?? "";
                this.FindControl<TextBox>("Field11_TextBox").Text = wczytaneDane[10] ?? "";
                this.FindControl<TextBox>("Field12_TextBox").Text = wczytaneDane[11] ?? "";
                this.FindControl<TextBox>("Field13_TextBox").Text = wczytaneDane[12] ?? "";
                this.FindControl<TextBox>("Field14_TextBox").Text = wczytaneDane[13] ?? "";
                this.FindControl<TextBox>("Field15_TextBox").Text = wczytaneDane[14] ?? "";

                if (statusLabel != null)
                {
                    statusLabel.Text = $"Wczytano wniosek studenta: {wybranyWniosek.Opis}";
                    statusLabel.Foreground = Avalonia.Media.Brushes.LightBlue;
                }
            }
            else
            {
                if (statusLabel != null)
                {
                    statusLabel.Text = "Najpierw wybierz wniosek z listy rozwijanej!";
                    statusLabel.Foreground = Avalonia.Media.Brushes.Orange;
                }
            }
        }
        
        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            string[] wczytaneDane = _dbManager.ReadLastData();
            var statusLabel = this.FindControl<TextBlock>("StatusTextBlock");

            if (wczytaneDane[0] != null || wczytaneDane[1] != null)
            {
                this.FindControl<TextBox>("Field1_TextBox").Text = wczytaneDane[0];
                this.FindControl<TextBox>("Field2_TextBox").Text = wczytaneDane[1];
                this.FindControl<TextBox>("Field3_TextBox").Text = wczytaneDane[2];
                this.FindControl<TextBox>("Field4_TextBox").Text = wczytaneDane[3];
                this.FindControl<TextBox>("Field5_TextBox").Text = wczytaneDane[4];
                this.FindControl<TextBox>("Field6_TextBox").Text = wczytaneDane[5];
                this.FindControl<TextBox>("Field7_TextBox").Text = wczytaneDane[6];
                this.FindControl<TextBox>("Field8_TextBox").Text = wczytaneDane[7];
                this.FindControl<TextBox>("Field9_TextBox").Text = wczytaneDane[8];
                this.FindControl<TextBox>("Field10_TextBox").Text = wczytaneDane[9];
                this.FindControl<TextBox>("Field11_TextBox").Text = wczytaneDane[10];
                this.FindControl<TextBox>("Field12_TextBox").Text = wczytaneDane[11];
                this.FindControl<TextBox>("Field13_TextBox").Text = wczytaneDane[12];
                this.FindControl<TextBox>("Field14_TextBox").Text = wczytaneDane[13];
                this.FindControl<TextBox>("Field15_TextBox").Text = wczytaneDane[14];

                if (statusLabel != null)
                {
                    statusLabel.Text = "Wczytano ostatni zapisany wniosek.";
                    statusLabel.Foreground = Avalonia.Media.Brushes.LightBlue;
                }
            }
            else
            {
                if (statusLabel != null)
                {
                    statusLabel.Text = "Baza jest pusta, brak danych do wczytania.";
                    statusLabel.Foreground = Avalonia.Media.Brushes.Orange;
                }
            }
        }
    }
}