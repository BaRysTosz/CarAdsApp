using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using System.Windows.Input;
using CarAdsApp.MVVM.Models;
using CarAdsApp.Services;

namespace CarAdsApp.MVVM.ViewModels;

public class WszystkieOgloszeniaViewModel
{
    public ObservableCollection<OgloszenieSamochodu> Ogloszenia { get; set; }

    public ICommand PolubKomenda { get; set; }

    public WszystkieOgloszeniaViewModel()
    {
        Ogloszenia = SerwisDanych.Ogloszenia;

        PolubKomenda = new Command<OgloszenieSamochodu>(Polub);
    }

    private void Polub(OgloszenieSamochodu ogloszenie)
    {
        ogloszenie.CzyUlubione = !ogloszenie.CzyUlubione;
    }
}