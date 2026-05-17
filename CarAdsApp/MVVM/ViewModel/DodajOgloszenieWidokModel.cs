using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CarAdsApp.BazaDanych;
using CarAdsApp.Modele;

namespace CarAdsApp.ModeleWidokow;

public class DodajOgloszenieWidokModel
    : INotifyPropertyChanged
{
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

    private decimal _cena;
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

    private int _przebieg;
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

    private double _pojemnosc;
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

    public ICommand DodajCommand { get; }

    public DodajOgloszenieWidokModel(BazaSQLite baza)
    {
        _baza = baza;

        DodajCommand =
            new Command(async () => await Dodaj());
    }

    private async Task Dodaj()
    {
        var ogloszenie =
            new OgloszenieSamochodu
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
}