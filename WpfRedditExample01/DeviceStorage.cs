using System.Collections.Generic;

namespace WpfRedditExample01;

internal delegate void DeviceAddedEventHandler(Device newDevice);
internal delegate void DeviceUpdatedEventHandler(Device updatedDevice, Device oldDevice);

internal sealed class DeviceStorage
{
    // Dictionaries are unnecessary, just an example how you can speed things up if you have lots of data
    // (search becomes O(1) at the expense of additional memory storage).
    private readonly Dictionary<int, Device> _deviceById = new();
    private readonly Dictionary<int, int> _deviceIndexById = new();
    private readonly List<Device> _devices = new();

    public IReadOnlyCollection<Device> Devices => _devices.AsReadOnly();

    public event DeviceAddedEventHandler? DeviceAdded;

    public event DeviceUpdatedEventHandler? DeviceUpdated;

    public void AddOrUpdate(Device device)
    {
        if (_deviceById.TryGetValue(device.Id, out var existingDevice))
        {
            _devices[_deviceIndexById[device.Id]] = device;
            DeviceUpdated?.Invoke(device, existingDevice);
        }
        else
        {
            _devices.Add(device);
            _deviceById.Add(device.Id, device);
            _deviceIndexById.Add(device.Id, _devices.Count - 1);
            DeviceAdded?.Invoke(device);
        }
    }
}

