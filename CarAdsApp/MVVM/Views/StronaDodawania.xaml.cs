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
    public void ShowBladMarkaCaption() => BladMarka.IsVisible = true;
    public void ShowBladModelCaption() => BladModel.IsVisible = true;
    public void ShowBladCenaCaption() => BladCena.IsVisible = true;
    public void ShowBladPaliwoCaption() => BladPaliwo.IsVisible = true;
    public void ShowBladPrzebiegCaption() => BladPrzebieg.IsVisible = true;
    public void ShowBladVinCaption() => BladVin.IsVisible = true;
    public void ShowBladRokCaption() => BladRok.IsVisible = true;
    public void ShowBladPojemnoscCaption() => BladPojemnosc.IsVisible = true;

    public void ResetAllCaption()
    {
        BladMarka.IsVisible = false;
        BladModel.IsVisible = false;
        BladCena.IsVisible = false;
        BladPaliwo.IsVisible = false;
        BladPrzebieg.IsVisible = false;
        BladVin.IsVisible = false;
        BladRok.IsVisible = false;
        BladPojemnosc.IsVisible = false;
    }
    private void Button_Clicked(object sender, EventArgs e)
    {

    }
}