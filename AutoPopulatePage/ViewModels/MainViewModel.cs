
namespace AutoPopulatePage.ViewModels;

[QueryProperty(nameof(User), nameof(User))]
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

    User user;
    public MainViewModel()
    {
        user = new User
        {
            UserId = 2,
            FirstName = "Jill",
            LastName = "Robinson",
            Image = "https://composerblob.blob.core.windows.net/composerfiles/EmployeePicFemale1.jpg"
        };
    }

    [RelayCommand]
    async Task GoToFieldAssignedWbsPageAsync()
    {
        await Shell.Current.GoToAsync($"{nameof(FieldAssignedWbsPage)}", true,
            new Dictionary<string, object>
            {
                ["User"] = user
            });
    }

}
