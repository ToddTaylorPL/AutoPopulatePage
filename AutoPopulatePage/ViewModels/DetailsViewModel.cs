
namespace AutoPopulatePage.ViewModels;

[QueryProperty(nameof(Monkey), nameof(Monkey))]
public partial class DetailsViewModel : BaseViewModel
{
    [ObservableProperty]
    Monkey monkey;

    MonkeyService monkeyService;

    public ObservableCollection<Monkey> MonkeyList { get; set; } = new();

    public DetailsViewModel(MonkeyService monkeyService)
    {
        this.monkeyService = monkeyService;
    }

    [RelayCommand]
    async Task GetMonkeysAsync()
    {
        if (IsBusy)
            return;
        try
        {
            IsBusy = true;

            // The following will run with param set to "No Param" to demonstrate the code will return records.
            // viewModel.GetFieldAssignedWbsListCommand.Execute(null);
            // must be run under "public DetailsPage". 
            //var monkeyList = await monkeyService.GetMonkeys("No Param");

            // This should run after the page is navigated to and the "Monkey" Model Param is passed and set.
            var monkeyList = await monkeyService.GetMonkeys(Monkey.Name);

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
