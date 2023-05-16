using BluetoothDeviceListTool.Services.Contracts;

namespace BluetoothDeviceListTool.Views;

public partial class MainPage : ContentPage
{
    private readonly IPermissionService permissionService;

    private readonly MainViewModel viewModel;

    public MainPage(
        MainViewModel viewModel, 
        IPermissionService permissionService)
	{
		this.InitializeComponent(); 
        this.BindingContext = viewModel;
        this.viewModel = viewModel;
        this.permissionService = permissionService;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        _ = await this.permissionService.CheckAndRequestBluetoothPermissionsAsync();
        viewModel.GetPairedDevices();
    }
}