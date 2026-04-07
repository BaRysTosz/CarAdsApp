using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAdsApp.MVVM.Models;

public class OgloszenieSamochodu
{
    public string? Tytul { get; set; }
    public string? Cena { get; set; }
    public string? Lokalizacja { get; set; }
    public string? ZdjecieUrl { get; set; }

    public bool CzyUlubione { get; set; }
}