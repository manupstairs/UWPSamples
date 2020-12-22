using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Windows.ApplicationModel;
using Windows.ApplicationModel.AppService;
using Windows.Foundation.Collections;

namespace TwoWayExchangeDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AppServiceConnection Connection { get; set; }

        public Task InitializeTask { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            InitializeTask = InitializeAsync();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var message = new ValueSet();
            message.Add("Desktop", this.textBoxSend.Text);
            await Connection.SendMessageAsync(message);
        }

        public async Task InitializeAsync()
        {
            Connection = new AppServiceConnection();
            Connection.PackageFamilyName = Package.Current.Id.FamilyName;
            Connection.AppServiceName = "TwoWayExchangeAppService";
            AppServiceConnectionStatus status = await Connection.OpenAsync();
            if (status == AppServiceConnectionStatus.Success)
            {
                Connection.RequestReceived += Connection_RequestReceived;
            }
        }

        private void Connection_RequestReceived(AppServiceConnection sender, AppServiceRequestReceivedEventArgs args)
        {
            if (args.Request.Message.TryGetValue("UWP", out object content))
            {
                Dispatcher.Invoke(() => { this.textBoxReceive.Text += $"{content}\n"; });
            }
        }
    }
}
