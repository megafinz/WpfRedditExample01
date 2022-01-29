using System.Threading;
using System.Windows;

namespace WpfRedditExample01;

internal sealed partial class App
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        // Composition root.
        var deviceStorage = new DeviceStorage();
        var messageParser = new MessageParser();
        var udpReceiver = new UdpReceiver(messageParser, deviceStorage);

        var window = new MainWindow
        {
            DataContext = new MainWindowViewModel(deviceStorage)
        };

        // Fire and forget.
        var _ = udpReceiver.Start(CancellationToken.None);

        window.Show();
    }
}
