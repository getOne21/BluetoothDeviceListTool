using static Microsoft.Maui.ApplicationModel.Permissions;

namespace BluetoothDeviceListTool.Helpers
{
    public class BluetoothPermissions : BasePlatformPermission
    {
#if ANDROID
    public override (string androidPermission, bool isRuntime)[] RequiredPermissions =>
        new List<(string permission, bool isRuntime)>
        {
            ("android.permission.BLUETOOTH_ADMIN", true),
            ("android.permission.BLUETOOTH_ADVERTISE", true),
            ("android.permission.BLUETOOTH_CONNECT", true),
            ("android.permission.BLUETOOTH", true),
            ("android.permission.BLUETOOTH_SCAN", true),
        }.ToArray();
#endif
    }
}