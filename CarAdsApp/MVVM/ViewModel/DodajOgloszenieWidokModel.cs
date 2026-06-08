using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CarAdsApp.BazaDanych;
using CarAdsApp.Modele;
using CarAdsApp.Widoki;

namespace CarAdsApp.ModeleWidokow;

public class DodajOgloszenieWidokModel : INotifyPropertyChanged
{
    private List<OgloszenieSamochodu> WszystkieOgloszenia = new();
    private readonly BazaSQLite _baza;

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged(
        [CallerMemberName] string nazwa = null!)
    {
        PropertyChanged?.Invoke(
            this,
            new PropertyChangedEventArgs(nazwa));
    }

    private string _marka = string.Empty;
    public required string Marka
    {
        get => _marka;
        set
        {
            if (_marka != value)
            {
                _marka = value;
                OnPropertyChanged();
            }
            
        }
    }

    private string _model = string.Empty;
    public string Model
    {
        get => _model;
        set
        {
            if(_model != value)
            {
                _model = value;
                OnPropertyChanged();
            }
            
        }
    }

    private string _opis = string.Empty;
    public string Opis
    {
        get => _opis;
        set
        {
            _opis = value;
            OnPropertyChanged();
        }
    }

    private decimal _cena = 0;
    public decimal Cena
    {
        get => _cena;
        set
        {
            _cena = value;
            OnPropertyChanged();
        }
    }

    private string _paliwo = string.Empty;
    public string Paliwo
    {
        get => _paliwo;
        set
        {
            _paliwo = value;
            OnPropertyChanged();
        }
    }

    private int _przebieg = 0;
    public int Przebieg
    {
        get => _przebieg;
        set
        {
            _przebieg = value;
            OnPropertyChanged();
        }
    }

    private string _vin = string.Empty;
    public string Vin
    {
        get => _vin;
        set
        {
            _vin = value;
            OnPropertyChanged();
        }
    }

    private int _rokProdukcji;
    public int RokProdukcji
    {
        get => _rokProdukcji;
        set
        {
            _rokProdukcji = value;
            OnPropertyChanged();
        }
    }

    private double _pojemnosc = 0;
    public double Pojemnosc
    {
        get => _pojemnosc;
        set
        {
            _pojemnosc = value;
            OnPropertyChanged();
        }
    }

    private string _numerTelefonu = string.Empty;
    public string NumerTelefonu
    {
        get => _numerTelefonu;
        set
        {
            _numerTelefonu = value;
            OnPropertyChanged();
        }
    }

    private string _lokalizacja = string.Empty;
    public string Lokalizacja
    {
        get => _lokalizacja;
        set
        {
            _lokalizacja = value;
            OnPropertyChanged();
        }
    }

    private string _zdjecie1 = string.Empty;
    public string Zdjecie1
    {
        get => _zdjecie1;
        set
        {
            _zdjecie1 = value;
            OnPropertyChanged();
        }
    }

    private string _zdjecie2 = string.Empty;
    public string Zdjecie2
    {
        get => _zdjecie2;
        set
        {
            _zdjecie2 = value;
            OnPropertyChanged();
        }
    }

    private string _zdjecie3 = string.Empty;
    public string Zdjecie3
    {
        get => _zdjecie3;
        set
        {
            _zdjecie3 = value;
            OnPropertyChanged();
        }
    }

    private string _wybranaMarka = string.Empty;
    public string WybranaMarka
    {
        get => _wybranaMarka;
        set
        {
            if (_wybranaMarka != value)
            {
                _wybranaMarka = value;
                Filtruj();
            }
        }
    }

    private string _wybranePaliwo = string.Empty;
    public string WybranePaliwo
    {
        get => _wybranePaliwo;
        set
        {
            if (_wybranePaliwo != value)
            {
                _wybranePaliwo = value;
                Filtruj();
            }
        }
    }

    public ICommand DodajCommand { get; }

    public DodajOgloszenieWidokModel(BazaSQLite baza)
    {
        _baza = baza;

        DodajCommand =
            new Command(async () => await Dodaj());
    }
    public async void Zaladoj()
    {
        WszystkieOgloszenia = await _baza.PobierzOgloszenia();
    }
    public void Filtruj()
    {
        

        var lista = WszystkieOgloszenia.AsEnumerable();

        // MARKA
        if (!string.IsNullOrWhiteSpace(WybranaMarka)
            && WybranaMarka != "Wszystkie")
        {
            lista = lista.Where(x =>
                x.Marka == WybranaMarka);
        }

        // PALIWO
        if (!string.IsNullOrWhiteSpace(WybranePaliwo)
            && WybranePaliwo != "Wszystkie")
        {
            lista = lista.Where(x =>
                x.Paliwo == WybranePaliwo);
        }

        
    }
    private async Task Dodaj()
    {
        var page = Shell.Current.CurrentPage as StronaDodawania;
        page?.ResetAllCaption();

        if (!String.IsNullOrWhiteSpace(Marka) &&
            !String.IsNullOrEmpty(Model) &&
            !String.IsNullOrEmpty(Paliwo) &&
            !String.IsNullOrEmpty(Vin) &&
            RokProdukcji > 0 &&
            Cena > 0 && 
            Przebieg > 0 &&
            Pojemnosc > 0 &&
            page != null)
        {
            var ogloszenie = new OgloszenieSamochodu
            {
                Marka = Marka,
                Model = Model,
                Opis = Opis,
                Cena = Cena,
                Paliwo = Paliwo,
                Przebieg = Przebieg,
                Vin = Vin,
                RokProdukcji = RokProdukcji,
                Pojemnosc = Pojemnosc,
                NumerTelefonu = NumerTelefonu,
                Lokalizacja = Lokalizacja,
                Zdjecie1 = Zdjecie1,
                Zdjecie2 = Zdjecie2,
                Zdjecie3 = Zdjecie3
            };

            await _baza.DodajOgloszenie(ogloszenie);

            if (StronaGlownaWidokModel.Instancja != null)
            {
                await StronaGlownaWidokModel
                    .Instancja
                    .DodajNoweOgloszenie(ogloszenie);
            }
            await Application.Current.MainPage.DisplayAlert(
                    "Sukces",
                    "Dodano ogłoszenie",
                    "OK");

            // RESET FORMULARZA
            Marka = "";
            Model = "";
            Opis = "";
            Cena = 0;
            Paliwo = "";
            Przebieg = 0;
            Vin = "";
            RokProdukcji = 0;
            Pojemnosc = 0;
            NumerTelefonu = "";
            Lokalizacja = "";
            Zdjecie1 = "";
            Zdjecie2 = "";
            Zdjecie3 = "";
        }
        else if (string.IsNullOrEmpty(Marka))
        {
            page?.ShowBladMarkaCaption();
            if (page != null) { page.IsVisible = true; }
        }
        else if (string.IsNullOrEmpty(Model))
        {
            page?.ShowBladModelCaption();
            if (page != null) { page.IsVisible = true; }
        }
        else if (string.IsNullOrEmpty(Paliwo))
        {
            page?.ShowBladPaliwoCaption();
            if (page != null) { page.IsVisible = true; }
        }
        else if (string.IsNullOrEmpty(Vin))
        {
            page?.ShowBladVinCaption();
            if (page != null) { page.IsVisible = true; }
        }
        else if (Cena <= 0)
        {
            page?.ShowBladCenaCaption();
            if (page != null) { page.IsVisible = true; }
        }
        else if (RokProdukcji <= 0)
        {
            page?.ShowBladRokCaption();
            if (page != null) { page.IsVisible = true; }
        }
        else if (Przebieg <= 0)
        {
            page?.ShowBladPrzebiegCaption();
            if (page != null) { page.IsVisible = true; }
        }
        else if (Pojemnosc <= 0)
        {
            page?.ShowBladPojemnoscCaption();
            if (page != null) { page.IsVisible = true; }
        }
    }
    
}