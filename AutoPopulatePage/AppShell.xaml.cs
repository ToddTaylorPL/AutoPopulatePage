namespace AutoPopulatePage;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(DetailsPage), typeof(DetailsPage));
        Routing.RegisterRoute(nameof(FieldAssignedWbsPage), typeof(FieldAssignedWbsPage));
    }
}
