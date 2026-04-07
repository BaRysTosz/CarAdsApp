using CarAdsApp.MVVM.ViewModels;

namespace CarAdsApp.MVVM.Views;

public partial class DodajOgloszenieStrona : ContentPage
{
    public DodajOgloszenieViewModel ViewModel { get; set; }

    public DodajOgloszenieStrona()
    {
        InitializeComponent();
        ViewModel = new DodajOgloszenieViewModel();
        BindingContext = ViewModel;
    }
}