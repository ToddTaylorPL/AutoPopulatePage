
namespace AutoPopulatePage.ViewModels;

[QueryProperty(nameof(User), nameof(User))]
public partial class MainViewModel : BaseViewModel
{
    public Monkey Monkey { get; } = new Monkey();

    [RelayCommand]
    async Task GoToMonkeyGHPageAsync()
    {
        await Shell.Current.GoToAsync($"{nameof(MonkeyGHPage)}", true,
            new Dictionary<string, object>
            {
                ["Monkey"] = Monkey
            });
    }

    [RelayCommand]
    async Task GoToMonkeyDNPageAsync()
    {
        await Shell.Current.GoToAsync($"{nameof(MonkeyDNPage)}", true,
            new Dictionary<string, object>
            {
                ["Monkey"] = Monkey
            });
    }

    [RelayCommand]
    async Task GoToLocalDbPageAsync()
    {
        await Shell.Current.GoToAsync($"{nameof(LocalDbPage)}", true,
            new Dictionary<string, object>
            {
                ["Monkey"] = Monkey
            });
    }

}
