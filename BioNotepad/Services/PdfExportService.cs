using System.Linq;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using BioNotepad.Models;

namespace BioNotepad.Services;

public static class PdfExportService
{
    public static void ExportSessionToPdf(AnalysisSession session, string outputPath)
    {
        Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(2, Unit.Centimetre);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(11));
                
                page.Header().Element(compose =>
                {
                    compose.Column(column =>
                    {
                        column.Item().Text("Raport Analityczny: " + session.Title)
                            .SemiBold().FontSize(20).FontColor(Colors.Blue.Darken2);
                        column.Item().Text($"Data utworzenia: {session.CreatedAt:dd-MM-yyyy HH:mm}")
                            .FontSize(10).FontColor(Colors.Grey.Medium);
                        column.Item().PaddingTop(10).LineHorizontal(1).LineColor(Colors.Grey.Lighten2);
                    });
                });
                
                page.Content().PaddingTop(10).Column(column =>
                {
                    if (session.Entries == null || !session.Entries.Any())
                    {
                        column.Item().Text("Brak wpisów w tej sesji.");
                        return;
                    }

                    foreach (var entry in session.Entries)
                    {
                        column.Item().PaddingBottom(15).Background(Colors.Grey.Lighten4).Padding(10).Column(entryCol =>
                        {
                            entryCol.Item().Text(entry.CreatedAt.ToString("dd-MM-yyyy HH:mm:ss"))
                                .FontSize(9).FontColor(Colors.Grey.Darken1);
                            
                            entryCol.Item().PaddingTop(5).Text(entry.Description);
                            
                            if (entry.Attachments != null && entry.Attachments.Any())
                            {
                                entryCol.Item().PaddingTop(10).Text("Załączone pliki:").SemiBold().FontSize(10);
                                foreach (var att in entry.Attachments)
                                {
                                    entryCol.Item().Text($"• {att.FileName}").FontSize(9).FontColor(Colors.Blue.Darken1);
                                }
                            }
                        });
                    }
                });
                
                page.Footer().AlignCenter().Text(x =>
                {
                    x.Span("Strona ");
                    x.CurrentPageNumber();
                    x.Span(" z ");
                    x.TotalPages();
                });
            });
        })
        .GeneratePdf(outputPath);
    }
}