using System;

namespace WpfRedditExample01;

internal abstract record MessageParsingResult;

internal sealed record DeviceConnectedResult(Device Device) : MessageParsingResult;

internal sealed class MessageParser
{
    public MessageParsingResult ParseMessage(Message message)
    {
        switch (message)
        {
            case DeviceConnectedMessage(var id, var name, var state):
                var device = new Device(id, name, state);
                return new DeviceConnectedResult(device);

            // TODO: handle other messages.
        }

        throw new InvalidOperationException($"Unsupported message: {message.GetType()}");
    }
}
