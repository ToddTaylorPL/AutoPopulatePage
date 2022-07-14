namespace AutoPopulatePage.Views;

public partial class MonkeyGHPage : ContentPage
{
	public MonkeyGHPage(MonkeyGHViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        MonkeyGHViewModel viewModel = (MonkeyGHViewModel)BindingContext;  // added "= (DetailsViewModel)BindingContext"
        viewModel.GetMonkeysGHCommand.Execute(null);
       
        base.OnNavigatedTo(args);
    }
}