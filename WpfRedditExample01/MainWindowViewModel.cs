using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WpfRedditExample01;

internal sealed class MainWindowViewModel : ViewModelBase
{
    // Dictionaries are unnecessary, just an example how you can speed things up if you have lots of data
    // (search becomes O(1) at the expense of additional memory storage).
    private readonly Dictionary<int, int> _deviceIndexById = new();

    public MainWindowViewModel(DeviceStorage deviceStorage)
    {
        deviceStorage.DeviceAdded += OnDeviceAdded;
        deviceStorage.DeviceUpdated += OnDeviceUpdated;
    }

    public ObservableCollection<DeviceViewModel> Devices { get; } = new();

    private void OnDeviceAdded(Device newDevice)
    {
        Devices.Add(DeviceViewModel.FromModel(newDevice));
        _deviceIndexById.Add(newDevice.Id, Devices.Count - 1);
    }

    private void OnDeviceUpdated(Device updatedDevice, Device _)
    {
        var deviceVm = Devices[_deviceIndexById[updatedDevice.Id]];
        deviceVm.State = updatedDevice.State;
    }
}
