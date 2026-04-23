using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Windows.Media.Imaging;

namespace WpfApp
{
    public partial class GameWindow : Window
    {
        private int rows, cols;
        private int score = 0;
        private DispatcherTimer timer;
        private DispatcherTimer gameTimer;
        private Random random = new Random();

        private AnimalType[,] board;
        private Button[,] buttons;

        private int hyraxCount;
        private int caughtHyrax = 0;
        private int timeLeft;

        public enum AnimalType { None, Hyrax, Raccoon, Crocodile }

        public GameWindow(int rows, int cols, int hyrax, int raccoons, int crocodiles, int time)
        {
            InitializeComponent();

            this.rows = rows;
            this.cols = cols;
            this.hyraxCount = hyrax;
            this.timeLeft = time;

            board = new AnimalType[rows, cols];
            buttons = new Button[rows, cols];

            CreateBoard();
            
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(0.75);
            timer.Tick += SpawnAnimals;
            timer.Start();
            
            gameTimer = new DispatcherTimer();
            gameTimer.Interval = TimeSpan.FromSeconds(1);
            gameTimer.Tick += GameTick;
            gameTimer.Start();

            if (TimeText != null) TimeText.Text = $"Czas: {timeLeft}";
            if (ScoreText != null) ScoreText.Text = $"Punkty: {score}";
        }

        private Image CreateImage(string path)
        {
            try
            {
                return new Image
                {
                    Source = new BitmapImage(new Uri(path, UriKind.RelativeOrAbsolute)),
                    Stretch = System.Windows.Media.Stretch.Uniform
                };
            }
            catch
            {
                return new Image();
            }
        }

        private void GameTick(object sender, EventArgs e)
        {
            timeLeft--;
            TimeText.Text = $"Czas: {timeLeft}";

            if (timeLeft <= 0)
            {
                EndGame(false, "Czas się skończył!");
            }
        }

        private void CreateBoard()
        {
            GameGrid.RowDefinitions.Clear();
            GameGrid.ColumnDefinitions.Clear();
            GameGrid.Children.Clear();

            for (int i = 0; i < rows; i++)
                GameGrid.RowDefinitions.Add(new RowDefinition());

            for (int j = 0; j < cols; j++)
                GameGrid.ColumnDefinitions.Add(new ColumnDefinition());

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Button btn = new Button();
                    btn.Content = CreateImage("images/trash.jpg");
                    btn.Tag = new Tuple<int, int>(i, j);
                    btn.Click += Cell_Click;

                    Grid.SetRow(btn, i);
                    Grid.SetColumn(btn, j);

                    GameGrid.Children.Add(btn);
                    buttons[i, j] = btn;
                }
            }
        }

        private void SpawnAnimals(object sender, EventArgs e)
        {
            ClearBoard();

            int i = random.Next(rows);
            int j = random.Next(cols);
            int animal = random.Next(3);

            switch (animal)
            {
                case 0:
                    board[i, j] = AnimalType.Hyrax;
                    buttons[i, j].Content = CreateImage("images/hyrax.jpg");
                    break;
                case 1:
                    board[i, j] = AnimalType.Raccoon;
                    buttons[i, j].Content = CreateImage("images/szczop.jpg");
                    break;
                case 2:
                    board[i, j] = AnimalType.Crocodile;
                    buttons[i, j].Content = CreateImage("images/croc.jpg");
                    break;
            }
        }

        private void ClearBoard()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    board[i, j] = AnimalType.None;
                    buttons[i, j].Content = CreateImage("images/trash.jpg");
                }
            }
        }

        private void Cell_Click(object sender, RoutedEventArgs e)
        {
            if (!(sender is Button btn)) return;
            var pos = (Tuple<int, int>)btn.Tag;

            int i = pos.Item1;
            int j = pos.Item2;

            if (board[i, j] == AnimalType.Hyrax)
            {
                score++;
                caughtHyrax++;
                board[i, j] = AnimalType.None;
                buttons[i, j].Content = CreateImage("images/trash.jpg");
            }
            else if (board[i, j] == AnimalType.Raccoon)
            {
                score--;
                board[i, j] = AnimalType.None;
            }
            else if (board[i, j] == AnimalType.Crocodile)
            {
                EndGame(false, "Zjadł Cię krokodyl!");
                return;
            }

            ScoreText.Text = $"Punkty: {score}";

            if (caughtHyrax >= hyraxCount)
                EndGame(true, "Złapałeś wszystkie góralki!");
        }

        private void EndGame(bool win, string message)
        {
            timer.Stop();
            gameTimer.Stop();

            string title = win ? "Zwycięstwo!" : "Koniec gry";
            MessageBox.Show(message, title);

            this.Close();
        }
    }
}