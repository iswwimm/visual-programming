using Microsoft.Win32;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace WpfApp1;

public partial class MainWindow : Window
{
    private Bitmap _currentBitmap;

    public MainWindow() { InitializeComponent(); }
    
    private void RefreshImage()
    {
        if (_currentBitmap == null) return;
        using (MemoryStream ms = new MemoryStream())
        {
            _currentBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            ms.Seek(0, SeekOrigin.Begin);
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.StreamSource = ms;
            bi.CacheOption = BitmapCacheOption.OnLoad;
            bi.EndInit();
            imgDisplay.Source = bi;
        }
    }

    private void BtnLoad_Click(object sender, RoutedEventArgs e)
    {
        OpenFileDialog op = new OpenFileDialog();
        op.Filter = "BMP Files (*.bmp)|*.bmp";
        if (op.ShowDialog() == true)
        {
            _currentBitmap = new Bitmap(op.FileName);
            RefreshImage();
        }
    }
    
    private void BtnRotate_Click(object sender, RoutedEventArgs e)
    {
        if (_currentBitmap == null) return;
        if (rb90.IsChecked == true) _currentBitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
        else if (rb180.IsChecked == true) _currentBitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
        else if (rb270.IsChecked == true) _currentBitmap.RotateFlip(RotateFlipType.Rotate270FlipNone);
        RefreshImage();
    }
    private void BtnInvert_Click(object sender, RoutedEventArgs e)
    {
        if (_currentBitmap == null) return;
        for (int y = 0; y < _currentBitmap.Height; y++)
        {
            for (int x = 0; x < _currentBitmap.Width; x++)
            {
                Color c = _currentBitmap.GetPixel(x, y);
                _currentBitmap.SetPixel(x, y, Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B));
            }
        }
        RefreshImage();
    }

    private void BtnUpsideDown_Click(object sender, RoutedEventArgs e)
    {
        if (_currentBitmap == null) return;
        _currentBitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);
        RefreshImage();
    }
    private void BtnOnlyGreen_Click(object sender, RoutedEventArgs e) { }
}