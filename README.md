# Kontaktverwaltung

Konsolenprogramm in C#. Kontakte anlegen, anzeigen, suchen, loeschen.
Wird in einer Textdatei gespeichert, damit die Kontakte auch nach dem
Beenden noch da sind.

## Starten

Braucht .NET 8 SDK.

```
cd Kontaktverwaltung
dotnet run
```

## Struktur

- Kontakt.cs - die Kontakt-Klasse (Name, Telefon, Email)
- Program.cs - Menue und die ganze Logik

## Was das Projekt zeigt

- Eigene Klasse mit Konstruktor
- Liste (List<Kontakt>) zum Speichern mehrerer Objekte
- Konsolen-Menue mit switch-case
- Suche mit LINQ (Where)
- Speichern und Laden aus einer Textdatei (File.WriteAllLines / ReadAllLines)
