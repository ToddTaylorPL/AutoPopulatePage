
namespace AutoPopulatePage.ViewModels;

public partial class MainViewModel : BaseViewModel
{

    public Monkey Monkey { get; } = new Monkey();

    [RelayCommand]
    async Task GoToDetailsPageAsync()
    {
        await Shell.Current.GoToAsync($"{nameof(DetailsPage)}", true,
            new Dictionary<string, object>
            {
                ["Monkey"] = Monkey
            });
    }

}
