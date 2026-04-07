

using CarAdsApp.MVVM.ViewModels;

namespace CarAdsApp.MVVM.Views;

public partial class MojeOgloszeniaStrona : ContentPage
{
    public MojeOgloszeniaViewModel ViewModel { get; set; }

    public MojeOgloszeniaStrona()
    {
        InitializeComponent();
        ViewModel = new MojeOgloszeniaViewModel();
        BindingContext = ViewModel;
    }
}