using System.Collections.ObjectModel;
using CarAdsApp.BazaDanych;
using CarAdsApp.Modele;

namespace CarAdsApp.ModeleWidokow;

public class StronaGlownaWidokModel
{
    private readonly BazaSQLite _baza;

    public static StronaGlownaWidokModel Instancja;

    private List<OgloszenieSamochodu> WszystkieOgloszenia =
        new();

    public ObservableCollection<OgloszenieSamochodu> Ogloszenia
    { get; set; } = new();

    public ObservableCollection<string> Marki
    { get; set; } = new();

    public ObservableCollection<string> Paliwa
    { get; set; } = new();

    private string _wybranaMarka;

    public string WybranaMarka
    {
        get => _wybranaMarka;
        set
        {
            _wybranaMarka = value;
            Filtruj();
        }
    }

    private string _wybranePaliwo;

    public string WybranePaliwo
    {
        get => _wybranePaliwo;
        set
        {
            _wybranePaliwo = value;
            Filtruj();
        }
    }

    public int RokOd { get; set; }
    public int RokDo { get; set; }

    public int PrzebiegOd { get; set; }
    public int PrzebiegDo { get; set; }

    public StronaGlownaWidokModel(BazaSQLite baza)
    {
        _baza = baza;

        Instancja = this;

        _ = Zaladuj();
    }

    public async Task DodajNoweOgloszenie(
        OgloszenieSamochodu ogloszenie)
    {
        WszystkieOgloszenia.Insert(0, ogloszenie);

        if (!Marki.Contains(ogloszenie.Marka))
        {
            Marki.Add(ogloszenie.Marka);
        }

        if (!Paliwa.Contains(ogloszenie.Paliwo))
        {
            Paliwa.Add(ogloszenie.Paliwo);
        }

        Filtruj();

        await Task.CompletedTask;
    }

    private async Task Zaladuj()
    {
        WszystkieOgloszenia =
            await _baza.PobierzOgloszenia();

        WszystkieOgloszenia =
            WszystkieOgloszenia
            .OrderByDescending(x => x.Id)
            .ToList();

        Ogloszenia.Clear();
        Marki.Clear();
        Paliwa.Clear();

        Marki.Add("Wszystkie");
        Paliwa.Add("Wszystkie");

        foreach (var item in WszystkieOgloszenia)
        {
            Ogloszenia.Add(item);

            if (!Marki.Contains(item.Marka))
            {
                Marki.Add(item.Marka);
            }

            if (!Paliwa.Contains(item.Paliwo))
            {
                Paliwa.Add(item.Paliwo);
            }
        }

        WybranaMarka = "Wszystkie";
        WybranePaliwo = "Wszystkie";
    }

    public void Filtruj()
    {
        Ogloszenia.Clear();

        var lista = WszystkieOgloszenia.AsEnumerable();

        // MARKA
        if (!string.IsNullOrWhiteSpace(WybranaMarka)
            && WybranaMarka != "Wszystkie")
        {
            lista = lista.Where(x =>
                x.Marka == WybranaMarka);
        }

        // PALIWO
        if (!string.IsNullOrWhiteSpace(WybranePaliwo)
            && WybranePaliwo != "Wszystkie")
        {
            lista = lista.Where(x =>
                x.Paliwo == WybranePaliwo);
        }

        // ROCZNIK
        if (RokOd > 0)
        {
            lista = lista.Where(x =>
                x.RokProdukcji >= RokOd);
        }

        if (RokDo > 0)
        {
            lista = lista.Where(x =>
                x.RokProdukcji <= RokDo);
        }

        // PRZEBIEG
        if (PrzebiegOd > 0)
        {
            lista = lista.Where(x =>
                x.Przebieg >= PrzebiegOd);
        }

        if (PrzebiegDo > 0)
        {
            lista = lista.Where(x =>
                x.Przebieg <= PrzebiegDo);
        }

        foreach (var item in lista)
        {
            Ogloszenia.Add(item);
        }
    }
}