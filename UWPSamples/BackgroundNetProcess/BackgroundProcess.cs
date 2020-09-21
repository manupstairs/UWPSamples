using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.AppService;
using Windows.Foundation.Collections;

namespace BackgroundNetProcess
{
    public class BackgroundProcess
    {
        private AppServiceConnection Connection { get;  set; }

        public Task InitializeTask { get; private set; }

        public BackgroundProcess()
        {
            InitializeTask = InitializeAsync();
        }

        public async Task InitializeAsync()
        {
            Connection = new AppServiceConnection();
            Connection.PackageFamilyName = Package.Current.Id.FamilyName;
            Connection.AppServiceName = "NotificationAppService";
            AppServiceConnectionStatus status = await Connection.OpenAsync();
            if (status != AppServiceConnectionStatus.Success)
            {
                Console.WriteLine(status);
                Debug.WriteLine(status);
            }
            else
            {
                Console.WriteLine(status);
                Debug.WriteLine(status);
                Connection.RequestReceived += Connection_RequestReceived;
            }
        }

        private async void Connection_RequestReceived(AppServiceConnection sender, AppServiceRequestReceivedEventArgs args)
        {
            var deferral = args.GetDeferral();
            var content = args.Request.Message["request"];
            var message = new ValueSet();
            message.Add("response", $"Received request content: {content}");
            await Connection.SendMessageAsync(message);
            deferral.Complete();
        }
    }
}
