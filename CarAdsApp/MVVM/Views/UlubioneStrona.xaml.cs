using CarAdsApp.MVVM.ViewModels;

namespace CarAdsApp.MVVM.Views;

public partial class UlubioneStrona : ContentPage
{
    public UlubioneStrona()
    {
        InitializeComponent();
        BindingContext = new UlubioneViewModel();
    }
}