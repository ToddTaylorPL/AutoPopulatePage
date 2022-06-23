namespace AutoPopulatePage.Views;

public partial class DetailsPage : ContentPage
{
	public DetailsPage(DetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;

        //This can be run with  "var monkeyList = await monkeyService.GetMonkeys("No Param");" in the ViewModel
        // The issue is that the Query Param is not set when this is called and will error is Monkey.Name is attempted to be passed.
        //viewModel.GetMonkeysCommand.Execute(null);
    }

    //The following errors... just trying to call GetMonkeysCommand here because at this point the "Monkey" Object Param in the ViewModel.
    DetailsViewModel viewModel;
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        DetailsViewModel viewModel = (DetailsViewModel)BindingContext;
        viewModel.GetMonkeysCommand.Execute(null);
       
        base.OnNavigatedTo(args);
    }
}