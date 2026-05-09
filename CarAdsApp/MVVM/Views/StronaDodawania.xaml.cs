using CarAdsApp.ModeleWidokow;
using System.Linq;

namespace CarAdsApp.Widoki;

public partial class StronaDodawania : ContentPage
{
    public StronaDodawania(DodajOgloszenieWidokModel widokModel)
    {
        InitializeComponent();
        BindingContext = widokModel;
    }
}