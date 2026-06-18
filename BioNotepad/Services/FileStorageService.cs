using System;
using System.IO;

namespace BioNotepad.Services;

public static class FileStorageService
{
    public static string SaveAttachmentLocally(string originalFilePath)
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        var attachmentsDir = Path.Join(path, "BioNotepad", "Attachments");
        
        Directory.CreateDirectory(attachmentsDir);

        var fileName = Path.GetFileName(originalFilePath);
        var uniqueFileName = $"{Guid.NewGuid()}_{fileName}";
        var destinationPath = Path.Join(attachmentsDir, uniqueFileName);

        File.Copy(originalFilePath, destinationPath, overwrite: true);

        return destinationPath;
    }
}