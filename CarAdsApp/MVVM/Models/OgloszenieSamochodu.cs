using SQLite;

namespace CarAdsApp.Modele;

public class OgloszenieSamochodu
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string Marka { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public string Opis { get; set; } = string.Empty;
    public decimal Cena { get; set; }
    public string Paliwo { get; set; } = string.Empty;
    public int Przebieg { get; set; }
    public string Vin { get; set; } = string.Empty;
    public int RokProdukcji { get; set; }
    public double Pojemnosc { get; set; }
    public string NumerTelefonu { get; set; } = string.Empty;
    public string Lokalizacja { get; set; } = string.Empty;

    public string Zdjecie1 { get; set; } = string.Empty;
    public string Zdjecie2 { get; set; } = string.Empty;
    public string Zdjecie3 { get; set; } = string.Empty;

    [Ignore]
    public List<string> Zdjecia =>
        new()
        {
            Zdjecie1,
            Zdjecie2,
            Zdjecie3
        };
    [Ignore]
    public int IndexZdjecia { get; set; }

    [Ignore]
    public List<string> ListaZdjec =>
        new() { Zdjecie1, Zdjecie2, Zdjecie3 };

}