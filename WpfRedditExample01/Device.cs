namespace WpfRedditExample01;

internal enum DeviceState { Running, Idle, Error }

internal sealed class Device
{
    public Device(int id, string name, DeviceState state)
    {
        (Id, Name, State) = (id, name, state);
    }

    public int Id { get; }

    public string Name { get; }

    public DeviceState State { get; }
}
