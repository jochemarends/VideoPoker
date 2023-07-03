using VideoPoker.ViewModels;

namespace VideoPoker;

public partial class GameOverPage : ContentPage
{
	public GameOverPage(GameOverViewModel gameOverViewModel)
	{
		InitializeComponent();
		BindingContext = gameOverViewModel;
	}
}