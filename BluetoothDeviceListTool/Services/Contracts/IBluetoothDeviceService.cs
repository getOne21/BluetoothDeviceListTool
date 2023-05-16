namespace BluetoothDeviceListTool.Services.Contracts
{
    public interface IBluetoothDeviceService
    {
        IEnumerable<DeviceInfoDto> GetPairedDevices();
    }
}
