namespace WpfRedditExample01;

internal abstract class Message
{
}

internal sealed class NewDeviceMessage : Message
{
    public NewDeviceMessage(string newDeviceName)
    {
        NewDeviceName = newDeviceName;
    }

    public string NewDeviceName { get; }
}
