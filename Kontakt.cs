namespace Kontaktverwaltung;

public class Kontakt
{
    public string Name;
    public string Telefon;
    public string Email;

    public Kontakt(string name, string telefon, string email)
    {
        Name = name;
        Telefon = telefon;
        Email = email;
    }

    public void Anzeigen()
    {
        Console.WriteLine($"{Name} - Tel: {Telefon} - Email: {Email}");
    }

    public string ZuTextZeile()
    {
        return $"{Name};{Telefon};{Email}";
    }
}
