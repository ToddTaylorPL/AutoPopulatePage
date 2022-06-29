﻿
namespace AutoPopulatePage.ViewModels;

[QueryProperty(nameof(Monkey), nameof(Monkey))]
[QueryProperty(nameof(User), nameof(User))]
public partial class DetailsViewModel : BaseViewModel
{

    [ObservableProperty]
    User user;

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

            // This passes the Parameter from the "From" Page to the MonkeyService to retrieve the data.  
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
