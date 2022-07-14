namespace AutoPopulatePage.Views;

public partial class LocalDbPage : ContentPage
{
    private static LocalDb localDb;

    public LocalDbPage()
    {
        InitializeComponent();
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        cvOfflineNotes.ItemsSource = await LocalDbPage.LocalDb.GetOfflineNotesAsync();
        base.OnNavigatedTo(args);
    }

    public static LocalDb LocalDb
    {
        get
        {
            if (localDb == null)
            {
                localDb = new
                    LocalDb(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "OfflineNote.db3"));
            }
            return localDb;
        }
    }

    async void OnButtonClicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(entryOfflineNote.Text))
        {
            await LocalDbPage.LocalDb.SaveOfflineNoteAsync(new OfflineNote
            {
                Note = entryOfflineNote.Text
            });

            entryOfflineNote.Text = string.Empty;

            cvOfflineNotes.ItemsSource = await LocalDbPage.LocalDb.GetOfflineNotesAsync();
        }
    }
}