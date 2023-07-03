using VideoPoker.ViewModels;

namespace VideoPoker;

public partial class GamePage : ContentPage
{
	public GamePage(GameViewModel gameViewModel)
	{
		InitializeComponent();
		BindingContext = gameViewModel;
	}
}