using CarAdsApp.BazaDanych;
using CarAdsApp.Modele;
using CarAdsApp.Serwisy;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Linq;

public partial class StronaGlownaWidokModel : ObservableObject
{
    private readonly BazaSQLite _baza;
    private readonly SerwisApi _api;

    public ObservableCollection<OgloszenieSamochodu> Ogloszenia { get; set; } = new();

    public ObservableCollection<string> Marki { get; set; } = new();

    [ObservableProperty]
    private string wybranaMarka;
    [ObservableProperty]
    private OgloszenieSamochodu zaznaczoneOgloszenie;

    public StronaGlownaWidokModel(BazaSQLite baza, SerwisApi api)
    {
        _baza = baza;
        _api = api;

        Task.Run(async () => await ZaladujOgloszenia());
    }
    [RelayCommand]
    void NastepneZdjecie()
    {
        if (ZaznaczoneOgloszenie == null) return;

        ZaznaczoneOgloszenie.IndexZdjecia++;

        if (ZaznaczoneOgloszenie.IndexZdjecia > 2)
            ZaznaczoneOgloszenie.IndexZdjecia = 0;
    }
    [RelayCommand]
    public async Task ZaladujOgloszenia()
    {
        Ogloszenia.Clear();
        Marki.Clear();

        if (await _baza.LiczbaOgloszen() == 0)
        {
            var startowe = await _api.PobierzPoczatkoweOgloszenia();

            foreach (var ogloszenie in startowe)
            {
                await _baza.DodajOgloszenie(ogloszenie);
            }
        }

        var lista = await _baza.PobierzOgloszenia();

        foreach (var ogloszenie in lista)
        {
            Ogloszenia.Add(ogloszenie);

            if (!Marki.Contains(ogloszenie.Marka))
            {
                Marki.Add(ogloszenie.Marka);
            }
        }
    }

    partial void OnWybranaMarkaChanged(string value)
    {
        Task.Run(async () => await Filtruj());
    }

    private async Task Filtruj()
    {
        Ogloszenia.Clear();

        var lista = await _baza.PobierzOgloszenia();

        if (string.IsNullOrWhiteSpace(WybranaMarka))
        {
            foreach (var ogloszenie in lista)
            {
                Ogloszenia.Add(ogloszenie);
            }
        }
        else
        {
            foreach (var ogloszenie in lista.Where(x => x.Marka == WybranaMarka))
            {
                Ogloszenia.Add(ogloszenie);
            }
        }
    }
}