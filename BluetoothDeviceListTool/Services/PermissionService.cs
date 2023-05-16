using BluetoothDeviceListTool.Helpers;
using BluetoothDeviceListTool.Services.Contracts;

namespace BluetoothDeviceListTool.Services
{
    public class PermissionService : IPermissionService
    {
        public async Task<PermissionStatus> CheckAndRequestBluetoothPermissionsAsync()
        {
            PermissionStatus status = await Permissions.CheckStatusAsync<BluetoothPermissions>();
            if (status == PermissionStatus.Granted)
            {
                return status;
            }

            if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
            {
                // Prompt the user to turn on in settings
                // On iOS once a permission has been denied it may not be requested again from the application
                return status;
            }

            if (Permissions.ShouldShowRationale<BluetoothPermissions>())
            {
                // for later
            }

            status = await Permissions.RequestAsync<BluetoothPermissions>();

            return status;
        }
    }
}
