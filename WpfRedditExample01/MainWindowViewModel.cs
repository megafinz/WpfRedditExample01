using System.Collections.ObjectModel;

namespace WpfRedditExample01;

internal sealed class MainWindowViewModel
{
    public MainWindowViewModel(DeviceStorage deviceStorage)
    {
        deviceStorage.DeviceAdded += OnDeviceAdded;
    }

    public ObservableCollection<DeviceViewModel> Devices { get; } = new();

    private void OnDeviceAdded(Device newDevice)
    {
        Devices.Add(DeviceViewModel.FromModel(newDevice));
    }
}
