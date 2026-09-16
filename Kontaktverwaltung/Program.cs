using Kontaktverwaltung;

List<Kontakt> kontakte = new List<Kontakt>();
string dateiname = "kontakte.txt";

KontakteLaden();

bool weiterMachen = true;

while (weiterMachen)
{
    Console.WriteLine();
    Console.WriteLine("=== KONTAKTVERWALTUNG ===");
    Console.WriteLine("1) Kontakt hinzufuegen");
    Console.WriteLine("2) Alle Kontakte anzeigen");
    Console.WriteLine("3) Kontakt suchen");
    Console.WriteLine("4) Kontakt loeschen");
    Console.WriteLine("5) Beenden");
    Console.Write("Auswahl: ");

    string? auswahl = Console.ReadLine();

    switch (auswahl)
    {
        case "1":
            KontaktHinzufuegen();
            break;

        case "2":
            AlleAnzeigen();
            break;

        case "3":
            KontaktSuchen();
            break;

        case "4":
            KontaktLoeschen();
            break;

        case "5":
            weiterMachen = false;
            break;

        default:
            Console.WriteLine("Ungueltige Eingabe.");
            break;
    }
}

Console.WriteLine("Programm beendet.");


void KontaktHinzufuegen()
{
    Console.Write("Name: ");
    string? name = Console.ReadLine();
    if (name == null)
    {
        name = "";
    }

    Console.Write("Telefon: ");
    string? telefon = Console.ReadLine();
    if (telefon == null)
    {
        telefon = "";
    }

    Console.Write("Email: ");
    string? email = Console.ReadLine();
    if (email == null)
    {
        email = "";
    }

    kontakte.Add(new Kontakt(name, telefon, email));
    KontakteSpeichern();

    Console.WriteLine("Kontakt gespeichert.");
}

void AlleAnzeigen()
{
    if (kontakte.Count == 0)
    {
        Console.WriteLine("Keine Kontakte vorhanden.");
        return;
    }

    for (int i = 0; i < kontakte.Count; i++)
    {
        Console.Write($"{i + 1}) ");
        kontakte[i].Anzeigen();
    }
}

void KontaktSuchen()
{
    Console.Write("Suchbegriff (Name): ");
    string? suchbegriff = Console.ReadLine();
    if (suchbegriff == null)
    {
        suchbegriff = "";
    }

    var treffer = kontakte.Where(k => k.Name.ToLower().Contains(suchbegriff.ToLower())).ToList();

    if (treffer.Count == 0)
    {
        Console.WriteLine("Nichts gefunden.");
        return;
    }

    foreach (var kontakt in treffer)
    {
        kontakt.Anzeigen();
    }
}

void KontaktLoeschen()
{
    AlleAnzeigen();

    if (kontakte.Count == 0)
    {
        return;
    }

    Console.Write("Welchen Kontakt loeschen (Nummer)? ");
    string? eingabe = Console.ReadLine();

    if (!int.TryParse(eingabe, out int nummer))
    {
        Console.WriteLine("Das war keine Zahl.");
        return;
    }

    int index = nummer - 1;

    if (index < 0 || index >= kontakte.Count)
    {
        Console.WriteLine("Diese Nummer gibt es nicht.");
        return;
    }

    kontakte.RemoveAt(index);
    KontakteSpeichern();
    Console.WriteLine("Kontakt geloescht.");
}

void KontakteSpeichern()
{
    var zeilen = kontakte.Select(k => k.ZuTextZeile());
    File.WriteAllLines(dateiname, zeilen);
}

void KontakteLaden()
{
    if (!File.Exists(dateiname))
    {
        return;
    }

    foreach (string zeile in File.ReadAllLines(dateiname))
    {
        string[] teile = zeile.Split(";");

        if (teile.Length == 3)
        {
            kontakte.Add(new Kontakt(teile[0], teile[1], teile[2]));
        }
    }
}
