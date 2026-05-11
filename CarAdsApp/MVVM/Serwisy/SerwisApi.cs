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
                Marka = "Toyota",
                Model = "Celica",
                Opis = "Bardzo zadbany samochód",
                Cena = 24000,
                Paliwo = "Benzyna",
                Przebieg = 180000,
                Vin = "JT164AEB109023098",
                RokProdukcji = 1998,
                Pojemnosc = 2.0,
                NumerTelefonu = "500600700",
                Lokalizacja = "Kraków",
                Zdjecie1 = "https://i.imgur.com/ETzimrm.jpg",
                Zdjecie2 = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTSY2S0LPtJqyH9yEtoL40_9H8riqqbvmAcBg&s",
                Zdjecie3 = "https://i.iplsc.com/000A4V1THI8K7ATA-C323-F4.webp"
            },
            new OgloszenieSamochodu
            {
                Marka = "Honda",
                Model = "Civic",
                Opis = "Do remontu",
                Cena = 7800,
                Paliwo = "Benzyna",
                Przebieg = 220000,
                Vin = "JH236767671232459",
                RokProdukcji = 1999,
                Pojemnosc = 1.6,
                NumerTelefonu = "600700800",
                Lokalizacja = "Warszawa",
                Zdjecie1 = "https://media.carsandbids.com/cdn-cgi/image/width=2080,quality=70/4822e9034b0b6b357b3f73fabdfc10e586c36f68/photos/KVN4NewP-rGsPb_3SR_-(edit).jpg?t=171915875007",
                Zdjecie2 = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQg34QbMZ7ORjFgFQ1EHjvIMF9Qg-lH8Z2VDw&s",
                Zdjecie3 = "https://images.customwheeloffset.com/web-compressed/776368-4-1999-civic-honda-ex-d2-racing-coilovers-gram-lights-57dr-black.jpg"
            },
            new OgloszenieSamochodu
            {
                Marka = "Honda",
                Model = "Integra",
                Opis = "Stan kolekcjonerski",
                Cena = 140000,
                Paliwo = "Benzyna",
                Przebieg = 160500,
                Vin = "JH236767671123098",
                RokProdukcji = 1999,
                Pojemnosc = 1.8,
                NumerTelefonu = "600700490",
                Lokalizacja = "Warszawa",
                Zdjecie1 = "https://media.carsandbids.com/cdn-cgi/image/width=2080,quality=70/d9b636c2ec84ddc3bc7f2eb32861b39bdd5f9683/photos/3qy08Wby-y6jG4nVleL-(edit).jpg?t=165739850499",
                Zdjecie2 = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSGLO3vFecv2oJuZQ67tvbnWiSdgNVAYuxlAw&s",
                Zdjecie3 = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTFkizEtHnAN_hRoFta0K2_X_x-uGH21ByfuA&s"
            },
            new OgloszenieSamochodu
            {
                Marka = "Toyota",
                Model = "Celica GT-FOUR",
                Opis = "Bardzo dobry stan",
                Cena = 65800,
                Paliwo = "Benzyna",
                Przebieg = 160000,
                Vin = "JT236767671232459",
                RokProdukcji = 1995,
                Pojemnosc = 2.0,
                NumerTelefonu = "234059900",
                Lokalizacja = "Zakopane",
                Zdjecie1 = "https://otoklasyki.pl/media/cache/poster_medium/toyota-celica-gt4-st205-1582548812613_63ceb5cc3f3fd.webp",
                Zdjecie2 = "https://i.ytimg.com/vi/mWSs6pTXSFE/maxresdefault.jpg",
                Zdjecie3 = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcStIBO6ri1_VCXEFXCDnU16dENN_naVy7ZIyA&s"
            },
            new OgloszenieSamochodu
            {
                Marka = "Toyota",
                Model = "Corolla e11",
                Opis = "Pakiet TTE",
                Cena = 9000,
                Paliwo = "Benzyna",
                Przebieg = 320000,
                Vin = "JT152AEB103072440",
                RokProdukcji = 1998,
                Pojemnosc = 1.6,
                NumerTelefonu = "120934872",
                Lokalizacja = "Gdansk",
                Zdjecie1 = "https://cloud.leparking.fr/2024/02/09/17/04/toyota-corolla-toyota-toyota-corolla-e11-g6s-by-tte-nr-70-250_9009251004.jpg",
                Zdjecie2 = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRJEnQYRQFFNPaRC9WeIF-Di5Ded9iooPW8oQ&s",
                Zdjecie3 = "https://shop.mcgautostyling.com/wp-content/uploads/2023/08/tte_rear_lip.jpg"
            },
        };
    }
}