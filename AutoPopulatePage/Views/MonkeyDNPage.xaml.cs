namespace AutoPopulatePage.Views;

public partial class MonkeyDNPage : ContentPage
{
	public MonkeyDNPage(MonkeyDNViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        MonkeyDNViewModel viewModel = (MonkeyDNViewModel)BindingContext;  // added "= (DetailsViewModel)BindingContext"
        viewModel.GetMonkeysDNCommand.Execute(null);
       
        base.OnNavigatedTo(args);
    }
}