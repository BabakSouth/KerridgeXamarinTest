namespace KerridgeTask.Pages;

public partial class LoadingPage : ContentPage
{
	public LoadingPage(string message)
	{
		InitializeComponent();
        LabelMessage.Text = message;
    }
}