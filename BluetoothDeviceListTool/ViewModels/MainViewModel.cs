using BluetoothDeviceListTool.Services;
using BluetoothDeviceListTool.Services.Contracts;
using System.Windows.Input;

namespace BluetoothDeviceListTool.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    private readonly IBluetoothDeviceService bluetoothDeviceService;

    public MainViewModel(IBluetoothDeviceService bluetoothDeviceService)
    {
        this.bluetoothDeviceService = bluetoothDeviceService;
        this.NearDevicesCommand = new Command(this.GetNearDevices);
    }

    public ICommand NearDevicesCommand { get; }

    private string name;
    public string Name
    {
        get { return name; }
        set
        {
            if (name != value)
            {
                name = value;
                OnPropertyChanged();
            }
        }
    }

    private string id;
    public string Id
    {
        get { return id; }
        set
        {
            if (id != value)
            {
                id = value;
                OnPropertyChanged();
            }
        }
    }

    private ObservableCollection<DeviceInfoDto> devices;
    public ObservableCollection<DeviceInfoDto> Devices
    {
        get 
        { 
            this.GetPairedDevices();
            return this.devices; 
        }
        set
        {
            this.devices = value;
            this.OnPropertyChanged();
        }
    }

    private ObservableCollection<DeviceInfoDto> nearDevices;
    public ObservableCollection<DeviceInfoDto> NearDevices
    {
        get
        {
            return this.nearDevices;
        }
        set
        {
            this.nearDevices = value;
            this.OnPropertyChanged();
        }
    }

    private void GetPairedDevices()
    {
        var devices = this.bluetoothDeviceService.GetPairedDevices();
        this.devices = new ObservableCollection<DeviceInfoDto>(devices);
    }

    private async void GetNearDevices()
    {
        var nearDevices = await this.bluetoothDeviceService.GetNearDevicesAsync();
        this.NearDevices = new ObservableCollection<DeviceInfoDto>(nearDevices);
    } 
}
