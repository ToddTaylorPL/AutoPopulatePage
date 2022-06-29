namespace AutoPopulatePage.Views;

public partial class DetailsPage : ContentPage
{
	public DetailsPage(DetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        DetailsViewModel viewModel = (DetailsViewModel)BindingContext;  // added "= (DetailsViewModel)BindingContext"
        viewModel.GetMonkeysCommand.Execute(null);
       
        base.OnNavigatedTo(args);
    }
}