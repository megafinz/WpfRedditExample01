using System.Collections.Generic;

namespace WpfRedditExample01;

internal delegate void DeviceAddedEventHandler(Device newDevice);

internal sealed class DeviceStorage
{
    private readonly List<Device> _devices = new();

    public IReadOnlyCollection<Device> Devices => _devices.AsReadOnly();

    public event DeviceAddedEventHandler? DeviceAdded;

    public void Add(Device device)
    {
        _devices.Add(device);
        DeviceAdded?.Invoke(device);
    }
}

