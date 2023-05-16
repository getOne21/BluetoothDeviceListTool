using BluetoothDeviceListTool.Services.Contracts;
using Plugin.BLE.Abstractions.Contracts;

namespace BluetoothDeviceListTool.Services
{
    public class BluetoothDeviceService : IBluetoothDeviceService
    {
        private readonly IAdapter adapter;

        public BluetoothDeviceService(IAdapter adapter)
        {
            this.adapter = adapter ?? throw new ArgumentNullException(nameof(adapter));
        }

        public IEnumerable<DeviceInfoDto> GetPairedDevices()
        {
            var systemDevices = adapter.GetSystemConnectedOrPairedDevices();
            return systemDevices.Select(systemDevice => new DeviceInfoDto
            {
                Id = systemDevice.Id,
                Name = systemDevice.Name,
            });
        }
    }

    public class DeviceInfoDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
