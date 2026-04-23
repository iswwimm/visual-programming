using System;
using System.Windows;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int rows = int.Parse(RowsBox.Text);
                int cols = int.Parse(ColsBox.Text);
                int time = int.Parse(TimeBox.Text);
                int hyrax = int.Parse(HyraxBox.Text);
                int raccoons = int.Parse(RaccoonBox.Text);
                int crocodiles = int.Parse(CrocodileBox.Text);
                
                if (rows <= 0 || cols <= 0 || hyrax <= 0)
                {
                    MessageBox.Show("Wprowadź poprawne wartości (większe od 0)!");
                    return;
                }
                
                GameWindow game = new GameWindow(rows, cols, hyrax, raccoons, crocodiles, time);
                
                game.Show();
                
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Proszę wpisać tylko liczby całkowite!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}");
            }
        }
    }
}