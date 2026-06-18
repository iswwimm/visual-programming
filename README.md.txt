# BioNotepad 

BioNotepad to desktopowy notatnik analityczny zaprojektowany z myślą o bioinformatykach i biologach molekularnych. Aplikacja ułatwia zarządzanie sesjami eksperymentalnymi, logowanie postępów analizy, bezpieczne przechowywanie plików wsadowych (np. `.fasta`, `.csv`) oraz generowanie końcowych raportów w formacie PDF.

## Technologie i Architektura

Projekt został zrealizowany zgodnie z dobrymi praktykami inżynierii oprogramowania, wykorzystując wzorzec **MVVM** (Model-View-ViewModel).

- **Język:** C# 12
- **Framework:** .NET 10.0
- **Interfejs Użytkownika:** Avalonia UI (XAML)
- **Baza Danych:** SQLite (via Entity Framework Core 8/9)
- **Generowanie PDF:** QuestPDF
- **Zarządzanie stanem:** CommunityToolkit.Mvvm

## Główne Funkcjonalności

1. **Zarządzanie Sesjami:** Tworzenie i przeglądanie izolowanych sesji analitycznych.
2. **Dziennik Zdarzeń:** Dodawanie tekstowych wpisów opisujących parametry uruchomienia skryptów, logi błędów czy obserwacje z analizy.
3. **Bezpieczne Załączniki:** Możliwość podpinania plików (np. `.fasta`, `.png`) pod konkretne wpisy. Pliki są automatycznie kopiowane do bezpiecznego, wewnętrznego katalogu aplikacji (`AppData/Local/BioNotepad`), chroniąc je przed przypadkowym usunięciem przez użytkownika.
4. **Eksport do PDF:** Generowanie czytelnych raportów podsumowujących całą sesję, gotowych do wydruku lub archiwizacji.

## Uruchomienie Projektu (Development)

1. Sklonuj repozytorium na swój dysk.
2. Otwórz plik `BioNotepad.sln` w środowisku IDE (rekomendowany JetBrains Rider lub Visual Studio).
3. Przywróć pakiety NuGet:
   ```bash
   dotnet restore