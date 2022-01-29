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
            // Simulate async UDP interaction.
            await Task.Delay(2000, ct);

            // Construct message, parse it, decide what to do with the result.
            var message = new NewDeviceMessage("Fancy Device");
            var result = _messageParser.ParseMessage(message);

            switch (result)
            {
                case NewDeviceAddedResult ndar:
                    _deviceStorage.Add(ndar.NewDevice);
                    break;

                // TODO: other results.
            }
        }
    }
}
