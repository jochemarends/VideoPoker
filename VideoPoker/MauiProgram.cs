using Microsoft.Extensions.Logging;
using VideoPoker.Services;
using VideoPoker.ViewModels;
using VideoPoker.Models;

namespace VideoPoker;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		HandEvaluator handEvaluator = new()
		{
			new JacksOrBetter(),
			new TwoPair(),
			new ThreeOfAKind(),
			new Straight(),
			new Flush(),
			new FullHouse(),
			new FourOfAKind(),
			new StraightFlush(),
			new RoyalFlush()
		};

		DeckOfCardsService deckOfCardsService = new();
		Deck deck = Task.Run(deckOfCardsService.GetDeckAsync).GetAwaiter().GetResult();

		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
			.Services
			.AddSingleton(deck)
			.AddSingleton(handEvaluator)
			.AddTransient<GamePage>()
			.AddTransient<GameViewModel>()
			.AddTransient<MainPage>()
			.AddTransient<MainViewModel>()
			.AddTransient<GameOverPage>()
			.AddTransient<GameOverViewModel>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
