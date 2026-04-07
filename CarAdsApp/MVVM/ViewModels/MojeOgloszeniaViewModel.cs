using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using System.Linq;
using CarAdsApp.MVVM.Models;
using CarAdsApp.Services;

namespace CarAdsApp.MVVM.ViewModels;

public class MojeOgloszeniaViewModel
{
    public ObservableCollection<OgloszenieSamochodu> MojeOgloszenia { get; set; }

    public MojeOgloszeniaViewModel()
    {
        MojeOgloszenia = new ObservableCollection<OgloszenieSamochodu>(
            SerwisDanych.Ogloszenia.Where(o => o.CzyMoje)
        );
    }
}
