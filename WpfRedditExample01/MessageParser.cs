using System;

namespace WpfRedditExample01;

internal abstract class MessageParsingResult
{
}

internal sealed class NewDeviceAddedResult : MessageParsingResult
{
    public NewDeviceAddedResult(Device newDevice)
    {
        NewDevice = newDevice;
    }

    public Device NewDevice { get; }
}

internal sealed class MessageParser
{
    public MessageParsingResult ParseMessage(Message message)
    {
        switch (message)
        {
            case NewDeviceMessage ndm:
                var newDevice = new Device(ndm.NewDeviceName);
                return new NewDeviceAddedResult(newDevice);

            // TODO: handle other messages.
        }

        throw new InvalidOperationException($"Unsupported message: {message.GetType()}");
    }
}
