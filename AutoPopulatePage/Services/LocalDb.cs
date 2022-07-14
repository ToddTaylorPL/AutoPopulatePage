
namespace AutoPopulatePage.Services;
public class LocalDb
{
    private readonly SQLiteAsyncConnection _database;
    
    public LocalDb(string dbPath)
    {
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<OfflineNote>();
    }

    public Task<List<OfflineNote>> GetOfflineNotesAsync()
    {
        return _database.Table<OfflineNote>().ToListAsync();
    }

    public Task<int> SaveOfflineNoteAsync(OfflineNote offlineNote)
    {
        return _database.InsertAsync(offlineNote);
    }
}
