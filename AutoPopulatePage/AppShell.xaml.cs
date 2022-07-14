namespace AutoPopulatePage;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(MonkeyGHPage), typeof(MonkeyGHPage));
        Routing.RegisterRoute(nameof(MonkeyDNPage), typeof(MonkeyDNPage));
        Routing.RegisterRoute(nameof(LocalDbPage), typeof(LocalDbPage));
    }
}
