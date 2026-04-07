using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using CarAdsApp.MVVM.Models;

namespace CarAdsApp.Services;

public static class SerwisDanych
{
    public static ObservableCollection<OgloszenieSamochodu> Ogloszenia { get; set; }
        = new ObservableCollection<OgloszenieSamochodu>
    {
        new OgloszenieSamochodu
        {
            Tytul = "BMW E46",
            Cena = "8000 zł",
            Lokalizacja = "Kraków",
            ZdjecieUrl = "https://via.placeholder.com/300x150"
        },
        new OgloszenieSamochodu
        {
            Tytul = "Audi A4",
            Cena = "12000 zł",
            Lokalizacja = "Warszawa",
            ZdjecieUrl = "https://via.placeholder.com/300x150"
        },
        new OgloszenieSamochodu
        {
            Tytul = "Golf V",
            Cena = "7000 zł",
            Lokalizacja = "Gdańsk",
            ZdjecieUrl = "https://via.placeholder.com/300x150"
        }
    };
}