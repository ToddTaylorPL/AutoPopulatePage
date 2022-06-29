
namespace AutoPopulatePage.ViewModels;

[QueryProperty(nameof(User), nameof(User))]
public partial class FieldAssignedWbsViewModel : BaseViewModel
{
    [ObservableProperty]
    User user;

    FieldAssignedWbsService fieldAssignedWbsService;

    IConnectivity connectivity;

    [ObservableProperty]
    Monkey monkey;

    MonkeyService monkeyService;
    public ObservableCollection<Monkey> MonkeyList { get; set; } = new();

    public ObservableCollection<FieldAssignedWbs> WbsList { get; set; } = new();

    public FieldAssignedWbsViewModel(FieldAssignedWbsService fieldAssignedWbsService, IConnectivity connectivity, MonkeyService monkeyService)
    {
        Title = "WBS Assigned";
        this.fieldAssignedWbsService = fieldAssignedWbsService;
        this.connectivity = connectivity;
        this.monkeyService = monkeyService;
    }

    [RelayCommand]
    async Task GetFieldAssignedWbsListAsync()
    {
        if (IsBusy)
            return;
        try
        {
            IsBusy = true;

            var wbsList = await fieldAssignedWbsService.GetFieldAssignedWbsList(User.UserId);

            if (WbsList.Count != 0)
                WbsList.Clear();

            foreach (var wbs in wbsList)
                WbsList.Add(wbs);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error!",
                $"Undable to return records: {ex.Message}", "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }

    private string goToPage;
   
    [RelayCommand]
    async Task GoToProductionPageAsync(FieldAssignedWbs fieldAssignedWbs)
    {
        //int wbsId = fieldAssignedWbs.WbsId;

        //if (wbsId == 133)
        //{
        //    goToPage = $"{nameof(FieldProductionLfsPage)}";
        //}
        //else if (wbsId == 126)
        //{
        //    goToPage = $"{nameof(FieldProductionEaPage)}";
        //}
        //else if (wbsId == 304 || wbsId == 308 || wbsId == 312 || wbsId == 316 || wbsId == 320)
        //{
        //    goToPage = $"{nameof(FieldProductionRocPage)}";
        //}

        await Shell.Current.GoToAsync(goToPage, true,
        new Dictionary<string, object>
        {
            ["FieldAssignedWbs"] = fieldAssignedWbs
        });
    }

    [RelayCommand]
    async Task GetMonkeysAsync()
    {
        //if (IsBusy)
        //    return;
        try
        {
            IsBusy = true;

  
            // This passes the Parameter from the "From" Page to the MonkeyService to retrieve the data.  
            var monkeyList = await monkeyService.GetMonkeys("TestMonkey");

            if (MonkeyList.Count != 0)
                MonkeyList.Clear();

            foreach (var monkey in monkeyList)
                MonkeyList.Add(monkey);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error!",
                $"Undable to return records: {ex.Message}", "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }

}

