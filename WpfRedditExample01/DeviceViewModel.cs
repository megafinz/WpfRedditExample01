namespace WpfRedditExample01;

internal sealed class DeviceViewModel : ViewModelBase
{
    private DeviceState _state;

    private DeviceViewModel(int id, string name, DeviceState state)
    {
        (Id, Name, State) = (id, name, state);
    }

    public int Id { get; }

    public string Name { get; }

    // This is the only property that can change,
    // make sure to call OnPropertyChanged so Views will update correctly.
    public DeviceState State
    {
        get => _state;
        set
        {
            if (_state == value) return;
            _state = value;
            OnPropertyChanged();
        }
    }

    public static DeviceViewModel FromModel(Device model) => new(model.Id, model.Name, model.State);
}
