using SQLite;

namespace CarAdsApp.Modele;

public class OgloszenieSamochodu
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string Marka { get; set; }
    public string Model { get; set; }
    public string Opis { get; set; }
    public decimal Cena { get; set; }
    public string Paliwo { get; set; }
    public int Przebieg { get; set; }
    public string Vin { get; set; }
    public int RokProdukcji { get; set; }
    public double Pojemnosc { get; set; }
    public string NumerTelefonu { get; set; }
    public string Lokalizacja { get; set; }

    public string Zdjecie1 { get; set; }
    public string Zdjecie2 { get; set; }
    public string Zdjecie3 { get; set; }

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