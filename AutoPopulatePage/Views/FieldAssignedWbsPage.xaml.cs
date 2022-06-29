namespace AutoPopulatePage.Views;

public partial class FieldAssignedWbsPage : ContentPage
{
	public FieldAssignedWbsPage(FieldAssignedWbsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        FieldAssignedWbsViewModel viewModel = (FieldAssignedWbsViewModel)BindingContext;
                
        viewModel.GetFieldAssignedWbsListCommand.Execute(null);
        viewModel.GetMonkeysCommand.Execute(null);

    }

}
