using Microsoft.Extensions.Logging;
using Project3_Final.Data;

namespace Project3_Final;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		//Initialize the connection on ServicePage
		//This will allow the various Service pages to connect to the database.
		Services.ServicePage.Initialize();
		//Load databases and initialize various lists for service pages
		Services.CustomerServices.LoadFromDatabase();
		Services.GymService.LoadFromDatabase();
		Services.StaffServices.LoadFromDatabase();
		Services.TrainerServices.LoadFromDatabase();
		//Services.EquipmentServices.LoadFromDatabase();
		Services.SessionService.LoadFromDatabase();

		builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		builder.Services.AddSingleton<WeatherForecastService>();

		return builder.Build();
	}
}
