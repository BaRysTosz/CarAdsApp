using SQLite;
using CarAdsApp.Modele;

namespace CarAdsApp.BazaDanych;

public class BazaSQLite
{
    private SQLiteAsyncConnection _baza;

    public async Task Inicjalizuj()
    {
        if (_baza != null)
            return;

        var sciezka = Path.Combine(FileSystem.AppDataDirectory, "ogloszenia.db3");

        _baza = new SQLiteAsyncConnection(sciezka);

        await _baza.CreateTableAsync<OgloszenieSamochodu>();
    }

    public async Task<List<OgloszenieSamochodu>> PobierzOgloszenia()
    {
        await Inicjalizuj();
        return await _baza.Table<OgloszenieSamochodu>().ToListAsync();
    }

    public async Task DodajOgloszenie(OgloszenieSamochodu ogloszenie)
    {
        await Inicjalizuj();
        await _baza.InsertAsync(ogloszenie);
    }

    public async Task<int> LiczbaOgloszen()
    {
        await Inicjalizuj();
        return await _baza.Table<OgloszenieSamochodu>().CountAsync();
    }
}