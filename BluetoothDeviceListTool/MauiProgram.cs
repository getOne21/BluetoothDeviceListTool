using BluetoothDeviceListTool.Services;
using BluetoothDeviceListTool.Services.Contracts;
using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;

namespace BluetoothDeviceListTool;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("FontAwesome6FreeBrands.otf", "FontAwesomeBrands");
				fonts.AddFont("FontAwesome6FreeRegular.otf", "FontAwesomeRegular");
				fonts.AddFont("FontAwesome6FreeSolid.otf", "FontAwesomeSolid");
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        var adapter = CrossBluetoothLE.Current.Adapter;
		builder.Services.AddSingleton<IAdapter>((serviceProvider) => adapter);

        builder.Services.AddSingleton<IPermissionService, PermissionService>();
        builder.Services.AddSingleton<IBluetoothDeviceService, BluetoothDeviceService>();
		builder.Services.AddSingleton<MainViewModel>();
		builder.Services.AddSingleton<MainPage>();

		return builder.Build();
	}
}
