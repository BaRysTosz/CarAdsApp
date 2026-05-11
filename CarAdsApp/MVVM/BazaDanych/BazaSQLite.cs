using SQLite;
using CarAdsApp.Modele;
using CarAdsApp.Serwisy;

namespace CarAdsApp.BazaDanych;

public class BazaSQLite
{
    private readonly SQLiteAsyncConnection _baza;
    private readonly SerwisApi _api;

    public BazaSQLite(SerwisApi api)
    {
        _api = api;

        string sciezka =
            Path.Combine(
                FileSystem.AppDataDirectory,
                "ogloszenia.db3");

        // USUNIĘCIE STAREJ BAZY
        //if (File.Exists(sciezka))
        //{
            //File.Delete(sciezka);
        //}

        _baza = new SQLiteAsyncConnection(sciezka);
    }

    public async Task Inicjalizuj()
    {
        await _baza.CreateTableAsync<OgloszenieSamochodu>();

        var istnieja =
            await _baza.Table<OgloszenieSamochodu>()
            .CountAsync();

        if (istnieja == 0)
        {
            var dane =
                await _api.PobierzPoczatkoweOgloszenia();

            foreach (var item in dane)
            {
                await _baza.InsertAsync(item);
            }
        }
    }

    public async Task<List<OgloszenieSamochodu>>
        PobierzOgloszenia()
    {
        await Inicjalizuj();

        return await _baza.Table<OgloszenieSamochodu>()
            .ToListAsync();
    }

    public async Task DodajOgloszenie(
        OgloszenieSamochodu ogloszenie)
    {
        await Inicjalizuj();

        await _baza.InsertAsync(ogloszenie);
    }
}