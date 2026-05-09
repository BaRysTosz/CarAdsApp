using CarAdsApp.Modele;

namespace CarAdsApp.Serwisy;

public class SerwisApi
{
    public async Task<List<OgloszenieSamochodu>> PobierzPoczatkoweOgloszenia()
    {
        await Task.Delay(1000);

        return new List<OgloszenieSamochodu>
        {
            new OgloszenieSamochodu
            {
                Marka = "BMW",
                Model = "320d",
                Opis = "Bardzo zadbany samochód",
                Cena = 85000,
                Paliwo = "Diesel",
                Przebieg = 180000,
                Vin = "WBATEST123456",
                RokProdukcji = 2018,
                Pojemnosc = 2.0,
                NumerTelefonu = "500600700",
                Lokalizacja = "Kraków",
                Zdjecie1 = "https://images.unsplash.com/photo-1555215695-3004980ad54e",
                Zdjecie2 = "https://images.unsplash.com/photo-1492144534655-ae79c964c9d7",
                Zdjecie3 = "https://images.unsplash.com/photo-1503376780353-7e6692767b70"
            },
            new OgloszenieSamochodu
            {
                Marka = "Audi",
                Model = "A4",
                Opis = "Auto w idealnym stanie",
                Cena = 92000,
                Paliwo = "Benzyna",
                Przebieg = 120000,
                Vin = "AUDI123456789",
                RokProdukcji = 2019,
                Pojemnosc = 2.0,
                NumerTelefonu = "600700800",
                Lokalizacja = "Warszawa",
                Zdjecie1 = "https://images.unsplash.com/photo-1542282088-fe8426682b8f",
                Zdjecie2 = "https://images.unsplash.com/photo-1502877338535-766e1452684a",
                Zdjecie3 = "https://images.unsplash.com/photo-1494976388531-d1058494cdd8"
            }
        };
    }
}