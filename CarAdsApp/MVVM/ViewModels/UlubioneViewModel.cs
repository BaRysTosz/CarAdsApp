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

public class UlubioneViewModel
{
    public ObservableCollection<OgloszenieSamochodu> Ulubione { get; set; }

    public UlubioneViewModel()
    {
        Ulubione = new ObservableCollection<OgloszenieSamochodu>(
            SerwisDanych.Ogloszenia.Where(o => o.CzyUlubione)
        );
    }
}
