using VideoPoker.ViewModels;

namespace VideoPoker;

public partial class MainPage : ContentPage
{
	public MainPage(GameViewModel gameViewModel)
	{
		InitializeComponent();
		BindingContext = gameViewModel;
	}
}

