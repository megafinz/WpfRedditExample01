using System;
using System.Threading;
using System.Threading.Tasks;

namespace WpfRedditExample01;

internal sealed class UdpReceiver
{
    private readonly MessageParser _messageParser;
    private readonly DeviceStorage _deviceStorage;

    public UdpReceiver(MessageParser messageParser, DeviceStorage deviceStorage)
    {
        _messageParser = messageParser;
        _deviceStorage = deviceStorage;
    }

    public async Task Start(CancellationToken ct)
    {
        while (!ct.IsCancellationRequested)
        {
            // Construct message, parse it, decide what to do with the result.
            var message = await SimulateDeviceConnected(ct);
            var result = _messageParser.ParseMessage(message);

            switch (result)
            {
                case DeviceConnectedResult dcr:
                    _deviceStorage.AddOrUpdate(dcr.Device);
                    break;

                // TODO: other results.
            }
        }
    }

    private static async Task<DeviceConnectedMessage> SimulateDeviceConnected(CancellationToken ct)
    {
        await Task.Delay(1000, ct);

        var deviceIdsAndNames = new[] { (1, "Fancy Device"), (2, "Cool Device"), (3, "Evil Device") };
        var deviceStates = new[] { DeviceState.Idle, DeviceState.Running, DeviceState.Error };

        var (id, name) = deviceIdsAndNames[Random.Shared.Next(deviceIdsAndNames.Length)];
        var state = deviceStates[Random.Shared.Next(deviceStates.Length)];

        return new DeviceConnectedMessage(id, name, state);
    }
}
