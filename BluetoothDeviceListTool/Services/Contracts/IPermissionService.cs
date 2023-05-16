namespace BluetoothDeviceListTool.Services.Contracts
{
    public interface IPermissionService
    {
        Task<PermissionStatus> CheckAndRequestBluetoothPermissionsAsync();
    }
}
