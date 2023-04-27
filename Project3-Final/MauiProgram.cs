/*
CPRG-211F: Object-Oriented Programming 2

Project: Database Connected Application

Teammates:
	John Holloway,
	Victor Odhiambo
	Guntas Dhaliwal
	Aiza Sabir

Program Description:

Gym Management System

This program is designed to connect with an online database, in this case a MySql server hosted online at https://johnholloway.ca, present the existing records to the user, and update the records in real time but automatically pushing information to the database via SQL queries - does not require the user to click on a "Save file" button or anything.

Program requires an active internet connection as database is not stored locally.

*/


using Microsoft.Extensions.Logging;
//using Project3_Final.Data;

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

		Services.SessionService.LoadFromDatabase();

		builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif


		return builder.Build();
	}
}
