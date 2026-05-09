using System.Windows.Input;
using CarAdsApp.BazaDanych;
using CarAdsApp.Modele;

namespace CarAdsApp.ModeleWidokow;

public class DodajOgloszenieWidokModel
{
    private readonly BazaSQLite _baza;

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

    public ICommand DodajCommand { get; }

    public DodajOgloszenieWidokModel(BazaSQLite baza)
    {
        _baza = baza;

        DodajCommand = new Command(async () => await Dodaj());
    }

    private async Task Dodaj()
    {
        var ogloszenie = new OgloszenieSamochodu
        {
            Marka = Marka,
            Model = Model,
            Opis = Opis,
            Cena = Cena,
            Paliwo = Paliwo,
            Przebieg = Przebieg,
            Vin = Vin,
            RokProdukcji = RokProdukcji,
            Pojemnosc = Pojemnosc,
            NumerTelefonu = NumerTelefonu,
            Lokalizacja = Lokalizacja,
            Zdjecie1 = Zdjecie1,
            Zdjecie2 = Zdjecie2,
            Zdjecie3 = Zdjecie3
        };

        await _baza.DodajOgloszenie(ogloszenie);

        await Application.Current.MainPage.DisplayAlert(
            "Sukces",
            "Dodano ogłoszenie",
            "OK");
    }
}