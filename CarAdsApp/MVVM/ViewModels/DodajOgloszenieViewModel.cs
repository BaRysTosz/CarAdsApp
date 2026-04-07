using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Input;
using CarAdsApp.MVVM.Models;
using CarAdsApp.Services;

namespace CarAdsApp.MVVM.ViewModels;

public class DodajOgloszenieViewModel
{
    public string Tytul { get; set; }
    public string Cena { get; set; }
    public string Lokalizacja { get; set; }
    public string ZdjecieUrl { get; set; } = "https://via.placeholder.com/300x150";

    public ICommand DodajKomenda { get; set; }

    public DodajOgloszenieViewModel()
    {
        DodajKomenda = new Command(DodajOgloszenie);
    }

    private void DodajOgloszenie()
    {
        var nowe = new OgloszenieSamochodu
        {
            Tytul = this.Tytul,
            Cena = this.Cena,
            Lokalizacja = this.Lokalizacja,
            ZdjecieUrl = this.ZdjecieUrl,
            CzyMoje = true
        };

        SerwisDanych.Ogloszenia.Add(nowe);

        Tytul = Cena = Lokalizacja = "";
    }
}
