using CarAdsApp.ModeleWidokow;

namespace CarAdsApp.Widoki;

public partial class StronaGlowna : ContentPage
{
    private readonly StronaGlownaWidokModel _widokModel;

    public StronaGlowna(
        StronaGlownaWidokModel widokModel)
    {
        InitializeComponent();

        _widokModel = widokModel;

        BindingContext = _widokModel;
    }

    private void FiltrujClicked(
        object sender,
        EventArgs e)
    {
        _widokModel.Filtruj();
    }
}