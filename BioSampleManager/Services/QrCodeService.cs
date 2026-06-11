using System.IO;
using Avalonia.Media.Imaging;
using BioSampleManager.Models;
using QRCoder;

namespace BioSampleManager.Services;

public class QrCodeService
{
    public Bitmap? GenerateQrCodeBitmap(BiologicalSample sample)
    {
        string payload = $"ID: {sample.Id}\nNazwa: {sample.Name}\nTyp: {sample.Type}\nData: {sample.CollectionDate:yyyy-MM-dd}";

        using var qrGenerator = new QRCodeGenerator();
        using var qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
        

        using var qrCode = new PngByteQRCode(qrCodeData);
        byte[] qrCodeImageBytes = qrCode.GetGraphic(10);

        using var stream = new MemoryStream(qrCodeImageBytes);
        return new Bitmap(stream);
    }
    
    public void ExportQrCodeToFile(BiologicalSample sample, string filePath)
    {
        string payload = $"ID: {sample.Id}\nNazwa: {sample.Name}\nTyp: {sample.Type}\nData: {sample.CollectionDate:yyyy-MM-dd}";

        using var qrGenerator = new QRCodeGenerator();
        using var qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
        
        using var qrCode = new PngByteQRCode(qrCodeData);
        byte[] qrCodeImageBytes = qrCode.GetGraphic(20);

        File.WriteAllBytes(filePath, qrCodeImageBytes);
    }
}