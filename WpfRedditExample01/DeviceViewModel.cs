namespace WpfRedditExample01;

internal sealed class DeviceViewModel
{
    private DeviceViewModel(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public static DeviceViewModel FromModel(Device model) => new(model.Name);
}
