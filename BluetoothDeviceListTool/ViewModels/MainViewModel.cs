using BluetoothDeviceListTool.Services;
using BluetoothDeviceListTool.Services.Contracts;

namespace BluetoothDeviceListTool.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    private readonly IBluetoothDeviceService bluetoothDeviceService;

    public MainViewModel(IBluetoothDeviceService bluetoothDeviceService)
    {
        this.bluetoothDeviceService = bluetoothDeviceService;
    }

    private string name;
    public string Name
    {
        get => this.name;
        set
        {
            if (this.name != value)
            {
                this.name = value;
                this.OnPropertyChanged();
            }
        }
    }

    private string id;
    public string Id
    {
        get => this.id;
        set
        {
            if (this.id != value)
            {
                this.id = value;
                this.OnPropertyChanged();
            }
        }
    }

    private ObservableCollection<DeviceInfoDto> devices;
    public ObservableCollection<DeviceInfoDto> Devices
    {
        get => this.devices;
        set
        {
            this.devices = value;
            this.OnPropertyChanged();
        }
    }

    private ObservableCollection<DeviceInfoDto> nearDevices;
    public ObservableCollection<DeviceInfoDto> NearDevices
    {
        get => this.nearDevices;
        set
        {
            this.nearDevices = value;
            this.OnPropertyChanged();
        }
    }

    public void GetPairedDevices()
    {
        var devices = this.bluetoothDeviceService.GetPairedDevices();
        this.Devices = new ObservableCollection<DeviceInfoDto>(devices);
    }
}
