using Microsoft.Extensions.Logging;
using VideoPoker.Services;
using VideoPoker.ViewModels;
using VideoPoker.Models;

namespace VideoPoker;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
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
			.AddTransient<GameViewModel>()
			.AddTransient<MainPage>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
