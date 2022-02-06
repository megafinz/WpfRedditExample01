namespace WpfRedditExample01;

internal abstract record Message;

internal sealed record DeviceConnectedMessage(int Id, string Name, DeviceState State) : Message;
