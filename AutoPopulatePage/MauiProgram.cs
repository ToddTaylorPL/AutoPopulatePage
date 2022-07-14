﻿namespace AutoPopulatePage;

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
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.Services.AddSingleton<MonkeyService>();

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<MainViewModel>();

        builder.Services.AddTransient<MonkeyGHPage>();
        builder.Services.AddTransient<MonkeyGHViewModel>();

        builder.Services.AddTransient<MonkeyDNPage>();
        builder.Services.AddTransient<MonkeyDNViewModel>();

        return builder.Build();
	}
}
